using System;
using BeerFinder.Shared.ResponseMsg;

namespace BeerFinder.BLL.Interfaces
{
	public interface IGlasswareBLL: IBLL, IDisposable
	{
		/// <summary>
		/// Gets glassware filter data
		/// </summary>
		/// <returns>Response object with data required by the view</returns>
		GlasswareResponseMsg GetGlasswareFilterData();
	}
}
