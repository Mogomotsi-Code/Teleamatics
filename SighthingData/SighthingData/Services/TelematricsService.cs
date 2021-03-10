using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SighthingData.Constants;
using SighthingData.Models;

namespace SighthingData.Services
{
    public class TelematricsService : ITematricsService
    {
        HttpClient _client;
        public TelematricsService()
        {
            _client = new HttpClient();
           _client.BaseAddress = new Uri(Enpoints.BASE_URL);
            _client.DefaultRequestHeaders.Add("Accept", "application/json");

        }

        public async Task<List<Device>> GetDeviceData()
        {

            try
            {
                var results  = await _client.GetAsync($"{Enpoints.DEVICE_STATS}");
                if(results.StatusCode.Equals(HttpStatusCode.OK))
                {
                    return JsonConvert.DeserializeObject<List<Device>>( await results.Content.ReadAsStringAsync());
                }
                return null;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
