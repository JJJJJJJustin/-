using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupermarketManagementSystem
{
    public partial class Admin2_1Window : Form
    {
        private int m_ExecutedSQL = 0;

        public Admin2_1Window()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "") {
                string sql = $"insert into t_Goods values ('{textBox1.Text}', '{textBox2.Text}', {textBox3.Text}, {textBox4.Text})";

                DBHandle example = new DBHandle();
                try {
                    example.Execute(sql);                               //执行SQL语句的函数，如果执行成功返回受影响行数
                    MessageBox.Show("添加成功！\n尝试刷新后查看 :-}");

                    m_ExecutedSQL++;
                    label5.Text = $"已成功添加{m_ExecutedSQL}个";
                }
                catch (SqlException ex)
                {
                    StackFrame frame = new StackFrame(1);

                    MessageBox.Show($"添加失败！\n" +
                        $"错误位置->文件：{frame.GetFileName()}, 位于{frame.GetFileLineNumber()}行， 方法：{frame.GetMethod().Name}\n" +
                        $"错误信息：{ex.Message}， 错误代码：{sql} \n" + 
                        "请尝试更改后重新填入 :-)");
                }
            }
            else
            {
                MessageBox.Show("商品信息不能为空！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
    }
}
