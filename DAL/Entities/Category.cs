using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zahrodskyi_4.DAL.Entities
{
	public class Category
	{
		public int CategoryID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }


		public virtual ICollection<Good> Goods { get; set; }

		public Category()
		{
			Goods = new List<Good>();
		}
	}
}
