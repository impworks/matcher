using System;
using System.Collections.Concurrent;

namespace Matcher
{
    /// <summary>
    /// A wrapper for optional results.
    /// </summary>
    public class Option<T>
    {
        public Option()
        {
            HasValue = false;
        }

        public Option(T value)
        {
            _value = value;
            HasValue = true;
        }

        private readonly T _value;

        /// <summary>
        /// Returns true if the option has a value.
        /// Returns false if it is empty.
        /// </summary>
        public bool HasValue { get; }

        /// <summary>
        /// Gets the value of this option.
        /// Throws an <see cref="InvalidOperationException" /> if the option is empty.
        /// </summary>
        public T Value
        {
            get
            {
                if(!HasValue)
                    throw new InvalidOperationException("This option has no value!");
                return _value;
            }
        }

        /// <summary>
        /// Implicit conversion operator.
        /// </summary>
        public static implicit operator Option<T>(T value)
        {
            return new Option<T>(value);
        }
    }

    /// <summary>
    /// Helper class for constructing options.
    /// </summary>
    public class Option
    {
        /// <summary>
        /// Cache for empty options (since they are immutable).
        /// </summary>
        private static readonly ConcurrentDictionary<Type, object> _emptyOptions = new ConcurrentDictionary<Type, object>();

        /// <summary>
        /// Returns an option with a value.
        /// </summary>
        public static Option<T> Value<T>(T value) => new Option<T>(value);

        /// <summary>
        /// Returns an empty option.
        /// </summary>
        public static Option<T> None<T>() => (Option<T>) _emptyOptions.GetOrAdd(typeof(T), t => new Option<T>());

        /// <summary>
        /// Return an option depending on the condition.
        /// </summary>
        public static Option<T> When<T>(bool condition, T value) => condition ? Value(value) : None<T>();

        /// <summary>
        /// Return an option depending on the condition.
        /// </summary>
        public static Option<T> When<T>(bool condition, Func<T> valueFunc) => condition ? Value(valueFunc()) : None<T>();
    }
}
