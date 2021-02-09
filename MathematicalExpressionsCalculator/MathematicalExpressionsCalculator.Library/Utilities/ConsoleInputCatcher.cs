using System;
using System.Collections.Generic;
using System.Text;

namespace MathematicalExpressionsCalculator.Library.Utilities
{
    /// <summary>
    /// Represents a console user input catcher.
    /// </summary>
    public class ConsoleInputCatcher : IInputCatcher
    {
        public string Capture()
        {
            return Console.ReadLine().Trim();
        }
    }
}
