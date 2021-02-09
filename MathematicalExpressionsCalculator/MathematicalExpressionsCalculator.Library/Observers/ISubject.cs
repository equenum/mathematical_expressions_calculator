using System;
using System.Collections.Generic;
using System.Text;

namespace MathematicalExpressionsCalculator.Library.Observers
{
    /// <summary>
    /// Represents a subject interface.
    /// </summary>
    public interface ISubject
    {
        /// <summary>
        /// Attaches an observer to the subject.
        /// </summary>
        /// <param name="observer">Observer.</param>
        void Attach(IObserver observer);
        /// <summary>
        /// Detaches an observer of the subject.
        /// </summary>
        /// <param name="observer">Observer.</param>
        void Detach(IObserver observer);
        /// <summary>
        /// Notifies all of the observers of the subject state change.
        /// </summary>
        void Notify();
    }
}
