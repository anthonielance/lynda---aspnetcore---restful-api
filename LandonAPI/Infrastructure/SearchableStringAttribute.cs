namespace LandonAPI.Infrastructure
{
    public class SearchableStringAttribute : SearchableAttribute
    {
        public SearchableStringAttribute()
         => ExpressionProvider = new StringSearchExpressionProvider();
    }
}
