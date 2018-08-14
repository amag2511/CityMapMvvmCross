using System.Runtime.Serialization;

namespace CityMap.DataModels
{
	[DataContract]
	public class CityDataModel
	{
		[DataMember(Name = "id")]
		public int Id { get; set; }

		[DataMember(Name = "title")]
		public string Title { get; set; }

		[DataMember(Name = "description")]
		public string Description { get; set; }

		[DataMember(Name = "latitude")]
		public double Latitude { get; set; }

		[DataMember(Name = "longitude")]
		public double Longitude { get; set; }

		[DataMember(Name = "url")]
		public string Url { get; set; }
	}
}

