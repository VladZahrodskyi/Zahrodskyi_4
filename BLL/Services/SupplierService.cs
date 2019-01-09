using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Zahrodskyi_4.DAL.Interfaces;
using Zahrodskyi_4.DAL.Entities;
using BLL.Infrastructure;
using System.Linq;

namespace BLL.Services
{
	public class SupplierService : ISupplierService
	{
		IUnitOfWork uow;
		IMapper mapper;

		public SupplierService(IUnitOfWork unitOfWork)
		{
			if (unitOfWork != null)
				this.uow = unitOfWork;
			MapperConfiguration configuration = new MapperConfiguration(cnfg =>
			{
				cnfg.CreateMap<Category, CategoryDTO>();
				cnfg.CreateMap<City, CityDTO>();
				cnfg.CreateMap<Good, GoodDTO>();
				cnfg.CreateMap<Supplier, SupplierDTO>();
			});

			mapper = configuration.CreateMapper();
		}
		public void Create(SupplierDTO supplier)
		{
			if (supplier == null)
			{
				throw new ValidationException("", "You try creating the nullable instanse of new Supplier");
			}
			try
			{
				Supplier newSupplier = mapper.Map<Supplier>(supplier);
				uow.Suppliers.Create(newSupplier);
			}
			catch (Exception ex)
			{
				throw new ValidationException(ex.Message, ex, "Cannot create an instance of new Supplier");
			}
		}

		public void Delete(int supplierId)
		{
			try
			{
				uow.Suppliers.Delete(supplierId);
			}
			catch (Exception ex)
			{

				throw new ValidationException(ex.Message, ex, $"Cannot delete an instance of SupplierId - {supplierId}");
			}

		}

		public IEnumerable<SupplierDTO> GetAll()
		{
			IEnumerable<SupplierDTO> suppliers;
			try
			{

				suppliers = mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierDTO>>(
				uow.Suppliers.GetAll()
				);
			}
			catch (Exception ex)
			{
				throw new ValidationException(ex.Message, ex, "Cannot send all instances of  Suppliers");
			}
			
			return suppliers;

			// return mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierDTO>>(
			// uow.Suppliers.GetAll()
			// );
		}



		public IEnumerable<SupplierDTO> GetAll(Expression<Func<SupplierDTO, bool>> predicate)
		{
			Expression < Func<Supplier, bool>> newPredicate = mapper
				.Map< Expression<Func<Supplier, bool>>>(predicate);
			try
			{
				return mapper
				.Map<IEnumerable<Supplier>, IEnumerable<SupplierDTO>>(
				uow.Suppliers.Find(newPredicate)
				);
			}
			catch (Exception ex)
			{

				throw new ValidationException(ex.Message, ex, "Cannot send instances of Suppliers");
			}

		}

		public SupplierDTO GetById(int id)
		{
			try
			{
				return mapper.
				Map<Supplier, SupplierDTO>(
				uow.Suppliers.Get(id)
				);
			}
			catch (Exception ex)
			{
				throw new ValidationException(ex.Message, ex, "Cannot send the instance of Supplier");
			}

		}

		public IEnumerable<SupplierDTO> GetSuppliersFromCategory(string category)
		{
			try
			{
				
				return mapper.
				Map<IEnumerable<Supplier>, IEnumerable<SupplierDTO>>(
				uow.Goods.GetAll()
				.Where(x=>x.Category.Name.ToUpper() == category.ToUpper())
				.Select(x=>x.Supplier)
				.Distinct());
			}
			catch (Exception ex)
			{

				throw new ValidationException(ex.Message, ex, "Cannot send all instances of  Suppliers");
			}
			
		}


		public void Update(SupplierDTO supplier)
		{
			Supplier updatedSupplier = mapper.Map<SupplierDTO, Supplier>(supplier);
			try
			{
				uow.Suppliers.Update(updatedSupplier);
			}
			catch (Exception ex)
			{

				throw new ValidationException(ex.Message, ex, $"Cannot update an instance of Supplier - {supplier.SupplierID}, {supplier.Name} ");
			}
			
		}

		#region IDisposable Support
		private bool disposedValue = false; // To detect redundant calls

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					uow.Dispose();
					
					// TODO: dispose managed state (managed objects).
				}

				// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
				// TODO: set large fields to null.

				disposedValue = true;
			}
		}

		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		// ~SupplierService() {
		//   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
		//   Dispose(false);
		// }

		// This code added to correctly implement the disposable pattern.
		public void Dispose()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(true);
			// TODO: uncomment the following line if the finalizer is overridden above.
			// GC.SuppressFinalize(this);
		}
		#endregion
	}
}
