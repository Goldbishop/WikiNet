using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.Domain;
using Wiki.Repository;

namespace Wiki.Service {
	public interface IRoleService {
		//Create Role
		Role Create( string name , string description , int ns = 1 );
		Role Create( string name , string description , bool edit , bool view , bool move , bool delete , int ns = 1 );

		//Edit Role
		Role Edit( Int16 id , string description );
		Role Edit( Int16 id , string description , int ns , bool edit , bool view , bool move , bool delete );

		//Disable Role
		void Delete( Int16 id );

	}
	public class RoleService : IRoleService {
		public RoleService() { }

		public IRoleRepository RoleRepository { get; set; }
		public IRoleAccessRepository RoleAccessRepository { get; set; }

		#region IRoleService Members

		public Role Create( string name , string description , int ns = 1 ) {
			return Create( name , description , false , true , false , false , ns );
		}
		/// <exception cref="ArgumentException">Thrown if the name already exists</exception>
		public Role Create( string name , string description , bool edit , bool view , bool move , bool delete , int ns = 1 ) {
			if( !RoleRepository.NameExists( name ) ) {
				var role = new Role() {
					Name = name ,
					Description = description ,
				};

				RoleRepository.Add( role );
				RoleRepository.Save();

				var access = new RoleAccess() {
					RoleID = role.Id ,
					NamespaceID = ns ,
					View = view ,
					Edit = edit ,
					Move = move ,
					Delete = delete
				};

				RoleAccessRepository.Add( access );
				RoleAccessRepository.Save();

				return role;
			} else {
				throw new ArgumentException( string.Format( "The Name, {0}, already exists!" , name ) );
			}
		}

		public Role Edit( short id , string description ) {
			var role = RoleRepository.FindById( id );
			if( description != role.Description ) {
				role.Description = description;

				RoleRepository.Save();
			}

			return role;
		}

		public Role Edit( short id , string description , int ns , bool edit , bool view , bool move , bool delete ) {
			var role = Edit( id , description );

			var access = RoleAccessRepository.FindByNamespaceRole( ns , id );
			bool changed = false;

			if( edit != access.Edit )
				access.Edit = edit; changed |= true;

			if( view != access.View )
				access.View = view; changed |= true;

			if( move != access.Move )
				access.Move = move; changed |= true;

			if( delete != access.Delete )
				access.Delete = delete; changed |= true;

			if( changed )
				RoleAccessRepository.Save();

			return role;
		}

		public void Delete( short id ) {
			var role = RoleRepository.FindById( id );
			if( role != null ) {
				role.Active = false;

				RoleRepository.Save();
			}
		}

		#endregion
	}
}
