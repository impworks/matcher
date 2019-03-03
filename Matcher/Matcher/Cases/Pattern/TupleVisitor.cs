using System.Linq.Expressions;

namespace Matcher.Cases.Pattern
{
    /// <summary>
    /// Visitor for Tuple() method invocation.
    /// </summary>
    public class TupleVisitor: Visitor<NewArrayExpression>
    {
        public TupleVisitor(NewArrayExpression expr) : base(expr)
        {
        }

        public override bool Visit(object obj, VisitorContext context)
        {
            if (obj == null)
                return false;

            var type = obj.GetType();
            if (!type.IsGenericType || !type.FullName.StartsWith("System.Tuple`") && !type.FullName.StartsWith("System.ValueTuple`"))
                return false;

            var elemCount = type.GetGenericArguments().Length;
            if (elemCount != _expr.Expressions.Count)
                return false;

            for (var i = 0; i < elemCount; i++)
            {
                var visitor = Visitor.For(_expr.Expressions[i]);
                var elem = type.IsValueType
                    ? type.GetField("Item" + (i + 1)).GetValue(obj)
                    : type.GetProperty("Item" + (i + 1)).GetValue(obj);
                if (!visitor.Visit(elem, context))
                    return false;
            }

            return true;
        }
    }
}
