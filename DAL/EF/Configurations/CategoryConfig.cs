using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Zahrodskyi_4.DAL.Entities;

namespace Zahrodskyi_4.DAL.EF.Configurations
{
	class CategoryConfig : EntityTypeConfiguration<Category>
	{
		public CategoryConfig()
		{
			//General Properties
			this.HasKey(p => p.CategoryID);
			this.Property(p => p.Description).HasMaxLength(300);
			this.Property(p => p.Name).HasMaxLength(50);

			//TODO: Reference Properties
			this.HasMany<Good>(p => p.Goods)
				.WithRequired(g=>g.Category);
			
		}
	}
}
