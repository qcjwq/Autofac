using System;

namespace AutofacDemo2
{
    public class Student:IPerson
    {
        public void Say()
        {
            Console.WriteLine("我是一个学生！");
        }
    }
}