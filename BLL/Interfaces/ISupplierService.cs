using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTO;
using System.Linq.Expressions;
using System.Linq;
namespace BLL.Interfaces
{
	public interface ISupplierService:IDisposable
	{

		void Create(SupplierDTO supplier);
		void Update(SupplierDTO supplier);
		void Delete(int supplierId);

		//SupplierDTO GetSingle(Expression<Func<SupplierDTO, bool>> predicate);//Need?
		SupplierDTO GetById(int id);

		IEnumerable<SupplierDTO> GetAll();
		IEnumerable<SupplierDTO> GetAll(Expression<Func<SupplierDTO, bool>> predicate);
		IEnumerable<SupplierDTO> GetSuppliersFromCategory(string category);//int?
	}
}
