namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double n = double.Parse(textBox1.Text);
            double fac = 1;
            for(int i = 1; i <= n; i++)
            {
                fac = fac * i;
            }
            textBox2.Text = fac.ToString();
        }
    }
}
