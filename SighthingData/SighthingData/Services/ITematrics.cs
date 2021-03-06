using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SighthingData.Models;

namespace SighthingData.Services
{
    public interface ITematricsService
    {
        Task<List<Device>> GetDeviceData();
    }
}
