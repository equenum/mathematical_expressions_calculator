using MathematicalExpressionsCalculator.Library.Observers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MathematicalExpressionsCalculator.Library.Repositories
{
    public class FileRepository : IFileRepository
    {
        private string _inputFilePath;
        private string _outputFilePath;
        private List<IExpressionSubject> _store = new List<IExpressionSubject>();

        public void Add()
        {
            using var output = new StreamWriter(_outputFilePath);

            foreach (IExpressionSubject element in _store)
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

            Console.WriteLine($"Result has been written to output file ({_outputFilePath}).");
        }

        public List<IExpressionSubject> Get()
        {
            string[] lines = File.ReadAllLines(_inputFilePath);

            foreach (string line in lines)
            {
                _store.Add(new ExpressionSubject(line.Trim()));
            }

            return _store;
        }

        public void SetInputFilePath(string inputFilePath)
        {
            _inputFilePath = inputFilePath;
            _outputFilePath = @Path.GetDirectoryName(_inputFilePath) + @"\output.txt";
        }
    }
}
