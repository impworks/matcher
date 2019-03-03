using System.Linq.Expressions;

namespace Matcher.Cases.Pattern
{
    /// <summary>
    /// Visitor for OfType[T]() method.
    /// </summary>
    public class OfTypeVisitor: Visitor<MethodCallExpression>
    {
        public OfTypeVisitor(MethodCallExpression expr) : base(expr)
        {
        }

        public override bool Visit(object obj, VisitorContext context)
        {
            if (obj == null)
                return false;

            var type = _expr.Method.GetGenericArguments()[0];
            var objType = obj.GetType();

            if (!type.IsAssignableFrom(objType))
                return false;

            return Visitor.For(_expr.Arguments[0]).Visit(obj, context);
        }
    }
}
