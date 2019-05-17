using Logger;

namespace CounselorApp
{
    public class Logger
    {
        private static SimpleLogger instance ;

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
