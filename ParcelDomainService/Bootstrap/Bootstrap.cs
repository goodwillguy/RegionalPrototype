using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using SimpleInjector.Extensions;
using Parcel.Common.Interface;
using Parcel.Common.Factory;
using Tz.Common;
using Tz.Region;

namespace ParcelDomainService
{
    public class AssembReg
    {
        public Type Service { get; set; }
        public Type Implementation { get; set; }
    }

    public static class Bootstrapper
    {
        public static readonly Container Container;

        public static List<string> RegionalAssemblies = new List<string>();

        static Bootstrapper()
        {
            var container = new Container();

            RegionalAssemblies.Add("ParcelBusiness_Singapore");
            RegionalAssemblies.Add("ParcelBusiness_Hongkong");

            // register all your components with the container here:
            // container.Register<IService1, Service1>()
            // container.RegisterLifetimeScope<IDataContext,DataContext>();

            container.Register<IDbContextFactory, ParcelDbContextFactory>();
            container.Register<IConnectionString, GlobalConnectionFetcher>();

            var parcelDomainFactory = new RegionalParcelDomainFactory(container);

            container.RegisterSingle(parcelDomainFactory.GetType(), parcelDomainFactory);

            LoadAssemblies(container);
            container.Verify();

            Container = container;
        }

       

        static void LoadAssemblies(Container Container)
        {
            Dictionary<string, Type> types = new Dictionary<string, Type>();


            foreach (var regionalAssembly in RegionalAssemblies)
            {
                var assemb = Assembly.Load(regionalAssembly);

                Container.Options.AllowOverridingRegistrations = true;
                var referencedAssembly = assemb.GetReferencedAssemblies();

                List<AssembReg> totalAssembList = new List<AssembReg>();

                var ablist= GetInterfaceRegistrations(assemb);

                totalAssembList.AddRange(ablist);

                foreach (var assembly in referencedAssembly)
                {
                    var loadedAssembly = Assembly.Load(assembly);

                    var assemlyCollection = GetInterfaceRegistrations(loadedAssembly);

                    totalAssembList.AddRange(assemlyCollection);

                }

                foreach (var reg in totalAssembList)
                {

                    Container.Register(reg.Service, reg.Implementation, Lifestyle.Transient);
                }

            }
        }

        static IEnumerable<AssembReg> GetInterfaceRegistrations(Assembly asembly)
        {
            var test =
               from type in asembly.GetExportedTypes()
               where type.Namespace.ToLower().Contains("parcel")
               where type.GetInterfaces().Any()
               select type.GetInterfaces();

            var registrations =
                from type in asembly.GetExportedTypes()
                where type.Namespace.ToLower().Contains("parcel")
                where type.GetInterfaces().Any()
                select new AssembReg { Service = type.GetInterfaces().FirstOrDefault(i => i.Namespace.ToLower().Contains("tz") || i.Namespace.ToLower().Contains("parcel")), Implementation = type };

            return registrations;
        }
    }
}