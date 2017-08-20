using System;
using BeerFinder.Shared.RequestMsg;
using BeerFinder.Shared.ResponseMsg;

namespace BeerFinder.DAL.Interfaces
{
	public interface IBeerDAL:IDAL, IDisposable
	{
		BeerResponseMsg GetBeerData(BeerRequestMsg requestMsg);
	}
}
