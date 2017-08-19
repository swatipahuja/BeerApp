using System;

namespace BeerFinder.Shared.Interfaces
{
	public interface IDto
	{
		int Id { get; set; }
		string Name { get; set; }
		DateTime CreatedDate { get; set; }
	}
}
