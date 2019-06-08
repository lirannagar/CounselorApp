using Logger;

namespace UnitTests
{
    public class LoggerTest
    {
        private static SimpleLogger instance;

        public static SimpleLogger Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SimpleLogger();
                }
                return instance;
            }
        }

    }
}
