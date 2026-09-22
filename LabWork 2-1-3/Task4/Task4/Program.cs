using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            for (int i = 2; i < text.Length; i = i + 3)
            {
                text = text.Substring(0, i) + "X" + text.Substring(i + 1);
            }
            for (int i = 4; i < text.Length; i = i + 5)
            {
                text = text.Substring(0, i) + "5" + text.Substring(i + 1);
            }
            for (int i = 14; i < text.Length; i = i + 15)
            {
                text = text.Substring(0, i) + "?" + text.Substring(i + 1);
            }
            Console.WriteLine(text);
        }
    }
}
