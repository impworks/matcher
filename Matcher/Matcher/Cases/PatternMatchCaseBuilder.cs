using System;
using System.Linq.Expressions;
using Matcher.Cases.Pattern;

namespace Matcher.Cases
{
    /// <summary>
    /// Helper class for mapping a matched pattern patterns.
    /// </summary>
    public class PatternMatchCaseBuilder<TValue, TResult>
    {
        public PatternMatchCaseBuilder(IMatchContext<TValue, TResult> context, Expression<Func<IPatternBuilder, object>> expr)
        {
            _context = context;
            _expr = expr;
        }

        private readonly IMatchContext<TValue, TResult> _context;
        private readonly Expression<Func<IPatternBuilder, object>> _expr;

        /// <summary>
        /// Maps the pattern to a static result.
        /// </summary>
        public void Map(TResult result)
        {
            Map(() => result);
        }

        /// <summary>
        /// Maps the pattern to a factory.
        /// </summary>
        public void Map(Func<Option<TResult>> func)
        {
            _context.Case(new PatternMatchCase<TValue, TResult>(_expr, func));
        }

        /// <summary>
        /// Maps the pattern to a factory using the captured variables.
        /// </summary>
        public void Map<T1>(Func<T1, Option<TResult>> func)
        {
            _context.Case(new PatternMatchCase<TValue, TResult>(_expr, func));
        }

        /// <summary>
        /// Maps the pattern to a factory using the captured variables.
        /// </summary>
        public void Map<T1, T2>(Func<T1, T2, Option<TResult>> func)
        {
            _context.Case(new PatternMatchCase<TValue, TResult>(_expr, func));
        }

        /// <summary>
        /// Maps the pattern to a factory using the captured variables.
        /// </summary>
        public void Map<T1, T2, T3>(Func<T1, T2, T3, Option<TResult>> func)
        {
            _context.Case(new PatternMatchCase<TValue, TResult>(_expr, func));
        }

        /// <summary>
        /// Maps the pattern to a factory using the captured variables.
        /// </summary>
        public void Map<T1, T2, T3, T4>(Func<T1, T2, T3, T4, Option<TResult>> func)
        {
            _context.Case(new PatternMatchCase<TValue, TResult>(_expr, func));
        }

        /// <summary>
        /// Maps the pattern to a factory using the captured variables.
        /// </summary>
        public void Map<T1, T2, T3, T4, T5>(Func<T1, T2, T3, T4, T5, Option<TResult>> func)
        {
            _context.Case(new PatternMatchCase<TValue, TResult>(_expr, func));
        }

        /// <summary>
        /// Maps the pattern to a factory using the captured variables.
        /// </summary>
        public void Map<T1, T2, T3, T4, T5, T6>(Func<T1, T2, T3, T4, T5, T6, Option<TResult>> func)
        {
            _context.Case(new PatternMatchCase<TValue, TResult>(_expr, func));
        }

        /// <summary>
        /// Maps the pattern to a factory using the captured variables.
        /// </summary>
        public void Map<T1, T2, T3, T4, T5, T6, T7>(Func<T1, T2, T3, T4, T5, T6, T7, Option<TResult>> func)
        {
            _context.Case(new PatternMatchCase<TValue, TResult>(_expr, func));
        }

        /// <summary>
        /// Maps the pattern to a factory using the captured variables.
        /// </summary>
        public void Map<T1, T2, T3, T4, T5, T6, T7, T8>(Func<T1, T2, T3, T4, T5, T6, T7, T8, Option<TResult>> func)
        {
            _context.Case(new PatternMatchCase<TValue, TResult>(_expr, func));
        }

        /// <summary>
        /// Maps the pattern to a factory using the captured variables.
        /// </summary>
        public void Map<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Option<TResult>> func)
        {
            _context.Case(new PatternMatchCase<TValue, TResult>(_expr, func));
        }

        /// <summary>
        /// Maps the pattern to a factory using the captured variables.
        /// </summary>
        public void Map<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Option<TResult>> func)
        {
            _context.Case(new PatternMatchCase<TValue, TResult>(_expr, func));
        }
    }
}
