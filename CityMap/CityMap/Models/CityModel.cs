namespace CityMap.Models
{
	public class CityModel
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }
		
		public double Latitude { get; set; }
		
		public double Longitude { get; set; }

		public string Url { get; set; }

		public string ImagePath { get; set; }
	}
}
