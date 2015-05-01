using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector.Integration.Wcf;
using SimpleInjector;
namespace Tz.Common
{
    public abstract class SelfHostedWCF
    {
        protected SimpleInjector.Integration.Wcf.SimpleInjectorServiceHost Host;

        public SelfHostedWCF(Container container)
        {
            //Host = new SimpleInjectorServiceHost(container, this.GetType(), new Uri("http://localhost:9191"));
            //Host.Open();
        }
    }
}
