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
	//public class MyStoreDbInitializer : DropCreateDatabaseIfModelChanges<StoreContext>
	public class MyStoreDbInitializer : DropCreateDatabaseAlways<StoreContext>
	//public class MyStoreDbInitializer: CreateDatabaseIfNotExists<StoreContext>
	{
		protected override void Seed(StoreContext db)
		{
			
			List<City> cities = new List<City>()
			{
				new City {CityID=1,  CityIndex = 01001, CityName = "New York" },
				new City {CityID=2, CityIndex = 01002, CityName = "Lass Vegas" }
			};
			db.Cities.AddRange(cities);

			List<Category> category_goods = new List<Category>()
			{
				new Category {CategoryID=1,  Name = "Phone", Description = "!!!!!!!!" },
				new Category { CategoryID=2 ,Name = "Clothes", Description = "!!!!!!!!" }
			};
			db.Categories.AddRange(category_goods);

			List<Supplier> suppliers = new List<Supplier>()
			{
				new Supplier
				{
					Name = "PhoneSeller",
					SupplierID = 1,
					City = cities[0],
					Goods = new List<Good>()
					{
						new Good {GoodID = 1, Category = category_goods[0],  Brand = "Nokia",Model = "N5", Price = 1005 },
						new Good {GoodID=2 ,Category = category_goods[0],  Brand = "Apple",Model = "Iphone X", Price = 789 }
					}
				},
				new Supplier
				{
					Name = "ClothSeller",
					SupplierID = 2,
					City=cities[1],
					Goods = new List<Good>()
					{
						new Good{GoodID=3,Category= category_goods[1], Brand = "Adidas",Model="KA5ER",Description="Original",Price =120,  },
						new Good{GoodID=4,Category= category_goods[1],  Brand = "Nike",Model="ER",Description="Bionic",Price =180, }
					}
				}
			};
			db.Suppliers.AddRange(suppliers);



			db.SaveChanges();
			base.Seed(db);
		}
	}
}
