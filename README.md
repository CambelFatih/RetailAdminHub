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

## Swagger UI 
![SwaggerUI](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/b86fbee3-d2af-4b40-9fa3-06e6cda37dc5)
![AccountPost](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/bf3eddc1-70d2-412f-8b14-748bffcaeef7)
![Token](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/584a23c0-c170-42d9-a708-05d022c8ad85)
![TokenTest](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/cbec8f62-7920-491f-b1c4-b96833108ffc)
![AccountGet](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/494ce3ae-c3e3-4317-9d58-9606218a7835)
![ProductPost](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/d4c3b3f9-e99f-43c2-9679-ac6d41c04941)
![ProductGet](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/b46d2164-d3d7-4f6c-85dc-4a005871c371)
![CategoryPost](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/a56e5006-77c6-4318-8111-60bc59a3ab08)
![CategoryGet](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/e6f2f5f4-c87b-4c8b-9590-279ccbcca78e)
![CategoryProductCreatePost](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/2741a6fb-c380-4889-8879-e96334879fa5)
![CategoryProductCreateGetFromProduct](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/6ddc267e-5816-4deb-933f-757462fea2ad)
![CategoryProductGetFromCategoryByID](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/7c77f925-5f88-4139-9f2a-fb784fd1d50b)
![CategoryProductRelationGetByIdProduct](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/b26549ce-af1d-4798-8917-409e426bba8a)
![patchProductStock](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/f48d3877-a649-4b32-ae76-5b18987b2a60)
![PatchProduct](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/c550ff9e-7d79-4742-91f4-8bd14a4ec8d7)
![PATCHSONUCproduct](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/6d07011b-37d3-4461-82cf-261d21009ac0)

![CategoryProductRemoveRelation](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/2a73f6a5-4953-41d0-9207-34bfe60e96a7)
![CategoryProductRemoveRelationResult](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/c2e50743-de62-4af4-aa39-4e6bb8e5905b)
![DeleteProduct](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/ed57391f-f1cd-41b8-b7de-c0dcb5c34031)
![ProductGet](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/897a707f-58f6-4a1e-b0f2-f9b5a1bae2ab)
![removeProductRESULT](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/ebd2c854-841a-4763-812d-082d66b5bc59)

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
