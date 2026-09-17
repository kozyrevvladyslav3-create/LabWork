using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введіть приклад:");
            var result = new DataTable().Compute(Console.ReadLine(), null);
            Console.WriteLine("Відповідь:" + result);
        }
    }
}
