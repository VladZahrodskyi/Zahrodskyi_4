using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Zahrodskyi_4.DAL.Interfaces;
using Zahrodskyi_4.DAL.Entities;
using BLL.Infrastructure;

namespace BLL.Services
{
	public class GoodService : IGoodService
	{
		IUnitOfWork uow;
		IMapper mapper;

		public GoodService(IUnitOfWork unitOfWork)
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

		public void Create(GoodDTO good)
		{
			if (good == null)
			{
				throw new ValidationException("", "You try creating the nullable instanse of Good");
			}
			try
			{
				Good newGood = mapper.Map<Good>(good);
				uow.Goods.Create(newGood);
			}
			catch (Exception ex)
			{
				throw new ValidationException(ex.Message, ex, "Cannot create an instance of Good");
			}
		}

		public void Delete(int goodId)
		{
			try
			{
				uow.Goods.Delete(goodId);
			}
			catch (Exception ex)
			{
				throw new ValidationException(ex.Message, ex, "Cannot delete an instance of Good");
			}
		}

		public IEnumerable<GoodDTO> GetAll()
		{
			IEnumerable<GoodDTO> goods;
			try
			{
				goods = mapper.Map<IEnumerable<Good>, IEnumerable<GoodDTO>>(uow.Goods.GetAll());
			}
			catch (Exception ex)
			{

				throw new ValidationException(ex.Message, ex, "Cannot send instances of Goods");
			}
			return goods;
		}
		public IEnumerable<GoodDTO> Find(Expression<Func<GoodDTO, bool>> predicate)
		{
			Expression<Func<Good, bool>> newPredicate = mapper.Map<Expression<Func<Good, bool>>>(predicate);
			IEnumerable<GoodDTO> goods;
			try
			{
				goods = mapper.Map<IEnumerable<GoodDTO>>(uow.Goods.Find(newPredicate));
			}
			catch (Exception ex)
			{
				throw new ValidationException(ex.Message, ex, "Cannot Find instances of Goods");
			}
			return goods;
		}

		public GoodDTO GetById(int id)
		{
			GoodDTO good;
			try
			{
				good = mapper.Map<Good, GoodDTO>(uow.Goods.Get(id));
			}
			catch (Exception ex)
			{

				throw new ValidationException(ex.Message, ex, "Cannot send an instance of Good");
			}
			return good;
		}

		public IEnumerable<GoodDTO> GetGoodsFromCategory(string category)
		{
			IEnumerable<GoodDTO> good;
			try
			{
				IEnumerable<Good> _good = uow.Goods.Find(n => n.Category.Name.ToUpper() == category.ToUpper());//We cannot have two same categories
				good = mapper.Map<IEnumerable<Good>, IEnumerable<GoodDTO>>(_good);
			}
			catch (Exception ex)
			{

				throw new ValidationException(ex.Message, ex, "Cannot send instances of Goods");
			}
			return good;
		}

		public IEnumerable<GoodDTO> GetGoodsWithMaxPrice()
		{
			try
			{
				decimal maxPrice = 0.0m;
				foreach (var item in uow.Goods.GetAll())
				{
					if (item.Price > maxPrice)
						maxPrice = item.Price;
				}
				//decimal price = uow.Goods.GetAll().Max(p => p.Price);
				return mapper.Map<IEnumerable<GoodDTO>>(uow.Goods.Find(x=>x.Price == maxPrice));
			}
			catch (Exception ex)
			{
				throw new ValidationException(ex.Message, ex, "Cannot send instances of Goods with Max Price");
			}
		}

		public IEnumerable<GoodDTO> GetGoodsFromSupplier(string supplier)
		{
			IEnumerable<GoodDTO> good;
			try
			{
				IEnumerable<Good> _good = uow.Goods.Find(n => n.Supplier.Name.ToUpper() == supplier.ToUpper());//We cannot have two same categories
				good = mapper.Map<IEnumerable<Good>, IEnumerable<GoodDTO>>(_good);
			}
			catch (Exception ex)
			{

				throw new ValidationException(ex.Message, ex, "Cannot send instances of Goods");
			}
			return good;
		}

		public IEnumerable<GoodDTO> GetGoodsWithMinPrice()
		{
			try
			{
				decimal price = uow.Goods.GetAll().Min(p => p.Price);
				return mapper.Map<IEnumerable<GoodDTO>>(uow.Goods.Find(x => x.Price == price));
			}
			catch (Exception ex)
			{
				throw new ValidationException(ex.Message, ex, "Cannot send instances of Goods with Max Price");
			}
		}

		//public IEnumerable<GoodDTO> GetGoodsWithMaxPriceAndLess(decimal maxPrice)
		//{
		//	IEnumerable<GoodDTO> good;
		//	try
		//	{
		//		IEnumerable<Good> _good = uow.Goods.Find(n => n.Price<=maxPrice);
		//		good = mapper.Map<IEnumerable<Good>, IEnumerable<GoodDTO>>(_good);
		//	}
		//	catch (Exception ex)
		//	{

		//		throw new ValidationException(ex.Message, ex, "Cannot send instances of Goods");
		//	}
		//	return good;
		//}

		//public IEnumerable<GoodDTO> GetGoodsWithMinPriceAndAbove(decimal minPrice)
		//{
		//	IEnumerable<GoodDTO> good;
		//	try
		//	{
		//		IEnumerable<Good> _good = uow.Goods.Find(n => n.Price <= minPrice);
		//		good = mapper.Map<IEnumerable<Good>, IEnumerable<GoodDTO>>(_good);
		//	}
		//	catch (Exception ex)
		//	{

		//		throw new ValidationException(ex.Message, ex, "Cannot send instances of Goods");
		//	}
		//	return good;
		//}

		//public GoodDTO GetSingle(Expression<Func<GoodDTO, bool>> predicate)
		//{
		//	throw new NotImplementedException();
		//}

		public void Update(GoodDTO good)
		{
			throw new NotImplementedException();
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
		// ~GoodService() {
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
