# Update for ASP.NET Core 5

This file contains the changes needed to follow the examples in the book using ASP.NET Core 5 and .NET 5.0. The majority of the changes are just using the .NET 5 versions of the packages required by the examples, although there are some additional changes in Chapter 37 to reflect differences in the way that Blazor WebAssembly is configured.

Adam Freeman, November 2020

---
**Preparation**

Install verson 5.0.0 of the .NET SDK, which can be downloaded from https://dotnet.microsoft.com/download/dotnet/5.0. You *must* use the 5.0.100 build of the SDK. The SDK is required even if you are using Visual Studio.

Once installation is complete, run the following command to display the SDKs available:

    dotnet --list-sdks

You should see an entry for version 5.0.100 in the list, like this:

    5.0.100 [C:\Program Files\dotnet\sdk]
    
The move to .NET 5.0 also requires an update to Visual Studio 2019. Use the Visual Studio Installer tool to update to version 16.8.0 or later.

---

## Chapter 2

**Listing 2-3**. Use the following commands:

    dotnet new globaljson --sdk-version 5.0.100 --output FirstProject
    dotnet new mvc --no-https --output FirstProject --framework net5.0
---
## Chapter 3

**Listing 3-1**. Use the following commands:

    dotnet new globaljson --sdk-version 5.0.100 --output PartyInvites
    dotnet new mvc --no-https --output PartyInvites --framework net5.0
---
## Chapter 4

**Listing 4-2**. Use the following commands:

    dotnet new globaljson --sdk-version 5.0.100 --output MySolution/MyProject
    dotnet new web --no-https --output MySolution/MyProject --framework net5.0
    dotnet new sln -o MySolution
    dotnet sln MySolution add MySolution/MyProject 

**Listing 4-3**. Use the following code:

    {
        "sdk": {
            "version": "5.0.100"
        }
    }

**Listing 4-8**. Use the following command:

    dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 5.0.0

**Listing 4-11**. Use the following commands:

    dotnet tool uninstall --global dotnet-ef
    dotnet tool install --global dotnet-ef --version 5.0.0

**Listing 4-13**. use the following commands:

    dotnet tool uninstall --global Microsoft.Web.LibraryManager.Cli
    dotnet tool install --global Microsoft.Web.LibraryManager.Cli --version 2.1.113
---
## Chapter 5

**Listing 5-1**. Use the following commands:

    dotnet new globaljson --sdk-version 5.0.100 --output LanguageFeatures
    dotnet new web --no-https --output LanguageFeatures --framework net5.0
    dotnet new sln -o LanguageFeatures
    dotnet sln LanguageFeatures add LanguageFeatures
---
## Chapter 6

**Listing 6-1**. Use the following commands:

    dotnet new globaljson --sdk-version 5.0.100 --output Testing/SimpleApp
    dotnet new web --no-https --output Testing/SimpleApp --framework net5.0
    dotnet new sln -o Testing
    dotnet sln Testing add Testing/SimpleApp

---

**Listing 6-7**. Use the following commands:

    dotnet new xunit -o SimpleApp.Tests --framework net5.0
    dotnet sln add SimpleApp.Tests
    dotnet add SimpleApp.Tests reference SimpleApp
---
## Chapter 7

**Listing 7-1**. Use the following commands:

    dotnet new globaljson --sdk-version 5.0.100 --output SportsSln/SportsStore
    dotnet new web --no-https --output SportsSln/SportsStore --framework net5.0
    dotnet new sln -o SportsSln 
    dotnet sln SportsSln add SportsSln/SportsStore

**Listing 7-2**. Use the following commands:

    dotnet new xunit -o SportsSln/SportsStore.Tests --framework net5.0
    dotnet sln SportsSln add SportsSln/SportsStore.Tests
    dotnet add SportsSln/SportsStore.Tests reference SportsSln/SportsStore

**Listing 7-12**. Use the following commands:

    dotnet add package Microsoft.EntityFrameworkCore.Design --version 5.0.0
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 5.0.0

**Listing 7-13**. Use the following commands:

    dotnet tool uninstall --global dotnet-ef
    dotnet tool install --global dotnet-ef --version 5.0.0

**Listing 7-34**. Use the following commands:

    dotnet tool uninstall --global Microsoft.Web.LibraryManager.Cli
    dotnet tool install --global Microsoft.Web.LibraryManager.Cli --version 2.1.113
---
## Chapter 11

**Listing 11-1**. Use the following command:

    dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore --version 5.0.0


**Listing 11-20**. Use the following Dockerfile:

    FROM mcr.microsoft.com/dotnet/aspnet:5.0
    FROM mcr.microsoft.com/dotnet/sdk:5.0

    COPY /bin/Release/net5.0/publish/ SportsStore/

    ENV ASPNETCORE_ENVIRONMENT Production

    EXPOSE 5000
    WORKDIR /SportsStore
    ENTRYPOINT ["dotnet", "SportsStore.dll",  "--urls=http://0.0.0.0:5000"]


**Listing 11-24**. 

Instead of the `docker-compose up` command, use this command to start the SQL Server container:

    docker-compose up sqlserver

