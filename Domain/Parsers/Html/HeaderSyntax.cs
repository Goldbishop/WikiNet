using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Wiki.Domain.Parsers {
	public class HeaderSyntax : HtmlSyntax, ISyntaxParser {
		public HeaderSyntax()
			: base() {
			OpenSyntax = @"(={2,6})";
			CloseSyntax = @"(={2,6})";
			//Special situation with Header is there are 6 of them (H1-H6).  Abstracted
			//	to the minimal point and implemented accordingly.
			OpenHtml = @"<H#>";
			CloseHtml = @"</H#>";
			IsLineBased = true;
			ContentGroup = 2;
		}

		public string Parse( string content ) {
			if( SyntaxPattern.IsMatch( content ) ) {
				var match = SyntaxPattern.Match( content );
				var open = match.Groups[ 1 ].Value;
				var close = match.Groups[ 3 ].Value;

				//Check if open and close pattern length is the same
				if( open.Length != close.Length ) {
					//They do not match in length
					return content;
				}

				var len = open.Length; //Since open and close are the same length, use open as a basis.

				OpenHtml.Replace( "#" , len.ToString() );
				CloseHtml.Replace( "#" , len.ToString() );

				return SyntaxPattern.Replace( content , ReplacePattern() );
			} else {
				return content;
			}
		}
	}
}
