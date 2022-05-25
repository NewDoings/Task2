using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        public static int[] coordinates;
        public static int[] coordinates2;

        static async Task Main(string[] args)
        {
            string path = @"C:\Users\User\source\repos\Task2\Task2\note.txt";
            string path2 = @"C:\Users\User\source\repos\Task2\Task2\coordinates.txt";

            

            using (FileStream fstream = File.OpenRead(path))
            {
                // выделяем массив для считывания данных из файла
                byte[] buffer = new byte[fstream.Length];
                // считываем данные
                await fstream.ReadAsync(buffer, 0, buffer.Length);
                // декодируем байты в строку
                string textFromFile = Encoding.Default.GetString(buffer);
                Console.WriteLine($"Текст из файла note: {textFromFile}");

                string[] str = textFromFile.Split();
                str = str.Where(x => x != "").ToArray();

                int[] arr = new int[str.Length];

                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = Convert.ToInt32(str[i]);
                }

                //for (int i = 0; i < str.Length; i++)
                //{
                //    Console.WriteLine("Ответ: " + arr[i]);
                //}
                coordinates = arr;
                Console.WriteLine("Нажмите любую клавишу\n");
                Console.ReadKey();
            }

            using (FileStream fstream = File.OpenRead(path2))
            {
                // выделяем массив для считывания данных из файла
                byte[] buffer = new byte[fstream.Length];
                // считываем данные
                await fstream.ReadAsync(buffer, 0, buffer.Length);
                // декодируем байты в строку
                string textFromFile = Encoding.Default.GetString(buffer);
                Console.WriteLine($"Текст из файла coordinates: {textFromFile}\n");

                string[] str = textFromFile.Split();
                str = str.Where(x => x != "").ToArray();

                int[] arr = new int[str.Length];

                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = Convert.ToInt32(str[i]);
                }

                //for (int i = 0; i < str.Length; i++)
                //{
                //    Console.WriteLine("Ответ: " + arr[i]);
                //}
                coordinates2 = arr;
                Console.WriteLine("Нажмите любую клавишу\n");
                Console.ReadKey();
            }
            
            double kek;

            for (int i = 0; i < coordinates.Length; i += 2)
            {
                kek = counting(coordinates2[0], coordinates[i], coordinates2[0], coordinates[i+1]);
                if (kek == coordinates2[2])
                {
                    Console.WriteLine(0);
                }
                if (kek < coordinates2[2])
                {
                    Console.WriteLine(1);
                }
                if (kek > coordinates2[2])
                {
                    Console.WriteLine(2);
                }
            }
            Console.ReadKey();
        }
        public static double counting(int x1 , int x2 , int y1, int y2 )
        {
            double resalt = ((int)Math.Pow(x2 - x1,2) + (int)Math.Pow(y2 - y1, 2));
            return Math.Sqrt(resalt);
        }
    }
}
