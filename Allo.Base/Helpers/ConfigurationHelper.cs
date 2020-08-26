using System.IO;
using Microsoft.Extensions.Configuration;

namespace Allo.Base.Helpers
{
    //NOTE: Static method that return configuration from setting file, appsettings.json is a default 
    public static class ConfigurationHelper
    {
        public static IConfiguration GetConfiguration(string fileName = "appsettings.json")
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(fileName)
                .Build();
        }
    }
}
