using System;
using System.Collections.Specialized;
using System.Web;
using BeerFinder.BLL;
using BeerFinder.BLL.Interfaces;
using BeerFinder.Shared.RequestMsg;
using BeerFinder.Shared.ResponseMsg;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BeerFinder.Service.App
{
	public class BeerFinderService : IBeerFinderService
	{

		/// <summary>
		/// Gets search result and filters for the beers
		/// </summary>
		/// <param name="requestMsg">Request message</param>
		/// <returns>Response object with data required by the view</returns>
		public string GetBeerData(string searchQuery, string pageNumber, string categoryId, string glasswareId)
		{
			BeerResponseMsg result = new BeerResponseMsg();
			using (var beerBL = BLFactory.CreateBL<IBeerBLL>())
			{
				result = beerBL.GetBeerData(new BeerRequestMsg() {
					SearchString = searchQuery.Trim(),
					CategoryId = categoryId,
					GlasswareId = glasswareId,
					PageNumber = pageNumber
				});
			}
			return JToken.Parse(JsonConvert.SerializeObject(result)).ToString();
		}

		/// <summary>
		/// Gets category filter for  beers
		/// </summary>
		/// <returns>Response object with data required by the view</returns>
		public string GetCategoryFilterData()
		{
			CategoryResponseMsg result = new CategoryResponseMsg();
			using (var categoryFilterBL = BLFactory.CreateBL<ICategoryBLL>())
			{
				result = categoryFilterBL.GetCategoryFilterData();
			}
			return JToken.Parse(JsonConvert.SerializeObject(result)).ToString();
		}

		/// <summary>
		/// Gets glassware filter for  beers
		/// </summary>
		/// <returns>Response object with data required by the view</returns>
		public string GetGlasswareFilterData()
		{
			GlasswareResponseMsg result = new GlasswareResponseMsg();
			using (var glasswareFilterBL = BLFactory.CreateBL<IGlasswareBLL>())
			{
				result = glasswareFilterBL.GetGlasswareFilterData();
			}
			return JToken.Parse(JsonConvert.SerializeObject(result)).ToString();

		}
	}
}
