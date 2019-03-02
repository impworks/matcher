using System;

namespace Matcher
{
    /// <summary>
    /// Exception that is thrown when no case matches the value.
    /// </summary>
    public class MatchFailedException: Exception
    {
        public MatchFailedException(object value)
            : this(value, "None of the cases matched the value!")
        {
        }

        public MatchFailedException(object value, string message) : base(message)
        {
            OriginalValue = value;
        }

        /// <summary>
        /// Value that was tested for matching cases.
        /// </summary>
        public object OriginalValue { get; }
    }
}
