using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTO;
using System.Linq.Expressions;

namespace BLL.Interfaces
{
	public interface IGoodService:IDisposable
	{
		void Create(GoodDTO good);
		void Update(GoodDTO good);
		void Delete(int goodId);
		
		//GoodDTO GetSingle(Expression<Func<GoodDTO, bool>> predicate);
		GoodDTO GetById(int id);

		IEnumerable<GoodDTO> GetAll();
		IEnumerable<GoodDTO> Find(Expression<Func<GoodDTO, bool>> predicate);
		IEnumerable<GoodDTO> GetGoodsFromCategory(string category);
		IEnumerable<GoodDTO> GetGoodsFromSupplier(string supplier);
		IEnumerable<GoodDTO> GetGoodsWithMaxPrice();
		IEnumerable<GoodDTO> GetGoodsWithMinPrice();
		//IEnumerable<GoodDTO> GetGoodsWithMaxPriceAndLess(decimal maxPrice);
		//IEnumerable<GoodDTO> GetGoodsWithMinPriceAndAbove(decimal minPrice);
	}
}
