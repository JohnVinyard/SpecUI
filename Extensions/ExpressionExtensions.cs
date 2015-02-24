using System;
using System.Linq.Expressions;

namespace SpecUI.Extensions
{
    public static class ExpressionExtensions
    {
        public static string GetName<T>(this Expression<Func<T>> exp) {
            var body = exp.Body as MemberExpression;

            if (body == null) {
                var ubody = (UnaryExpression)exp.Body;
                body = ubody.Operand as MemberExpression;
            }

            return body.Member.Name;
        }
    }
}