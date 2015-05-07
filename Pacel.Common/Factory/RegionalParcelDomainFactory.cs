using Tz.Parcel.Common.Interface;
using Tz.Parcel.Common.Service;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tz.Common;
using Tz.Region;

namespace Tz.Parcel.Common.Factory
{
    public class RegionalParcelDomainFactory : IRegionalFactory
    {
        public const string DefaultRegion = "Default";
        private static readonly Dictionary<string, List<TypeInfo>> _regionalAssembliesConfig = new Dictionary<string, List<TypeInfo>>();
        private Container _container;

        private List<Type> _genericTypeCollection = new List<Type>();
        public RegionalParcelDomainFactory(Container container, IConnectionString connectionString)
        {
            _container = container;
        }

        static RegionalParcelDomainFactory()
        {
            GetRegionalAssemblies();

        }

        static void GetRegionalAssemblies()
        {

            List<string> RegionalAssemblies = new List<string>();
            RegionalAssemblies.Add("Tz.Singapore_ParcelDomainService");
            RegionalAssemblies.Add("Tz.Hongkong_ParcelDomainService");

            foreach (var assembly in RegionalAssemblies)
            {
                var assemb = Assembly.Load(assembly);

                List<TypeInfo> genericTypeInfoForRegion = new List<TypeInfo>();

                var regionalConfigurationInfo = assemb.GetExportedTypes()
                    .Where(types => types.GetInterfaces().Any(i => i.IsAssignableFrom(typeof(IRegionalConfiguration))))
                    .FirstOrDefault();

                genericTypeInfoForRegion = GetGenericTypesFromAssembly(assemb);

                foreach(var dependentAssembly in assemb.GetReferencedAssemblies().Where(ass=>ass.Name.ToLower().Contains("tz")).ToList())
                {
                    var loadDependentAssembly = Assembly.Load(dependentAssembly);
                    var dependentAssemblyTypes = GetGenericTypesFromAssembly(loadDependentAssembly);
                    genericTypeInfoForRegion.AddRange(dependentAssemblyTypes);
                }


                if (regionalConfigurationInfo == null)
                {
                    continue;
                }

                var reginalAssemblyInstance = Activator.CreateInstance(regionalConfigurationInfo) as IRegionalConfiguration;



                _regionalAssembliesConfig.Add(reginalAssemblyInstance.RegionName(), genericTypeInfoForRegion);
            }
        }

        static  List<TypeInfo> GetGenericTypesFromAssembly(Assembly assembly)
        {

            var genericDefintion = assembly.GetExportedTypes()
                .SelectMany(typ => typ.GetInterfaces())
                .Where(inter => inter.IsGenericType)
                .Select(inter => inter.GetTypeInfo())
                .ToList();

            return genericDefintion;
        }

        public object ResolveInstance(Type type)
        {
            return _container.GetInstance(type);
        }

        public List<TypeInfo> GetAssemblyTypesByRegion(string region)
        {
            return _regionalAssembliesConfig[region];
        }

    }

    public static class FactoryExtension
    {
        public static T GetInstance<T>(this IRegionalFactory factory, string regionString)
        {
            var targetType = typeof(T).GetGenericTypeDefinition();
            List<TypeInfo> regionType = factory.GetAssemblyTypesByRegion(regionString);

            if (regionType == null)
            {
                regionType = factory.GetAssemblyTypesByRegion(RegionalParcelDomainFactory.DefaultRegion);
            }

            var parcelDomain = regionType
                             .Where(ty => ty.GetGenericTypeDefinition() == targetType)
                             .FirstOrDefault();

            T instance = (T)factory.ResolveInstance(parcelDomain);

            return instance;


        }

        public static TypeInfo GetType<T>(this IRegionalFactory factory, string regionString)
        {
            var targetType = typeof(T).GetGenericTypeDefinition();
            List<TypeInfo> regionType = factory.GetAssemblyTypesByRegion(regionString);

            if (regionType == null)
            {
                regionType = factory.GetAssemblyTypesByRegion(RegionalParcelDomainFactory.DefaultRegion);
            }

            var parcelDomain = regionType
                             .Where(ty => ty.GetGenericTypeDefinition() == targetType)
                             .FirstOrDefault();


            return parcelDomain;


        }
    }
}
