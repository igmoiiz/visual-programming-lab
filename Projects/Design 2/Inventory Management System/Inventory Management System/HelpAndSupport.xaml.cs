using System;
using System.Windows;

namespace Inventory_Management_System
{
	public partial class HelpAndSupport : Window
	{
		public HelpAndSupport()
		{
			InitializeComponent();
		}

		private void DownloadUserManual_Click(object sender, RoutedEventArgs e)
		{
			// Logic to download the user manual
			MessageBox.Show("User  manual downloaded successfully!"); // Placeholder for actual download logic
		}

		private void ViewFAQs_Click(object sender, RoutedEventArgs e)
		{
			// Logic to open the FAQs page
			MessageBox.Show("Opening FAQs..."); // Placeholder for actual FAQs logic
		}

		private void Submit_Click(object sender, RoutedEventArgs e)
		{
			string name = NameTextBox.Text.Trim();
			string email = EmailTextBox.Text.Trim();
			string message = MessageTextBox.Text.Trim();

			if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(message))
			{
				MessageBox.Show("Please fill in all fields.");
				return;
			}

			// Logic to send the support message (e.g., save to database or send an email)
			MessageBox.Show("Your message has been submitted successfully! We will get back to you shortly.");
			StatusTextBlock.Text = "Message sent!";
			NameTextBox.Clear();
			EmailTextBox.Clear();
			MessageTextBox.Clear();
		}
	}
}