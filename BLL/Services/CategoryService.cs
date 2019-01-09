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
namespace BLL.Services
{
	public class CategoryService : ICategoryService
	{
		IUnitOfWork uow;
		IMapper mapper;

		public CategoryService(IUnitOfWork unitOfWork)
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
		public void Create(CategoryDTO category)
		{
			if (category == null)
			{
				throw new ValidationException("", "You try creating the nullable instanse of new Category");
			}
			try
			{
				Category newCategory = mapper.Map<Category>(category);
				uow.CategoryGoods.Create(newCategory);
			}
			catch (Exception ex)
			{
				throw new ValidationException(ex.Message, ex, "Cannot create an instance of new Category");
			}
		}
		public void Delete(int categoryId)
		{
			try
			{
				uow.CategoryGoods.Delete(categoryId);
			}
			catch (Exception ex)
			{
				throw new ValidationException(ex.Message, ex, "Cannot delete an instance of new Category");
			}
			
		}
		public IEnumerable<CategoryDTO> GetAll()
		{
			IEnumerable<CategoryDTO> categories;
			try
			{
				categories = mapper.Map<IEnumerable<CategoryDTO>>(uow.CategoryGoods.GetAll());
			}
			catch (Exception ex)
			{
				throw new ValidationException(ex.Message, ex, "Cannot get instances of Categories");
			}
			return categories;
		}

		public IEnumerable<CategoryDTO> Find(Expression<Func<CategoryDTO, bool>> predicate)
		{
			IEnumerable<CategoryDTO> categories;
			Expression<Func<Category, bool>> newPredicate;
			try
			{
				newPredicate = mapper.Map<Expression<Func<Category, bool>>>(predicate);
				categories = mapper.Map<IEnumerable<CategoryDTO>>(uow.CategoryGoods.Find(newPredicate));
			}
			catch (Exception ex)
			{
				throw new ValidationException(ex.Message, ex, "Cannot find instances of new Categories");
			}
			return categories;
		}

		public CategoryDTO GetById(int id)
		{
			CategoryDTO category;
			try
			{
				category = mapper.Map<CategoryDTO>(uow.CategoryGoods.Get(id));
			}
			catch (Exception ex)
			{
				throw new ValidationException(ex.Message, ex, "Cannot get instances of Categories");
			}
			return category;
		}
		public void Update(CategoryDTO category)
		{
			Category newCategory;
			try
			{
				newCategory = mapper.Map<Category>(category);
				uow.CategoryGoods.Update(newCategory);
			}
			catch (Exception ex)
			{

				throw new ValidationException(ex.Message, ex, "Cannot update instancw of the Category");
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
		// ~CategoryService() {
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
