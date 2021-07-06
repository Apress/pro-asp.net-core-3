# Errata for *Pro ASP.NET Core 3*

**Chapter 11**

Improvements in the performance of Docker have revealed a race condition where the container for the SportsStore application attempts to access the database before it is ready. This results in an authentication error that stops the SportsStore container.

If you encoutner this problem, you can start the containers individually. Instead of the `docker-compose up` command shown in Listing 11-14, use this command to start the SQL Server container:

    docker-compose up sqlserver

Wait until SQL Server has started and no new messages are displayed at the console. Open a new command prompt and run this command:

    docker-compose up sportsstore

The SportsStore application will start and will be able to access the database. You may see authentication failure messages but this is normal and is caused by the way Entity Framework Core checks to see if a database has been created.

(Thanks to David Lovell for reporting this problem)

***
**Chapter 11**

The statement that checks to see whether the administration user exists in the database in Listing 11-7 is incorrect:

    IdentityUser user = await userManager.FindByIdAsync(adminUser);

The statement will never locate the administration user, even when one exists in the database. Use this statement instead:

    IdentityUser user = await userManager.FindByNameAsync(adminUser);



(Thanks to Yanko Hernández Álvarez for reporting this problem)

***

**Chapter 28**

Some URLs in this chapter are incorrect. The chapter specifies URLs like this:

    http://localhost:5000/controller/Form

The segment `controller` should be `controllers` like this:

    http://localhost:5000/controllers/Form

(Thanks to Joel Hallan for reporting this problem)
***

**Chapter 39**

The `CheckPassword` method in Listing 39-27 doesn't check the password provided by the JavaScript client. Use the following code instead:

    private async Task<bool> CheckPassword(Credentials creds) {
        IdentityUser user = await userManager.FindByNameAsync(creds.Username);
        if (user != null) {
            return (await signinManager.CheckPasswordSignInAsync(user, 
                creds.Password, true)).Succeeded;
        }
        return false;
    }

(Thanks to Amna Al Naseri for reporting this problem)
