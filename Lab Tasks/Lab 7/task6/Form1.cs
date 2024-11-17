namespace task6
{
    public partial class Form1 : Form
    {
        private decimal ti;
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ti = time.Value * 10;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(ti > 0)
            {
                ti--;
                label1.Text = "Time Left: " + ti.ToString() + " seconds left";

            }
            else
            {
                timer1.Stop();
                MessageBox.Show("Time is Over");
            }
        }
    }
}
