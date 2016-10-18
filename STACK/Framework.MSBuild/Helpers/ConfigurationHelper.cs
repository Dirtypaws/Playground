using System.Configuration;

namespace Framework.Helpers
{
    public class ConfigurationHelper
    {
        public static IConfigurationRoot Configuration = new ConfigurationRoot();
    }

    public interface IConfigurationRoot
    {
        string GetConnectionStrings(string name);
    }

    public class ConfigurationRoot : IConfigurationRoot
    {
        public string GetConnectionStrings(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}