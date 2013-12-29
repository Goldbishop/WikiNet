using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Wiki.Web {
	public class SiteInstaller : IWindsorInstaller {
		#region IWindsorInstaller Members

		public void Install( IWindsorContainer container , IConfigurationStore store ) {
			container.Register(
				Classes.FromThisAssembly()
					.BasedOn<IController>()
						.LifestyleTransient()
			);
		}

		#endregion
	}
}