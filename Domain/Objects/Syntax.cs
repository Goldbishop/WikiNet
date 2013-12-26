using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.Domain {
	public class SyntaxMap : DomainMap<Syntax> {
		public SyntaxMap() {
			ToTable( "Syntax" );

			HasKey( s => s.Id );

			Property( s => s.Id ).HasColumnName( "id" );
			Property( s => s.Name ).HasColumnName( "name" );
			Property( s => s.Type ).HasColumnName( "type" );
			Property( s => s.Order ).HasColumnName( "order" );
			Property( s => s.Search ).HasColumnName( "tag" );
			Property( s => s.Replace ).HasColumnName( "replace" );
			Property( s => s.Editable ).HasColumnName( "editable" );

		}
	}

	public class Syntax : ISyntax {
		#region ISyntax Members

		public short Id { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public short Order { get; set; }
		public string Search { get; set; }
		public string Replace { get; set; }
		public bool Editable { get; set; }

		#endregion
	}

	public interface ISyntax {
		Int16 Id { get; set; }
		string Name { get; set; }
		string Type { get; set; }
		Int16 Order { get; set; }
		string Search { get; set; }
		string Replace { get; set; }
		bool Editable { get; set; }
	}
}
