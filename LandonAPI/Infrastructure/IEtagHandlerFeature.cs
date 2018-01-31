namespace LandonAPI.Infrastructure
{
    public interface IEtagHandlerFeature
    {
        bool NoneMatch(IEtaggable entity);
    }
}