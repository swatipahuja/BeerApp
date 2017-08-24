using System;
using BeerFinder.Shared.ResponseMsg;

namespace BeerFinder.DAL.Interfaces
{
	public interface IGlasswareDAL : IDAL, IDisposable
	{
		/// <summary>
		/// Gets glassware filter data
		/// </summary>
		/// <returns>Response object with data required by the view</returns>
		GlasswareResponseMsg GetGlasswareFilterData();
	}
}
