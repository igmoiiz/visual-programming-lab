using System.Globalization;

namespace Activity
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dayyear.Items.Add("Days");
            dayyear.Items.Add("Year");
            Pizza.Items.Add("Small");
            Pizza.Items.Add("Medium");
            Pizza.Items.Add("Large");
        }


        private void button_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"You selected {combo.SelectedText}");
        }

        private void combo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dayyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dayyear.SelectedItem == "Days")
            {
                combo.Items.Add("Monday");
                combo.Items.Add("Tuesday");
                combo.Items.Add("Wednesday");
                combo.Items.Add("Thursday");
                combo.Items.Add("Friday");
                combo.Items.Add("Saturday");
                combo.Items.Add("Sunday");
            }
            else if (dayyear.SelectedIndex == 1)
            {
                combo.Items.Add("2024");
                combo.Items.Add("2025");
                combo.Items.Add("2026");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {

            }
            else if (checkBox2.Checked)
                
        }
    }
}
