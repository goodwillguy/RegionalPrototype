using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tz.Common
{
    public class ConnectionStringConfiguration:IConnectionString
    {

        public string ConnectionString(string region)
        {
           string conString=string.Empty;

           if (region=="Singapore")
           {
               conString= ConfigurationManager.ConnectionStrings["Singapore"].ConnectionString;
           }
           else if (region == "Genetech")
           {
               conString = ConfigurationManager.ConnectionStrings["Genetech"].ConnectionString;
           }
           else
           {
               conString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
           }
            return conString;
        }
    }
}
