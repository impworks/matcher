using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Matcher.Cases
{
    /// <summary>
    /// Applies a regular expression to a string.
    /// </summary>
    public class RegexMatchCase<TResult>: IMatchCase<string, TResult>
    {
        public RegexMatchCase(Regex regex, Delegate func)
        {
            _regex = regex;
            _func = func;
        }

        private readonly Regex _regex;
        private readonly Delegate _func;

        public Option<TResult> Match(string value)
        {
            var match = _regex.Match(value);
            if (!match.Success)
                return Option.None<TResult>();

            var argCount = _func.Method.GetParameters().Length;
            if (argCount > match.Groups.Count)
                return Option.None<TResult>();

            var argExprs = Enumerable.Range(0, argCount).Select(x => Expression.Constant(match.Groups[x].Value));
            return MatchCaseHelper.InvokeWithArgs<TResult>(_func, argExprs);
        }
    }
}
