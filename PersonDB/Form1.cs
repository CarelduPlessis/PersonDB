using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonDB
{
    public partial class Form1 : Form
    {
        DBClass dbclass = new DBClass();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dbclass.ShowPerson(); //Display on DataGridView 
        }

       
    }
}
