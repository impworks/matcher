namespace Matcher.Cases
{
    /// <summary>
    /// A single case to be tested.
    /// </summary>
    public interface IMatchCase<in TValue, TResult>
    {
        /// <summary>
        /// Tests the value for matching this case.
        /// </summary>
        Option<TResult> Match(TValue value);
    }
}
