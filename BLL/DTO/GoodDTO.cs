using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
	public class GoodDTO
	{
		public int GoodID { get; set; }
		public string Brand { get; set; }
		public string Model { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }

		public  CategoryDTO Category { get; set; }
		public  SupplierDTO Supplier { get; set; }
	}
}
