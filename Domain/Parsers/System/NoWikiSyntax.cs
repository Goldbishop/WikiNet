using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Wiki.Domain.Parsers {
	public class NoWikiSyntax : SystemSyntax , ISyntaxParser {
		public NoWikiSyntax() : base() {
			ContentGroup = 1;
		}

		#region ISyntaxParser Members

		public string Parse( string content ) {
			//Pattern checks for Beginning tag, <nowiki>, and then
			//  returns 
			var patt = new Regex( "<nowiki>(.+?)(</nowiki>)?$" );

			if( patt.IsMatch( content ) ) {
				var match = patt.Match( content );
				var val = match.Groups[ 1 ].Value;

				if( match.Groups[ 2 ] != null ) {
					//TODO: return all content
				} else {
					//TODO: Return content to the end of the line
				}

			}

			return content;
		}

		#endregion
	}
}
