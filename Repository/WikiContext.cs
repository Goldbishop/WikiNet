using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.Domain;

namespace Wiki.EF {
	public class WikiContext : ObjectContext, IWikiContext {
		public WikiContext() : base( "WikiEntities" ) {
			Articles = CreateObjectSet<Article>();
			Namespaces = CreateObjectSet<Namespace>();
			Versions = CreateObjectSet<Version>();
			Users = CreateObjectSet<User>();
			Roles = CreateObjectSet<Role>();
			UserRoles = CreateObjectSet<UserRoles>();
		}

		//Publicly Accessible
		public ObjectSet<Article> Articles { get; private set; }
		public ObjectSet<Namespace> Namespaces { get; private set; }
		public ObjectSet<Version> Versions { get; private set; }
		public ObjectSet<User> Users { get; private set; }
		public ObjectSet<Role> Roles { get; private set; }

		//Hidden Usage
		public ObjectSet<UserRoles> UserRoles { get; private set; }

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
