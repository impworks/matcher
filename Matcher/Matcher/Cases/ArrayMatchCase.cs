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
        public ArrayMatchCase(Delegate d)
        {
            _delegate = d;
        }

        private readonly Delegate _delegate;

        public Option<TResult> Match(TValue value)
        {
            if (value == null)
                return Option.None<TResult>();

            var arr = (TElem[])(object)value;
            var actualCount = arr.Length;
            var expectedCount = _delegate.Method.GetParameters().Length;

            if (actualCount != expectedCount)
                return Option.None<TResult>();

            var callExpr = Expression.Call(Expression.Constant(_delegate.Target), _delegate.Method, arr.Select(x => Expression.Constant(x)).ToArray());
            var lambdaExpr = Expression.Lambda(callExpr);
            var result = lambdaExpr.Compile().DynamicInvoke();

            return Option.Value((TResult)result);
        }
    }
}
