# Update for Blazor WebAssembly

When I wrote *Pro ASP.NET Core 3*, Blazor WebAssembly was available as a preview. This file contains the changes required to follow the examples in Chapter 37 with the final release.

Adam Freeman, July 2020

---
**Preparation**

Install verson 3.1.5 of the .NET Core SDK, which can be downloaded from https://dotnet.microsoft.com/download/dotnet-core/3.1. Once installation is complete, run the following command to display the SDKs available:

    dotnet --list-sdks

You should see an entry for version 3.1.301 in the list, like this:

    3.1.101 [C:\Program Files\dotnet\sdk]
    3.1.301 [C:\Program Files\dotnet\sdk]

**Listing 37-5**

Use the following command to install the project template:

    dotnet new -i Microsoft.AspNetCore.Blazor.Templates::3.2.0-preview1.20073.1

***

**Listing 37-7**

Use the following commands to create the references between the projects and to install the Blazor Server package:

    dotnet add reference ../DataModel ../BlazorWebAssembly

    dotnet add package Microsoft.AspNetCore.Blazor.Server --version 3.2.0-preview1.20073.1

***

**Listing 37-9**

Use the following code to configure the application:

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.EntityFrameworkCore;
    using Advanced.Models;
    using Microsoft.AspNetCore.ResponseCompression;

    namespace Advanced {
        public class Startup {

            public Startup(IConfiguration config) {
                Configuration = config;
            }

            public IConfiguration Configuration { get; set; }

            public void ConfigureServices(IServiceCollection services) {
                services.AddDbContext<DataContext>(opts => {
                    opts.UseSqlServer(Configuration[
                        "ConnectionStrings:PeopleConnection"]);
                    opts.EnableSensitiveDataLogging(true);
                });
                services.AddControllersWithViews().AddRazorRuntimeCompilation();
                services.AddRazorPages().AddRazorRuntimeCompilation();
                services.AddServerSideBlazor();
                services.AddSingleton<Services.ToggleService>();

                services.AddResponseCompression(opts => {
                    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                        new[] { "application/octet-stream" });
                });            
            }

            public void Configure(IApplicationBuilder app, DataContext context) {

                app.UseDeveloperExceptionPage();
                app.UseStaticFiles();
                app.UseRouting();

                app.UseEndpoints(endpoints => {
                    endpoints.MapControllerRoute("controllers",
                        "controllers/{controller=Home}/{action=Index}/{id?}");
                    endpoints.MapDefaultControllerRoute();
                    endpoints.MapRazorPages();
                    endpoints.MapBlazorHub();

                    endpoints.MapFallbackToClientSideBlazor<BlazorWebAssembly.App>
                        ("/webassembly/{*path:nonfile}", "index.html");                

                    endpoints.MapFallbackToPage("/_Host");
                });

                app.Map("/webassembly", opts =>
                    opts.UseClientSideBlazorFiles<BlazorWebAssembly.App>());

                SeedData.SeedDatabase(context);
            }
        }
    }
