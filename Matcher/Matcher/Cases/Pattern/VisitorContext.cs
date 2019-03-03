using System.Collections.Generic;

namespace Matcher.Cases.Pattern
{
    /// <summary>
    /// Capture context for visiting a pattern node.
    /// </summary>
    public class VisitorContext
    {
        /// <summary>
        /// The list of objects captured by names in the pattern.
        /// </summary>
        public Dictionary<string, object> CapturedObjects { get; } = new Dictionary<string, object>();
    }
}
