using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace LandonAPI.Infrastructure
{
    public static class ExpressionHelper
    {
        private static readonly MethodInfo LambdaMethod = typeof(Expression)
            .GetMethods()
            .First(x => x.Name == "Lambda" && x.ContainsGenericParameters && x.GetParameters().Length == 2);

        private static MethodInfo[] QueryableMethods = typeof(Queryable)
            .GetMethods()
            .ToArray();

        private static MethodInfo GetLambdaFuncBuilder(Type source, Type destination)
        {
            var predicateType = typeof(Func<,>).MakeGenericType(source, destination);
            return LambdaMethod.MakeGenericMethod(predicateType);
        }

        public static PropertyInfo GetPropertyInfo<T>(string name)
            => typeof(T).GetProperties().Single(p => p.Name == name);

        public static ParameterExpression Parameter<T>()
            => Expression.Parameter(typeof(T));

        public static MemberExpression GetPropertyExpression(ParameterExpression obj, PropertyInfo property)
            => Expression.Property(obj, property);

        public static LambdaExpression GetLambda<TSource, TDestination>(ParameterExpression obj, Expression arg)
            => GetLambda(typeof(TSource), typeof(TDestination), obj, arg);

        public static LambdaExpression GetLambda(Type source, Type destination, ParameterExpression obj, Expression arg)
        {
            var lambdaBuilder = GetLambdaFuncBuilder(source, destination);
            return (LambdaExpression)lambdaBuilder.Invoke(null, new object[] { arg, new[] { obj } });
        }

        public static IQueryable<T> CallWhere<T>(IQueryable<T> query, LambdaExpression predicate)
        {
            var whereMethodBuilder = QueryableMethods
                .First(x => x.Name == "Where" && x.GetParameters().Length == 2)
                .MakeGenericMethod(new[] { typeof(T) });

            return (IQueryable<T>)whereMethodBuilder
                .Invoke(null, new object[] { query, predicate });
        }

        public static IQueryable<TEntity> CallOrderByOrThenBy<TEntity>(IQueryable<TEntity> modifiedQuery, bool useThenBy, bool descending, Type propertyType, LambdaExpression keySelector)
        {
            var methodName = "OrderBy";
            if (useThenBy) methodName = "ThenBy";
            if (descending) methodName += "Descending";

            var method = QueryableMethods
                .First(x => x.Name == methodName && x.GetParameters().Length == 2)
                .MakeGenericMethod(new[] { typeof(TEntity), propertyType });

            return (IQueryable<TEntity>)method.Invoke(null, new object[] { modifiedQuery, keySelector });
        }
    }
}
