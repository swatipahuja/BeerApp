using System.Runtime.Serialization;
using BeerFinder.Shared.Enum;

namespace BeerFinder.Shared.RequestMsg
{
	[DataContract]
	public class BeerRequestMsg
	{
		[DataMember(Name = "searchString")]
		public string SearchString { get; set; }
		[DataMember(Name = "pageNumber")]
		public int PageNumber { get; set; } = 1;
		[DataMember(Name = "sortField")]
		public SortField SortField { get; set; } =  SortField.Name;
		[DataMember(Name = "sortDirection")]
		public SortDirection SortDirection { get; set; } = SortDirection.Asc;
	}
}
