namespace Task1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void add_Click(object sender, EventArgs e)
        {
            double n1 = int.Parse(textBox1.Text);
            double n2 = int.Parse(textBox2.Text);
            double r = n1 + n2;
            textBox3.Text = r.ToString();
        }

        private void Sub_Click(object sender, EventArgs e)
        {
            double n1 = int.Parse(textBox1.Text);
            double n2 = int.Parse(textBox2.Text);
            double r = n1 - n2;
            textBox3.Text = r.ToString();
        }

        private void mul_Click(object sender, EventArgs e)
        {
            double n1 = int.Parse(textBox1.Text);
            double n2 = int.Parse(textBox2.Text);
            double r = n1 * n2;
            textBox3.Text = r.ToString();
        }

        private void div_Click(object sender, EventArgs e)
        {
            double n1 = int.Parse(textBox1.Text);
            double n2 = int.Parse(textBox2.Text);
            double r = n1 / n2;
            textBox3.Text = r.ToString();
        }
    }
}