Wait until SQL Server has started and no new messages are displayed at the console. Open a new command prompt and run this command:

    docker-compose up sportsstore

The SportsStore application will start and will be able to access the database. You may see authentication failure messages but this is normal and is caused by the way Entity Framework Core checks to see if a database has been created.

---
## Chapter 12

**Listing 12-1**. Use the following commands:

    dotnet new globaljson --sdk-version 5.0.100 --output Platform
    dotnet new web --no-https --output Platform --framework net5.0
    dotnet new sln -o Platform
    dotnet sln Platform add Platform

**Listing 12-3**. Use the following command:

    dotnet add package Swashbuckle.AspNetCore --version 5.6.3

---

## Chapter 15
**Listing 15-27**. Use the following command:

    dotnet tool install --global Microsoft.Web.LibraryManager.Cli --version 2.1.113

---

## Chapter 17

Before **Listing 17-11**. Use this command:

    dotnet tool install --global dotnet-sql-cache --version 5.0.0

**Listing 17-12**. Use this command:

    dotnet add package Microsoft.Extensions.Caching.SqlServer --version 5.0.0

**Listing 17-17**. Use these commands:

    dotnet tool uninstall --global dotnet-ef
    dotnet tool install --global dotnet-ef --version 5.0.0

**Listing 17-19**. Use these commands:

    dotnet add package Microsoft.EntityFrameworkCore.Design --version 5.0.0
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 5.0.0

**Listing 17-28**. The command in this listing produces an error that reports Kestrel cannot start. This can be ignored and is caused by the code that seeds the database terminating the process before the end of the normal ASP.NET Core startup sequence.

---


## Chapter 18
**Listing 18-1**. Use the following commands:

    dotnet new globaljson --sdk-version 5.0.100 --output WebApp
    dotnet new web --no-https --output WebApp --framework net5.0
    dotnet new sln -o WebApp
    dotnet sln WebApp add WebApp

**Listing 18-2**. Use the following commands:

    dotnet add package Microsoft.EntityFrameworkCore.Design --version 5.0.0
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 5.0.0

**Listing 18-3**. Use the following commands:

    dotnet tool uninstall --global dotnet-ef
    dotnet tool install --global dotnet-ef --version 5.0.0

**Listing 18-13**. Use the following commands:

    dotnet tool uninstall --global Microsoft.Web.LibraryManager.Cli
    dotnet tool install --global Microsoft.Web.LibraryManager.Cli --version 2.1.113

---

## Chapter 20
**Listing 20-6**. Use the following command:

    dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson --version 5.0.0

**Listing 20-26**. Use the following command:

    dotnet add package Swashbuckle.AspNetCore --version 5.6.3

**Listing 20-28**. Use the following configuration:

    <Project Sdk="Microsoft.NET.Sdk.Web">

    <PropertyGroup>
        <TargetFramework>net5.0</TargetFramework>
    </PropertyGroup>

    <ItemGroup>
        <PackageReference Include="Microsoft.AspNetCore.Mvc.NewtonsoftJson" Version="5.0.0" />
        <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="5.0.0">
        <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
        <PrivateAssets>all</PrivateAssets>
        </PackageReference>
        <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="5.0.0" />
        <PackageReference Include="Swashbuckle.AspNetCore" Version="5.6.3" />
    </ItemGroup>

    <PropertyGroup>
        <IncludeOpenAPIAnalyzers>true</IncludeOpenAPIAnalyzers>
    </PropertyGroup>

    </Project>
---
## Chapter 21

**Listing 21-1**. Use the following command:

    dotnet add package Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation --version 5.0.0

---

## Chapter 32
**Listing 32-1**. Use the following commands:

    dotnet new globaljson --sdk-version 5.0.100 --output Advanced
    dotnet new web --no-https --output Advanced --framework net5.0
    dotnet new sln -o Advanced
    dotnet sln Advanced add Advanced

**Listing 32-2**. Use the following commands:

    dotnet add package Microsoft.EntityFrameworkCore.Design --version 5.0.0
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 5.0.0

**Listing 32-3**. Use the following commands:

    dotnet tool uninstall --global dotnet-ef
    dotnet tool install --global dotnet-ef --version 5.0.0

**Listing 32-14**. Use the following command:

    dotnet add package Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation --version 5.0.0
---

## Chapter 37
**Listing 37-4**. Use the following commands:

    dotnet new classlib -o ../DataModel -f net5.0
    dotnet add ../DataModel package System.ComponentModel.Annotations --version 5.0.0
    Move-Item -Path @("Models/Person.cs", "Models/Location.cs", "Models/Department.cs") ../DataModel

**Listing 37-5**. Use the following command:

    dotnet new -i Microsoft.AspNetCore.Blazor.Templates::3.2.1

**Listing 37-7**. Use the following commands:

    dotnet add reference ../DataModel ../BlazorWebAssembly
    dotnet add package Microsoft.AspNetCore.Components.WebAssembly.Server --version 5.0.0 
    dotnet add ..\BlazorWebAssembly package Microsoft.AspNetCore.Blazor.HttpClient --version 3.2.0-preview3.20168.3

