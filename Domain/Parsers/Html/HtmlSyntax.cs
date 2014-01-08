using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.Domain.Parsers {
	//Syntax object designed specifically for HTML parsing
	public class HtmlSyntax : SyntaxParser , IReplacePattern {

		/// <summary>
		/// This should be the html element that the Open/CloseSyntax characters should be
		/// interpreted as.
		/// </summary>
		public string OpenHtml { get; set; }
		/// <summary>
		/// This should be the html element that the Open/CloseSyntax characters should be
		/// interpreted as.
		/// </summary>
		public string CloseHtml { get; set; }

		#region ISyntaxParser Members

		public string ReplacePattern() {
			return @"" + OpenHtml + "$" + ContentGroup.ToString() + CloseHtml + "";
		}

		#endregion
	}


}
