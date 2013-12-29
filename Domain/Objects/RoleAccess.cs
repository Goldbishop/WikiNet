using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wiki.Domain {
	public class RoleAccessMap : DomainMap<RoleAccess> {
		public RoleAccessMap() {
			ToTable( "Role_Access" );

			HasKey( ra => new { ra.NamespaceID , ra.RoleID } );

			Property( ra => ra.NamespaceID ).HasColumnName( "NSId" );
			Property( ra => ra.RoleID ).HasColumnName( "RoleId" );
			Property( ra => ra.Edit ).HasColumnName( "edit" );
			Property( ra => ra.View ).HasColumnName( "view" );
			Property( ra => ra.Move ).HasColumnName( "move" );
			Property( ra => ra.Delete ).HasColumnName( "delete" );

			//Navigation mapping
			HasRequired( ra => ra.Role )
				.WithMany( r => r.Access )
				.HasForeignKey( ra => ra.RoleID );
			HasRequired( ra => ra.Namespace )
				.WithMany( ns => ns.Access )
				.Map( x => x.MapKey( "NSId" ) );
		}
	}

	public interface IRoleAccess {
		Int16 RoleID { get; set; }
		int NamespaceID { get; set; }
		bool Edit { get; set; }
		bool View { get; set; }
		bool Move { get; set; }
		bool Delete { get; set; }

		//Navigation Properties
		Role Role { get; set; }
		Namespace Namespace { get; set; }
	}

	public class RoleAccess : IRoleAccess {
		#region IRoleAccess Members

		public short RoleID { get; set; }
		public int NamespaceID { get; set; }
		public bool Edit { get; set; }
		public bool View { get; set; }
		public bool Move { get; set; }
		public bool Delete { get; set; }
		
		//Navigation Properties
		public Role Role { get; set; }
		public Namespace Namespace { get; set; }

		#endregion
	}

}
