using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Zahrodskyi_4.DAL.Interfaces
{
	public interface IRepository<T> where T : class
	{
		void Create(T item);
		void Update(T item);
		void Delete(int id);

		T Get(int id);

		IEnumerable<T> Find(Expression<Func<T, Boolean>> predicate);

		IEnumerable<T> GetAll();
	}
}
