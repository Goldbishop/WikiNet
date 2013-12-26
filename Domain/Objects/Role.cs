using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.Domain {
	public class Role : IRole {

		#region IRole Members

		public Int16 Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		public ICollection<User> Users { get; set; }
		public ICollection<RoleAccess> Access { get; set; }

		#endregion

	}

	public interface IRole {
		Int16 Id { get; set; }
		string Name { get; set; }
		string Description { get; set; }

		ICollection<User> Users { get; set; }
		ICollection<RoleAccess> Access { get; set; }
	}
}
