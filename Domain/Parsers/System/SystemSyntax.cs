using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Wiki.Domain.Parsers {
	//Syntax object designed specifically for Internal System parsing
	public class SystemSyntax : SyntaxParser {

		public bool HasContent { get; set; }

	}

}
