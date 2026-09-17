using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Current User Score: 0\r\nПитання 1, з яких кольорів складається Революційний прапор ОУН?\r\n1.жовтий і блакитний\r\n2.червоний і зелений\r\n3.чорний і жовтий\r\n4.червоний і чорний\r\nІ користувач вводить:");
            string answer = Console.ReadLine();
            if (answer == "4")
            {
                Console.WriteLine("Правильна відповідь!");
                Console.WriteLine("Current User Score: 800\r\nПитання 2, завдяки якій мові було зроблено цю програму?\r\n1.C\r\n2.Python\r\n3.C#\r\n4.C++\r\nІ користувач вводить:");
                answer = Console.ReadLine();
                if (answer == "3")
                {
                    Console.WriteLine("Правильна відповідь!");
                    Console.WriteLine("Current User Score: 1600\r\nПитання 3, яка за номером ця практична?\r\n1.1\r\n2.2\r\n3.3\r\n4.4\r\nІ користувач вводить:");
                    answer = Console.ReadLine();
                    if (answer == "2")
                    {
                        Console.WriteLine("Правильна відповідь!");
                        Console.WriteLine("Current User Score: 2400\r\nПитання 4, яке за номером це завдання?\r\n1.1\r\n2.2\r\n3.3\r\n4.4\r\nІ користувач вводить:");
                        answer = Console.ReadLine();
                        if (answer == "3")
                        {
                            Console.WriteLine("Правильна відповідь!");
                            Console.WriteLine("Current User Score: 3200\r\nПитання 5, яка кількість скріншотів була відправлена разом із попереднім завданням?\r\n1.1\r\n2.2\r\n3.3\r\n4.4\r\nІ користувач вводить:");
                            answer = Console.ReadLine();
                            if (answer == "2")
                            {
                                Console.WriteLine("Правильна відповідь! Стипендію отримано!\r\nScore: 4000");
                            }
                            else
                            {
                                Console.WriteLine("Неправильна відповідь.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Неправильна відповідь.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неправильна відповідь.");
                    }
                }
                else
                {
                    Console.WriteLine("Неправильна відповідь.");
                }
            }
            else
            {
                Console.WriteLine("Неправильна відповідь.");
            }
        }
    }
}
