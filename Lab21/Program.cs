using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab21
{
    class Program
    {
        static int length = 0;
        static int width = 0;
        static int[,] garden;
        static void Main(string[] args)
        {
            Console.Write("Введите длину участка: ");
            length = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите ширину участка: ");
            width = Convert.ToInt32(Console.ReadLine());
            garden = new int[width, length];

            Thread gardener1 = new Thread(Gardener1);
            Thread gardener2 = new Thread(Gardener2);
            gardener1.Start();
            gardener2.Start();
            gardener1.Join();
            gardener2.Join();

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    Console.Write(garden[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        public static void Gardener1()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (garden[i, j] == 0)
                        garden[i, j] = 1;
                    Thread.Sleep(1);
                }
            }
        }

        public static void Gardener2()
        {
            for (int i = length - 1; i > 0; i--)
            {
                for (int j = width - 1; j > 0; j--)
                {
                    if (garden[j, i] == 0)
                        garden[j, i] = 2;
                    Thread.Sleep(1);
                }
            }
        }
    }
}
