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
		public string PageNumber { get; set; } = "1";
		[DataMember(Name = "glasswareId")]
		public string GlasswareId { get; set; }
		[DataMember(Name = "categoryId")]
		public string CategoryId { get; set; } 
	}
}
