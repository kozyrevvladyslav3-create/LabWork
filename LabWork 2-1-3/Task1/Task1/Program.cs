using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введіть цифру:");
            var userInput = Console.ReadLine();
            string result = "";
            string minus = "";
            if (int.Parse(userInput) < 0)
            {
                minus = "-";
                var e = int.Parse(userInput) * -1;
                userInput = e.ToString();
            }
            int len = userInput.Length;
            for (int i = 0; i < len; i++)
            {
                int diff = len - 1 - i;
                result += userInput[diff];
            }
            Console.WriteLine(minus + result);
        }
    }
}
