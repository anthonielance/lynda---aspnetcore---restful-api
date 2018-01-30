using System.Linq.Expressions;

namespace LandonAPI.Infrastructure
{
    public interface ISearchExpressionProvider
    {
        ConstantExpression GetValue(string input);
        Expression GetComparison(MemberExpression left, string op, ConstantExpression right);
    }
}
