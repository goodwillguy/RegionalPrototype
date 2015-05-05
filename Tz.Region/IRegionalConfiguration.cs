using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tz.Region
{
    public interface IRegionalConfiguration
    {
        string RegionName();
        Type GetAssemblyType();
        void SetupUpDependency(Container container);
    }
}
