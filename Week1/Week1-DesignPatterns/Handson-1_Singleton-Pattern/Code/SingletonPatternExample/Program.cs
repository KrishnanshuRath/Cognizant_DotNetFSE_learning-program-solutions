using System;
using SingletonPatternExample;

class Program
{
    static void Main()
    {
        Console.WriteLine("Testing Singleton Logger...");

        // Requesting a Logger instance
        Logger logger1 = Logger.GetInstance();
        logger1.Log("First log message");

        Logger logger2 = Logger.GetInstance();
        logger2.Log("Second log message");

        // Confirming both are the same object
        if (object.ReferenceEquals(logger1, logger2))
        {
            Console.WriteLine("logger1 and logger2 are the same instance (Singleton works!)");
        }
        else
        {
            Console.WriteLine("Different instances found (Singleton failed!)");
        }
    }
}
