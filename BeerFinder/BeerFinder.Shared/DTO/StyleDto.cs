using System;
using BeerFinder.Shared.Interfaces;

namespace BeerFinder.Shared.DTO
{
	public class StyleDto: IDto
	{
		public int Id { get; set; }
		public CategoryDto Category { get; set; }
		public int CategoryId { get; set; }
		public string Description { get; set; }
		public string Name { get; set; }
		public string ShortName { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime UpdateDate { get; set; }

	}
}
