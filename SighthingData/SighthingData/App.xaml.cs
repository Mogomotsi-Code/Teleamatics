using System;
using Prism.Ioc;
using Prism.Unity;
using SighthingData.Constants;
using SighthingData.Services;
using SighthingData.ViewModels;
using SighthingData.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SighthingData
{
    public partial class App : PrismApplication
    {
        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync($"{Pages.NAVIAGATION_PAGE}/{Pages.BLUETOOTH_DEVICES_PAGE}");
            //await NavigationService.NavigateAsync($"{Pages.NAVIAGATION_PAGE}/{Pages.HEATMAP_PAGE}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ITematricsService, TelematricsService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<HeatMapPage, HeatMapPageViewModel>();
            containerRegistry.RegisterForNavigation<BluetoothDevicesPage, BluetoothDevicesPageViewModel>();
        }
    }
}
