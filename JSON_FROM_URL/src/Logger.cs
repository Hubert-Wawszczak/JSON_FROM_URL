using System;

namespace JSON_FROM_URL
{
    public class Logger
    {
        private static Logger _instance;
        private static readonly object _lock = new();

        private Logger()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static Logger GetLogger()
        {
            if (_instance == null)
                lock (_lock)
                {
                    if (_instance == null) _instance = new Logger();
                }

            return _instance;
        }


        public void LogMessage(string message, short flag = 1)
        {
            if (flag == 1)
                Console.WriteLine("INFO " + message);
            if (flag == 2)
                Console.WriteLine("WARNING " + message);
            if (flag == 3)
                Console.WriteLine("ERROR " + message);
            if (flag == 4)
                Console.WriteLine("CRITICAL " + message);
            if (flag == 5)
                Console.WriteLine("EXCEPTION " + message);
        }
    }
}