using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.EF {
	public class RoleRepository:RepositoryBase, IRoleRepository {
		#region IRoleRepository Members

		public IEnumerable<Role> Find( Guid userId ) {
			return AllInformation()
				.Where( r => r.Users.Any(u => u.Id == userId) );
		}

		public bool UsersExist( Guid roleId ) {
			return AllInformation()
				.Any( r => r.UserRoles.Any( ur => ur.RoleId == roleId ) );
		}

		#endregion

		#region IRepositoryBase<Role> Members

		public System.Data.Objects.ObjectSet<Role> Entity {
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

		bool UsersExist( Guid roleId );
	}
}
