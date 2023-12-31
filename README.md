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

## Database Connection with this project
### Project Database Configuration Documentation

This documentation provides instructions on how to configure the project to work with your own database on your local machine. The project uses PostgreSQL by default, but you can easily switch to another database system, such as MySQL, by following the outlined steps.

### Requirements

Before getting started, make sure you have Docker installed on your machine.

#### Docker Installation

If you don't have Docker installed, you can pull and run PostgreSQL in a Docker container as follows:

```bash
docker pull postgres
docker run -d --name postgresCont -p 5432:5432 -e POSTGRES_PASSWORD=123 postgres
```
This command pulls the latest PostgreSQL Docker image, creates a container named postgresCont, maps port 5432, and sets the PostgreSQL password to 123. You can change the container name, port, and password as needed.

### Step 2: Configure the Connection String
In the **appsettings.json** file, modify the **ConnectionStrings** section to use PostgreSQL as follows:
```json
"ConnectionStrings": {
  "PostgreSQL": "Host=localhost;Port=5432;Database=patika6;Username=postgres;Password=123;"
}
```
### **ServiceRegistration.cs** File From Persistence Layer
```csharp
namespace RetailAdminHub.Persistence;

/// <summary>
/// This class contains extension methods to register persistence-related services in the service collection.
/// </summary>
public static class ServiceRegistration
{
    /// <summary>
    /// Registers the necessary persistence services in the provided <paramref name="services"/>.
    /// </summary>
    /// <param name="services">The service collection to which services will be added.</param>
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        // Add DbContext for RetailAdminHubDbContext using Npgsql provider with the connection string from configuration.
        services.AddDbContext<RetailAdminHubDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
        // Add UnitOfWork as a scoped service, which is tied to the scope of the HTTP request.
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
```

### **ServiceRegistration.cs** File From Persistence Layer
```csharp
namespace RetailAdminHub.Application;
/// <summary>
/// A class responsible for registering application services.
/// </summary>
public static class ServiceRegistration
{
    /// <summary>
    /// Adds application services to the specified service collection.
    /// </summary>
    /// <param name="services">The service collection to which services will be added.</param>
    public static void AddApplicationServices(this IServiceCollection services)
    {
        // Register MediatR services from the assembly containing this class.
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly));
        // Add HttpClient services.
        services.AddHttpClient();
        // Configure FluentValidation for request validation.
        // Register FluentValidation auto-validation for ASP.NET Core.
        services.AddFluentValidationAutoValidation();
        // Register validators from the assembly containing BaseValidator.
        services.AddValidatorsFromAssemblyContaining<BaseValidator>();
    }
}
```

### **Program.cs** File From API Layer
```csharp
builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();
```

### **Configration.cs** File From Persistence Layer
```csharp
namespace RetailAdminHub.Persistence;
/// <summary>
/// Helper class to retrieve the connection string from the application's configuration.
/// </summary>
static class Configuration
{
    /// <summary>
    /// Gets the connection string from the application's configuration.
    /// </summary>
    /// <returns>The connection string.</returns>
    static public string ConnectionString
    {
        get
        {
            // Create a ConfigurationManager instance to access the configuration.
            ConfigurationManager configurationManager = new();
            try
            {
                // Set the base path and add the appsettings.json file for configuration.
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/RetailAdminHub.API"));
                configurationManager.AddJsonFile("appsettings.json");

            }
            catch
            {
                // If appsettings.json is not found, attempt to use appsettings.Production.json.
                configurationManager.AddJsonFile("appsettings.Production.json");
            }
            // Retrieve and return the PostgreSQL connection string from the configuration.
            var connectionString= configurationManager.GetConnectionString("PostgreSQL");
            if (connectionString == null)
                throw new ConfigurationException("PostgreSQL connection string not found in configuration.");
            return connectionString;
        }
    }
}

```

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

