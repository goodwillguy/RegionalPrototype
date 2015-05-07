using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using SimpleInjector.Extensions;
using Tz.Parcel.Common.Interface;
using Tz.Parcel.Common.Factory;
using Tz.Common;
using Tz.Region;
using Tz.Parcel.Common.Factory;

using SimpleInjector.Integration.Wcf;
using SimpleInjector.Extensions.LifetimeScoping;
using Tz.Parcel.Common.Interface.Repository;

namespace ParcelService
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
        static WcfOperationLifestyle wcfLifeTime = new WcfOperationLifestyle();
        static Bootstrapper()
        {
            var container = new Container();

            RegionalAssemblies.Add("Tz.Singapore_ParcelDomainService");
            RegionalAssemblies.Add("Tz.Hongkong_ParcelDomainService");
            
            // register all your components with the container here:
            // container.Register<IService1, Service1>()
            // container.RegisterLifetimeScope<IDataContext,DataContext>();

            //container.Register<IDbContextFactory, ParcelDbContextFactory>();

            IConnectionString iconnection = new GlobalConnectionFetcher();


            container.RegisterSingle(typeof(IConnectionString), iconnection);

            var parcelDomainFactory = new RegionalParcelDomainFactory(container, iconnection);

            //container.RegisterSingle<IRegionalFactory,RegionalParcelDomainFactory>();//, parcelDomainFactory);
            container.RegisterSingle(typeof(IRegionalFactory), parcelDomainFactory);
            //container.Register<IRegionalFactory, RegionalParcelDomainFactory>(wcfLifeTime);

            LoadAssemblies(container);
            container.Verify();

            Container = container;
            SimpleInjectorServiceHostFactory.SetContainer(container);
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
                    if (reg.Service != typeof(IRegionalFactory) && reg.Service!=typeof(IConnectionString))
                    {

                        if (reg.Service == typeof(IRegionalParcelRepository<ISingaporeRegion>))
                        {
                            Container.Register(reg.Service, reg.Implementation, wcfLifeTime);
                        }
                        else
                        {
                            Container.Register(reg.Service, reg.Implementation);
                        }
                    }

                }

            }
        }

        static IEnumerable<AssembReg> GetInterfaceRegistrations(Assembly asembly)
        {
            var test =
               from type in asembly.GetExportedTypes()
               where type.Namespace.ToLower().Contains("tz")
               where type.GetInterfaces().Any()
               select type.GetInterfaces();

            var registrations =
                from type in asembly.GetExportedTypes()
                where type.Namespace.ToLower().Contains("tz") && !type.IsInterface
                where type.GetInterfaces().Any()
                select new AssembReg { Service = type.GetInterfaces().FirstOrDefault(i => i.Namespace.ToLower().Contains("tz") || i.Namespace.ToLower().Contains("parcel")), Implementation = type };

            return registrations;
        }
    }
}