using System.Collections.Generic;
using BeerFinder.Shared.DTO;

namespace BeerFinder.BLL.Interfaces
{
	public interface IBeerBLL:IBLL
	{
		List<BeerDto> GetBeerData(string queryString);
	}
}
