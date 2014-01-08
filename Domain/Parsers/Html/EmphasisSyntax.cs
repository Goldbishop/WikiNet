using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.Domain.Parsers {
	public class EmphasisSyntax : HtmlSyntax, ISyntaxParser {
		public EmphasisSyntax()
			: base() {
			//Going to capture both Italics, Bold and the combination of both
			// * Italics = [']{2} (ie: '' something '' )
			// * Bold = [']{3} (ie: ''' something ''' )
			// * Italics & Bold = [']{5} (ie: ''''' something ''''' )
			// Since this is line based I detect from the Front (^) of the string to the End ($)
			OpenSyntax = @"^([']{2,5})[ ]";
			CloseSyntax = @"[ ]([']{2,5})$";
			IsLineBased = true;
			ContentGroup = 2;
		}

		public string Parse( string content ) {
			if( SyntaxPattern.IsMatch( content ) ) {
				var match = SyntaxPattern.Match( content );
				var open = match.Groups[ 1 ].Value;
				var close = match.Groups[ 3 ].Value;

				//Check if open and close patterns are the same length
				if( open.Length == close.Length ) {
					var len = open.Length;

					switch( len ) {
						case 5:
							//TODO: Parse for Bold & Italics
							OpenHtml = @"<b><i>";
							CloseHtml = @"</b><i>";
							
							break;
						case 3:
							//TODO: Parse for Bold
							OpenHtml = @"<b>";
							CloseHtml = @"</b>";

							break;
						case 2:
							//TODO: Parse for Italics
							OpenHtml = @"<i>";
							CloseHtml = @"</i>";

							break;
						default:
							return content;
					}

					return SyntaxPattern.Replace( content , ReplacePattern() );
				}
			}

			return content;
		}
	}
}
