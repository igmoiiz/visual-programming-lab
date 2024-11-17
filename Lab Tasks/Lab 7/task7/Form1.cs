namespace task7
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            DateTime d = DateTime.Today;
            DateTime t = DateTime.UtcNow;
            InitializeComponent();
            label1.Text = d.ToString();
            label2.Text = t.ToString();
        }
    }
}
