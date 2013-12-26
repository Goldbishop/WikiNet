using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.Domain;

namespace Wiki.Repository {
	public class WikiContext : ObjectContext, IWikiContext {
		public WikiContext() : base( "WikiEntities" ) {
			Articles = CreateObjectSet<Article>();
			Namespaces = CreateObjectSet<Namespace>();
			Users = CreateObjectSet<User>();
			Roles = CreateObjectSet<Role>();
		}

		//Publicly Accessible
		public ObjectSet<Article> Articles { get; private set; }
		public ObjectSet<Namespace> Namespaces { get; private set; }
		public ObjectSet<User> Users { get; private set; }
		public ObjectSet<Role> Roles { get; private set; }

		#region IWikiContext Members

		public void Flush() {
			this.SaveChanges();
		}

		#endregion

	}


	public interface IWikiContext {
		void Flush();
	}
}
