using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Lab_Number2
{
    public class PerformanceAnalyzer
    {
        public void Analyze(Action action, string description)// принимает действие и его описание, измеряет время его выполнения и выводит результат
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start(); // запуск таймера
            action.Invoke(); // Выполняем действие
            stopwatch.Stop(); //остановка таймера

            long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;// сохраняем время выполнения в миллисекундах  
            // Выводим результаты
            Console.WriteLine($"{description}: {elapsedMilliseconds} ms");

        }


        public void AnalyzeProcessing(string filePath, int N, int M, int multiplier)//анализ обработки файлов с использованием как последовательного, так и многопоточного подхода
        {
            FileProcessor processor = new FileProcessor(filePath, M);
            // Последовательная обработка
            Analyze(() => processor.ProcessFile(multiplier), "Последовательная обработка");
            // Многопоточная обработка с использованием ThreadPool
            Analyze(() => processor.ProcessFileWithThreadPool(multiplier), "Многопоточная обработка с ThreadPool");

        }

    }
}