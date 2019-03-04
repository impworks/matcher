using System;
using System.Linq;
using System.Linq.Expressions;

namespace Matcher.Cases
{
    /// <summary>
    /// Checks the array for a given number of elements.
    /// </summary>
    public class ArrayMatchCase<TElem, TValue, TResult> : IMatchCase<TValue, TResult>
    {
        public ArrayMatchCase(Delegate func)
        {
            _func = func;
        }

        private readonly Delegate _func;

        public Option<TResult> Match(TValue value)
        {
            if (value == null)
                return Option.None<TResult>();

            var arr = (TElem[])(object)value;
            var actualCount = arr.Length;
            var expectedCount = _func.Method.GetParameters().Length;

            if (actualCount != expectedCount)
                return Option.None<TResult>();

            var args = arr.Select(x => Expression.Constant(x));
            return MatchCaseHelper.InvokeWithArgs<TResult>(_func, args);
        }
    }
}
