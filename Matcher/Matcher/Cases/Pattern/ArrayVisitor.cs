using System.Linq.Expressions;

namespace Matcher.Cases.Pattern
{
    /// <summary>
    /// Visitor for Array() method.
    /// </summary>
    public class ArrayVisitor: Visitor<NewArrayExpression>
    {

        public ArrayVisitor(NewArrayExpression expr) : base(expr)
        {
        }

        public override bool Visit(object obj, VisitorContext context)
        {
            if (obj == null)
                return false;

            var type = obj.GetType();
            if (!type.IsArray)
                return false;

            var length = (int) type.GetProperty("Length").GetValue(obj);
            var elemGetter = type.GetMethod("Get");

            if (_expr.Expressions.Count != length)
                return false;

            for (var i = 0; i < length; i++)
            {
                var elem = elemGetter.Invoke(obj, new object[] {i});
                var visitor = Visitor.For(_expr.Expressions[i]);
                if (!visitor.Visit(elem, context))
                    return false;
            }

            return true;
        }
    }
}
