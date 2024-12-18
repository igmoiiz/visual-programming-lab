using System;
using System.Windows;
using System.Windows.Threading;

namespace Lab_12___Activity
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private DispatcherTimer timer;
		private DateTime lastMessageTime; // Field to store the last message time

		public MainWindow()
		{
			InitializeComponent();
			DataContext = this; // Set the DataContext for binding
			StartTimer();
			lastMessageTime = DateTime.Now; // Initialize last message time
		}

		private void StartTimer()
		{
			timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromSeconds(1); // Update every second
			timer.Tick += Timer_Tick;
			timer.Start();
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			CurrentTime = DateTime.Now; // Update the CurrentTime property

			// Check if a minute has passed since the last message box was shown
			if ((DateTime.Now - lastMessageTime).TotalMinutes >= 1)
			{
				MessageBox.Show("Time has changed!", "Time Update", MessageBoxButton.OK, MessageBoxImage.Information);
				lastMessageTime = DateTime.Now; // Update the last message time
			}
		}

		public int MyProperty
		{
			get { return (int)GetValue(MyPropertyProperty); }
			set { SetValue(MyPropertyProperty, value); }
		}

		// Using a DependencyProperty as the backing store for MyProperty. This enables animation, styling, binding, etc...
		public static readonly DependencyProperty MyPropertyProperty = DependencyProperty.Register("MyProperty", typeof(int), typeof(MainWindow), new FrameworkPropertyMetadata(0));

		// CurrentTime property definition
		public DateTime CurrentTime
		{
			get { return (DateTime)GetValue(CurrentTimeProperty); }
			set { SetValue(CurrentTimeProperty, value); }
		}

		// DependencyProperty declaration for CurrentTime
		public static readonly DependencyProperty CurrentTimeProperty = DependencyProperty.Register("CurrentTime", typeof(DateTime), typeof(MainWindow), new FrameworkPropertyMetadata(DateTime.Now));
	}
}