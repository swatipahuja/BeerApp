using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using BeerFinder.Shared.Interfaces;

namespace BeerFinder.Shared.DTO
{
	[DataContract]
	public class BeerDto : IDto
	{
		#region Private Fields
		private string _isBeerOrganicString = "N";
		private bool _isBeerOrganic;
		#endregion

		#region Public Data Members

		[DataMember(Name = "id")]
		public string Id { get; set; }

		[DataMember(Name = "name")]
		public string Name { get; set; }

		[DataMember(Name = "createDate")]
		public DateTime? CreatedDate { get; set; }

		[DataMember(Name = "nameDisplay")]
		public string DisplayName { get; set; }

		[DataMember(Name = "description")]
		public string Description { get; set; }

		[DataMember(Name = "foodPairings")]
		public string FoodPairing { get; set; }

		[DataMember(Name = "glass")]
		public GlasswareDto Glass { get; set; }

		[DataMember(Name = "style")]
		public StyleDto Style { get; set; }

		[DataMember(Name = "abv")]
		public string Abv { get; set; }

		[DataMember(Name = "ibu")]
		public float Ibu { get; set; }

		[DataMember(Name = "isOrganic")]
		public string IsOrganic
		{
			get { return _isBeerOrganicString; }
			set
			{
				_isBeerOrganicString = value;
				_isBeerOrganic = value == "Y";
			}
		}
		[DataMember(Name = "labels")]
		public LabelDto Labels { get; set; } 

		[DataMember(Name = "servingTemperature")]
		public string ServingTemperature { get; set; }

		[DataMember(Name = "servingTemperatureDisplay")]
		public string ServingTemperatureDisplay { get; set; }

		[DataMember(Name = "year")]
		public int? Year { get; set; }

		[DataMember(Name = "updateDate")]
		public DateTime? UpdateDate { get; set; }
		[DataMember(Name = "categories")]
		public CategoryDto Categories { get; set; }
		[DataMember(Name = "breweries")]
		public List<BreweryDto> Breweries { get; set; }
		[DataMember(Name = "glassWareId")]
		public string GlassWareId { get; set; }
		[DataMember(Name = "styleId")]
		public string StyleId { get; set; }
		[DataMember(Name = "categoryId")]
		public string CategoryId { get; set; }
		#endregion
	}
}
