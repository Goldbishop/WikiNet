using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Wiki.Domain.Parsers {
	public interface IReplacePattern {
		string ReplacePattern();
	}

	public interface ISyntaxParser {
		string Parse( string content );
	}

	/// <summary>
	/// 
	/// </summary>
	public abstract class SyntaxParser {
		public SyntaxParser() {
			//Default Values for Some properties
			ContentGroup = 1;
			IsLineBased = false;
			IsContainer = false;
		}

		/// <summary>
		/// This can be either a Regex Group syntax or normal straigh character identifier(s)
		/// Make sure to use ContentGroup if you make the Open & Close Syntax in Regex form.
		/// </summary>
		public string OpenSyntax { get; set; }
		/// <summary>
		/// This can be either a Regex Group syntax or normal straigh character identifier(s)
		/// Make sure to use ContentGroup if you make the Open & Close Syntax in Regex form.
		/// </summary>
		public string CloseSyntax { get; set; }
		public byte ContentGroup { get; set; }
		/// <summary>
		/// Will the Syntax pattern only be valid if on a single line?
		/// </summary>
		public bool IsLineBased { get; set; }
		/// <summary>
		/// Is the Syntax pattern the container for more patterns?
		/// </summary>
		public bool IsContainer { get; set; }

		public virtual Regex SyntaxPattern {
			get {
				if( string.IsNullOrWhiteSpace( CloseSyntax ) )
					return new Regex( @"" + OpenSyntax + "(.*)" );
				else
					return new Regex( @"" + OpenSyntax + "(.*)" + CloseSyntax + "" );
			}
		}

	}
}
