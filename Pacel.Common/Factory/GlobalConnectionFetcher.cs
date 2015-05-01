using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.Common;

namespace Parcel.Common.Factory
{
    public class GlobalConnectionFetcher : IConnectionString
    {
        Dictionary<string, string> regionSpecificConnectionString = new Dictionary<string, string>();
        public GlobalConnectionFetcher()
        {
            regionSpecificConnectionString.Add("Singapore", @"Data Source=.\SQLEXPRESS;Initial Catalog=tz.singaporepost.server.db.p3.2;Integrated Security=false;user=webuser;password=q1w2e3r4");
            regionSpecificConnectionString.Add("Genetech", @"Data Source=.\SQLEXPRESS;Initial Catalog=tz.Genentech.server.db.p1.0;Integrated Security=false;user=webuser;password=q1w2e3r4");
        }
        public string ConnectionString(string region)
        {
            if (regionSpecificConnectionString.ContainsKey(region))
            {
                return regionSpecificConnectionString[region];
            }
            else
            {
                throw new Exception("No connection string found for region");
            }
        }
    }
}
