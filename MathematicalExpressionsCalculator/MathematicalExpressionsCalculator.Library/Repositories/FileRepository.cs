using MathematicalExpressionsCalculator.Library.Observers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MathematicalExpressionsCalculator.Library.Repositories
{
    public class FileRepository : IRepository<IExpressionSubject>
    {
        private readonly string _inputFilePath;

        public string OutputFilePath { get; set; }

        public FileRepository(string inputFilePath)
        {
            _inputFilePath = inputFilePath;
            OutputFilePath = @Path.GetDirectoryName(_inputFilePath) + @"\output.txt";
        }

        public List<IExpressionSubject> Store { get; set; } = new List<IExpressionSubject>();

        public void Add()
        {
            using var output = new StreamWriter(OutputFilePath);

            foreach (IExpressionSubject element in Store)
            {
                if (double.TryParse(element.Result, out _))
                {
                    output.WriteLine(String.Format("Result: {0} = {1:0.##}", string.Join("", element.InfixNotationValue), double.Parse(element.Result)));
                }
                else
                {
                    output.WriteLine($"{string.Join("", element.InfixNotationValue)} = {element.Result}");
                }
            }

            Console.WriteLine($"Result has been written to output file ({OutputFilePath}).");
        }

        public List<IExpressionSubject> Get()
        {
            string[] lines = File.ReadAllLines(_inputFilePath);

            foreach (string line in lines)
            {
                Store.Add(new ExpressionSubject(line.Trim()));
            }

            return Store;
        }
    }
}
