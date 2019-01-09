using System;
using System.Collections.Generic;
using System.Text;
using Zahrodskyi_4.DAL.Interfaces;
using Zahrodskyi_4.DAL.Repositories;
using BLL.Services;
using BLL.Interfaces;
using Zahrodskyi_4.DAL.EF.Context;

using Zahrodskyi_4.DAL.Entities;
using Ninject.Modules;

namespace BLL.Infrastructure 	
{
	public class ServiceModule : NinjectModule
	{
		private readonly string _connectionString;

		public ServiceModule(string connectionString)
		{
			_connectionString = connectionString;
		}

		public override void Load()
		{
			//Bind<StoreContext>().ToSelf().WithConstructorArgument(_connectionString);
			Bind<IUnitOfWork>().To<EFUnitOfWork>().InSingletonScope().WithConstructorArgument(_connectionString);
			Bind<IGoodService>().To<GoodService>().InSingletonScope();
			Bind<ICategoryService>().To<CategoryService>().InSingletonScope();
			Bind<ISupplierService>().To<SupplierService>().InSingletonScope();
			
			
		}
	}
}
