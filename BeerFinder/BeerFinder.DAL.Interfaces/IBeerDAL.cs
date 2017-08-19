using System;
using System.Collections.Generic;
using BeerFinder.Shared.DTO;

namespace BeerFinder.DAL.Interfaces
{
	public interface IBeerDAL:IDAL, IDisposable
	{
		List<BeerDto> GetBeerData(string queryString);
	}
}
