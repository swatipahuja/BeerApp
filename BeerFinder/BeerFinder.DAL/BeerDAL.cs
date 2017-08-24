using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;
using BeerFinder.DAL.Interfaces;
using BeerFinder.Logger;
using BeerFinder.Shared;
using BeerFinder.Shared.RequestMsg;
using BeerFinder.Shared.ResponseMsg;
using BeerFinder.Shared.Utilities;

namespace BeerFinder.DAL
{
	public class BeerDAL : IBeerDAL
	{
		#region Private Members

		private ILogger _logger = LoggerFactory.CreateLogger(typeof(BeerDAL));

		/// <summary>
		/// Gets beer data from BrweryDB in asynchronous manner
		/// </summary>
		/// <param name="requestMsg">Request message</param>
		/// <returns></returns>
		private async Task<BeerResponseMsg> GetBeersDataAsync(BeerRequestMsg requestMsg)
		{
			BeerResponseMsg beerData = null;

			string[] queryParameters = { "search" };
			NameValueCollection extraParams = new NameValueCollection();
			try
			{
				//build query string parameters
				extraParams.Add("type", "beer");
				extraParams.Add("withBreweries", "Y");
				extraParams.Add("q", requestMsg.SearchString);
				extraParams.Add("p", requestMsg.PageNumber);

				HttpClient client = HttpClientProvider.Client;
				Uri requestUri = HttpClientProvider.CreateRequest(queryParameters, extraParams);
				HttpResponseMessage response = await client.GetAsync(requestUri.AbsoluteUri);

				if (response.IsSuccessStatusCode)
				{
					beerData = await response.Content.ReadAsAsync<BeerResponseMsg>();
				}
				else
				{
					string error = await response.Content.ReadAsStringAsync();
					string errorMessage = $"{(int)response.StatusCode} - {response.ReasonPhrase} : {error}.";
					ApplicationException ex = new ApplicationException();
					_logger.LogException(LogSeverity.Error, errorMessage, ex);
					throw ex;
				}
			}
			catch (Exception ex)
			{
				_logger.LogException(LogSeverity.Error, Constants.LogExceptionMessages.DataAccessException, ex);
				throw;
			}
			return beerData;
		}

		#endregion

		#region Public Members

		public void Dispose()
		{
			_logger = null;
		}

		/// <summary>
		/// Gets search result and filters for the beers
		/// </summary>
		/// <param name="requestMsg">Request message</param>
		/// <returns>Response object with data required by the view</returns>
		public BeerResponseMsg GetBeerData(BeerRequestMsg requestMsg)
		{
			BeerResponseMsg result = new BeerResponseMsg();
			result = GetBeersDataAsync(requestMsg).GetAwaiter().GetResult();
			return result;
		}
		#endregion
	}
}
