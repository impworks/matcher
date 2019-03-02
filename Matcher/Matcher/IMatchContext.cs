using Matcher.Cases;

namespace Matcher
{
    /// <summary>
    /// The list of cases to match the value.
    /// </summary>
    public interface IMatchContext<TValue, TResult>
    {
        /// <summary>
        /// Adds a new case to the context.
        /// </summary>
        void Case(IMatchCase<TValue, TResult> c);
    }
}
