using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupermarketManagementSystem
{
    public partial class User1Help3Window : Form
    {
        public User1Help3Window()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("逗你玩的，这个按钮什么作用也没有", "骗到你了", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
