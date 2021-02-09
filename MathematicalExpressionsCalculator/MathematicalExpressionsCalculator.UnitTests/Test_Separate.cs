using MathematicalExpressionsCalculator.Library.ExpressionHandling;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathematicalExpressionsCalculator.UnitTests
{
    [TestClass]
    public class Test_Separate
    {
        private readonly List<string> _operators = new List<string>() { "(", ")", "+", "-", "*", "/" };

        [DataRow("45+25+65", "25")]
        [DataRow("45+2.55+65", "2.55")]
        [DataRow("1+2+3", "2")]
        [DataTestMethod]
        public void Separate_StringExpression_IEnumerableSeparatedStringExpression(string input, string expected)
        {
            // Arrange
            string[] resultArray = new string[5];
            int i = 0;

            // Act
            foreach (string element in ExpressionSeparator.Separate(input.Trim(), _operators))
            {
                resultArray[i] = element;
                i++;
            }

            string result = resultArray[2];

            // Assert
            Assert.AreEqual(result, expected);
        }
    }
}
