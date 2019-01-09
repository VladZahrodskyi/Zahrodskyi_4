using System;
using System.Collections.Generic;
using System.Text;



namespace BLL.DTO
{
	public class SupplierDTO
	{
		public int SupplierID { get; set; }
		public string Name { get; set; }
		public  CityDTO City { get; set; }
		public  ICollection<GoodDTO> Goods { get; set; }
	}
}
