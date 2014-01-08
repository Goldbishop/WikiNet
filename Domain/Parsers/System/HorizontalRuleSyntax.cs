using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.Domain.Parsers {
	public class HorizontalRuleSyntax : SystemSyntax , ISyntaxParser, IReplacePattern {
		//A Horizontal must be on a line all to it self.
		public HorizontalRuleSyntax()
			: base() {
			OpenSyntax = "([-]{5})";
			IsLineBased = true;
		}

		#region ISyntaxParser Members

		public string Parse( string content ) {
			if( SyntaxPattern.IsMatch( content ) ) {
				var match = SyntaxPattern.Match( content );
				var open = match.Groups[ 1 ].Value;

				if( open.Length == 5 ) {
					return SyntaxPattern.Replace( content , ReplacePattern() );
				}
			}

			return content;
		}

		#endregion

		#region IReplacePattern Members

		public string ReplacePattern() {
			return @"<hr>";
		}

		#endregion
	}
}
