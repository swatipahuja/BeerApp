using System;
using System.Runtime.Serialization;
using BeerFinder.Shared.Interfaces;

namespace BeerFinder.Shared.DTO
{
	[DataContract]
	public class CategoryDto: IDto
	{
		[DataMember(Name = "id")]
		public string Id { get; set; }
		[DataMember(Name = "name")]
		public string Name { get; set; }
		[DataMember(Name = "createDate")]
		public DateTime? CreatedDate { get; set; }
	}
}
