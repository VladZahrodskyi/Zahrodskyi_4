using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using Zahrodskyi_4.DAL.Interfaces;
using Zahrodskyi_4.DAL.Entities;
using Zahrodskyi_4.DAL.EF.Context;
namespace Zahrodskyi_4.DAL.Repositories
{

	public class CityRepository : IRepository<City>
	{
		private StoreContext db;
		public CityRepository(StoreContext storeContext)
		{
			this.db = storeContext;
		}
		public void Create(City city)
		{
			db.Cities.Add(city);
			db.SaveChanges();
		}

		public void Delete(int id)
		{
			City _city = db.Cities.Find(id);
			if (_city != null)
			{
				db.Cities.Remove(_city);
			}
			db.SaveChanges();
		}

		public IEnumerable<City> Find(Expression<Func<City, bool>> predicate)
		{
			return db.Cities.Where(predicate).ToList();
		}

		public City Get(int id)
		{
			return db.Cities.Find(id);
		}

		public IEnumerable<City> GetAll()
		{
			return db.Cities;
		}

		public void Update(City city)
		{
			db.Entry(city).State = EntityState.Modified;
			//db.SaveChanges();
		}
	}
}
