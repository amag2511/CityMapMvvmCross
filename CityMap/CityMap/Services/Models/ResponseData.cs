namespace CityMap.Services.Models
{
	public class ResponseData<T>
	{
		public bool IsSuccessed { get; set; }
		public T Result { get; set; }
	}
}
