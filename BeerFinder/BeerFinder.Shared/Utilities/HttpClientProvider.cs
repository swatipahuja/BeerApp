using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace BeerFinder.Shared.Utilities
{
	public static class HttpClientProvider
	{
		#region Private Members
		private static HttpClient _client;
		private static string _baseAddr = ConfigurationManager.AppSettings["BaseUrl"];
		private static string _apiKey = ConfigurationManager.AppSettings["ApiKey"];
		private static NameValueCollection _parameters = new NameValueCollection();

		/// <summary>
		/// Sets default parameters for http client
		/// </summary>
		private static void SetDefautParameters()
		{
			if (_parameters.Count > 0)
			{
				_parameters.Clear();
			}
			_parameters.Add("key", _apiKey);
		}

		/// <summary>
		/// Sets Default headers for the client
		/// </summary>
		private static void SetDefaultHeaders()
		{
			_client.DefaultRequestHeaders.Accept.Clear();
			MediaTypeWithQualityHeaderValue jsonMediaType = new MediaTypeWithQualityHeaderValue("application/json");
			_client.DefaultRequestHeaders.Accept.Add(jsonMediaType);
		}

		/// <summary>
		/// Initializes the lient
		/// </summary>
		private static void InitClient()
		{
			_client = new HttpClient();
			_client.BaseAddress = new Uri(_baseAddr);

			SetDefautParameters();
			SetDefaultHeaders();
		}
		#endregion

		#region Public Members

		/// <summary>
		/// Create single instance of http client
		/// </summary>
		public static HttpClient Client
		{
			get
			{
				if (_client == null)
				{
					_client = new HttpClient();
				}
				return _client;
			}
		}

		/// <summary>
		/// Create the request
		/// </summary>
		/// <param name="segments"></param>
		/// <param name="extraParams"></param>
		/// <returns></returns>
		public static Uri CreateRequest(string[] segments, NameValueCollection extraParams = null)
		{
			InitClient();
			UriBuilder uriBuilder = new UriBuilder(_baseAddr);
			if (extraParams != null)
			{
				_parameters.Add(extraParams);
			}

			uriBuilder.Path += string.Join("/", segments);
			List<string> parametersString = new List<string>();
			foreach (string key in _parameters.Keys)
			{
				parametersString.Add(key + "=" + HttpUtility.UrlEncode(_parameters[key]));
			}
			uriBuilder.Query = string.Join("&", parametersString);

			return uriBuilder.Uri;
		}
		#endregion
	}
}