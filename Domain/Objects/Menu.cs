using System;

namespace Wiki.Domain {
	public class MenuMap : DomainMap<Menu> {
		public MenuMap() {
			//Refer to: http://stackoverflow.com/questions/6482542/setting-up-a-recursive-mapping-with-fluent-for-entity-framework-4-1

			HasKey( m => m.MenuId );

			ToTable( "Menu" );

			Property( m => m.MenuId ).HasColumnName( "id" )
				.IsRequired();
			Property( m => m.ParentId ).HasColumnName( "parentid" )
				.IsOptional();
			Property( m => m.Key ).HasColumnName( "key" )
				.IsRequired();
			Property( m => m.Value ).HasColumnName( "value" )
				.IsRequired();
			Property( m => m.Active ).HasColumnName( "active" )
				.IsRequired();
			Property( m => m.Inactive ).HasColumnName( "inactive" )
				.IsOptional();

			HasOptional( m => m.Parent )
				.WithMany()
				.HasForeignKey( m => m.ParentId );
		}
	}

	public interface IMenu {
		int MenuId { get; set; }
		int? ParentId { get; set; }
		string Key { get; set; }
		string Value { get; set; }
		bool Active { get; set; }
		DateTime? Inactive { get; set; }

		Menu Parent { get; set; }
	}

	public class Menu : IMenu {
		public Menu() { }	//For Controller Access
		#region IMenu Members

		public int MenuId { get; set; }
		public int? ParentId { get; set; }
		public string Key { get; set; }
		public string Value { get; set; }
		public bool Active { get; set; }
		public DateTime? Inactive { get; set; }

		public virtual Menu Parent { get; set; }

		#endregion
	}
}
