using MathematicalExpressionsCalculator.Library.Observers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathematicalExpressionsCalculator.UnitTests
{
    [TestClass]
    public class Test_Calculate
    {
        [DataRow("2+15/3+4*2", "15")]
        [DataRow("1+2*(3+2)", "11")]
        [DataTestMethod]
        public void Calculate_StringExpression_StringResult(string input, string expected)
        {
            // Arrange
            var expression = new ExpressionSubject(input);

            // Act
            string result = expression.Calculate();

            // Assert
            Assert.AreEqual(result, expected);
        }
    }
}
