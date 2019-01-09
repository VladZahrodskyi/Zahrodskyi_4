using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zahrodskyi_4.DAL.Entities

{
	public class Good
	{
		public int GoodID { get; set; }
		public string Brand { get; set; }
		public string Model { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }

		public Category Category { get; set; }
		public Supplier Supplier { get; set; }
	}
}
