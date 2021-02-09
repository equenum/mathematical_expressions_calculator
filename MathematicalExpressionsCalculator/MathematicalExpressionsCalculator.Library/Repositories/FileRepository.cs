using MathematicalExpressionsCalculator.Library.Observers;
using MathematicalExpressionsCalculator.Library.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MathematicalExpressionsCalculator.Library.Repositories
{
    /// <summary>
    /// Represent a file repository.
    /// </summary>
    public class FileRepository : IFileRepository
    {
        private readonly IConsoleMessenger _consoleMessenger;

        private string _inputFilePath;
        private string _outputFilePath;
        private List<IExpressionSubject> _store = new List<IExpressionSubject>();

        public FileRepository(IConsoleMessenger consoleMessenger)
        {
            _consoleMessenger = consoleMessenger;
        }

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

            _consoleMessenger.FileRepoResultMessage(_outputFilePath);
        }

        public List<IExpressionSubject> Get()
        {
            string[] lines = File.ReadAllLines(_inputFilePath);

            foreach (string line in lines)
            {
                IExpressionSubject expression = Factory.CreateExpressionSubject(line.Trim());
                _store.Add(expression);
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
