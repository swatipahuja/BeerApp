using System.Runtime.Serialization;

namespace BeerFinder.Shared.Enum
{
	public enum SortDirection
	{
		[EnumMember(Value = "ASC")]
		Asc,
        [EnumMember(Value = "DESC")]
		Desc
	}
}
