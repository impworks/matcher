using System;
using System.Linq;
using System.Linq.Expressions;

namespace Matcher.Cases
{
    /// <summary>
    /// Destructs the tuple into values.
    /// </summary>
    public class TupleMatchCase<TValue, TResult>: IMatchCase<TValue, TResult>
    {
        public TupleMatchCase(Delegate d)
        {
            _delegate = d;
        }

        private readonly Delegate _delegate;

        public Option<TResult> Match(TValue value)
        {
            var type = typeof(TValue);

            if (value == null || !type.IsGenericType)
                return Option.None<TResult>();

            var typeName = type.GetGenericTypeDefinition().FullName;
            if (!typeName.StartsWith("System.Tuple`") && !typeName.StartsWith("System.ValueTuple`"))
                return Option.None<TResult>();

            var argCount = _delegate.Method.GetParameters().Length;
            var valueCount = type.GetGenericArguments().Length;

            if (argCount != valueCount)
                return Option.None<TResult>();

            var tupleExpr = Expression.Constant(value);
            var argExprs = Enumerable.Range(1, argCount).Select(x => Expression.PropertyOrField(tupleExpr, "Item" + x));

            var callExpr = Expression.Call(Expression.Constant(_delegate.Target), _delegate.Method, argExprs);
            var lambdaExpr = Expression.Lambda(callExpr);
            var result = lambdaExpr.Compile().DynamicInvoke();

            return Option.Value((TResult)result);
        }
    }
}
