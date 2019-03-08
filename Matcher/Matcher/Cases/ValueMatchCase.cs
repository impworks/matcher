using System;

namespace Matcher.Cases
{
    /// <summary>
    /// Matches the case against a particular value.
    /// </summary>
    public class ValueMatchCase<TValue, TResult> : IMatchCase<TValue, TResult>
    {
        public ValueMatchCase(TValue value, Func<Option<TResult>> factory)
        {
            _value = value;
            _factory = factory;
        }

        private readonly TValue _value;
        private readonly Func<Option<TResult>> _factory;

        public Option<TResult> Match(TValue value)
        {
            if (value is IEquatable<TValue> eqv && eqv.Equals(_value))
                return _factory();

            if (value == null && _value == null)
                return _factory();

            if (value != null && value.Equals(_value))
                return _factory();

            return Option.None<TResult>();
        }
    }
}
