using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tz.Common;

namespace Tz.Parcel.Common.Interface
{
    public interface IRegionalFactory
    {
        List<TypeInfo> GetAssemblyTypesByRegion(string region);
        object ResolveInstance(Type type);

    }
}
