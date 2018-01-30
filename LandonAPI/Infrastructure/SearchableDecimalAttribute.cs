using System;

namespace LandonAPI.Infrastructure
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class SearchableDecimalAttribute : SearchableAttribute
    {
        public SearchableDecimalAttribute()
            => ExpressionProvider = new DecimalToIntSearchExpressionProvider();
    }
}
