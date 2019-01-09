using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using Zahrodskyi_4.DAL.Entities;
using Zahrodskyi_4.DAL.Interfaces;
using Zahrodskyi_4.DAL.EF.Context;
namespace Zahrodskyi_4.DAL.Repositories
{
	public class SupplierRepository : IRepository<Supplier>
	{
		private StoreContext db;

		public SupplierRepository(StoreContext storeContext)
		{
			this.db = storeContext;
		}
		public void Create(Supplier supplier)
		{
			db.Suppliers.Add(supplier);
			db.SaveChanges();
		}
		
		public void Delete(int id)
		{
			Supplier _supplier = db.Suppliers.Find(id);
			if (_supplier != null)
			{
				db.Suppliers.Remove(_supplier);
			}
			db.SaveChanges();
		}

		public IEnumerable<Supplier> Find(Expression<Func<Supplier, bool>> predicate)
		{
			return db.Suppliers.Where(predicate);
		}

		public Supplier Get(int id)
		{
			return db.Suppliers.Find(id);
		}

		public IEnumerable<Supplier> GetAll()
		{
			return db.Suppliers;
		}

		public void Update(Supplier supplier)
		{
			db.Entry(supplier).State = EntityState.Modified;
			//db.SaveChanges();
		}
	}
}
