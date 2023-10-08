using Jw.Business.Factories;

namespace Jw.Business.Models
{
    public class BsFactory : IBsFactory
    {
        IDtaFactory bsFactory;
        ISrvFactory srvFactory;
        public BsFactory(IDtaFactory _bsFactory, ISrvFactory _srvFactory)
        {
            bsFactory = _bsFactory;
            srvFactory = _srvFactory;
        }
        public IDtaFactory GetDtFactory()
        {
            return bsFactory;
        }

        public ISrvFactory GetSrvFactory()
        {
            return srvFactory;
        }

    }
}
