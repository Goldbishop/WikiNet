using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.Domain {
	public class RoleMap : DomainMap<Role> {
		public RoleMap() {
			ToTable( "Role" );

			HasKey( r => r.Id );

			//Property mapping
			Property( r => r.Id ).HasColumnName( "id" )
				.HasDatabaseGeneratedOption( DatabaseGeneratedOption.Identity );
			Property( r => r.Name ).HasColumnName( "name" )
				.IsRequired().HasMaxLength( 25 );
			Property( r => r.Description ).HasColumnName( "description" )
				.IsOptional().HasMaxLength( 255 );
			Property( r => r.Active ).HasColumnName( "active" )
				.IsOptional();

			//Navigation mapping
			HasMany( r => r.Users )
				.WithRequired( u => u.Role );
			HasMany( r => r.Access )
				.WithRequired( ra => ra.Role );

		}
	}

	public interface IRole {
		Int16 Id { get; set; }
		string Name { get; set; }
		string Description { get; set; }
		bool Active { get; set; }

		ICollection<User> Users { get; set; }
		ICollection<RoleAccess> Access { get; set; }
	}

	public class Role : IRole {

		#region IRole Members

		public Int16 Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public bool Active { get; set; }

		public ICollection<User> Users { get; set; }
		public ICollection<RoleAccess> Access { get; set; }

		#endregion

	}

}
