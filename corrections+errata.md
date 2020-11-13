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

**Chapter 13**

On page 303 in the sentence "The URL pattern used by fallbacks is {path:nofile}, and they rely on the Order property...", there are two typos in "{path:nofile}". 
It should be: 

 {*path:nonfile}

 (Thank you Ilya for reporting this typo)
 
 ***

**Chapter 28**

Some URLs in this chapter are incorrect. The chapter specifies URLs like this:

    http://localhost:5000/controller/Form

The segment `controller` should be `controllers` like this:

    http://localhost:5000/controllers/Form

(Thanks for Joel Hallan for reporting this problem)
***

