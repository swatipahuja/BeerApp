using System.ServiceModel;
using System.ServiceModel.Web;
using BeerFinder.Shared.RequestMsg;

namespace BeerFinder.Service.App
{
	[ServiceContract]
	public interface IBeerFinderService
	{
		/// <summary>
		/// Gets search result and filters for the beers
		/// </summary>
		/// <param name="requestMsg">Request message</param>
		/// <returns>Response object with data required by the view</returns>
		[OperationContract]
		[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, 
			 UriTemplate = "getBeers?searchQuery={searchQuery}&pageNumber={pageNumber}&categoryId={categoryId}&glassWareId={glassWareId}")]
		string GetBeerData(string searchQuery, string pageNumber, string categoryId, string glasswareId);

		/// <summary>
		/// Gets category filter for  beers
		/// </summary>
		/// <returns>Response object with data required by the view</returns>
		[OperationContract]
		[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "getCategoryFilterData")]
		string GetCategoryFilterData();

		/// <summary>
		/// Gets glassware filter for  beers
		/// </summary>
		/// <returns>Response object with data required by the view</returns>
		[OperationContract]
		[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "getGlasswareFilterData")]
		string GetGlasswareFilterData();
	}
}
