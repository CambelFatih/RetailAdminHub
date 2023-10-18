# RetailAdminHub
## Project Overview
The project follows the principles of Onion Architecture, which is a layered architectural pattern that emphasizes separation of concerns and maintainability.

![onion](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/bb37b70f-59b7-40ee-a65c-c063c301bba7)

### Core Layer (RetailAdminHub.Domain)
- Defines core domain logic and models.
- Utilizes packages for identity management using ASP.NET Core Identity.
- Represents the innermost layer of the onion, focusing on business rules and entities.
#### Packages
### Application Layer (RetailAdminHub.Application)
- Contains application services and business logic.
- Utilizes packages for features like AutoMapper, MediatR, FluentValidation for validation, and JWT token handling.
- Orchestrates interactions between the core domain and external layers.
#### Packages
- **AutoMapper:** Version 12.0.1
- **FluentValidation:** Version 11.7.1
- **FluentValidation.AspNetCore:** Version 11.3.0
- **FluentValidation.DependencyInjectionExtensions:** Version 11.7.1
- **MediatR:** Version 12.1.1
- **Microsoft.AspNetCore.Identity.EntityFrameworkCore:** Version 7.0.11
- **Microsoft.AspNetCore.Mvc.NewtonsoftJson:** Version 7.0.12
- **System.IdentityModel.Tokens.Jwt:** Version 7.0.2
### Persistence Layer (RetailAdminHub.Persistence)
- Responsible for data access and persistence using Entity Framework Core and PostgreSQL as the database provider.
- Utilizes Entity Framework Core and PostgreSQL integration.
- Implements repository patterns to interact with the database without exposing details to higher layers.
#### Packages
- **Microsoft.EntityFrameworkCore:** Version 7.0.11
- **Microsoft.EntityFrameworkCore.Tools:** Version 7.0.11
- **Microsoft.Extensions.Configuration:** Version 7.0.0
- **Microsoft.Extensions.Configuration.Json:** Version 7.0.0
- **Microsoft.Extensions.DependencyInjection.Abstractions:** Version 7.0.0
- **Npgsql.EntityFrameworkCore.PostgreSQL:** Version 7.0.11
### Infrastructure Layer (RetailAdminHub.Infrastructure)
- Handles cross-cutting concerns such as logging using Serilog and memory management.
- Utilizes Serilog for logging and memory stream management.
- Integrates with external frameworks and technologies.
#### Packages
- **Microsoft.IO.RecyclableMemoryStream:** Version 2.3.2
- **Serilog.AspNetCore:** Version 7.0.0
- **Serilog.Sinks.File:** Version 5.0.0
- **Serilog.Sinks.RollingFile:** Version 3.3.0
### Web API Layer
- Represents the API using ASP.NET Core.
- Utilizes packages for JWT token authentication, Swagger for API documentation, and other necessary dependencies for API functionality.
- Serves as the entry point of the application.
#### Packages
- **AutoMapper.Extensions.Microsoft.DependencyInjection:** Version 12.0.1
- **Microsoft.AspNetCore.Authentication.JwtBearer:** Version 7.0.12
- **Microsoft.AspNetCore.OpenApi:** Version 7.0.11
- **Microsoft.EntityFrameworkCore.Design:** Version 7.0.11
- **Swashbuckle.AspNetCore:** Version 6.5.0

### Target Framework
- **Target Framework:** .NET 7.0 (Used in all layers)

## Design Patterns Used in the Project

### Unit Of Work Pattern
- Utilized the `IUnitOfWork` interface and its implementing classes to ensure that operations are performed together, allowing all steps within the same operation to be successfully completed together.

### CQRS (Command Query Responsibility Segregation) Pattern
- Segregated command and query operations to different processors, enabling independent optimization of each, for example, in classes like `CreateProductCommandHandler` and `ProductReadRepository`.

### Mediator Pattern
- Utilized the `IMediator` interface to facilitate the sending and handling of messages, managing communication between objects from a centralized point. This is evident in the usage of `IMediator` in the `ProductController` class.

### Repository Pattern
- Abstracted database operations to perform database operations consistently. Classes like `ReadRepository` and `WriteRepository` represent this pattern.

These patterns have been employed in the project's design.


##### Patch Method
Example patch request bodys, You can use the sample request bodys code below
you can just update(replace) 
``` json
//1.name property update patch method request body

[
  {
    "path": "name",
    "value": "NVDIA 4090 GPU"
  }
]

//2.stock property update patch method request body

[
  {
    "path": "stock",
    "value": 22
  }
]

//3.price property update patch method request body

[
  {
    "path": "price",
    "value": 33.5
  }
]
```
