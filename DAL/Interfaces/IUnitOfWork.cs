using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zahrodskyi_4.DAL.Entities;

namespace Zahrodskyi_4.DAL.Interfaces
{
	public interface IUnitOfWork:IDisposable
	{
		IRepository<Good> Goods { get; }
		IRepository<Supplier> Suppliers { get; }
		IRepository<Category> CategoryGoods { get; }
		IRepository<City> Cities { get; }
	}
}
