using Pacel.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ParcelService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IParcelService, IParcelDomain
    {
        private ParcelBusinessFactory factory = new ParcelBusinessFactory();
        public void CreateAndReservceParcel(string region)
        {
            if(string.IsNullOrWhiteSpace(region))
            {
                region="Singapore";
            }
            var ins=ParcelBusinessFactory.GetParcelObject(region);
            ins.CreateParcel();

        }


        public string GetFirstParcel(string region)
        {
            if (string.IsNullOrWhiteSpace(region))
            {
                region = "Singapore";
            }
            var ins = ParcelBusinessFactory.GetParcelObject(region);
            return ins.GetFirstParcel();
        }

        public bool PickupParcel(Guid parcelId, string parcelData)
        {
            throw new NotImplementedException();
        }
    }
}
