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
	public class CategoryRepository : IRepository<Category>
	{
		private StoreContext db;
		public CategoryRepository(StoreContext storeContext)
		{
			this.db = storeContext;
		}
		public void Create(Category category)
		{
			//db.Categories.Add(category);
			db.Entry(category).State = EntityState.Added;
			db.SaveChanges();
		}

		public void Delete(int id)
		{
			Category _category = db.Categories.Find(id);
			if (_category != null)
			{
				db.Categories.Remove(_category);
			}
			db.SaveChanges();
		}

		public IEnumerable<Category> Find(Expression<Func<Category, bool>> predicate)
		{
			return db.Categories.Where(predicate);
		}

		public Category Get(int id)
		{
			return db.Categories.Find(id);
		}

		public IEnumerable<Category> GetAll()
		{
			return db.Categories;
		}

		public void Update(Category category)
		{
			db.Entry(category).State = EntityState.Modified;
			//db.SaveChanges();
		}
	}
}
