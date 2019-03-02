using System;

namespace Matcher.Cases
{
    /// <summary>
    /// Binds the value to a new name.
    /// </summary>
    public class DefaultBindMatchCase<TValue, TResult> : IMatchCase<TValue, TResult>
    {
        public DefaultBindMatchCase(Func<TValue, TResult> factory)
        {
            _factory = factory;
        }

        private readonly Func<TValue, TResult> _factory;

        public Option<TResult> Match(TValue value)
        {
            return Option.Value(_factory(value));
        }
    }
}
