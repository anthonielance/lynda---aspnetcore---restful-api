namespace LandonAPI.Infrastructure
{
    public interface IEtaggable
    {
        string GetEtag();
    }
}