namespace Matcher.Cases.Pattern
{
    /// <summary>
    /// Visitor interface.
    /// </summary>
    public interface IVisitor
    {
        bool Visit(object obj, VisitorContext context);
    }

    /// <summary>
    /// Base class for all expression visitors.
    /// </summary>
    public abstract class Visitor<TExpr>: IVisitor
    {
        public Visitor(TExpr expr)
        {
            _expr = expr;
        }

        protected readonly TExpr _expr;

        /// <summary>
        /// Processes the current node.
        /// </summary>
        public abstract bool Visit(object obj, VisitorContext context);
    }
}
