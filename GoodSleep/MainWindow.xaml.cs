using GoodSleep.Models;
using GoodSleep.Utilities;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GoodSleep
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        #region 생성자
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            listDevices.MouseDoubleClick += ListDevices_MouseDoubleClick;
        }
        #endregion

        #region 내부 함수
        private void ShowProperty(PowerDevice device)
        {
            if (device != null)
            {
                DeviceUtility.ShowProperty(device);
            }
        }

        private async Task UpdateViewAsync()
        {
            gridLoading.Visibility = Visibility.Visible;
            listDevices.ItemsSource = await DeviceUtility.GetPowerDevicesAsync();
            gridLoading.Visibility = Visibility.Collapsed;
        }
        #endregion

        #region 내부 이벤트
        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await UpdateViewAsync();
        }

        private void ListDevices_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ShowProperty(listDevices.SelectedItem as PowerDevice);
        }

        private void ContentShow_Click(object sender, RoutedEventArgs e)
        {
            ShowProperty(listDevices.SelectedItem as PowerDevice);
        }

        private async void ContextEnable_Click(object sender, RoutedEventArgs e)
        {
            if (listDevices.SelectedItem != null)
            {
                if (await DeviceUtility.SetDeviceStateAsync((listDevices.SelectedItem as PowerDevice), true))
                {
                    await UpdateViewAsync();
                }
                else
                {
                    MessageBox.Show("해당 장치는 활성화 할 수 없습니다.", "오류", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private async void ContextDisable_Click(object sender, RoutedEventArgs e)
        {
            if (listDevices.SelectedItem != null)
            {
                if (await DeviceUtility.SetDeviceStateAsync((listDevices.SelectedItem as PowerDevice), false))
                {
                    await UpdateViewAsync();
                }
                else
                {
                    MessageBox.Show("해당 장치는 비활성화 할 수 없습니다.", "오류", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        #endregion
    }
}
