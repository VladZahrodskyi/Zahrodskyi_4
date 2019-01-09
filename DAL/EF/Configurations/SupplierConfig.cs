using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Zahrodskyi_4.DAL.Entities;

namespace Zahrodskyi_4.DAL.EF.Configurations
{
	class SupplierConfig : EntityTypeConfiguration<Supplier>
	{
		public SupplierConfig()
		{
			//General Properties
			this.HasKey(p=>p.SupplierID);
			this.Property(p => p.Name).HasMaxLength(100).IsRequired();

			//TODO: Reference Properties
			this.HasMany<Good>(p => p.Goods)
				.WithRequired(g => g.Supplier);
			
		}
	}
}
