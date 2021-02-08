using MathematicalExpressionsCalculator.Library.ExpressionHandling;
using MathematicalExpressionsCalculator.Library.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathematicalExpressionsCalculator.Library.Observers
{
    public class ExpressionSubject : IExpressionSubject
    {
        private readonly List<string> _operators = new List<string>() { "(", ")", "+", "-", "*", "/" };
        private readonly List<IObserver> _observers = new List<IObserver>();

        public string[] InfixNotationValue { get; }

        public string[] PostfixNotationValue { get; private set; }

        public Stack<string> Stack { get; set; } = new Stack<string>();

        public double A { get; set; } = 0;

        public double B { get; set; } = 0;

        public string Result { get; private set; } = "Error in expression!";

        public ExpressionSubjectState State { get; private set; } = ExpressionSubjectState.Default;

        public ExpressionSubject(string input)
        {
            InfixNotationValue = input.ToCharArray().Select(c => c.ToString()).ToArray();

            this.Attach(new DivisionObserver());
            this.Attach(new MultiplicationObserver());
            this.Attach(new AdditionObserver());
            this.Attach(new SubtractionObserver());
        }

        public string Calculate()
        {
            if (new ExpressionValidator(string.Join("", InfixNotationValue)).Validate()) // TODO - Dependency injection
            {
                PostfixNotationValue = NotationConverter.ConvertToPostfix(string.Join("", InfixNotationValue), _operators);

                foreach (var item in PostfixNotationValue)
                {
                    if (_operators.Contains(item))
                    {
                        B = double.Parse(Stack.Pop());
                        A = double.Parse(Stack.Pop());

                        if (item == "/")
                        {
                            State = ExpressionSubjectState.Division;
                            this.Notify();
                        }
                        else if (item == "*")
                        {
                            State = ExpressionSubjectState.Multiplication;
                            this.Notify();
                        }
                        else if (item == "+")
                        {
                            State = ExpressionSubjectState.Addition;
                            this.Notify();
                        }
                        else if (item == "-")
                        {
                            State = ExpressionSubjectState.Subtraction;
                            this.Notify();
                        }
                    }
                    else
                    {
                        Stack.Push(item);
                    }
                }

                return Result = Stack.Pop();
            }
            else
            {
                return Result;
            }
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }
    }
}
