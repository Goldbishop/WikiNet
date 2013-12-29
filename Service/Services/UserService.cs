using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.Domain;
using Wiki.Repository;

namespace Wiki.Service {
	public interface IUserService {
		//Create User Information
		User Create( Int16 role , string email , string display );
		User Create( Int16 role , string email , string display , string fname , string lname );
		User Create( Int16 role , string email , string display , string fname , string lname , string street1 , string street2 , string city , string state , string country , string zip );

		//Edit User Information
		User Edit( Guid id , string display );
		User Edit( Guid id , string display , string fname , string lname );
		User Edit( Guid id , string display , string fname , string lname , string street1 , string street2 , string city , string state , string zip , string country );

		//Delete User Information
		void Delete( Guid id );

		//TODO:User Verify
		User Verify( string email );
	}

	public class UserService : IUserService {
		public UserService() { }

		public IUserRepository UserRepository { get; set; }
		public IUserDetailsRepository UserDetailsRepository { get; set; }

		#region IUserService Members
		//Create User Information
		public User Create( Int16 role , string email , string display ) {
			var user = new User() {
				RoleID = role ,
				Email = email ,
				Display = display ,
				Verified = false
			};

			UserRepository.Add( user );
			UserRepository.Save();

			return user;
		}
		public User Create( Int16 role , string email , string display , string fname , string lname ) {
			var user = Create( role , email , display , fname , lname , null , null , null , null , null , null );

			return user;
		}
		public User Create( Int16 role , string email , string display , string fname , string lname , string street1 , string street2 , string city , string state , string country , string zip ) {
			var user = Create( role , email , display );

			var userdetails = new UserDetails() {
				UserID = user.Id ,
				FirstName = fname ,
				LastName = lname ,
				Street1 = street1 ,
				Street2 = street2 ,
				City = city ,
				State = state ,
				Zip = zip ,
				Country = country
			};

			UserDetailsRepository.Add( userdetails );
			UserDetailsRepository.Save();

			return user;
		}

		//Edit User Information
		public User Edit( Guid id , string display ) {
			var user = UserRepository.FindById( id );

			user.Display = display;

			UserRepository.Save();

			return user;
		}
		public User Edit( Guid id , string display , string fname , string lname ) {
			return Edit( id , display , fname , lname , null , null , null , null , null , null );
		}
		public User Edit( Guid id , string display , string fname , string lname , string street1 , string street2 , string city , string state , string zip , string country ) {
			var user = Edit( id , display );

			if( fname != user.Details.FirstName && lname != user.Details.LastName ) {
				var userdetails = UserDetailsRepository.FindByUserId( user.Id );
				userdetails.FirstName = fname;
				userdetails.LastName = lname;

				if( street1 != userdetails.Street1 )
					userdetails.Street1 = street1;

				if( street2 != userdetails.Street2 )
					userdetails.Street2 = street2;

				if( city != userdetails.City )
					userdetails.City = city;

				if( state != userdetails.State )
					userdetails.State = state;

				if( zip != userdetails.Zip )
					userdetails.Zip = zip;

				if( country != userdetails.Country )
					userdetails.Country = country;

				UserDetailsRepository.Save();
			}
			return user;

		}

		//Delete User Information
		public void Delete( Guid id ) {
			var user = UserRepository.FindById( id );
			user.Active = false;

			UserRepository.Save();
		}

		//TODO:User Verify
		public User Verify( string email ) {
			var user = UserRepository.FindByEmail( email );
			user.Verified = true;

			UserRepository.Save();
			return user;
		}
		#endregion
	}
}
