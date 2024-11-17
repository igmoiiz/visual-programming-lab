namespace assignment_02_233587
{
    public partial class Form1 : Form
    {
        Font o;
        public Form1()
        {
            InitializeComponent();
            o = richTextBox1.SelectionFont;
            Add();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello World");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Font b = new Font(o, o.Style | FontStyle.Bold);
            richTextBox1.SelectionFont = b;
            richTextBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Font b = new Font(o, o.Style | FontStyle.Italic);
            richTextBox1.SelectionFont = b;
            richTextBox1.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = o;
            richTextBox1.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string item = "";
            if (pen.Checked)
            {
                item += "Pen ";
            }
            if (Pencil.Checked)
            {
                item += "Pencil";
            }
            MessageBox.Show($"You Buy {item}");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string gender = "";
            if (Male.Checked)
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }
            MessageBox.Show(gender);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show(numericUpDown1.Value.ToString());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Add()
        {
            comboBox1.Items.Add("Lahore");
            comboBox1.Items.Add("Multan");
            comboBox1.Items.Add("Karachi");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            OpenFileDialog o = new OpenFileDialog();
            if(o.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(o.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
