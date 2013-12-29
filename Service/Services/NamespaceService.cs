using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.Domain;
using Wiki.Repository;

namespace Wiki.Service {
	public interface INamespaceService {
		Namespace Create( string name , string description );
		Namespace Edit( int id , string description );
		void Delete( int id );
	}

	public class NamespaceService : INamespaceService {
		public NamespaceService() { }

		public INamespaceRepository NamespaceRepository { get; set; }

		#region INamespaceService Members

		public Namespace Create( string name , string description ) {
			var ns = new Namespace() {
				Name = name,
				Description = description,
				Active = true 
			};

			NamespaceRepository.Add( ns );
			NamespaceRepository.Save();

			return ns;
		}

		public Namespace Edit( int id , string description ) {
			var ns = NamespaceRepository.FindById( id );

			if( description != ns.Description ) {
				ns.Description = description;

				NamespaceRepository.Save();
			}

			return ns;
		}

		public void Delete( int id ) {
			var ns = NamespaceRepository.FindById( id );

			if( ns != null ) {
				ns.Active = false;

				NamespaceRepository.Save();
			}
		}

		#endregion
	}
}
