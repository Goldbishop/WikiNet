using System.Web.Mvc;
using Castle.Core;
using Castle.Facilities.Logging;
using Castle.Windsor;
using Wiki.Domain;
using Wiki.Repository;
using Wiki.Service;
using Woodsoft.Repository.Windsor;


namespace Wiki.Web {
	public class App {
		public static void Initialize( string log4netPath ) {
			var container = new WindsorContainer();

			container.Kernel.ComponentModelCreated += ( s => {
				if( s.LifestyleType == LifestyleType.Undefined )
					s.LifestyleType = LifestyleType.PerWebRequest;
			} );

			container.Install(
				new DomainInstaller() ,
				new RepositoryInstaller() ,
				new ServiceInstaller()
			);

			//Installer for MVC framework -- Must be done after other installers on its own.
			container.Install( new SiteInstaller() );

			ControllerBuilder.Current.SetControllerFactory( new WindsorControllerFactory( container.Kernel ) );

			container.AddFacility(new LoggingFacility(LoggerImplementation.Log4net, log4netPath);

			CWC.Init(container);
		}
	}
}