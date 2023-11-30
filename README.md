# VPTest

The approach I've taken aims to demonstrate a Domain Driven Design approach within a Mediator Command/Query pattern. I have not included any Events or unit tests. The code will throw run time errors but there are no compilation errors and is created in the sense that if the configuration were set up, it would run (bar some potential minor oversights). I have not set up the configuration code required to create the database, resolve the DI interfaces and EF/Migrations as I don't believe it's the primary reason for this test and it would take longer than 2-3 hours as it's not something I do often. 

I have added some discussion within the query command stating what I would do differently within a full stack environment. 

I have added some basic empty/null validation on some of the request entities, as well as validating the Sell Price is identical from the request via front end to what is stored in the database.  
