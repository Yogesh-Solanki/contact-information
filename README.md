# Contact Information 
This repository contains the ContactInformatioApi and ContactInformationClient application. The API deals with database while client provide user interaction for contact information crud operations.


## Organization of Application
> Folder structure of the application
### A typical abstract directory layout

    .
    ├── contactinformationapi                   # api solution
        ├── contactinformationapi               # api project
            ├── appstart
                ├── unityresolver.cs            # unity resolver class to resolve dependencies at runtime
                ├── webapiconfig.cs
            ├── controllers
                ├── contactscontroller          # web api controller
            ├── mapper
                ├── contactmapper               # map db entity to business model and vice versa
            ├── models
                ├── contact.cs                  # business model
            ├── contactinformationapi.csproj
            ├── global.asax
            ├── nlog.config                     # log configuration file
            ├── web.config
        ├── contactinformationlibrary           #class library
            ├── businesslayer
                ├── businessprovider.cs         # business layer class
            ├── databaselayer
                ├── databaseprovider.cs         # data layer class 
            ├── entity
                ├── appdbcontext.cs             # database context by entity framework code first approach
                ├── contact.cs                  # database entity
            ├── interface
                ├── ibusinessprovider.cs        # interface to represent business provider
                ├── idatabaseprovider.cs        # interface to represent database provider
            ├── app.config
            ├── contactinformationlibrary.csproj
            ├── nlog.config                     # log configuration file
        ├── packages                            # required packages for solution
        ├── contactinformationapi.sln           # solution file
    ├── contactinformationclient                # client solution
        ├── contactinformationclient            # client project
            ├── apiaccesslayer
                ├── apicaller.cs                # api caller layer
            ├── content
                ├── site.css                    # set theme of the application
            ├── controllers
                ├── contactscontroller.cs       # mvc web app controller
            ├── models
                ├── contact.cs                  # mvc web app model
                ├── responsebase.cs             # extended model for error messages
            ├── views                           # mvc views
            ├── global.asax
            ├── nlog.config                     # exception log handling
            ├── web.config
            ├── contactiformationclient.csproj  # proj file
        ├── packages
        ├── contactiformationclient.sln
        
            
        

## Prerequisites

+ Should have .net 6.1.0 installed on your system
+ Should have SQL Server installed on you system configured with database engine (localdb)\mssqllocaldb
+ Should have Visual Studio 2015 or above installed to run the project


## Steps to Run Application

+ Download the project
+ Run the ContactInformationApi project first from visual studio
+ Run the ContactInformationClient project after api project from visual studio
+ You are all done. Play with the application. Happy Coading. :)


## Versioning

+ This is version v1.0

## Author

+ Yogesh K. Solanki - .Net and Angular Developer


