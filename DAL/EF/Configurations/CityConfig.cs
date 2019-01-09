using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Zahrodskyi_4.DAL.Entities;

namespace Zahrodskyi_4.DAL.EF.Configurations
{
	class CityConfig : EntityTypeConfiguration<City>
	{
		public CityConfig()
		{
			//General Properties
			this.HasKey(p => p.CityID);
			this.Property(p => p.CityName).HasMaxLength(200).IsRequired();
			this.Property(p=>p.CityIndex).IsRequired();
			
			//TODO: Reference Properties
			this.HasMany<Supplier>(p => p.Suppliers)
				.WithRequired(s => s.City);
				
						
				
		}
	}
}
