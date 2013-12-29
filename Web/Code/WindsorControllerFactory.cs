using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.MicroKernel;

namespace Wiki.Web {
	public class WindsorControllerFactory : DefaultControllerFactory {
		private readonly IKernel Kernel;

		public WindsorControllerFactory( IKernel kernel ) {
			Kernel = kernel;
		}

		public override void ReleaseController( IController controller ) {
			Kernel.ReleaseComponent( controller );
		}

		protected override IController GetControllerInstance( RequestContext requestContext , Type controllerType ) {
			if( controllerType == null )
				throw new HttpException( 404 , string.Format( "The controll for path '{0}' could not be found." , requestContext.HttpContext.Request.Path ) );

			return ( IController ) Kernel.Resolve( controllerType );
		}
	}
}