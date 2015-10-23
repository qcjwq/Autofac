using System;

namespace AutofacDemo2
{
    public class LogConsole:ILog
    {
        public void Log()
        {
            Console.WriteLine("控制台记录日志");
        }
    }
}