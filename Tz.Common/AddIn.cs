using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Xml;
using System.Reflection;

namespace Tz.Common
{
    public class AddIn : IConfigurationSectionHandler
    {
        #region IConfigurationSectionHandler Members

        public object Create(object parent, object configContext, System.Xml.XmlNode section)
        {
            return section;
        }

        #endregion


        public static T[] CreateObjects<T>(string xpath)
        {
            object[] temp = CreateObjects(xpath);
            T[] rs = new T[temp.Length];
            temp.CopyTo(rs, 0);
            return rs;
        }

        public static Type[] GetTypes(string xpath)
        {
           
            var root = (XmlElement)ConfigurationManager.GetSection("addin");

            xpath += "/@type";
            

            var rs = new List<Type>();

            if (root != null)
            {
                var xmlNodeList = root.SelectNodes(xpath);
                if (xmlNodeList != null)
                    rs.AddRange(from XmlNode node in xmlNodeList select Type.GetType(node.Value, true));
            }
            return rs.ToArray();
        }

        public static Dictionary<string, Type> GetRegionAndDll(string xpath)
        {
            Dictionary<string, Type> dlls = new Dictionary<string, Type>();

            var root = (XmlElement)ConfigurationManager.GetSection("addin");


            var rs = new List<Type>();

            if (root != null)
            {
                var xmlNodeList = root.SelectNodes(xpath);
                if (xmlNodeList != null)
                {
                    foreach(XmlNode node in xmlNodeList)
                    {
                        var type=node.Attributes["type"].Value;
                        var region=node.Attributes["region"].Value;
                        var location = node.Attributes["location"].Value;

                        

                        var assembly=Assembly.Load(location);

                        var temp = assembly.GetType();

                        var dd = assembly.GetType(type);
                        var ddl = Type.GetType(type);

                        dlls.Add(region, ddl);
                    }
                }
            }
            return dlls;
        }

        public static object[] CreateObjects(string xpath)
        {
            Type[] types = GetTypes(xpath);
            object[] rs;
            if (types != null)
            {
                rs = new object[types.Length];
                for (int i = 0; i < rs.Length; i++)
                {
                    rs[i] = Activator.CreateInstance(types[i]);
                }
            }
            else
            {
                rs = new object[0];
            }

            return rs;
        }


    }
}
