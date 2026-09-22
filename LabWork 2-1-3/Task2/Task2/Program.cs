using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int number = int.Parse(Console.ReadLine()) - 1;
            string findText = text.Split(' ')[number];
            int indexForFindText = text.IndexOf(findText);
            string textAfterFindText = text.Substring(indexForFindText + findText.Length);
            Console.WriteLine(textAfterFindText);
        }
    }
}
