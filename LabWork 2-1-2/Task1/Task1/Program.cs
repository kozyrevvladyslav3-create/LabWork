using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введіть рік:");
            string yearstr = Console.ReadLine();
            int yearint = Convert.ToInt32(yearstr);
            if (yearint >= 400 && yearint % 400 == 0)
            {
                Console.WriteLine("Рік високосний");
            }
            else if (yearint >= 100 && yearint % 100 == 0)
            {
                Console.WriteLine("Рік невисокосний");
            }
            else if (yearint >= 4 && yearint % 4 == 0)
            {
                Console.WriteLine("Рік високосний");
            }
            else
            {
                Console.WriteLine("Рік невисокосний");
            }

        }
    }
}
