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
    public partial class Admin2Window : Form
    {
        public Admin2Window()
        {
            InitializeComponent();
        }
        private void Admin2Window_Load(object sender, EventArgs e)
        {
            Table();
            label4.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();      //默认选中的表格行在载入窗口时就对label4的值进行初始化（使用第一行的ID来初始化）
        }

        private void button1_Click(object sender, EventArgs e)                      //“上架商品”
        {
            Admin2_1Window addGoodsWindow = new Admin2_1Window();
            addGoodsWindow.ShowDialog();                                            //创建按键后显示的窗口并呈现
            //Admin2_2Window stockWindow = new Admin2_2Window();
            //stockWindow.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)                      //“下架商品”
        {
            #region 删除功能代码实现
            try 
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();        //存储书ID（从选定的当前行拿取其第一个单元格“ID”）
                                                                                            //这里的selectRows[0]表示默认选取第一行，但在手动选取时会根据情况变换成对应行。（不能使用Rows[0]，否则不会响应鼠标选中的某一行）
                DialogResult questionWindow = MessageBox.Show("确认下架该商品？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if(questionWindow == DialogResult.OK)
                {
                    string sql = $"delete from t_Goods where ID = '{id}'";
                    DBHandle example = new DBHandle();
                    if (example.Execute(sql) != 0) { MessageBox.Show("下架成功！"); } else { MessageBox.Show($"下架失败！ sql语句:{sql}"); };
                    example.Close();
                }
            }
            catch 
            {
                MessageBox.Show("请在表格中先选中需要下架的商品！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            #endregion
        }
        //private void button3_Click(object sender, EventArgs e)                      //“修改商品”
        //{
        //    try
        //    {
        //        string id    = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        //        string name  = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        //        string price = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        //        string stock = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        //        Admin4_2Window changeGoodsWindow = new Admin4_2Window(id, name, price, stock);
        //        changeGoodsWindow.ShowDialog();
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show($"请选中待修改的商品数据，\n错误：{ex.Message}", "修改", MessageBoxButtons.OK, MessageBoxIcon.Warning );
        //    }
        //}

        private void button4_Click(object sender, EventArgs e)                      //“刷新” 刷新操作（在更新之后再查一次实现更新）
        {
            Table();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            #region 根据商品编号查询的实现
            TableID();
            #endregion
        }

        private void button6_Click(object sender, EventArgs e)
        {
            #region 根据商品名称查询的实现
            TableName();
            #endregion
        }

        // 获取表格中选中格的部分数据，与窗口中的 lable4 “当前选中商品” 同步.
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            label4.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }

        // --------------------------------------------------------------------------------------------------------------
        //从对应数据库中的商品表中读取数据，用于呈现
        public void Table()
        {
            dataGridView1.Rows.Clear();                                                 //用于窗口循环中刷新更改后的数据

            string sql = "select * from t_Goods;";
            DBHandle example = new DBHandle();
            IDataReader data = example.Read(sql);
            while (data.Read())
            {
                dataGridView1.Rows.Add(data[0].ToString(), data[1].ToString(), data[2].ToString(), data[3].ToString());
                // ------------------------ ID--------------- Name ------------------ Price ----------- Stock -----------
            }
            data.Close();
            example.Close();
        }
        public void TableID()
        {
            dataGridView1.Rows.Clear();

            string sql = $"select * from t_Goods where ID = '{textBox1.Text}'";
            DBHandle example = new DBHandle();
            IDataReader data = example.Read(sql);
            while (data.Read())
            {
                dataGridView1.Rows.Add(data[0].ToString(), data[1].ToString(), data[2].ToString(), data[3].ToString());
            }
            data.Close();
            example.Close();

            textBox1.Text = "";                                                         //查询之后清空输入框
        }
        public void TableName()
        {
            dataGridView1.Rows.Clear();

            string sql = $"select * from t_Goods where Name like '%{textBox2.Text}%'";
            DBHandle example = new DBHandle();
            IDataReader data = example.Read(sql);
            while (data.Read())
            {
                dataGridView1.Rows.Add(data[0].ToString(), data[1].ToString(), data[2].ToString(), data[3].ToString());
            }
            data.Close();
            example.Close();

            textBox1.Text = "";                                                         //查询之后清空输入框
        }
    }
}
