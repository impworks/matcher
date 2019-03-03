using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Matcher.Cases.Pattern
{
    /// <summary>
    /// Helper class for creating node visitors.
    /// </summary>
    public static class Visitor
    {
        static Visitor()
        {
            var type = typeof(PatternExtensions);
            _arrayMethod = type.GetMethod(nameof(PatternExtensions.Array));
            _tupleMethod = type.GetMethod(nameof(PatternExtensions.Tuple));
            _varMethod = type.GetMethod(nameof(PatternExtensions.Var));
            _anyMethod = type.GetMethod(nameof(PatternExtensions.Any));
            _ofTypeMethod = type.GetMethod(nameof(PatternExtensions.OfType));
        }

        private static readonly MethodInfo _arrayMethod;
        private static readonly MethodInfo _tupleMethod;
        private static readonly MethodInfo _varMethod;
        private static readonly MethodInfo _anyMethod;
        private static readonly MethodInfo _ofTypeMethod;


        /// <summary>
        /// Creates a visitor for this node.
        /// </summary>
        public static IVisitor For(Expression expr)
        {
            if (expr.NodeType == ExpressionType.Constant)
                return new ConstantVisitor((ConstantExpression) expr);

            if (expr.NodeType == ExpressionType.Convert)
                return For((expr as UnaryExpression).Operand);

            if (expr.NodeType == ExpressionType.Call)
            {
                var callExpr = (MethodCallExpression) expr;
                if(callExpr.Method == _tupleMethod)
                    return new TupleVisitor(callExpr.Arguments[1] as NewArrayExpression);

                if(callExpr.Method == _arrayMethod)
                    return new ArrayVisitor(callExpr.Arguments[1] as NewArrayExpression);

                if(callExpr.Method == _varMethod)
                    return new VarVisitor(callExpr);

                if (callExpr.Method == _anyMethod)
                    return new AnyVisitor(callExpr);

                if (callExpr.Method.IsGenericMethod && callExpr.Method.GetGenericMethodDefinition() == _ofTypeMethod)
                    return new OfTypeVisitor(callExpr);
            }

            throw new ArgumentException("Unknown node type!");
        }
    }
}
