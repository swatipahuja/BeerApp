using System;
using BeerFinder.Shared.RequestMsg;
using BeerFinder.Shared.ResponseMsg;

namespace BeerFinder.BLL.Interfaces
{
	public interface IBeerBLL : IBLL, IDisposable
	{
		BeerResponseMsg GetBeerData(BeerRequestMsg requestMsg);
	}
}
