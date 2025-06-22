using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPatternExample
{
    public class Logger
    {
        // This variable stores the Logger object
        // private ensures only this class can access this variable
        // static ensures only one instance of this variable is shared globally
        private static Logger _instance;

        // This is to ensure thread safety (in case 2 instances access this class simultaneously)
        // readonly ensures value is cannot be modified and remains constant
        private static readonly object _lock = new object();

        // Constructor that executes automatically when this class is accessed
        // private ensures this constructor cannot be accessed outside this class
        private Logger()
        {
            Console.WriteLine("Logger instance created!");
        }

        // Since this class cannot be accessed from outside, we make an instance creator inside
        // We check if an instance already exists, if not, we lock the critical section of the code
        // Then the critical section of the code creates a logger instance after double checking if there exists another instance
        public static Logger GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Logger();
                    }
                }
            }
            return _instance;
        }

        // Log method to display a message in terminal
        public void Log(string message)
        {
            Console.WriteLine("[LOG] " + message);
        }
    }
}
