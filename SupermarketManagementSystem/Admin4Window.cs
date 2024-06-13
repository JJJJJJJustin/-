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
    public partial class Admin4Window : Form
    {
        public Admin4Window()
        {
            InitializeComponent();
        }
        private void Admin4Window_Load(object sender, EventArgs e)
        {
            Table();
            label4.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();      //默认选中的表格行在载入窗口时就对label4的值进行初始化（使用第一行的ID来初始化）
        }


        private void button1_Click(object sender, EventArgs e)                      //“上架商品”
        {
            Admin4_1Window addGoodsWindow = new Admin4_1Window();
            addGoodsWindow.ShowDialog();                                                  //创建按键后显示的窗口并呈现
            Table();
        }
        private void button2_Click(object sender, EventArgs e)                      //“下架商品”
        {
            #region 删除功能代码实现
            try
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();        //存储ID（从选定的当前行拿取其第一个单元格“ID”）
                                                                                            //这里的selectRows[0]表示默认选取第一行，但在手动选取时会根据情况变换成对应行。（不能使用Rows[0]，否则不会响应鼠标选中的某一行）
                string name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                DialogResult questionWindow = MessageBox.Show("确认下架该货物？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (questionWindow == DialogResult.OK)
                {
                    string sql = //$"delete from t_Goods where ID = '{id}';" +
                                 $"delete from t_Stock where ID = '{id}' and Name = '{name}';";
                    DBHandle example = new DBHandle();
                    if (example.Execute(sql) != 0) { MessageBox.Show("下架成功！"); } else { MessageBox.Show($"下架失败！ sql语句:{sql}"); };
                    example.Close();
                }
                Table();
            }
            catch
            {
                MessageBox.Show("请在表格中先选中需要下架的货物！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            #endregion
        }
        private void button3_Click(object sender, EventArgs e)                      //“修改商品信息”
        {
            #region 修改商品信息
            try
            {
                string id       = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string name     = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string stock    = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string supplier = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                string price    = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                Admin4_2Window changeGoodsWindow = new Admin4_2Window(id, name, stock, supplier, price);
                changeGoodsWindow.ShowDialog(); 
                Table();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"请选中待修改的货物数据，\n错误：{ex.Message}", "修改", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            #endregion
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string id    = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string stock = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                Admin4_3Window changeGoodsWindow = new Admin4_3Window(id, stock);
                changeGoodsWindow.ShowDialog();
                Table();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"请选中待修改的货物数据，\n错误：{ex.Message}", "修改", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            label4.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Table();
        }
        // --------------------------------------------------------------------------------------------------------------
        public void Table()                                                         //刷新表格
        {
            dataGridView1.Rows.Clear();

            string sql = "select * from t_Stock;";
            DBHandle example = new DBHandle();
            IDataReader data = example.Read(sql);
            while (data.Read())
            {
                dataGridView1.Rows.Add(data[0].ToString(), data[1].ToString(), data[2].ToString(), data[3].ToString(), data[4].ToString());
                // ------------------------ ID--------------- Name ------------------ Stock ----------- Supplier ----------- Price --------
            }
            data.Close();
            example.Close();
        }
        public void TableID()
        {
            dataGridView1.Rows.Clear();

            string sql = $"select * from t_Stock where ID = '{textBox1.Text}'";
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

            string sql = $"select * from t_Stock where Name like '%{textBox2.Text}%'";
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
