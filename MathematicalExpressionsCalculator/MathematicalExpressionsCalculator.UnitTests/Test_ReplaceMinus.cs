using MathematicalExpressionsCalculator.Library.ExpressionHandling;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathematicalExpressionsCalculator.UnitTests
{
    [TestClass]
    public class Test_ReplaceMinus
    {
        private readonly List<string> _operators = new List<string>() { "(", ")", "+", "-", "*", "/" };

        [DataRow("-2+-10*-5/-6", "(0-2)+(0-10)*(0-5)/(0-6)")]
        [DataTestMethod]
        public void ReplaceMinus_ExpressionWithNegativeArguments_ExpressionWithoutNegativeArguments(string expression, string expected)
        {
            // Act
            string result = MinusReplacer.ReplaceMinus(expression, _operators);

            // Assert
            Assert.AreEqual(result, expected);
        }
    }
}
