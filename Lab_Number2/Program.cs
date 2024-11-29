using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Number2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите N (количество натуральных чисел): ");
            int N = int.Parse(Console.ReadLine());

            Console.Write("Введите M (количество потоков): ");
            int M = int.Parse(Console.ReadLine());

            string filePath = "C:/Users/Sutyagin/source/repos/Lab_Number2/Lab_Number2/result.txt";

            FileGenerator generator = new FileGenerator();
            generator.GenerateFile(filePath, N);//генерация файла

            //Анализ производительности обработки чисел 
            PerformanceAnalyzer analyzer = new PerformanceAnalyzer();
            analyzer.AnalyzeProcessing(filePath, N, M, 2); // Например, умножаем на 2

            Console.WriteLine("Обработка завершена.");
            Console.ReadKey();
        }
    }
}
