using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Matcher.Cases
{
    internal static class MatchCaseHelper
    {
        /// <summary>
        /// Passes arguments to the delegate and returns its result.
        /// </summary>
        public static Option<T> InvokeWithArgs<T>(Delegate func, IEnumerable<Expression> args)
        {
            var callExpr = Expression.Call(Expression.Constant(func.Target), func.Method, args);
            var lambdaExpr = Expression.Lambda(callExpr);
            var result = lambdaExpr.Compile().DynamicInvoke();

            return Option.Value((T)result);
        }
    }
}
