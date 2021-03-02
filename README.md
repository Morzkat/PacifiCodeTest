# Hahn.ApplicationProcess.February2021
Sample Web API implementation with .NET Core and DDD using Clean Architecture.

## Solution Design
The solution design focuses on a basic Domain Driven Design techniques and implementation, while keeping the things as simple as possible but can be extended as needed. Multiple assemblies are used for separation of concerns to keep logic isolated from the other components. **.NET 5 C#** is the default framework and language for this application.

### Assembly Layers
-   **Hahn.ApplicationProcess.February2021.Domain**  - This assembly contains Business Logic, Validators, Interfaces and Models.
-   **Hahn.ApplicationProcess.February2021.Data**  - This assembly contains DataAccess, HTTPDataAccess, Repositories, the UnitOfWork.
-   **Hahn.ApplicationProcess.February2021.Web**  - This assembly is the web api host.
-   **Hahn.ApplicationProcess.February2021.Tests**  - This assembly contains unit test classes based on the [NUnit](https://github.com/nunit/nunit) testing framework.

## How to contribute

> :thought_balloon: If you are new in Open Source world feel free to check our [How to contribute guidelines](https://github.com/Jadhielv/Hahn.ApplicationProcess.February2021/blob/master/CONTRIBUTING.md)

## Validation
Data validation using [FluentValidation](https://github.com/JeremySkinner/FluentValidation)

## How to run application: 
[(Backend)](https://github.com/Jadhielv/Hahn.ApplicationProcess.February2021/tree/master/Backend)


### In case you want to use a local database:
1. Create empty database, name: **`Hahn.ApplicationProcess.February2021`**.
2. Execute [migrations](https://github.com/Morzkat/PacifiCodeTest/tree/master/Hahn.ApplicationProcess/src/Hahn.ApplicationProcess.February2021.Data/DataAccess/Migrations).
2. Set connection string (in [appsettings.json](https://github.com/Morzkat/PacifiCodeTest/blob/master/Hahn.ApplicationProcess/src/Hahn.ApplicationProcess.February2021.Web/appsettings.json) or by user secrets mechanism).
3. Run ...

[(Hahn.ApplicationProcess.February2021-frontend)](https://github.com/Morzkat/PacifiCodeTest/tree/master/hahn-applicationProcess-frontEnd)

Follow the instructions in [README](https://github.com/Morzkat/PacifiCodeTest/blob/master/hahn-applicationProcess-frontEnd/README.md) file.

## Give a Star!

If you like this project, learn something or you are using it in your applications, please give it a star. Thanks! ...

## License

This project is open source and available under the: [MIT License](LICENSE)