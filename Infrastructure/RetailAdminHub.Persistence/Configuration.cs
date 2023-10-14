using Microsoft.Extensions.Configuration;
namespace RetailAdminHub.Persistence;

static class Configuration
{
    static public string ConnectionString
    {
        get
        {
            ConfigurationManager configurationManager = new();
            try
            {
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/RetailAdminHub.API"));
                configurationManager.AddJsonFile("appsettings.json");

            }
            catch
            {
                configurationManager.AddJsonFile("appsettings.Production.json");
            }
            return configurationManager.GetConnectionString("PostgreSQL");
        }
    }
}
