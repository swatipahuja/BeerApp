using System;
using BeerFinder.Shared.Interfaces;

namespace BeerFinder.Shared.DTO
{
	public class CategoryDto: IDto
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public DateTime? CreatedDate { get; set; }
	}
}
