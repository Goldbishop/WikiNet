using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web {
	public class RouteConfig {
		public static void RegisterRoutes( RouteCollection routes ) {
			routes.IgnoreRoute( "{resource}.axd/{*pathInfo}" );


			/****
			 * Generic Routing pattern
			 * {controller} - Page*, Category, Template, Talk, Images
			 * {name} - Name of the Page to perform the action on
			 * 
			 * Notes:
			 * > Actions in this route are always View.  Use of querystrings 
			 *		to perform Edit, Move, or Delete.
			 ***/
			routes.MapRoute(
				name: "Generic" ,
				url: "{ns}:{name}" ,
				defaults: new {
					controller = "Article" ,
					action = "View" ,
					name = "Home" ,
					ns = "ns"
				} ,
				constraints: new {
					name = @"^[\w]+$"
				}
			);

			routes.MapRoute(
				name: "Default" ,
				url: "{name}" ,
				defaults: new {
					controller = "Home" ,
					action = "View" ,
					name = "name" ,
					ns = "Main"		// namespace
				}
			);
		}
	}
}