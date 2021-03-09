using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services.Dialogs;
using Xamarin.Forms;

namespace SighthingData.ViewModels
{
    public class BluetoothDevicesPageViewModel : ViewModelBase
    {
        private IBluetoothLE _ble;
        private IDialogService _dialogService;
        private bool _isBusy;
        private ObservableCollection<IDevice> _bluetoothDevices;
        public DelegateCommand ScanCommand { get; private set; }
        public ObservableCollection<IDevice> BluetoothDevices { get => _bluetoothDevices; set => SetProperty(ref _bluetoothDevices,value); }
        public bool IsBusy { get => _isBusy; set => SetProperty(ref _isBusy, value); }
        private IAdapter adapter;
        public BluetoothDevicesPageViewModel(INavigationService navigationService, IDialogService dialogService)
            :base(navigationService)
        {
            _bluetoothDevices = new ObservableCollection<IDevice>();
            _dialogService = dialogService;
            _ble = CrossBluetoothLE.Current;
            adapter = CrossBluetoothLE.Current.Adapter;
            ScanCommand = new DelegateCommand(async () => await ScanAsync() );
           
            adapter.DeviceDiscovered += (s, a) =>
            {
                if(_bluetoothDevices.FirstOrDefault(d => d.NativeDevice.Equals(a.Device.NativeDevice)) == null)
                {

                    try
                    {
                        _bluetoothDevices.Add(a.Device);
                    }
                    catch (Exception ex)
                    {

                    }
                   
                }
                BluetoothDevices = _bluetoothDevices;
            };
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            await ScanAsync();


        }
        private async Task ScanAsync()
        {
            try
            {
                if (_ble.State.Equals(BluetoothState.On))
                {
                    adapter.ScanMode = ScanMode.Balanced;
                    adapter.ScanTimeout = 60000;
                    IsBusy = true;
                    await adapter.StartScanningForDevicesAsync();
                    IsBusy = false;

                }
                else
                {
                    var dialogparameters = new DialogParameters
                {
                    { "title", "Alert" },
                    { "message", "Please turn on your bluetooth." }
                };
                    await _dialogService.ShowDialogAsync("Dialog", dialogparameters);
                }
            }
            catch(Exception ex)
            {

            }
            
        }
    }
}
