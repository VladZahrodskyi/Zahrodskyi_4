using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
	public class CityDTO
	{
		public int CityID { get; set; }
		public string CityName { get; set; }
		public int CityIndex { get; set; }

		public  ICollection<SupplierDTO> Suppliers { get; set; }
	}
}
