using System;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Оберіть фігуру:\r\n1.Квадрат\r\n2.Круг\r\n3.Прямоктник\r\n4.Трикутник");
            int inputt = int.Parse(Console.ReadLine());
            double result = 0;
            if (inputt == 1)
            {
                Console.WriteLine("Введіть сторону");
                double a = double.Parse(Console.ReadLine());
                result = 2*a;
            }
            else if (inputt == 2)
            {
                Console.WriteLine("Введіть радіус");
                double a = double.Parse(Console.ReadLine());
                result = Math.PI * a * a;
            }
            else if (inputt == 3)
            {
                Console.WriteLine("Введіть першу сторону");
                double a = double.Parse(Console.ReadLine());
                Console.WriteLine("Введіть другу сторону");
                double b = double.Parse(Console.ReadLine());
                result = a * b;
            }
            else if(inputt == 4)
            {
                Console.WriteLine("Введіть основу");
                double a = double.Parse(Console.ReadLine());
                Console.WriteLine("Введіть висоту");
                double h = double.Parse(Console.ReadLine());
                result = a * h / 2;
            }
            Console.WriteLine("Площа фігури:" + result);
        }
    }
}