**Listing 37-9**. Use the following code:

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
            }

            public void Configure(IApplicationBuilder app, DataContext context) {

                        
                app.UseDeveloperExceptionPage();
                app.UseStaticFiles();

                app.UseRouting();

                app.Map("/webassembly/{*path}", builder => {
                    app.Use(async (context, next) => {
                        PathString pathPrefix = new PathString("/webassembly");
                        context.Request.Path.StartsWithSegments(pathPrefix, out var rest);
                        if (rest != string.Empty && rest != "/") {
                            context.Request.Path = rest;
                        }
                        await next();
                    });
                    app.UseStaticFiles();
                });

                app.UseBlazorFrameworkFiles();
                
                app.UseEndpoints(endpoints => {
                    endpoints.MapControllerRoute("controllers",
                        "controllers/{controller=Home}/{action=Index}/{id?}");
                    endpoints.MapDefaultControllerRoute();
                    endpoints.MapRazorPages();
                    endpoints.MapBlazorHub();
                    endpoints.MapFallbackToFile("/webassembly/{*path:nonfile}", "index.html");
                    endpoints.MapFallbackToPage("/_Host");            });

                SeedData.SeedDatabase(context);
            }
        }
    }

**Listing 37-10**. Use the following content:

    <!DOCTYPE html>
    <html>

    <head>
        <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
        <title>BlazorWebAssembly</title>
        <base href="/webassembly/" />
        <link href="css/bootstrap/bootstrap.min.css" rel="stylesheet" />
        <link href="css/app.css" rel="stylesheet" />
        <link href="BlazorWebAssembly.styles.css" rel="stylesheet" />
    </head>

    <body>
        <div id="app">Loading...</div>

        <div id="blazor-error-ui">
            An unhandled error has occurred.
            <a href="" class="reload">Reload</a>
            <a class="dismiss">🗙</a>
        </div>
        <script src="_framework/blazor.webassembly.js"></script>
    </body>

    </html>

**Listing 37-12**. Use the following content:

    @using System.Net.Http
    @using System.Net.Http.Json
    @using Microsoft.AspNetCore.Components.Forms
    @using Microsoft.AspNetCore.Components.Routing
    @using Microsoft.AspNetCore.Components.Web
    @using Microsoft.AspNetCore.Components.Web.Virtualization
    @using Microsoft.AspNetCore.Components.WebAssembly.Http
    @using Microsoft.JSInterop
    @using BlazorWebAssembly
    @using BlazorWebAssembly.Shared
    @using Advanced.Models

**Listing 37-16**. Use the following content:

    <!DOCTYPE html>
    <html>

    <head>
        <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
        <title>BlazorWebAssembly</title>
        <base href="/webassembly/" />
        <link href="css/bootstrap/bootstrap.min.css" rel="stylesheet" />
        <link href="css/app.css" rel="stylesheet" />
        <link href="BlazorWebAssembly.styles.css" rel="stylesheet" />
        <link href="/lib/twitter-bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    </head>

    <body>
        <div id="app">Loading...</div>

        <div id="blazor-error-ui"
                class="text-center bg-danger h6 text-white p-2 fixed-top w-100"
                    style="display:none">  
            An unhandled error has occurred.
            <a href="" class="reload">Reload</a>
            <a class="dismiss">🗙</a>
        </div>
        <script src="_framework/blazor.webassembly.js"></script>
    </body>

    </html>

    
---

## Chapter 38

**Listing 38-3**. Use the following command:

    dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore --version 5.0.0

**Listing 38-6**. Use the following code:

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
    using Microsoft.AspNetCore.Identity;

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

                services.AddDbContext<IdentityContext>(opts =>
                    opts.UseSqlServer(Configuration[
                        "ConnectionStrings:IdentityConnection"]));
                services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<IdentityContext>();
            }

            public void Configure(IApplicationBuilder app, DataContext context) {


                app.UseDeveloperExceptionPage();
                app.UseStaticFiles();

                app.UseRouting();

                app.Map("/webassembly/{*path}", builder => {
                    app.Use(async (context, next) => {
                        PathString pathPrefix = new PathString("/webassembly");
                        context.Request.Path.StartsWithSegments(pathPrefix, out var rest);
                        if (rest != string.Empty && rest != "/") {
                            context.Request.Path = rest;
                        }
                        await next();
                    });
                    app.UseStaticFiles();
                });

                app.UseBlazorFrameworkFiles();

                app.UseEndpoints(endpoints => {
                    endpoints.MapControllerRoute("controllers",
                        "controllers/{controller=Home}/{action=Index}/{id?}");
                    endpoints.MapDefaultControllerRoute();
                    endpoints.MapRazorPages();
                    endpoints.MapBlazorHub();
                    endpoints.MapFallbackToFile("/webassembly/{*path:nonfile}", "index.html");
                    endpoints.MapFallbackToPage("/_Host");            });

                SeedData.SeedDatabase(context);
            }
        }
    }

---

## Chapter 39

**Listing 39-25**. Use the following commands:

    dotnet add package System.IdentityModel.Tokens.Jwt --version 6.8.0
    dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 5.0.0
