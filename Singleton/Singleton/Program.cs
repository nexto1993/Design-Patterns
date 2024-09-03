namespace Singleton
{

    sealed class ConfigurationManager
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

            Thread th1 = new Thread(() =>
            {
                ConfigurationManager config = ConfigurationManager.GetInstance();
            });

            Thread th2 = new Thread(() =>
            {
                ConfigurationManager config = ConfigurationManager.GetInstance();
            });
            th1.Start();
            th2.Start();
            th1.Join();
            th2.Join();
        }
    }
}
