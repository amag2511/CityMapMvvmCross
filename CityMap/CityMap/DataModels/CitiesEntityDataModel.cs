using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CityMap.DataModels
{
	[DataContract]
	public class CitiesEntityDataModel
	{
		[DataMember(Name = "photos")]
		public List<CityDataModel> Cities { get; set; }
	}
}
