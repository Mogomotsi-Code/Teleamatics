using System;
namespace SightingData.Api.Models
{
    public class Device
    {
        public string DeviceId { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string Acc { get; set; }
        public string Speed { get; set; }
        public DateTime PhoneTime { get; set; }
        public DateTime Servertime { get; set; }
        public string Ts { get; set; }
    }
}
