using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.Domain;

namespace Wiki.Repository {
	public class RoleRepository:RepositoryBase, IRoleRepository {
		public RoleRepository( WikiContext context ) : base(context) { }

		#region IRoleRepository Members

		public IEnumerable<Role> Find( Guid userId ) {
			return AllInformation()
				.Where( r => r.Users.Any(u => u.Id == userId) );
		}

		public bool UsersExist( short roleId ) {
			return AllInformation()
				.Any( r => r.Users.Any( ur => ur.RoleID == roleId ) );
		}

		#endregion

		#region IRepositoryBase<Role> Members

		public ObjectSet<Role> Entity {
			get { return Context.Roles; }
		}

		public void Save( Role entity ) {
			if( !Entity.Contains( entity ) )
				Entity.AddObject( entity );
		}

		public void Delete( Role entity ) {
			if( Entity.Contains( entity ) )
				Entity.DeleteObject( entity );
		}

		public IEnumerable<Role> AllInformation() {
			return Entity
				.Include( "Users" );
		}

		public IEnumerable<Role> FindAll() {
			return Entity;
		}

		#endregion
	}

	public interface IRoleRepository:IRepositoryBase<Role> {
		IEnumerable<Role> Find( Guid userId );

		bool UsersExist( short roleId );
	}
}
