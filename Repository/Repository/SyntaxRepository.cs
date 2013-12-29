using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.Domain;
using Woodsoft.Repository;

namespace Wiki.Repository {
	public interface ISyntaxRepository : IRepository<Syntax> {
		Syntax FindById( Int16 id );

	}

	public class SyntaxRepository : RepositoryBase<Syntax> , ISyntaxRepository {
		#region ISyntaxRepository Members

		public Syntax FindById( short id ) {
			return AllInformation()
				.Where( s => s.Id == id )
					.SingleOrDefault();
		}

		#endregion

		#region IRepository<Syntax> Members

		public void Add( Syntax entity ) {
			if( !Entity.Contains( entity ) )
				Entity.Add( entity );
		}

		public IQueryable<Syntax> AllInformation() {
			return Entity;
		}

		public void Delete( Syntax entity ) {
			if( Entity.Contains( entity ) )
				Entity.Remove( entity );
		}

		public ICollection<Syntax> Find() {
			return FindAll()
				.ToList();
		}

		public IQueryable<Syntax> FindAll() {
			return Entity;
		}

		public void Save() {
			Context.SaveChanges();
		}

		#endregion
	}
}
