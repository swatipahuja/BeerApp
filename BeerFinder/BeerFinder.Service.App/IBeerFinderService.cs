using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using BeerFinder.Shared.DTO;
using BeerFinder.Shared.RequestMsg;

namespace BeerFinder.Service.App
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBeerFinderService" in both code and config file together.
	[ServiceContract]
	public interface IBeerFinderService
	{
		[OperationContract]
		[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "getBeers/{requestMsg}")]
		string GetBeerData(string requestMsg);
	}
}
