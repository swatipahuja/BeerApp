using System.Collections.Generic;
using BeerFinder.BLL.Interfaces;
using BeerFinder.DAL;
using BeerFinder.DAL.Interfaces;
using BeerFinder.Shared.DTO;

namespace BeerFinder.BLL
{
	public class BeerBLL : BaseBLL, IBeerBLL
	{
		public List<BeerDto> GetBeerData(string queryString)
		{
			List<BeerDto> result = new List<BeerDto>();
			using (IBeerDAL beerDAL = new BeerDAL())
			{
				result = beerDAL.GetBeerData(queryString);
			}
			return result;
		}
	}
}
