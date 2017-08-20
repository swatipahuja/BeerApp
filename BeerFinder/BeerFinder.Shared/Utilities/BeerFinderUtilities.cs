namespace BeerFinder.Shared.Utilities
{
	public static class BeerFinderUtilities
	{
		public static string ConvertFirstCharToLower(string str)
		{
			string firstCharString = str[0].ToString();
			string buildString = str.Replace(firstCharString, firstCharString.ToLowerInvariant());
			return buildString;
		}
	}
}
