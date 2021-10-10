using CsharLibrary.Class.Data_Process;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace CsharView
{
    public partial class WpfClientRestTask : Window
    {
        private IManagement management;

        public WpfClientRestTask(IManagement _management)
        {
            management = _management;
            this.txtUrl = new TextBox();
            InitializeComponent();
        }

        private async void enviarBtn_Click(object sender, RoutedEventArgs e)
        {
            txtResponse.Text = await management.GetHttpUrl(txtUrl.Text);
        }

        private void serializaBtn_Click(object sender, RoutedEventArgs e)
        {
        }

        private void deserializaBtn_Click(object sender, RoutedEventArgs e)
        {
        }

        private void jsonChck_Checked(object sender, RoutedEventArgs e)
        {
            //txtResponse.IsEnabled = (bool)jsonChck.IsChecked;
            txtResponse.IsReadOnly = !(bool)jsonChck.IsChecked;
            serializaBtn.IsEnabled = (bool)jsonChck.IsChecked;
            deserializaBtn.IsEnabled = (bool)jsonChck.IsChecked;
        }

        private void jsonChck_Unchecked(object sender, RoutedEventArgs e)
        {
            //txtResponse.IsEnabled = (bool)jsonChck.IsChecked;
            txtResponse.IsReadOnly = !(bool)jsonChck.IsChecked;
            serializaBtn.IsEnabled = (bool)jsonChck.IsChecked;
            deserializaBtn.IsEnabled = (bool)jsonChck.IsChecked;
        }

        private void txtUrl_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex reg = new Regex("", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            bool isUri = reg.IsMatch(txtUrl.Text);
            enviarBtn.IsEnabled = isUri;
            jsonChck.Visibility = isUri ? Visibility.Visible : Visibility.Hidden;
        }

        private void tipoEnvCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool estado = tipoEnvCmb.SelectedIndex > 0 ? true : false;
            txtUrl.IsEnabled = estado;
        }
    }
}