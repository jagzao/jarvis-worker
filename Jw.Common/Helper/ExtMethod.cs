using Jw.Common.Enums;
using Jw.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jw.Common.Helper
{
    public static class ExtMethod
    {
        public static T ParseObject<T>(this object obj)
        {
            if (obj == null)
            {
                return default(T);
            }

            try
            {
                if (obj is ProcessWorker)
                {
                    var parse = new ProcessWorker();
                    parse.tenantProcess = (DtTenantProcess)obj;
                    var enm = (EnumProcess.Process)parse.tenantProcess.ProcessId;
                    parse.process = enm;
                    parse.Name = enm.ToString();
                    parse.IsWorking = false;
                    parse.Elapsed = TimeSpan.Zero;
                }
                if (obj is DtTenantProcess)
                {
                    var parse = new ProcessWorker();
                    parse.tenantProcess = (DtTenantProcess)obj;
                    var enm = (EnumProcess.Process)parse.tenantProcess.ProcessId;
                    parse.process = enm;
                    parse.Name = enm.ToString();
                    parse.IsWorking = false;
                    parse.Elapsed = TimeSpan.Zero;
                    
                    return (T)((object)parse);
                }

                T result = (T)obj;
                return result;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

    }
}
