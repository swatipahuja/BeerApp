using System.Runtime.Serialization;

namespace BeerFinder.Shared.Enum
{
	public enum SortField
	{
		[EnumMember(Value = "name")]
		Name,
		[EnumMember(Value = "abv")]
		Abv,
		[EnumMember(Value = "ibu")]
		Ibu,
	}
}
