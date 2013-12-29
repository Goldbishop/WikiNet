using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.Domain;
using Woodsoft.Repository;

namespace Wiki.Repository {
	public interface IUserRepository : IRepository<User> {
		User FindById( Guid id );
		User FindByEmail( string email );
		ICollection<User> FindByRole( Int16 id );
		ICollection<User> FindByVerified( bool val );

	}

	public class UserRepository : RepositoryBase<User> , IUserRepository {
		#region IUserRepository Members

		public User FindById( Guid id ) {
			return AllInformation()
				.Where( u => u.Id == id )
					.SingleOrDefault();
		}

		public User FindByEmail( string email ) {
			return AllInformation()
				.Where( u => u.Email == email )
					.SingleOrDefault();
		}

		public ICollection<User> FindByRole( short id ) {
			return FindAll()
				.Where( u => u.RoleID == id )
					.ToList();
		}

		public ICollection<User> FindByVerified( bool val ) {
			return FindAll()
				.Where( u => u.Verified == val )
					.ToList();
		}

		#endregion

		#region IRepository<User> Members

		public void Add( User entity ) {
			if( !Entity.Contains( entity ) )
				Entity.Add( entity );
		}

		public IQueryable<User> AllInformation() {
			return Entity
				.Include( "Details" )
				.Include( "Role" )
				.Include( "Articles" )
				.Include( "Contribution" );
		}

		public void Delete( User entity ) {
			if( Entity.Contains( entity ) )
				Entity.Remove( entity );
		}

		public ICollection<User> Find() {
			return FindAll()
				.ToList();
		}

		public IQueryable<User> FindAll() {
			return Entity
				.Include( "Details" )
				.Include( "Role" );
		}

		public void Save() {
			Context.SaveChanges();
		}

		#endregion
	}
}
