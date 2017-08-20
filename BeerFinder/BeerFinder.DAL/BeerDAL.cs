using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;
using BeerFinder.DAL.Interfaces;
using BeerFinder.Shared.RequestMsg;
using BeerFinder.Shared.ResponseMsg;
using BeerFinder.Shared.Utilities;

namespace BeerFinder.DAL
{
	public class BeerDAL : IBeerDAL
	{
		public void Dispose()
		{
			
		}

		public BeerResponseMsg GetBeerData(BeerRequestMsg requestMsg)
		{
			BeerResponseMsg result = new BeerResponseMsg();
			result =  GetBeersDataAsync(requestMsg).GetAwaiter().GetResult();
			return result;
		}
		private async Task<BeerResponseMsg> GetBeersDataAsync(BeerRequestMsg requestMsg)
		{
			BeerResponseMsg beerData = null;

			string[] queryParameters = { "search" };
			NameValueCollection extraParams = new NameValueCollection();
			try
			{
				string orderFieldLcFirst = BeerFinderUtilities.ConvertFirstCharToLower(requestMsg.SortField.ToString());

				extraParams.Add("type", "beer");
				extraParams.Add("withBreweries", "Y");
				extraParams.Add("q", requestMsg.SearchString);
				extraParams.Add("order", orderFieldLcFirst);
				extraParams.Add("sort", requestMsg.SortDirection.ToString().ToUpperInvariant());
				extraParams.Add("p", requestMsg.PageNumber.ToString());

				HttpClient client = HttpClientProvider.Client;
				Uri requestUri = HttpClientProvider.BuildRequest(queryParameters, extraParams);
				//Logger.Log($"REQUEST: requesting: {requestUri}");
				HttpResponseMessage response =  await client.GetAsync(requestUri.AbsoluteUri);

				if (response.IsSuccessStatusCode)
				{
					//Logger.Log($"REQUEST: loaded: {requestUri}");
					beerData = await response.Content.ReadAsAsync<BeerResponseMsg>();
				}
				else
				{
					//Logger.Log($"REQUEST: failed: {requestUri}");
					throw new ApplicationException($"{(int)response.StatusCode} - {response.ReasonPhrase} : {await response.Content.ReadAsStringAsync()}.");
				}
			}
			catch (Exception ex)
			{
				throw;
			}
			return beerData;
		}
	}
}
