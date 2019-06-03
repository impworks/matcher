using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Matcher.Cases
{
    /// <summary>
    /// Checks the sequence for a specific number of elements.
    /// </summary>
    public class SeqMatchCase<TElem, TValue, TResult> : IMatchCase<TValue, TResult>
    {
        public SeqMatchCase(Delegate func)
        {
            _func = func;
        }

        private readonly Delegate _func;

        public Option<TResult> Match(TValue value)
        {
            if (value == null)
                return Option.None<TResult>();

            var seq = (IEnumerable<TElem>)value;
            var expectedCount = _func.Method.GetParameters().Length;

            var args = new List<ConstantExpression>();
            foreach (var elem in seq)
            {
                args.Add(Expression.Constant(elem));
                if(args.Count > expectedCount)
                    return Option.None<TResult>();
            }

            if(args.Count < expectedCount)
                return Option.None<TResult>();

            return MatchCaseHelper.InvokeWithArgs<TResult>(_func, args);
        }
    }
}
