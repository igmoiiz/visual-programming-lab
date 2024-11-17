namespace task_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            { 
            
                double fahrenheit = double.Parse(textBox1.Text);
                double celsius = (fahrenheit - 32) * 5 / 9;
                textBox2.Text = celsius.ToString("F2");
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number for Fahrenheit.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
