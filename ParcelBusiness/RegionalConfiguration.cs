using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tz.Region;

namespace ParcelBusiness_Singapore
{
    public class RegionalConfiguration : ISingaporeRegion
    {
        public string RegionName()
        {
            return "Singapore";
        }

        public Type GetAssemblyType()
        {

            return typeof(ISingaporeRegion);
        }

        public void SetupUpDependency(SimpleInjector.Container container)
        {
            throw new NotImplementedException();
        }
    }
}
