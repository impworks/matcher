using System.Linq.Expressions;

namespace Matcher.Cases.Pattern
{
    /// <summary>
    /// Visitor for Any() method. 
    /// </summary>
    public class AnyVisitor : Visitor<MethodCallExpression>
    {
        public AnyVisitor(MethodCallExpression expr) : base(expr)
        {
        }

        public override bool Visit(object obj, VisitorContext context)
        {
            return true;
        }
    }
}
