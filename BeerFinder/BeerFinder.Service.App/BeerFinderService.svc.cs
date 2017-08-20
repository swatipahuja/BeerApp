using BeerFinder.BLL;
using BeerFinder.BLL.Interfaces;
using BeerFinder.Shared.RequestMsg;
using BeerFinder.Shared.ResponseMsg;
using Newtonsoft.Json;

namespace BeerFinder.Service.App
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BeerFinderService" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select BeerFinderService.svc or BeerFinderService.svc.cs at the Solution Explorer and start debugging.
	public class BeerFinderService : IBeerFinderService
	{
		
		public string GetBeerData(string requestMsg)
		{
			BeerResponseMsg result = new BeerResponseMsg();
			using (IBeerBLL beerBL = new BeerBLL())
			{
				result = beerBL.GetBeerData(new BeerRequestMsg() { SearchString = requestMsg });
				//result = beerBL.GetBeerData(JsonConvert.DeserializeObject<BeerRequestMsg>(requestMsg));
			}
			return JsonConvert.SerializeObject(result);
		}
	}
}
