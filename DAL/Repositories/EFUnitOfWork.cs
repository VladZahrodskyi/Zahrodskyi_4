using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zahrodskyi_4.DAL.Entities;
using Zahrodskyi_4.DAL.Interfaces;
using Zahrodskyi_4.DAL.EF.Context;
namespace Zahrodskyi_4.DAL.Repositories
{
	public class EFUnitOfWork : IUnitOfWork
	{
		private StoreContext db;
		private CategoryRepository CategoryRepository;
		private CityRepository CityRepository;
		private GoodRepository GoodRepository;
		private SupplierRepository SupplierRepository;
		

		public EFUnitOfWork(string connectionString)
		{
			db = new StoreContext(connectionString);
		} 

		public IRepository<Good> Goods
		{
			get
			{
				if (GoodRepository == null)
					GoodRepository = new GoodRepository(db);
				return GoodRepository;
			}
		}

		public IRepository<Supplier> Suppliers
		{
			get
			{
				if (SupplierRepository == null)
					SupplierRepository = new SupplierRepository(db);
				return SupplierRepository;
			}
		}

		public IRepository<Category> CategoryGoods
		{
			get
			{
				if (CategoryRepository == null)
					CategoryRepository = new CategoryRepository(db);
				return CategoryRepository;
			}
		}

		public IRepository<City> Cities
		{
			get
			{
				if (CityRepository == null)
					CityRepository = new CityRepository(db);
				return CityRepository;
			}
		}

		public void Save()
		{
			db.SaveChanges();
		}
		#region IDisposable Support
		private bool disposedValue = false; // To detect redundant calls

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					db.Dispose();
					//this.CategoryRepository=null;
					//this.CityRepository = null;
					//this.GoodRepository = null;
					//this.SupplierRepository = null;
					// TODO: dispose managed state (managed objects).
				}

				// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
				// TODO: set large fields to null.

				this.disposedValue = true;
			}
		}

		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		// ~EFUnitOfWork() {
		//   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
		//   Dispose(false);
		// }

		// This code added to correctly implement the disposable pattern.
		public void Dispose()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(true);
			// TODO: uncomment the following line if the finalizer is overridden above.
			GC.SuppressFinalize(this);
		}
		#endregion
	}
}
