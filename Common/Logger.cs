using System;
using System.Reflection;

namespace AlexejheroYTB.Common
{
    public static class Logger
    {
        public static void Log(object toLog)
        {
            Console.WriteLine($"[{Assembly.GetCallingAssembly().GetName().Name}] {toLog.ToString()}");
        }

        public static void Exception(Exception e)
        {
            Console.WriteLine($"[{Assembly.GetCallingAssembly().GetName().Name}] An exception has occurred");
            Console.WriteLine($"[{Assembly.GetCallingAssembly().GetName().Name}] Exception: {e.ToString()}");
        }
    }
}
