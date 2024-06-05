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
    public partial class Admin2_2Window : Form
    {
        public Admin2_2Window()
        {
            InitializeComponent();
        }
        public Admin2_2Window(string id, string name, string price, string stock)       //构造函数的重载（从上一级文件中获取某一行数据）
        {
            InitializeComponent();

            m_Id = id;                                                                  //暂存 id 到 m_Id 中,作为更新条件。
            textBox1.Text = id;
            textBox2.Text = name;
            textBox3.Text = price;
            textBox4.Text = stock;
            label7.Text = $"ID: {id},Name:{name},Price:{price},      Stock:{stock}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = $"update t_Goods set ID = '{m_Id}', [Name] = '{textBox2.Text}', Price = '{textBox3.Text}', Stock = '{textBox4.Text}' where ID = '{m_Id}'";
            DBHandle example = new DBHandle();
            if (example.Execute(sql) != 0)
            {
                MessageBox.Show("修改成功！");
                m_Executed++;
                label5.Text = $"已成功添加{m_Executed}个";
            }
            else
            {
                MessageBox.Show("修改失败");
            }
            example.Close();
        }



        // ---------------------------------------------------
        private string m_Id;
        private int m_Executed;
    }
}
