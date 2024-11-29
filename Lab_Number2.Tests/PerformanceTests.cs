using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Lab_Number2.Tests
{
    [TestClass]
    public class PerformanceTests
    {
        [TestMethod]
        public void TestFactorial()
        {
            // Тестирование факториала
            FileProcessor processor = new FileProcessor("result.txt", 1);
            int number = 10;
            long expectedFactorial = 3628800; // Ожидаемое значение факториала для 10
            long actualFactorial = processor.Factorial(number);
            Assert.AreEqual(expectedFactorial, actualFactorial); // Проверка, совпадает ли ожидаемое и фактическое значение
        }

        [TestMethod]
        public void TestFibonacci()
        {
            // Тестирование фибоначчи
            FileProcessor processor = new FileProcessor("result.txt", 1);
            int number = 10;
            int expectedFibonacci = 55; // Ожидаемое значение Фибоначчи для 10
            int actualFibonacci = processor.Fibonacci(number);
            Assert.AreEqual(expectedFibonacci, actualFibonacci); // Проверка
        }

        [TestMethod]
        public void TestSquare()
        {
            // Тестирование возведения в квадрат
            FileProcessor processor = new FileProcessor("result.txt", 1);
            int number = 10;
            int expectedSquare = 100; // Ожидаемое значение 10 в квадрате

            // Вызываем метод ProcessLine и получаем результаты
            var results = processor.ProcessLine(number.ToString(), 2);

            int actualSquare = results.squared; // Получаем значение возведения в квадрат

            Assert.AreEqual(expectedSquare, actualSquare); // Проверка
        }

        [TestMethod]
        public void TestPerformance()
        {
            // Определяем конкретные значения для N и M
            int[] NValues = { 10, 100, 1000, 100000 };
            int[] MValues = { 1, 2, 5, 10, 20, 30, 100 };

            // Путь к файлу
            string filePath = "C:/Users/Sutyagin/source/repos/Lab_Number2/Lab_Number2/result.txt";

            // Проходим по каждому значению N
            foreach (int N in NValues)
            {
                // Генерация файла с N натуральными числами
                FileGenerator generator = new FileGenerator();
                generator.GenerateFile(filePath, N);

                // Проходим по каждому значению M
                foreach (int M in MValues)
                {
                    // Анализ производительности
                    PerformanceAnalyzer analyzer = new PerformanceAnalyzer();
                    analyzer.AnalyzeProcessing(filePath, N, M, 2); // Анализ производительности
                }
            }
        }
    }
}

