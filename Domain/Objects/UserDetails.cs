using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wiki.Domain {
	public class UserDetailsMap : DomainMap<UserDetails> {
		public UserDetailsMap() {
			ToTable( "User_Detail" );

			HasKey( ud => ud.UserID );

			Property(ud => ud.Street1).HasColumnName("street1");
			Property(ud => ud.Street2).HasColumnName("street2");
			Property(ud => ud.City).HasColumnName("city");
			Property(ud => ud.State).HasColumnName("state");
			Property(ud => ud.Country).HasColumnName("country");

			//TODO: Map Navigation Property
			Property(ud => ud.UserID).HasColumnName("uid")
				.IsRequired();
			Property(ud => ud.FirstName).HasColumnName("fname")
				.IsRequired();
			Property(ud => ud.LastName).HasColumnName("lname")
				.IsRequired();
			HasRequired( ud => ud.User )
				.WithRequiredPrincipal( u => u.Details );

		}
	}

	public interface IUserDetails {
		Guid UserID { get; set; }
		string FirstName { get; set; }
		string LastName { get; set; }
		string Street1 { get; set; }
		string Street2 { get; set; }
		string City { get; set; }
		string County { get; set; }
		string State { get; set; }
		string Country { get; set; }

		User User { get; set; }
	}

	public class UserDetails : IUserDetails {
		#region IUserDetails Members

		public Guid UserID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Street1 { get; set; }
		public string Street2 { get; set; }
		public string City { get; set; }
		public string County { get; set; }
		public string State { get; set; }
		public string Country { get; set; }

		public User User { get; set; }
		#endregion
	}

}
