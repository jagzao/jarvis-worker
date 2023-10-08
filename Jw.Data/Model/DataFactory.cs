using Jw.Data.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jw.Data.Model
{
    public class DataFactory : IDataFactory
    {
        IProcessRepository processRepository;
        ITenantProcessRepository tenantProcessRepository;
        IUserRepository userRepository;
        public DataFactory(
            IProcessRepository processRepository, 
            ITenantProcessRepository _tenantProcessRepository, 
            IUserRepository _userRepository)
        {
            this.processRepository = processRepository;
            this.tenantProcessRepository = _tenantProcessRepository;
            userRepository = _userRepository;
        }
        public IProcessRepository GetProcessRepository()
        {
            return processRepository;
        }

        public ITenantProcessRepository GetTenantProcessRepository()
        {
            return tenantProcessRepository;
        }

        public IUserRepository GetUserRepository()
        {
            return userRepository;
        }
    }
}
