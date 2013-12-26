using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.Domain;

namespace Wiki.Repository {
	public class WikiContext : DbContext {
		public WikiContext( string connName )
			: base( "Name=" + connName ) {
				Configuration.LazyLoadingEnabled = false;
		}

		protected override void OnModelCreating( DbModelBuilder modelBuilder ) {
			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
			modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

			modelBuilder.Configurations.Add( new ArticleMap() );
			modelBuilder.Configurations.Add( new ArticleContentMap() );
			modelBuilder.Configurations.Add( new NamespaceMap() );
			modelBuilder.Configurations.Add( new RoleMap() );
			modelBuilder.Configurations.Add( new RoleAccessMap() );
			modelBuilder.Configurations.Add( new ArticleMap() );
			modelBuilder.Configurations.Add( new ArticleMap() );
			modelBuilder.Configurations.Add( new ArticleMap() );
			
		}

	}
}
