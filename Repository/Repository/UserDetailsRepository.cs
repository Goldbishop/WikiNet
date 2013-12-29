using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.Domain;
using Woodsoft.Repository;

namespace Wiki.Repository {
	public interface IUserDetailsRepository : IRepository<UserDetails> {
		UserDetails FindByUserId( Guid id );
	}
	public class UserDetailsRepository : RepositoryBase<UserDetails> , IUserDetailsRepository {

		#region IUserDetailsRepository Members

		public UserDetails FindByUserId( Guid id ) {
			return AllInformation()
				.Where( ud => ud.UserID == id )
					.SingleOrDefault();
		}

		#endregion

		#region IRepository<UserDetails> Members

		public void Add( UserDetails entity ) {
			if( !Entity.Contains( entity ) )
				Entity.Add( entity );
		}

		public IQueryable<UserDetails> AllInformation() {
			return Entity;
		}

		public void Delete( UserDetails entity ) {
			if( Entity.Contains( entity ) )
				Entity.Remove( entity );
		}

		public ICollection<UserDetails> Find() {
			return FindAll()
				.ToList();
		}

		public IQueryable<UserDetails> FindAll() {
			return Entity;
		}

		public void Save() {
			Context.SaveChanges();
		}

		#endregion
	}
}
