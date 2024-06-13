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

        private void 货物库存管理toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Admin4Window goodsManaWindow = new Admin4Window();
            goodsManaWindow.ShowDialog();
        }
        private void 商品管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin2Window goodsWindow = new Admin2Window();
            goodsWindow.ShowDialog(); 
        }

        private void 管理员信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin3Window InfoWindow = new Admin3Window();
            InfoWindow.ShowDialog();
        }

        private void 员工管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("开发中~", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("开发中~", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
