using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AutoMapper;
using Ninject;
using Ninject.Modules;
using BLL.Interfaces;
using BLL.Services;

namespace VisualConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			StandardKernel ninject = new StandardKernel(new BLL.Infrastructure.ServiceModule("StoreConnection"));

			ISupplierService supplier = ninject.Get<ISupplierService>();
			IGoodService good = ninject.Get<IGoodService>();
			ICategoryService category = ninject.Get<ICategoryService>();

			
			//#region First point "Get the list of goods of defined Category"

			//Console.WriteLine("First point \"Get the list of goods of defined Category\"\n");

			//Console.WriteLine("1.1		Get All Goods\n");
			//var goodsFromCategories = category.GetAll();
			//foreach (var categories in goodsFromCategories)
			//{
			//	foreach (var item in categories.Goods)
			//	{
			//		Console.WriteLine(
			//			$"{item.Category.CategoryID}-{item.Category.Name}-{item.Brand}-{item.Model}");
			//	}
			//}
			//Console.WriteLine("\n");
			//Console.WriteLine("1.2		Get goods by Id of Category\n");

			//var goodFromCategory = category.GetById(2);//Clothes
			//foreach (var item in goodFromCategory.Goods)
			//{
			//	Console.WriteLine($"{item.Brand}-{item.Model}");
			//}
			//Console.WriteLine("\n");
			//Console.WriteLine("1.3		Get goods by name of Category\n");
			//var goodsFromCategory = good.GetGoodsFromCategory("Phone");
			//foreach (var categories in goodsFromCategories)
			//{
			//	foreach (var item in categories.Goods)
			//	{
			//		Console.WriteLine(
			//			$"{item.Category.CategoryID}-{item.Category.Name}-{item.Brand}-{item.Model}");
			//	}
			//}
			//Console.WriteLine("\n");

			//#endregion

			//#region Second point "Define all Suppliers of Category"
			//Console.WriteLine("Second point \"Define all Suppliers of Category\"\n");
			//Console.WriteLine("2.1		Get Suppliers from Category By Id \n");
			//var categorySuppliers = category.GetById(1).Goods;
			//foreach (var item in categorySuppliers)
			//{
			//	Console.WriteLine($"{item.Supplier.Name}-{item.Supplier.City}");
			//}
			//Console.WriteLine("\n");
			//Console.WriteLine("2.2		Get Suppliers from Category By categoru name (Registed of literals is not important)\n");
			//Console.WriteLine("With upper");
			//var category_Suppliers1 = supplier.GetSuppliersFromCategory("Phone");
			//foreach (var item in category_Suppliers1)
			//{
			//	Console.WriteLine($"{item.SupplierID} - {item.Name} - {item.City.CityName}");
			//}
			//Console.WriteLine("\n");
			//OR
			//Console.WriteLine("__________OR_________");
			//Console.WriteLine("With all lower\n");
			//var category_Suppliers2 = supplier.GetSuppliersFromCategory("phone");
			//foreach (var item in category_Suppliers2)
			//{
			//	Console.WriteLine($"{item.SupplierID} - {item.Name} - {item.City.CityName}");
			//}
			//Console.WriteLine("\n");
			//#endregion
			//#region Third point "Define all Goods of Supplier"
			//Console.WriteLine("Third point \"Define all Goods of Supplier\"\n");
			//Console.WriteLine("3.1		Get suppliers goods by his Id\n");
			//var goodsOfSupplier = supplier.GetById(1).Goods;
			//foreach (var item in goodsOfSupplier)
			//{
			//	Console.WriteLine($"{item.Supplier.Name} - {item.Brand} - {item.Model}");
			//}
			//Console.WriteLine("\n");
			//Console.WriteLine("3.2		Get suppliers goods by his name\n");
			//var goodsofSupplier = good.GetGoodsFromSupplier("ClothSeller");
			//foreach (var item in goodsofSupplier)
			//{
			//	Console.WriteLine($"{item.Supplier.Name} - {item.Brand} - {item.Model}");
			//}
			//Console.WriteLine("\n");
			//#endregion
			//#region Second point "To Find some goods by criteria"
			//Console.WriteLine("Second point \"To Find some goods by criteria\"\n");
			//Console.WriteLine("4.1		MAX PRICE\n");
			//var goodsMaxPrice = good.GetGoodsWithMaxPrice();
			//foreach (var item in goodsMaxPrice)
			//{
			//	Console.WriteLine($"Goods with max price - {item.Brand} - {item.Model} - {item.Price}");
			//}
			//Console.WriteLine("\n");
			//Console.WriteLine("4.2		MIN PRICE\n");
			//var goodsMinPrice = good.GetGoodsWithMinPrice();
			//foreach (var item in goodsMinPrice)
			//{
			//	Console.WriteLine($"Goods with min price - {item.Brand} - {item.Model} - {item.Price}");
			//}
			//Console.WriteLine("\n");
			//Console.WriteLine("4.3		Goods from the City by id\n");
			//var goodsFromCity = good.Find(x => x.Supplier.City.CiteID == 2);
			//foreach (var item in goodsFromCity)
			//{
			//	Console.WriteLine($"Goods From {item.Supplier.City.CityName} - {item.Brand} - {item.Model}");
			//}
			//#endregion


			Console.ReadKey();
		}
	}
}
