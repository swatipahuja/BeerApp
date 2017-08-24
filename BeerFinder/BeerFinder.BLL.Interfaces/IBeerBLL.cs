using System;
using BeerFinder.Shared.RequestMsg;
using BeerFinder.Shared.ResponseMsg;

namespace BeerFinder.BLL.Interfaces
{
	public interface IBeerBLL : IBLL, IDisposable
	{
		/// <summary>
		/// Gets search result and filters for the beers
		/// </summary>
		/// <param name="requestMsg">Request message</param>
		/// <returns>Response object with data required by the view</returns>
		BeerResponseMsg GetBeerData(BeerRequestMsg requestMsg);
	}
}
