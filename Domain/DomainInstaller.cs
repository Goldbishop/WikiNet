using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;

namespace Wiki.Domain {
	public class DomainInstaller : IWindsorInstaller {
		#region IWindsorInstaller Members

		public void Install( Castle.Windsor.IWindsorContainer container , Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store ) {
			container.Register(
				Types.FromAssembly( Assembly.GetExecutingAssembly() )
					.Where( t => t.Namespace.StartsWith( "Wiki.Domain" ) )
					.WithService.FirstInterface().LifestylePerWebRequest()
			);
		}

		#endregion
	}
}
