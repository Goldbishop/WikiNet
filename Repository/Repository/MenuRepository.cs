using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.Domain;
using Woodsoft.Repository;

namespace Wiki.Repository {
	public interface IMenuRepository : IRepository<Menu> {
		Menu FindById( int id );
		ICollection<Menu> FindByParent( int id );
		ICollection<Menu> FindByActive( bool val );

	}

	public class MenuRepository : RepositoryBase<Menu> , IMenuRepository {

		#region IMenuRepository Members

		public Menu FindById( int id ) {
			return AllInformation()
				.Where( m => m.MenuId == id )
					.SingleOrDefault();
		}

		public ICollection<Menu> FindByParent( int id ) {
			return FindAll()
				.Where( m => m.ParentId == id )
					.ToList();
		}

		public ICollection<Menu> FindByActive( bool val ) {
			return FindAll()
				.Where( m => m.Active == val )
					.ToList();
		}

		#endregion

		#region IRepository<Menu> Members

		public void Add( Menu entity ) {
			if( !Entity.Contains( entity ) )
				Entity.Add( entity );
		}

		public IQueryable<Menu> AllInformation() {
			return Entity
				.Include( "Parent" );
		}

		public void Delete( Menu entity ) {
			if( Entity.Contains( entity ) )
				Entity.Remove( entity );
		}

		public ICollection<Menu> Find() {
			return FindAll()
				.ToList();
		}

		public IQueryable<Menu> FindAll() {
			return Entity;
		}

		public void Save() {
			Context.SaveChanges();
		}

		#endregion
	}
}
