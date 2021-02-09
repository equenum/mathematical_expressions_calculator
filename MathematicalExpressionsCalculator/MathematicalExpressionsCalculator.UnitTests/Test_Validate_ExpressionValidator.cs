using MathematicalExpressionsCalculator.Library.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathematicalExpressionsCalculator.UnitTests
{
    [TestClass]
    public class Test_Validate_ExpressionValidator
    {
        [DataRow("2^2", false)]
        [DataRow("one plus one", false)]
        [DataRow("123", false)]
        [DataRow("2/0", false)]
        [DataRow("-10+20", true)]
        [DataRow("2+15/3+4*2", true)]
        [DataTestMethod]
        public void Validate_StringExpression_TrueOrFalse(string input, bool expected)
        {
            // Arrange
            var expression = new ExpressionValidator();
            expression.Expression = input;

            // Act
            bool result = expression.Validate();

            // Assert
            Assert.AreEqual(result, expected);
        }
    }
}
