using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Matcher.Cases
{
    /// <summary>
    /// Checks the sequence for at least a specific number of elements and then some.
    /// </summary>
    public class SeqRestMatchCase<TElem, TValue, TResult> : IMatchCase<TValue, TResult>
    {
        public SeqRestMatchCase(Delegate func)
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

            var args = new List<Expression>();
            using (var iter = seq.GetEnumerator())
            {
                for (var i = 0; i < expectedCount - 1; i++)
                {
                    if(!iter.MoveNext())
                        return Option.None<TResult>();

                    args.Add(Expression.Constant(iter.Current));
                }
            }

            var skip = typeof(Enumerable).GetMethod("Skip").MakeGenericMethod(typeof(TElem));
            args.Add(
                Expression.Call(null, skip, Expression.Constant(seq), Expression.Constant(expectedCount - 1))
            );

            return MatchCaseHelper.InvokeWithArgs<TResult>(_func, args);
        }
    }
}
