using MathematicalExpressionsCalculator.Library.ExpressionHandling;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathematicalExpressionsCalculator.UnitTests
{
    [TestClass]
    public class Test_ConvertToPostfix
    {
        private readonly List<string> _operators = new List<string>() { "(", ")", "+", "-", "*", "/" };

        [DataRow("4*(5-(7+2))", "4572+-*")]
        [DataTestMethod]
        public void ConvertToPostfix_StringExpression_ArrayOfStringsPostfixExpression(string input, string expected)
        {
            // Act
            string result = string.Join("", NotationConverter.ConvertToPostfix(input, _operators));

            // Assert
            Assert.AreEqual(result, expected);
        }
    }
}
