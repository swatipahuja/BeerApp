using System;
using BeerFinder.Shared.ResponseMsg;

namespace BeerFinder.DAL.Interfaces
{
	public interface ICategoryDAL : IDAL, IDisposable
	{
		/// <summary>
		/// Gets category filter data
		/// </summary>
		/// <returns>Response object with data required by the view</returns>
		CategoryResponseMsg GetCategoryFilterData();
	}
}
