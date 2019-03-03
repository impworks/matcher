using System.Linq.Expressions;

namespace Matcher.Cases.Pattern
{
    /// <summary>
    /// Visitor for matching a constant.
    /// </summary>
    public class ConstantVisitor: Visitor<ConstantExpression>
    {
        public ConstantVisitor(ConstantExpression expr)
            : base(expr)
        {
        }

        public override bool Visit(object obj, VisitorContext context)
        {
            if (_expr.Value == null && obj == null)
                return true;

            if (_expr.Value == null || obj == null)
                return false;

            return _expr.Value.Equals(obj);
        }
    }
}
