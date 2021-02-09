using MathematicalExpressionsCalculator.Library.Observers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathematicalExpressionsCalculator.Library.Repositories
{
    public class ConsoleRepository : IConsoleRepository
    {
        private readonly IConsoleMessenger _consoleMessenger;

        private List<IExpressionSubject> _store = new List<IExpressionSubject>();

        public ConsoleRepository(IConsoleMessenger consoleMessenger)
        {
            _consoleMessenger = consoleMessenger;
        }

        public void Add()
        {
            foreach (IExpressionSubject expression in _store)
            {
                if (double.TryParse(expression.Result, out _))
                {
                    _consoleMessenger.ConsoleRepoDoubleResultMessage(expression.InfixNotationValue, expression.Result);
                }
                else
                {
                    _consoleMessenger.ConsoleRepoIntegerResultMessage(expression.InfixNotationValue, expression.Result);
                }
            }
        }

        public List<IExpressionSubject> Get()
        {
            return _store;
        }

        public void AddExpression(string userInput)
        {
            _store.Add(new ExpressionSubject(userInput));
        }
    }
}
