namespace Matcher.Cases.Pattern
{
    /// <summary>
    /// Extension methods for pattern matching.
    /// </summary>
    public static class PatternExtensions
    {
        /// <summary>
        /// Defines a tuple template.
        /// </summary>
        public static object Tuple(this IPatternBuilder builder, params object[] elems) => null;

        /// <summary>
        /// Defines an array / sequence template.
        /// </summary>
        public static object Array(this IPatternBuilder builder, params object[] elems) => null;

        /// <summary>
        /// Defines a variable capture template.
        /// </summary>
        public static IPatternCapture Var(this IPatternBuilder builder, string name) => null;

        /// <summary>
        /// Defines a placeholder.
        /// </summary>
        public static IPatternCapture Any(this IPatternBuilder builder) => null;

        /// <summary>
        /// Checks the captured variable (or placeholder) to be of the specified type.
        /// </summary>
        public static object OfType<T>(this IPatternCapture capture) => null;
    }
}
