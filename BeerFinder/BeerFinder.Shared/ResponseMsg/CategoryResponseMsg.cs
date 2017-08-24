using System.Collections.Generic;
using System.Runtime.Serialization;
using BeerFinder.Shared.DTO;
using BeerFinder.Shared.Interfaces;

namespace BeerFinder.Shared.ResponseMsg
{
	[DataContract]
	public class CategoryResponseMsg: IResponseMsg
	{
		[DataMember(Name = "data")]
		public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
		[DataMember(Name = "erroMessage")]
		public string ErrorMessage { get; set; }

	}
}
