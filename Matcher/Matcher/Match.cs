using System;

namespace Matcher
{
    /// <summary>
    /// Matcher root class.
    /// </summary>
    public static class Match
    {
        /// <summary>
        /// Creates a matcher for the specified value.
        /// </summary>
        public static Match<T> Value<T>(T value) => new Match<T>(value);
    }

    /// <summary>
    /// Match without a result type.
    /// </summary>
    public class Match<TValue>
    {
        public Match(TValue value)
        {
            _value = value;
        }

        protected readonly TValue _value;

        /// <summary>
        /// Creates a matcher with a typed return value.
        /// </summary>
        public Match<TValue, TResult> AndReturn<TResult>() => new Match<TValue, TResult>(_value);
    }

    /// <summary>
    /// Match with a result type.
    /// </summary>
    public class Match<TValue, TResult> : Match<TValue>
    {
        public Match(TValue value)
            : base(value)
        {
        }

        /// <summary>
        /// Matches the cases against the values and returns a result.
        /// </summary>
        public TResult With(Action<IMatchContext<TValue, TResult>> act)
        {
            var context = new MatchContext<TValue, TResult>();
            act(context);
            return context.Process(_value);
        }
    }
}
