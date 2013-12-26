using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace Wiki.Domain {
	public class DomainMap<T> : EntityTypeConfiguration<T> where T : class { }
}
