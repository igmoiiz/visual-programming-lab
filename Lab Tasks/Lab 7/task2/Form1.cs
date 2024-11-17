namespace task2
{
    public partial class Form1 : Form
    {
        private double n1;
        private double n2;
        private double r;
        private bool subclick;
        public Form1()
        {
            InitializeComponent();
            Buttons();
            n1 = Int32.MinValue;
            r = 0;
            subclick = false;
        }
        private void Buttons()
        {
            int k = 0;
            int sety = 86;
            int setx = 36;
            string[] text = { "1", "2", "3", "4", "5", "6", "7", "8", "9", ".", "0", "C" };
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    butt = new Button();
                    butt.Text = text[k];
                    butt.Size = new Size(65, 29);
                    butt.Location = new Point(setx, sety);
                    butt.UseVisualStyleBackColor = true;
                    butt.Visible = true;
                    butt.Click += Click;
                    setx += 110;
                    this.Controls.Add(butt);
                    k++;
                }
                sety += 70;
                setx = 36;
            }
            k = 0;
        }

        private void Click(object sender, EventArgs e)
        {
            Button but = sender as Button;
            textBox1.Text = null;
            string t = but.Text;
            if(subclick)
            {
                double s = double.Parse(t);
                s = -1 * s;
                t = s.ToString();
            }
            textBox1.Text = t;
            if (n1 == Int32.MinValue)
            {
                n1 = double.Parse(textBox1.Text);
                subclick = false;
                n2 = 0;
            }
            else
            {
                n2 = double.Parse(textBox1.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(n1 == Int32.MinValue)
            {
                subclick = true;
            }
            else
            {
                r = n1 - n2;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            r = n1 / n2;
        }

        private void add_Click(object sender, EventArgs e)
        {
            r = n1 + n2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            r = n1 * n2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = r.ToString();
            n1 = Int32.MinValue;
            subclick = false;
        }
    }
}
