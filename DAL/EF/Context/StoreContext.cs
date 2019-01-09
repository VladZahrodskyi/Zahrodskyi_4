using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using Zahrodskyi_4.DAL.EF.Configurations;
using Zahrodskyi_4.DAL.Entities;

using Zahrodskyi_4.DAL.EF.Context;

namespace Zahrodskyi_4.DAL.EF.Context
{
	public class StoreContext:DbContext
	{
		public StoreContext()
		{
			Database.SetInitializer(new MyStoreDbInitializer());
			//Database.Delete();
		}

		public StoreContext(string connectingString) : base(connectingString)
		{
			Database.SetInitializer(new MyStoreDbInitializer());
			//Database.Delete();
		}

		public  DbSet<Supplier> Suppliers { get; set; }
		public  DbSet<Good> Goods { get; set; }
		public  DbSet<City> Cities { get; set; }
		public  DbSet<Category> Categories { get; set; }

		protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
		{
			base.OnModelCreating(dbModelBuilder);

			dbModelBuilder.Configurations.Add(new GoodConfig());
			dbModelBuilder.Configurations.Add(new CategoryConfig());
			dbModelBuilder.Configurations.Add(new CityConfig());
			dbModelBuilder.Configurations.Add(new SupplierConfig());

		}
	}
	
	
}
