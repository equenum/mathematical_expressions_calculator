using System;
using System.Collections.Generic;
using System.Text;

namespace MathematicalExpressionsCalculator.Library.Utilities
{
    public class UserInputCatcher : IUserInputCatcher
    {
        public string Capture()
        {
            return Console.ReadLine().Trim();
        }
    }
}
