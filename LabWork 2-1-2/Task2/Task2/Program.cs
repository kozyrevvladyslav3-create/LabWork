using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введіть ширину бази(до 9):");
            int baseoft = Convert.ToInt32(Console.ReadLine());

            int i = 0;
            while (i != baseoft)
            {
                int j = 0;
                int k = 0;
                string spaces = null;
                string numbers = null;
                
                for (j = 0; j <= (baseoft - i); j++)
                {
                    spaces = spaces + " ";
                }
                for (k = 0; k <= i; k++)
                {
                    numbers = numbers + Convert.ToString((i + 1) + " ");
                }
                i++;
                Console.WriteLine(spaces + numbers);
            }
        }
    }
}
