using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zahrodskyi_4.DAL.Entities
{
	public class City
	{
		public int CityID { get; set; }
		public string CityName { get; set; }
		public int CityIndex { get; set; }

		public virtual ICollection<Supplier> Suppliers { get; set; }


		public City()
		{
			Suppliers = new List<Supplier>();
		}
			
	}

}
