using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MathematicalExpressionsCalculator.Library.Validation
{
    /// <summary>
    /// Represents a file validator.
    /// </summary>
    public class FileValidator : IFileValidator
    {
        public string FilePath { get; set; }

        public bool Validate()
        {
            return File.Exists(FilePath) && Path.GetExtension(FilePath) != "txt";
        }
    }
}
