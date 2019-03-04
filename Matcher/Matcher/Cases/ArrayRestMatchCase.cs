using System;
using System.Linq;
using System.Linq.Expressions;

namespace Matcher.Cases
{
    /// <summary>
    /// Checks the array for at least a given number of elements and then some.
    /// </summary>
    public class ArrayRestMatchCase<TElem, TValue, TResult> : IMatchCase<TValue, TResult>
    {
        public ArrayRestMatchCase(Delegate func)
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

            if (actualCount < expectedCount - 1)
                return Option.None<TResult>();

            var skip = typeof(Enumerable).GetMethod("Skip").MakeGenericMethod(typeof(TElem));
            var toArray = typeof(Enumerable).GetMethod("ToArray").MakeGenericMethod(typeof(TElem));

            var argExprs = arr.Take(expectedCount - 1).Select(x => Expression.Constant(x)).Cast<Expression>().ToList();
            argExprs.Add(
                Expression.Call(
                    null,
                    toArray,
                    Expression.Call(null, skip, Expression.Constant(arr), Expression.Constant(expectedCount - 1))
                )
            );

            return MatchCaseHelper.InvokeWithArgs<TResult>(_func, argExprs);
        }
    }
}
