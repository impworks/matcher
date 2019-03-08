using System;

namespace Matcher.Cases
{
    /// <summary>
    /// Always returns the result for any value.
    /// </summary>
    public class DefaultMatchCase<TValue, TResult> : IMatchCase<TValue, TResult>
    {
        public DefaultMatchCase(Func<Option<TResult>> factory)
        {
            _factory = factory;
        }

        private readonly Func<Option<TResult>> _factory;

        public Option<TResult> Match(TValue value)
        {
            return _factory();
        }
    }
}
