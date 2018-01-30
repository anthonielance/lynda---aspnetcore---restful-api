namespace LandonAPI.Infrastructure
{
    public class SearchableDateTimeAttribute : SearchableAttribute
    {
        public SearchableDateTimeAttribute()
            => ExpressionProvider = new DateTimeSearchExpressionProvider();
    }
}
