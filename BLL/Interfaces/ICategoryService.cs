using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTO;
using System.Linq.Expressions;

namespace BLL.Interfaces
{
	public interface ICategoryService:IDisposable
	{
		void Create(CategoryDTO category);
		void Update(CategoryDTO category);
		void Delete(int categoryId);

		CategoryDTO GetById(int id);

		//CategoryDTO GetSingle(Expression<Func<CategoryDTO, bool>> predicate);

		IEnumerable<CategoryDTO> GetAll();
		IEnumerable<CategoryDTO> Find(Expression<Func<CategoryDTO, bool>> predicate);
	}
}
