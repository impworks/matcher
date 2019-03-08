using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Matcher.Cases.Pattern
{
    /// <summary>
    /// Applies a full pattern to the object.
    /// </summary>
    public class PatternMatchCase<TValue, TResult>: IMatchCase<TValue, TResult>
    {
        public PatternMatchCase(Expression<Func<IPatternBuilder, object>> expr, Delegate func)
        {
            _expr = expr;
            _func = func;
        }

        private readonly Expression<Func<IPatternBuilder, object>> _expr;
        private readonly Delegate _func;

        public Option<TResult> Match(TValue value)
        {
            var context = new VisitorContext();
            var isMatch = Visitor.For(_expr.Body).Visit(value, context);
            if (!isMatch)
                return Option.None<TResult>();

            var argExprs = new List<Expression>();
            foreach (var arg in _func.Method.GetParameters())
            {
                if(!context.CapturedObjects.TryGetValue(arg.Name, out var argValue))
                    throw new ArgumentException($"No value was captured for argument '{arg.Name}'!");

                var argType = arg.ParameterType;
                if (argValue == null)
                {
                    if (argType.IsValueType)
                    {
                        if(!argType.IsGenericType || argType.GetGenericTypeDefinition() != typeof(Nullable<>))
                            throw new ArgumentException($"Value for argument '{arg.Name}' must be {argType.Name}, found null!");
                    }
                }
                else
                {
                    var valueType = argValue.GetType();
                    if(!argType.IsAssignableFrom(valueType))
                        throw new ArgumentException($"Value for argument '{arg.Name}' must be {argType.Name}, found {valueType.Name}!");
                }

                argExprs.Add(Expression.Constant(argValue));
            }

            var callExpr = Expression.Call(Expression.Constant(_func.Target), _func.Method, argExprs);
            var lambdaExpr = Expression.Lambda(callExpr);
            var result = lambdaExpr.Compile().DynamicInvoke();

            return (Option<TResult>) result;
        }
    }
}
