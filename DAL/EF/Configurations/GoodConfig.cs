using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Zahrodskyi_4.DAL.Entities;

namespace Zahrodskyi_4.DAL.EF.Configurations
{
	class GoodConfig:EntityTypeConfiguration<Good>
	{
		public GoodConfig()
		{
			//General Properties
			this.HasKey(h=>h.GoodID);
			this.Property(p => p.Description).HasMaxLength(1000).IsOptional();
			this.Property(p => p.Brand).HasMaxLength(100).IsRequired();
			this.Property(p => p.Model).HasMaxLength(50).IsRequired();
			this.Property(p => p.Price).IsRequired();
			
			//TODO: Reference Properties
			//All was setting in other Classes

		}
	}
}
