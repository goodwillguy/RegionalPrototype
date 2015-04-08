using Pacel.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tz.Common;

namespace ParcelService
{
    public class ParcelBusinessFactory
    {
        static Dictionary<string, Type> _list = new Dictionary<string, Type>();
        static ParcelBusinessFactory()
        {
            _list = AddIn.GetRegionAndDll("tz.pad/ParcelServices/ParcelService");

        }

        public static IParcelReservation GetParcelObject(string region)
        {
            IParcelReservation parcel = null;

            Type assemblyType = null;

            _list.TryGetValue(region, out assemblyType);

            parcel = (IParcelReservation)Activator.CreateInstance(assemblyType);

            return parcel;
        }
    }
}