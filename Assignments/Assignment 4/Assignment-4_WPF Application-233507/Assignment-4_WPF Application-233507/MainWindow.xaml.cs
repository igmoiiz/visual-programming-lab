using System.Collections.ObjectModel;
using System.Windows;

namespace CricketTeamManager
{
	public partial class MainWindow : Window
	{
		private ObservableCollection<string> players;

		public MainWindow()
		{
			InitializeComponent();
			players = new ObservableCollection<string>();
			PlayersListBox.ItemsSource = players;
		}

		private void AddPlayerButton_Click(object sender, RoutedEventArgs e)
		{
			string playerName = PlayerNameTextBox.Text.Trim();

			if (string.IsNullOrEmpty(playerName))
			{
				MessageBox.Show("Player name cannot be empty.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
				return;
			}

			if (players.Contains(playerName))
			{
				MessageBox.Show("Player already exists in the roster.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
				return;
			}

			players.Add(playerName);
			PlayerNameTextBox.Clear();
			MessageBox.Show("Player added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
		}

		private void RemovePlayerButton_Click(object sender, RoutedEventArgs e)
		{
			string selectedPlayer = PlayersListBox.SelectedItem as string;

			if (selectedPlayer != null)
			{
				players.Remove(selectedPlayer);
				MessageBox.Show("Player removed successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
			}
			else
			{
				MessageBox.Show("Please select a player to remove.", "Selection Error", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
		}
	}
}