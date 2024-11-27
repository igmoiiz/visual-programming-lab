using System;
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
    public partial class form_2 : Form
    {
        public form_2()
        {
            InitializeComponent();
        }
        public form_2(string name,string gender,string hobbies,string status,string country)
        {
            InitializeComponent();

            label1.Text = "Name is " + name + " \n" +
                        "Gender is " + gender + " \n" +
                        "Hobby is " + hobbies + " \n" +
                        "Status is " + status + " \n" +
                        "Country is " + country + " \n";

            label1.Show();

        }

        private void form_2_Load(object sender, EventArgs e)
        {
            
        }
    }
}
