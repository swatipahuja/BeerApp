using BeerFinder.BLL.Interfaces;
using BeerFinder.DAL;
using BeerFinder.DAL.Interfaces;
using BeerFinder.Logger;
using BeerFinder.Shared.ResponseMsg;

namespace BeerFinder.BLL
{
	public class GlasswareBLL : IGlasswareBLL
	{
		#region Private Members
		private ILogger _logger = LoggerFactory.CreateLogger(typeof(CategoryBLL));
		#endregion

		#region Public Members
		/// <summary>
		/// Gets glassware filter data
		/// </summary>
		/// <returns>Response object with data required by the view</returns>
		public GlasswareResponseMsg GetGlasswareFilterData()
		{
			GlasswareResponseMsg result = new GlasswareResponseMsg();
			using (var beerDAL = DALFactory.CreateDAL<IGlasswareDAL>())
			{
				result = beerDAL.GetGlasswareFilterData();
			}
			return result;
		}

		/// <summary>
		/// Dispose all resources
		/// </summary>
		public void Dispose()
		{
			_logger = null;
		}
		#endregion
	}
}
