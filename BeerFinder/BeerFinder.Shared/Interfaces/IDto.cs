using System;

namespace BeerFinder.Shared.Interfaces
{
	public interface IDto
	{
		string Id { get; set; }
		string Name { get; set; }
		DateTime? CreatedDate { get; set; }
	}
}
