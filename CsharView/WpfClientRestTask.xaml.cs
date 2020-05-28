using System.Text.RegularExpressions;
using System.Windows;

namespace CsharView
{
    /// <summary>
    /// Lógica de interacción para Wpf.xaml
    /// </summary>
    public partial class WpfClientRestTask : Window
    {
        private const string pattern = @"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";

        public WpfClientRestTask()
        {
            this.txtUrl = new System.Windows.Controls.TextBox();
            InitializeComponent();
        }

        private void enviarBtn_Click(object sender, RoutedEventArgs e)
        {
        }

        private void serializaBtn_Click(object sender, RoutedEventArgs e)
        {
        }

        private void deserializaBtn_Click(object sender, RoutedEventArgs e)
        {
        }

        private void jsonChck_Checked(object sender, RoutedEventArgs e)
        {
            txtResponse.IsEnabled = (bool)jsonChck.IsChecked;
            txtResponse.IsReadOnly = !(bool)jsonChck.IsChecked;
            serializaBtn.IsEnabled = (bool)jsonChck.IsChecked;
            deserializaBtn.IsEnabled = (bool)jsonChck.IsChecked;
        }

        private void jsonChck_Unchecked(object sender, RoutedEventArgs e)
        {
            txtResponse.IsEnabled = (bool)jsonChck.IsChecked;
            txtResponse.IsReadOnly = !(bool)jsonChck.IsChecked;
            serializaBtn.IsEnabled = (bool)jsonChck.IsChecked;
            deserializaBtn.IsEnabled = (bool)jsonChck.IsChecked;
        }

        private void txtUrl_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);

            bool isUri = reg.IsMatch(txtUrl.Text);
            enviarBtn.IsEnabled = isUri;
            jsonChck.Visibility = isUri ? Visibility.Visible : Visibility.Hidden;
        }

        private void tipoEnvCmb_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            bool estado = tipoEnvCmb.SelectedIndex > 0 ? true : false;
            txtUrl.IsEnabled = estado;
        }
    }
}