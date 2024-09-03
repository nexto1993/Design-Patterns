namespace Singleton
{

    public class ConfigurationManager
    {
        private static ConfigurationManager _instance;
        private static readonly object _lock = new object();
        private ConfigurationManager()
        {
        }

        public static ConfigurationManager GetInstance()
        {

            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ConfigurationManager();
                    }
                }
            }
            return _instance;
        }


        public string GetConfiguration(string key)
        {
            return $"Value for {key}";
        }
    }
        internal class Program
    {
        static void Main(string[] args)
        {
            // Retrieve the single instance of ConfigurationManager
            ConfigurationManager configManager1 = ConfigurationManager.GetInstance();
            ConfigurationManager configManager2 = ConfigurationManager.GetInstance();

            // Verify that both variables point to the same instance
            if (configManager1 == configManager2)
            {
                Console.WriteLine("Both instances are the same.");
            }

            // Use the singleton instance to get configuration values
            Console.WriteLine(configManager1.GetConfiguration("DatabaseConnectionString"));
            Console.WriteLine(configManager2.GetConfiguration("APIKey"));
        }
    }
}
