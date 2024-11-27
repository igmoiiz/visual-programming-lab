using System;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Activity_lab
{
    public partial class Form1 : Form
    {

        string gendeer;
        string hobbies;
        string status;
        string name;
        string country;

        
        public Form1()
        {
            InitializeComponent();

           string[] countries = { "Pakistan", "bangladesh", "USA", "Canada", "Ireland" };
           foreach (string country in countries)
           {
                comboBox1.Items.Add(country);
           }
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            if(radioButton1.Checked)
            {
                gender = radioButton1.Text;
            }
            else
            {
                gender = radioButton2.Text;
            }

            if(radioButton3.Checked)
            {
                status = radioButton3.Text;
            }
            else
            {
                status = radioButton4.Text;
            }

            if(checkBox1.Checked)
            {
                hobbies = checkBox1.Text;

            }
            else
            {
                hobbies = checkBox2.Text;
            }

            country = comboBox1.SelectedItem.ToString();

            name = textBox1.Text;

            Validation v1=new Validation();
            v1.chkName(name);
            

            form_2 obj = new form_2(name,gender,hobbies,status,country);
            obj.ShowDialog();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string sqlconn = "Data Source=AUMC-LAB3-25\\SQLEXPRESS;Initial log=Customer_VS;Integrated Security=True";

           
            conn.Close();
        }
    }
}
