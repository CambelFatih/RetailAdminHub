using Microsoft.Extensions.Configuration;
using RetailAdminHub.Application.Exceptions;

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
