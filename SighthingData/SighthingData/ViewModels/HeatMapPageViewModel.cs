using System;
using Prism.Navigation;
using SighthingData.Services;

namespace SighthingData.ViewModels
{
    public class HeatMapPageViewModel : ViewModelBase
    {
        ITematricsService _devicesService;


        public HeatMapPageViewModel(INavigationService navService, ITematricsService devicesService)
            :base(navService)
        {
            _devicesService = devicesService;
        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            var devices = await _devicesService.GetDeviceData();
            base.OnNavigatedTo(parameters);
           
        }
    }
}
