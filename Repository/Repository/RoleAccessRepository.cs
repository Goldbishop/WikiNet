using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.Domain;
using Woodsoft.Repository;

namespace Wiki.Repository {
	public interface IRoleAccessRepository : IRepository<RoleAccess> {
		RoleAccess FindByNamespaceRole( int ns , Int16 role );
		ICollection<RoleAccess> FindByNamespace( int id );
		ICollection<RoleAccess> FindByRole( Int16 id );
	}
	public class RoleAccessRepository : RepositoryBase<RoleAccess> , IRoleAccessRepository {
		#region IRoleAccessRepository Members

		public RoleAccess FindByNamespaceRole( int ns , short role ) {
			return AllInformation()
				.Where( n => n.NamespaceID == ns && n.RoleID == role )
					.SingleOrDefault();
		}

		public ICollection<RoleAccess> FindByNamespace( int id ) {
			return Find()
				.Where( n => n.NamespaceID == id )
					.ToList();
		}

		public ICollection<RoleAccess> FindByRole( short id ) {
			return Find()
				.Where( n => n.RoleID == id )
					.ToList();
		}

		#endregion

		#region IRepository<RoleAccess> Members

		public void Add( RoleAccess entity ) {
			if( !Entity.Contains( entity ) )
				Entity.Add( entity );
		}

		public IQueryable<RoleAccess> AllInformation() {
			return Entity
				.Include( "Role" )
				.Include( "Namespace" );
		}

		public void Delete( RoleAccess entity ) {
			if( Entity.Contains( entity ) )
				Entity.Remove( entity );
		}

		public ICollection<RoleAccess> Find() {
			return FindAll()
				.ToList();
		}

		public IQueryable<RoleAccess> FindAll() {
			return Entity
				.Include( "Role" )
				.Include( "Namespace" );
		}

		public void Save() {
			Context.SaveChanges();
		}

		#endregion
	}
}
