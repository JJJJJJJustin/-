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
    public partial class Admin1Window : Form
    {
        public Admin1Window()
        {
            InitializeComponent();
        }

        private void 商品管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin2Window goodsWindow = new Admin2Window();
            goodsWindow.ShowDialog();
        }
    }
}
