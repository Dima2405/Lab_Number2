using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_Number2
{
    public class FileProcessor
    {
        private readonly string _filePath; // поля для хранения путь к файлу
        private readonly int _M; // поля для хранения кол-во потоков

        public FileProcessor(string filePath, int M)
        {
            //Конструктор для инициализации полей
            _filePath = filePath;
            _M = M;
        }

        public void ProcessFile(int multiplier) //разбивает работу на несколько потоков
        {

            var lines = File.ReadAllLines(_filePath); //считывает все строки из файла
            int totalLines = lines.Length; //Определение количества строк в файле
            int linesPerThread = totalLines / _M; // делит общее количество строк на количество потоков _M, чтобы определить, сколько строк будет обрабатываться каждым потоком
            Task[] tasks = new Task[_M]; //Создает массив задач и запускаем обработку строк в отдельных потоках с помощью Task.Run().

            for (int i = 0; i < _M; i++) //создаются задачи, которые будут обрабатывать строки. Каждая задача получает свой диапазон строк для обработки.
            {
                int start = i * linesPerThread; // Начальный индекс: произведение номера потока i и количества строк
                int end = (i == _M - 1) ? totalLines : start + linesPerThread; //Кончечный индекс: проверяет, является ли текущий поток последним. Если это так, end устанавливается равным общему количеству строк (totalLines), иначе оно будет равно (start + linesPerThread),что означает, что поток будет обрабатывать фиксированное количество строк, равное linesPerThread.
                tasks[i] = Task.Run(() => ProcessLines(lines, start, end, multiplier)); //запускает обработку строк в отдельном потоке
            }
            Task.WaitAll(tasks); //ожидает завершения всех запущенных задач

        }


        private void ProcessLines(string[] lines, int start, int end, int multiplier)//Обработка строк в заданном диапазоне
        {
            for (int i = start; i < end; i++)
            {
                int number = int.Parse(lines[i]);
                // Для каждой строки выполняем различные операции
                int multiplied = number * multiplier; // умножение на 2
                int squared = (int)Math.Pow(number, 2); //возведение в квадрат
                long factorial = Factorial(number); // факториал
                int fibonacci = Fibonacci(number); // фибоначчи
                // Вывод в консоль
                Console.WriteLine($"Number: {number}, Multiplied: {multiplied}, Squared: {squared}, Factorial: {factorial}, Fibonacci: {fibonacci}");

            }

        }


        public void ProcessFileWithThreadPool(int multiplier)//использует пул потоков для обработки каждой строки файла
        {
            var lines = File.ReadAllLines(_filePath); //считывает все строки из файла
            int totalLines = lines.Length; //Определение количества строк в файле
            for (int i = 0; i < totalLines; i++)
            {
                // Локальная переменная для замыкания,чтобы избежать проблем с изменением переменной i в разных потоках
                int localIndex = i;
                ThreadPool.QueueUserWorkItem(_ => ProcessLine(lines[localIndex], multiplier)); //добавляет задачу в пул потоков, где каждая строка обрабатывается методом ProcessLine
            }

            // Ожидание завершения всех потоков
            Thread.Sleep(1000);
        }


        public (int multiplied, int squared, long factorial, int fibonacci) ProcessLine(string line, int multiplier)
        {
            int number = int.Parse(line);
            // Для каждой строки выполняем различные операции
            int multiplied = number * multiplier;
            int squared = (int)Math.Pow(number, 2);
            long factorial = Factorial(number);
            int fibonacci = Fibonacci(number);

            // Возвращаем результаты как кортеж
            return (multiplied, squared, factorial, fibonacci);
        }


        public long Factorial(int n)// Факториал
        {
            if (n < 0) throw new ArgumentOutOfRangeException("n", "Факториал не определен для отрицательных чисел.");
            if (n == 0 || n == 1) return 1;
            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }


        public int Fibonacci(int n)//Фибоначчи
        {
            if (n < 0) throw new ArgumentOutOfRangeException("n", "Число Фибоначчи не определено для отрицательных чисел.");
            if (n == 0) return 0;
            if (n == 1) return 1;
            int a = 0, b = 1, c = 0;
            for (int i = 2; i <= n; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }
            return c;
        }
    }
}