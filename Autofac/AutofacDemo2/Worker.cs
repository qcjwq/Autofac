using System;

namespace AutofacDemo2
{
    public class Worker:IPerson
    {
        public void Say()
        {
            Console.WriteLine("我是一个工人！");
        }
    }
}