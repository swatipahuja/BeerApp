using System;
using BeerFinder.Shared.ResponseMsg;

namespace BeerFinder.BLL.Interfaces
{
	public interface ICategoryBLL: IBLL, IDisposable
	{
		/// <summary>
		/// Gets category filter data
		/// </summary>
		/// <returns>Response object with data required by the view</returns>
		CategoryResponseMsg GetCategoryFilterData();
	}
}
