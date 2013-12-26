using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.Domain {
	public class Namespace : INamespace {

		public Namespace() {
			this.Articles = new HashSet<Article>();
		}


		#region INamespace Members

		public Guid Id { get; set; }
		public string Name { get; set; }

		public virtual ICollection<Article> Articles { get; set; }

		#endregion
	}

	public interface INamespace {
		Guid Id { get; set; }
		string Name { get; set; }

		ICollection<Article> Articles { get; set; }
	}
}
