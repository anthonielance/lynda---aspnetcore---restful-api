using System;
using System.Linq.Expressions;

namespace LandonAPI.Infrastructure
{
    public class DefaultSearchExpressionProvider : ISearchExpressionProvider
    {
        public virtual Expression GetComparison(MemberExpression left, string op, ConstantExpression right)
        {
            if (!op.Equals("eq", StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException($"Invalid operator '{op}'.");

            return Expression.Equal(left, right);
        }

        public virtual ConstantExpression GetValue(string input)
            => Expression.Constant(input);
    }
}
