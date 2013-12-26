using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using Wiki.Domain;

namespace Wiki.Repository {
	class UserRepository : RepositoryBase , IUserRepository {
		public UserRepository( WikiContext context ) : base( context ) { }

		#region IUserRepository Members

		public User Find( Guid id ) {
			return AllInformation()
				.Where( u => u.Id == id ).SingleOrDefault();
		}

		public User Find( string email ) {
			return AllInformation()
				.Where( u => u.Email == email ).SingleOrDefault();
		}

		public bool DisplayExists( string display ) {
			return FindAll()
				.Any( u => u.Display == display );
		}

		public bool EmailExists( string email ) {
			return FindAll()
				.Any( u => u.Email == email );
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
