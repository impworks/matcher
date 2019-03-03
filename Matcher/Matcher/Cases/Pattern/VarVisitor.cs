using System;
using System.Linq.Expressions;

namespace Matcher.Cases.Pattern
{
    /// <summary>
    /// Visitor for Var() method. 
    /// </summary>
    public class VarVisitor: Visitor<MethodCallExpression>
    {
        public VarVisitor(MethodCallExpression expr) : base(expr)
        {
        }

        public override bool Visit(object obj, VisitorContext context)
        {
            var nameExpr = _expr.Arguments[1] as ConstantExpression;
            var name = nameExpr.Value as string;

            if(context.CapturedObjects.ContainsKey(name))
                throw new ArgumentException($"Name '{name}' is already registered in the pattern!");

            context.CapturedObjects[name] = obj;

            return true;
        }
    }
}
