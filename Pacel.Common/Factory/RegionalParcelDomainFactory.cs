using Parcel.Common.Interface;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tz.Region;

namespace Parcel.Common.Factory
{
    public class RegionalParcelDomainFactory
    {
        public readonly Dictionary<string, List<TypeInfo>> _regionalAssembliesConfig = new Dictionary<string, List<TypeInfo>>();
        private Container _container;

        private List<Type> _genericTypeCollection=new List<Type>();
        public RegionalParcelDomainFactory(Container container)
        {
            PopulateGenericType();
            GetRegionalAssemblies();
            _container = container;
        }

        void PopulateGenericType()
        {
            _genericTypeCollection=typeof(RegionalParcelDomainFactory).Assembly.GetExportedTypes()
                .SelectMany(ty=>ty.GetInterfaces())
                .Where(typ=>typ.IsGenericType)
                .Select(typ=>typ).ToList();
        }


        void GetRegionalAssemblies()
        {



            List<string> RegionalAssemblies = new List<string>();
            RegionalAssemblies.Add("ParcelBusiness_Singapore");
            RegionalAssemblies.Add("ParcelBusiness_Hongkong");

            foreach (var assembly in RegionalAssemblies)
            {
                var assemb = Assembly.Load(assembly);

                var regionalConfigurationInfo = assemb.GetExportedTypes()
                    .Where(types => types.GetInterfaces().Any(i => i.IsAssignableFrom(typeof(IRegionalConfiguration))))
                    .FirstOrDefault();




                if (regionalConfigurationInfo == null)
                {
                    continue;
                }

                var reginalAssemblyInstance = Activator.CreateInstance(regionalConfigurationInfo) as IRegionalConfiguration;


                var genericDefintion = assemb.GetExportedTypes()
                    .SelectMany(typ=>typ.GetInterfaces())
                    .Where(inter=>inter.IsGenericType)
                    .Select(inter=>inter.GetTypeInfo())
                    .ToList();

                _regionalAssembliesConfig.Add(reginalAssemblyInstance.RegionName(), genericDefintion);
            }
        }

        public IParcelDomain<IRegionalConfiguration> GetRegionalInstance(string region)
        {
            var targetType = typeof(IParcelDomain<IRegionalConfiguration>).GetGenericTypeDefinition();
            List<TypeInfo> regionType = _regionalAssembliesConfig[region];

           var parcelDomain= regionType
                            .Where(ty => ty.GetGenericTypeDefinition() == targetType)
                            .FirstOrDefault();

           IParcelDomain<ISingaporeRegion> instance = _container.GetInstance(parcelDomain) as IParcelDomain<ISingaporeRegion>;

           return instance as IParcelDomain<IRegionalConfiguration>;
        }

    }

    //public static class FactoryExtension
    //{
    //    public static T GetInstance<T>(this RegionalParcelDomainFactory factory,string regionString) where T:interface
    //    {
    //        var regionInterface = factory._regionalAssembliesConfig[regionString];
            

    //    }
    //}
}
