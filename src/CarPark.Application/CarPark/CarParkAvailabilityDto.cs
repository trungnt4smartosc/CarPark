using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarPark.Application.CarPark
{
    public class CarParkAvailabilityDto
    {
        [JsonProperty("items")]
        public List<CarParkItem> Items { get; set; }
    }

    public class CarParkItem
    {
        [JsonProperty("carpark_data")]
        public List<CarParkData> CarParkData { get; set; }
    }

    public class CarParkData
    {
        [JsonProperty("carpark_info")]
        public List<CarParkInfo> CarParkInfo { get; set; }
        [JsonProperty("carpark_number")]
        public string CarParkNumber { get; set; }
        [JsonProperty("update_datetime")]
        public DateTime UpdateDatetime { get; set; }
    }

    public class CarParkInfo
    {
        [JsonProperty("total_lots")]
        public int TotalLots { get; set; }
        [JsonProperty("lot_type")]
        public string LotType { get; set; }
        [JsonProperty("lots_available")]
        public int LotsAvailable { get; set; }
    }
}
