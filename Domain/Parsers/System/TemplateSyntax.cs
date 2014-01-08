using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.Domain.Parsers {
	//TODO: Parse Template Name plus arguments
	// 1) Template Name is associated with an Article by the same name in the Template Namespace
	// 2) Arguments must either be numeric or named.  If neither exist then the argument is ignored
	// 3) Argument can be another template, at which point the parser needs to dig through that template first and expand before processing existing template.
	// 4) (Feature) Allow for Namespace Templates (boilerplates) [On any new article in that namespace, the template will autopopulate information/format]
	public class TemplateSyntax : SystemSyntax, ISyntaxParser {
		public TemplateSyntax()
			: base() {
				OpenSyntax = @"{{";
				CloseSyntax = @"}}";

		}

		#region ISyntaxParser Members

		public string Parse( string content ) {
			throw new NotImplementedException();
		}

		#endregion
	}
}
