using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.Domain;
using Woodsoft.Repository;

namespace Wiki.Repository {
	public interface IRoleRepository : IRepository<Role> {
		Role FindById( Int16 id );
		bool NameExists( string name );
	}

	public class RoleRepository : RepositoryBase<Role> , IRoleRepository {

		#region IRoleRepository Members

		public Role FindById( short id ) {
			return AllInformation()
				.Where( r => r.Id == id )
					.SingleOrDefault();
		}

		public bool NameExists( string name ) {
			return Find()
				.Any( r => r.Name == name );
		}
		#endregion

		#region IRepository<Role> Members

		public void Add( Role entity ) {
			if( !Entity.Contains( entity ) )
				Entity.Add( entity );
		}

		public IQueryable<Role> AllInformation() {
			return Entity
				.Include( "Users" )
				.Include( "Access" );
		}

		public void Delete( Role entity ) {
			if( Entity.Contains( entity ) )
				Entity.Remove( entity );
		}

		public ICollection<Role> Find() {
			return Entity.ToList();
		}

		public IQueryable<Role> FindAll() {
			return Entity
				.Include( "Access" );
		}

		public void Save() {
			Context.SaveChanges();
		}

		#endregion
	}
}