![CreateAccount](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/b2e5d981-a988-4d05-a441-458904381b63)
![CreateToken](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/e804b789-ae6f-4384-b46c-c2d468c6b66b)
![GetAllAccount](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/b5f9b08d-4171-4bd6-85fc-14f23846e6ff)
![CreateProduct](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/b35193f6-2b49-4a2a-adde-9e2bf0872b7f)
![CreateCategory](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/3483b8b6-a340-47da-b012-fd347619e266)
![CreateCategoryProduct](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/19c6d08f-b21f-4314-b625-cedf7ccd5cc7)
![GetByIdAccount](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/73bee9a5-e425-449c-9d3e-88681bb2c803)
![CategoryGetById](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/96bd569a-2d39-448d-bc09-6a48bbc3fde6)
![ProductGetByIdNotFound](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/d98c921d-8ba9-4a56-9007-953bcc8f6447)
![ProductGetById](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/22e0029c-379b-47e9-a6b0-8d3a859f98a4)
![PatchProduct](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/6d07d622-4c47-42f7-b32c-624ca79aff1d)
![GetAllProduct](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/cf39525e-c65f-448b-bbea-a0b8578ff6df)
![GetAllCategory](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/0f695a61-eaa9-4813-8d29-902de465cd7a)
![DeleteProduct](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/37b0a962-e231-4a8b-beb2-09d370616d02)

# The project screenshots below are out of date.
## Added Account
![AccountPost](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/bf3eddc1-70d2-412f-8b14-748bffcaeef7)
## Take a Token 
![Token](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/584a23c0-c170-42d9-a708-05d022c8ad85)
## Token Test success
![TokenTest](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/cbec8f62-7920-491f-b1c4-b96833108ffc)
## Account Get
![AccountGet](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/494ce3ae-c3e3-4317-9d58-9606218a7835)
## Added Product
![ProductPost](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/d4c3b3f9-e99f-43c2-9679-ac6d41c04941)
## see all products 
![ProductGet](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/b46d2164-d3d7-4f6c-85dc-4a005871c371)
## Create a Category
![CategoryPost](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/a56e5006-77c6-4318-8111-60bc59a3ab08)
## see all Category
![CategoryGet](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/e6f2f5f4-c87b-4c8b-9590-279ccbcca78e)
## Create a between Category and Product Relation
![CategoryProductCreatePost](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/2741a6fb-c380-4889-8879-e96334879fa5)
## see between Category and Product Relation 
![CategoryProductCreateGetFromProduct](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/6ddc267e-5816-4deb-933f-757462fea2ad)
## see between Category and Product Relation BY ID category
![CategoryProductGetFromCategoryByID](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/7c77f925-5f88-4139-9f2a-fb784fd1d50b)
## See between Category and Product Relation BY ID product
![CategoryProductRelationGetByIdProduct](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/b26549ce-af1d-4798-8917-409e426bba8a)
## Update with patch method "Stock" field 
![patchProductStock](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/f48d3877-a649-4b32-ae76-5b18987b2a60)
## Update with patch method Name field
![PatchProduct](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/c550ff9e-7d79-4742-91f4-8bd14a4ec8d7)
## See patch method result
![PATCHSONUCproduct](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/6d07011b-37d3-4461-82cf-261d21009ac0)
## Remove between Category and Product from Category id nad product id
![CategoryProductRemoveRelation](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/2a73f6a5-4953-41d0-9207-34bfe60e96a7)
## See remove category and product relation result
![CategoryProductRemoveRelationResult](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/c2e50743-de62-4af4-aa39-4e6bb8e5905b)
## Remove Product
![DeleteProduct](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/ed57391f-f1cd-41b8-b7de-c0dcb5c34031)
## See Remove Product Result
![ProductGet](https://github.com/CambelFatih/RetailAdminHub/assets/79880394/897a707f-58f6-4a1e-b0f2-f9b5a1bae2ab)
## Remove Product Resul
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
