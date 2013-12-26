using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wiki.Domain {
	public class RoleAccess : IRoleAccess {
		#region IRoleAccess Members

		public short RoleID { get; set; }
		public int NamespaceID { get; set; }
		public bool Edit { get; set; }
		public bool View { get; set; }
		public bool Move { get; set; }
		public bool Delete { get; set; }
		
		//Navigation Properties
		public Role Role { get; set; }
		public Namespace Namespace { get; set; }

		#endregion
	}

	public interface IRoleAccess {
		Int16 RoleID { get; set; }
		int NamespaceID { get; set; }
		bool Edit { get; set; }
		bool View { get; set; }
		bool Move { get; set; }
		bool Delete { get; set; }

		//Navigation Properties
		Role Role { get; set; }
		Namespace Namespace { get; set; }
	}
}
