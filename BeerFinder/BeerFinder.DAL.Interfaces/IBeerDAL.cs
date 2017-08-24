using System;
using BeerFinder.Shared.RequestMsg;
using BeerFinder.Shared.ResponseMsg;

namespace BeerFinder.DAL.Interfaces
{
	public interface IBeerDAL:IDAL, IDisposable
	{
		/// <summary>
		/// Gets search result and filters for the beers
		/// </summary>
		/// <param name="requestMsg">Request message</param>
		/// <returns>Response object with data required by the view</returns>
		BeerResponseMsg GetBeerData(BeerRequestMsg requestMsg);
	}
}
