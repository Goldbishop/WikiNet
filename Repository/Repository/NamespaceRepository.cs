using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.Domain;
using Woodsoft.Repository;

namespace Wiki.Repository {
	public interface INamespaceRepository:IRepository<Namespace> {
		Namespace FindById( int id );
	}
	public class NamespaceRepository:RepositoryBase<Namespace>, INamespaceRepository {

		#region INamespaceRepository Members

		public Namespace FindById( int id ) {
			return AllInformation()
				.Where( n => n.Id == id )
					.SingleOrDefault();
		}

		#endregion

		#region IRepository<Namespace> Members

		public void Add( Namespace entity ) {
			if( !Entity.Contains( entity ) )
				Entity.Add( entity );
		}

		public IQueryable<Namespace> AllInformation() {
			return Entity
				.Include( "Articles" )
				.Include( "Access" );
		}

		public void Delete( Namespace entity ) {
			if( Entity.Contains( entity ) )
				Entity.Remove( entity );
		}

		public ICollection<Namespace> Find() {
			return Entity.ToList();
		}

		public IQueryable<Namespace> FindAll() {
			return Entity
				.Include( "Access" );
		}

		public void Save() {
			Context.SaveChanges();
		}

		#endregion
	}
}
