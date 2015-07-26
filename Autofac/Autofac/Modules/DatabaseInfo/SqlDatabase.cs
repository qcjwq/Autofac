using System;
using AutofacDemo.Interfaces;

namespace AutofacDemo.Modules.DatabaseInfo
{
    public class SqlDatabase:IDatabase
    {
        public string Name => "SqlServer";

        public void Select(string commandText)
        {
            Console.WriteLine($"'{commandText}'is a query sql in {Name}!");
        }

        public void Insert(string commandText)
        {
            Console.WriteLine($"'{commandText}'is a insert sql in {Name}!");
        }

        public void Update(string commandText)
        {
            Console.WriteLine($"'{commandText}'is a update sql in {Name}!");
        }

        public void Delete(string commandText)
        {
            Console.WriteLine($"'{commandText}'is a delete sql in {Name}!");
        }
    }
}