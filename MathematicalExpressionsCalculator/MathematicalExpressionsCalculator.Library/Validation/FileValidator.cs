using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MathematicalExpressionsCalculator.Library.Validation
{
    public class FileValidator
    {
        private readonly string _filePath;

        public FileValidator(string filePath)
        {
            _filePath = filePath;
        }

        public bool Validate()
        {
            return File.Exists(_filePath) && Path.GetExtension(_filePath) != "txt";
        }
    }
}
