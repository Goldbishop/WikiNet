using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wiki.Domain;
using Wiki.Repository;
using Wiki.Service;

namespace Wiki.Web {
	public class SiteController : Controller {
		#region Common Properties to all Controllers
		public IUserRepository UserRepository { get; set; }
		public IArticleRepository ArticleRepository { get; set; }

		#endregion

		protected override void OnActionExecuting( ActionExecutingContext filterContext ) {
			
			base.OnActionExecuting( filterContext );
		}

		[ChildActionOnly]
		public ActionResult Menu() {
			return View();
		}
	}
}