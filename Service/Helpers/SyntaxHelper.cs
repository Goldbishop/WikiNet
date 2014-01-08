using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.Repository;

namespace Wiki.Service {
	public static class SyntaxHelper {
		public static ISyntaxRepository SyntaxRepository { get; set; }

		public static string Parse( string content ) {
			//TODO: Run Through the System Syntax parsers
			ParseSystem( content );

			//TODO: Run Through the Html Syntax Parsers
			ParseHtml( content );

			//TODO: Run through the User Repository Syntax Parsers
			ParseRepository( content );
		
			return null;
		}

		public static string ParseSystem( string content ) {


			return null;
		}

		public static string ParseHtml( string content ) {


			return null;
		}

		public static string ParseRepository( string content ) {
			//TODO: Run through User custom syntax
			var customSyntax = SyntaxRepository.FindAll();
			foreach( var syntax in customSyntax ) {

			}

			return null;
		}
	}
}
