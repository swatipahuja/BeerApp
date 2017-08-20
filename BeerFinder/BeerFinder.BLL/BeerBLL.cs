using BeerFinder.BLL.Interfaces;
using BeerFinder.DAL;
using BeerFinder.DAL.Interfaces;
using BeerFinder.Shared.DTO;
using BeerFinder.Shared.RequestMsg;
using BeerFinder.Shared.ResponseMsg;

namespace BeerFinder.BLL
{
	public class BeerBLL : BaseBLL, IBeerBLL
	{
		public BeerResponseMsg GetBeerData(BeerRequestMsg requestMsg)
		{
			BeerResponseMsg result = new BeerResponseMsg();
			using (IBeerDAL beerDAL = new BeerDAL())
			{
				result = beerDAL.GetBeerData(requestMsg);
			}
			result = PopulateFiltersData(result);
			return result;
		}

		private BeerResponseMsg PopulateFiltersData(BeerResponseMsg data)
		{
			foreach (BeerDto item in data.Beers)
			{
				if (item.Categories != null)
				{
					data.Categories.Add(item.Categories);
				}
				if (item.GlassWare != null)
				{
					data.GlassWare.Add(item.GlassWare);
				}
				if (item.Style != null)
				{
					data.Styles.Add(item.Style);
				}
			}
			return data;
		}
	}
}
