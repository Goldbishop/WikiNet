using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;

namespace Wiki.Service {
	public class ServiceInstaller : IWindsorInstaller {
		#region IWindsorInstaller Members

		public void Install( Castle.Windsor.IWindsorContainer container , Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store ) {
			container.Register( Types.FromAssembly( Assembly.GetExecutingAssembly() )
				.Where( t => t.Namespace.StartsWith( "Wiki.Service" ) )
				.WithService.FirstInterface().LifestylePerWebRequest() );
		}

		#endregion
	}
}
