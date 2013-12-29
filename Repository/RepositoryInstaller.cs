using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Wiki.Repository {
	public class RepositoryInstaller : IWindsorInstaller {
		#region IWindsorInstaller Members

		public void Install( IWindsorContainer container , IConfigurationStore store ) {
			container.Register( Types.FromAssembly( Assembly.GetExecutingAssembly() )
				.Where( t => t.Namespace.StartsWith( "Wiki.Repository" ) )
				.WithService.FirstInterface().LifestylePerWebRequest() );
		}

		#endregion
	}
}
