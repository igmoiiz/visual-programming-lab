using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _233507___Lab_11__Activity
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

		private void HandleChecked(object sender, RoutedEventArgs e)
		{
            text_box1.Text = "Hello My name is Moiz";
		}

        private void HandleUnchecked(object sender, RoutedEventArgs e)
        {
            text_box2.Text = "Hello I am not Moiz";
        }
	}
}