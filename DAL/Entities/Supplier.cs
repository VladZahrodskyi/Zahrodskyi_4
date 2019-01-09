using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zahrodskyi_4.DAL.Entities

{
	public class Supplier
	{
		public int SupplierID { get; set; }
		public string Name { get; set; }
		public City City { get; set; }
		public virtual ICollection<Good> Goods { get; set; }

		public Supplier()
		{
			if (Goods == null)
			{
				Goods = new List<Good>();
			}
		}

	}
}
