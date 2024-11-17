namespace task3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "Number";
            dataGridView1.Columns[1].Name = "Square";
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void cal_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            for(int i = 1; i <= 10; i++)
            {
                dataGridView1.Rows.Add(i, i * i);
            }
        }
    }
}
