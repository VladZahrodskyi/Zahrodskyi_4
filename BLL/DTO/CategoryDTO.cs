﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
	public class CategoryDTO
	{
		public int CategoryID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }


		public  ICollection<GoodDTO> Goods { get; set; }
	}
}
