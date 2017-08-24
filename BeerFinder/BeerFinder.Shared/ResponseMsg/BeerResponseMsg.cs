using System.Collections.Generic;
using System.Runtime.Serialization;
using BeerFinder.Shared.DTO;
using BeerFinder.Shared.Interfaces;

namespace BeerFinder.Shared.ResponseMsg
{
	[DataContract]
	public class BeerResponseMsg: IResponseMsg
	{
		[DataMember(Name = "currentPage")]
		public int CurrentPage { get; set; }

		[DataMember(Name = "numberOfPages")]
		public int NumberOfPages { get; set; }

		[DataMember(Name = "totalResults")]
		public int TotalResults { get; set; }

		[DataMember(Name = "data")]
		public List<BeerDto> Beers { get; set; } = new List<BeerDto>();
		[DataMember(Name = "categories")]
		public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
		[DataMember(Name = "styles")]
		public List<StyleDto> Styles { get; set; } = new List<StyleDto>();
		[DataMember(Name = "glass")]
		public List<GlasswareDto> Glass { get; set; } = new List<GlasswareDto>();
		public string ErrorMessage { get; set; }
	
	}
}
