using System;
using System.IO;
using System.Globalization;

namespace Secao13
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = @"C:\Users\RODRIGO\OneDrive\Documentos\Projetos\workspaces\ws-vs2019\Secao13\work\items.csv";
            string targetPath = @"C:\Users\RODRIGO\OneDrive\Documentos\Projetos\workspaces\ws-vs2019\Secao13\work\out\summary.csv";

            try
            {
                string[] lines = File.ReadAllLines(sourcePath);

                using (StreamWriter sw = File.AppendText(targetPath))
                {
                    foreach (string line in lines)
                    {
                        string[] fields = line.Split(',');

                        string name = fields[0];
                        double price = double.Parse(fields[1], CultureInfo.InvariantCulture);
                        int quantity = int.Parse(fields[2]);

                        double totalValue = price * quantity;

                        sw.WriteLine(name + "," + totalValue.ToString("F2", CultureInfo.InvariantCulture));
                    }
                }

                Console.WriteLine("File created!");
            }
            catch (IOException e)
            {
                Console.WriteLine("An error ocurred!");
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected error!");
                Console.WriteLine(e.Message);
            }
        }
    }
}
