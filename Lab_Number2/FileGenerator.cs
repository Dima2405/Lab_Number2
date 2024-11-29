using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lab_Number2
{
    public class FileGenerator
    {
        public void GenerateFile(string filePath, int N)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = 1; i <= N; i++)
                {
                    writer.WriteLine(i);
                }

            }

        }

    }
}