using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.Region;

namespace Tz.Hongkong_ParcelDomainService
{
    public class RegionalConfiguration:IHongkongRegion
    {
        public string RegionName()
        {
            return "Hongkong";
        }

        public Type GetAssemblyType()
        {
            return typeof(RegionalConfiguration).Assembly.GetType();
        }

        public void SetupUpDependency(SimpleInjector.Container container)
        {
            throw new NotImplementedException();
        }
    }
}
