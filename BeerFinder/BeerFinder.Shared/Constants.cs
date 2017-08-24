namespace BeerFinder.Shared
{
	public class Constants
	{
		public struct LogExceptionMessages
		{
			public readonly static string DataAccessException = "DataExcessExceptionMessage";

		}

		public struct LogTraceMessages
		{
			public readonly static string DataRequestingMsg = "DataRequestingMsg";
			public readonly static string DataLoadedSuccessfullyMsg = "DataLoadedSuccessfullyMsg";
			public readonly static string DataLoadFailureMsg = "DataLoadFailureMsg";

		}
	}
}
