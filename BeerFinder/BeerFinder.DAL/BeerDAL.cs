using System;
using System.Collections.Generic;
using BeerFinder.DAL.Interfaces;
using BeerFinder.Shared.DTO;

namespace BeerFinder.DAL
{
	public class BeerDAL : IBeerDAL
	{
		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public List<BeerDto> GetBeerData(string queryString)
		{
			List<BeerDto> result = new List<BeerDto>();
			return result;
		}
	}
}
