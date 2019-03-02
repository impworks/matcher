using System;
using System.Collections.Generic;
using System.Linq;
using Matcher.Cases;

namespace Matcher
{
    /// <summary>
    /// The context for a single value match.
    /// </summary>
    public class MatchContext<TValue, TResult>: IMatchContext<TValue, TResult>
    {
        public MatchContext()
        {
            _cases = new List<IMatchCase<TValue, TResult>>();
        }

        private readonly List<IMatchCase<TValue, TResult>> _cases;

        /// <summary>
        /// Adds a new case to the context.
        /// </summary>
        public void Case(IMatchCase<TValue, TResult> c)
        {
            _cases.Add(c);
        }

        /// <summary>
        /// Tests all cases for the value.
        /// </summary>
        public TResult Process(TValue value)
        {
            foreach (var c in _cases)
            {
                var caseResult = c.Match(value);
                if (caseResult.HasValue)
                    return caseResult.Value;
            }

            throw new MatchFailedException(value);
        }
    }
}
