using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.EF {
	class UserRepository : RepositoryBase , IUserRepository {
		public UserRepository( WikiContext context ) : base( context ) { }

		#region IUserRepository Members

		public User Find( Guid id ) {
			return AllInformation()
				.Where( u => u.Id == id ).SingleOrDefault();
		}

		public User Find( string email ) {
			return AllInformation()
				.Where( u => u.email == email ).SingleOrDefault();
		}

		public bool DisplayExists( string display ) {
			return FindAll()
				.Any( u => u.display == display );
		}

		public bool EmailExists( string email ) {
			return FindAll()
				.Any( u => u.email == email );
		}
		#endregion

		#region IRepositoryBase<User> Members

		public ObjectSet<User> Entity {
			get { return Context.Users; }
		}

		public void Save( User entity ) {
			if( !Entity.Contains( entity ) )
				Entity.AddObject( entity );
		}

		public void Delete( User entity ) {
			if( Entity.Contains( entity ) )
				Entity.DeleteObject( entity );
		}

		public IEnumerable<User> AllInformation() {
			return Entity
				.Include( "UserRoles" )
				.Include( "UserRoles.Role" )
				.Include( "ArticlesCreated" )
				.Include( "ArticlesCreated.Namespace" )
				.Include( "CreatedVersions" )
				.Include( "CreatedVersions.Article" );
		}

		public IEnumerable<User> FindAll() {
			return Entity
				.Include( "UserRoles" )
				.Include( "UserRoles.Role" );
		}

		#endregion
	}

	public interface IUserRepository : IRepositoryBase<User> {
		User Find( Guid id );
		User Find( string email );
		bool DisplayExists( string display );
		bool EmailExists( string email );
	}
}
