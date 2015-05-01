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

        static Bootstrapper()
        {
            var container = new Container();

            // register all your components with the container here:
            // container.Register<IService1, Service1>()
            // container.RegisterLifetimeScope<IDataContext,DataContext>();

            container.Register<IDbContextFactory, ParcelDbContextFactory>();
            container.Register<IConnectionString, GlobalConnectionFetcher>();
            LoadAssemblies(container);
            container.Verify();

            Container = container;
        }

        static void LoadAssemblies(Container Container)
        {
            Dictionary<string, Type> types = new Dictionary<string, Type>();
            string ass="ParcelBusiness_Singapore";
            var assemb=Assembly.Load(ass);

            Container.Options.AllowOverridingRegistrations = true;
            var referencedAssembly=assemb.GetReferencedAssemblies();

            List<AssembReg> totalAssembList = new List<AssembReg>();

            totalAssembList.AddRange(GetInterfaceRegistrations(assemb));

            foreach(var assembly in referencedAssembly)
            {
                var loadedAssembly = Assembly.Load(assembly);

                var assemlyCollection=GetInterfaceRegistrations(loadedAssembly);

                totalAssembList.AddRange(assemlyCollection);

            }

            foreach (var reg in totalAssembList)
            {

                Container.Register(reg.Service, reg.Implementation, Lifestyle.Transient);
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
                select new AssembReg { Service = type.GetInterfaces().Single(i => i.Namespace.ToLower().Contains("tz") || i.Namespace.ToLower().Contains("parcel")), Implementation = type };

            return registrations;
        }
    }
}