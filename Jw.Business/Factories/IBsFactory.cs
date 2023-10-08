namespace Jw.Business.Factories
{
    public interface IBsFactory
    {
        IDtaFactory GetDtFactory();
        ISrvFactory GetSrvFactory();
    }
}
