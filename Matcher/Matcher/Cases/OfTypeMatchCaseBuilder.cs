using System;

namespace Matcher.Cases
{
    /// <summary>
    /// Helper class for building an OfType case.
    /// </summary>
    public class OfTypeMatchCaseBuilder<TValue, TResult>
    {
        public OfTypeMatchCaseBuilder(IMatchContext<TValue, TResult> context)
        {
            _context = context;
        }

        private readonly IMatchContext<TValue, TResult> _context;

        /// <summary>
        /// Checks if the object can be cast to the specified type.
        /// </summary>
        public void Is<TNewType>(Func<TNewType, Option<TResult>> func)
        {
            _context.Case(new OfTypeMatchCase<TNewType, TValue, TResult>(false, func));
        }

        /// <summary>
        /// Checks if the object is exactly of the specified type.
        /// </summary>
        public void IsExactly<TNewType>(Func<TNewType, Option<TResult>> func)
        {
            _context.Case(new OfTypeMatchCase<TNewType, TValue, TResult>(true, func));
        }
    }
}
