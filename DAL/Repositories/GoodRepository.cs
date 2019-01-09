using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Zahrodskyi_4.DAL.Interfaces;
using Zahrodskyi_4.DAL.Entities;
using Zahrodskyi_4.DAL.EF.Context;
namespace Zahrodskyi_4.DAL.Repositories
{
	public class GoodRepository : IRepository<Good>
	{
		private StoreContext db;

		public GoodRepository(StoreContext storeContext)
		{
			this.db = storeContext;
		}
		public void Create(Good good)
		{
			db.Goods.Add(good);
			db.SaveChanges();
		}

		public void Delete(int id)
		{
			Good _good = db.Goods.Find(id);
			if (_good != null)
			{
				db.Goods.Remove(_good);
			}
			db.SaveChanges();
		}

		public IEnumerable<Good> Find(Expression<Func<Good, bool>> predicate)
		{
			return db.Goods.Where(predicate);
		}

		public Good Get(int id)
		{
			return db.Goods.Find(id);
		}

		public IEnumerable<Good> GetAll()
		{
			return db.Goods;
		}

		public void Update(Good good)
		{
			db.Entry(good).State = EntityState.Modified;
			//db.SaveChanges();
		}
	}
}
