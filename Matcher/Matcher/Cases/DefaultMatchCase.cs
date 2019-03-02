using System;

namespace Matcher.Cases
{
    /// <summary>
    /// Always returns the result for any value.
    /// </summary>
    public class DefaultMatchCase<TValue, TResult> : IMatchCase<TValue, TResult>
    {
        public DefaultMatchCase(Func<TResult> factory)
        {
            _factory = factory;
        }

        private readonly Func<TResult> _factory;

        public Option<TResult> Match(TValue value)
        {
            return Option.Value(_factory());
        }
    }
}
