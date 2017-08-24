using System;
using System.Runtime.Serialization;
using BeerFinder.Shared.Interfaces;

namespace BeerFinder.Shared.DTO
{
	[DataContract]
	public class StyleDto: IDto
	{
		[DataMember(Name = "id")]
		public string Id { get; set; }
		[DataMember(Name = "name")]
		public string Name { get; set; }
		[DataMember(Name = "createDate")]
		public DateTime? CreatedDate { get; set; }
		[DataMember(Name = "category")]
		public CategoryDto Category { get; set; }
		[DataMember(Name = "categoryId")]
		public int CategoryId { get; set; }
		[DataMember(Name = "description")]
		public string Description { get; set; }
		[DataMember(Name = "shortName")]
		public string ShortName { get; set; }
		[DataMember(Name = "updateDate")]
		public DateTime? UpdateDate { get; set; }

	}
}
