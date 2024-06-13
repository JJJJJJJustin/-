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
    public partial class User3Window : Form
    {
        public User3Window()
        {
            InitializeComponent();
        }

        private void User3Window_Load(object sender, EventArgs e)
        {
            Table();
            //comboBox1.SelectedIndex = 0;                                                            // 默认选中 combo 的第一个
            Combo();
        }

        private void button1_Click(object sender, EventArgs e)                                      //“添加待退商品”（在退货表格中）
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string orderId = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();           //从订单表中选择
                string goodId  = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string date    = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string price   = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                dataGridView2.Rows.Add(orderId.ToString(), goodId.ToString(), date.ToString(), price.ToString());
                
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;                         // 当前在订单表中选中的一行数据
                dataGridView1.Rows.RemoveAt(selectedRowIndex);                                      // 删除
            }
            else { MessageBox.Show("请先选中待退商品！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void button3_Click(object sender, EventArgs e)                                      //“取消退货”（在退货表格中）
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                string orderId = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();           // 从退货表中选择
                string goodId  = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();           // WARNING:要提前拿到该数据，因为如果不存放却先删除了一行数据之后，再去查找时，整个表格中的索引会发生变化，影响结果
                string data    = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
                string price   = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();
                int selectedRowIndex = dataGridView2.SelectedRows[0].Index;                         // 获取第一个选中行的索引

                dataGridView2.Rows.RemoveAt(selectedRowIndex);                                      // 删除
                dataGridView1.Rows.Add(orderId.ToString(), goodId.ToString(), data.ToString(), price.ToString()); //将商品退回到订单表中
                //MessageBox.Show($"已取消退货：订单编号 - {orderId}， 商品编号 - {goodId}, 成交日期 - {data}， 商品单价 - {price}");  // 输出选中行的数据：
            }
            else { MessageBox.Show("请先选中要删除的行"); }
        }
        private void button4_Click(object sender, EventArgs e)                                      // 通过订单号"查询"
        {
            #region 查询Combo筛选后的表格数据语句实现
            dataGridView1.Rows.Clear();

            string sql = $"select * from t_Order where OrderID = '{comboBox1.SelectedItem}';";
            DBHandle example = new DBHandle();
            IDataReader data = example.Read(sql);
            while (data.Read())
                {dataGridView1.Rows.Add(data[0].ToString(), data[2].ToString(), data[3].ToString(), data[4].ToString());}
            data.Close();
            example.Close();
            #endregion
        }
        private void button5_Click(object sender, EventArgs e) { Table(); }                         // “重新查询全部订单”
        
        // 之前的确认和取消操作只针对退货表格，在确定要退的商品数据后，执行sql语句对数据库中的表格操作。
        private void button2_Click(object sender, EventArgs e)
        {
            float PriceSum = 0;                                                                     // 记录退货总金额
            int rowCount = dataGridView2.RowCount;
            DBHandle example = new DBHandle();

            for (int i = 0; i <= rowCount - 1; i++)                                                 //将购物车中每一行部分数据添加进订单表，并更新商品表中库存 stock
            {
                string orderId = dataGridView2.Rows[i].Cells[0].Value.ToString();
                string goodId  = dataGridView2.Rows[i].Cells[1].Value.ToString();
                string sql = $"delete from t_Order where OrderID = '{orderId}' and GoodID = '{goodId}';" +
                             $"update t_Goods set Stock=Stock+1 where ID = '{goodId}';" +
                             $"update t_Stock set Stock=Stock+1 where ID = '{goodId}';";
                if (example.Execute(sql) > 1)
                    PriceSum += float.Parse(dataGridView2.Rows[i].Cells[3].Value.ToString());
                else
                {
                    MessageBox.Show("sql语句执行有误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    System.Diagnostics.Debugger.Break();                                            //触发断点（终端程序）
                }
            }

            example.Close();
            MessageBox.Show($"员工已成功为客户退货！\n 退回金额共计：{PriceSum}元");
            dataGridView2.Rows.Clear();                                                             //下单后刷新（清空）购物车界面
            Table();                                                                                //也刷新商品表
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)                     // 下拉菜单
        { }

        public void Table()
        {
            #region 查询表格数据语句实现
            dataGridView1.Rows.Clear();

            string sql = $"select * from t_Order where UserID = {Data.UID};";                       // 员工使用的账号（user）
            DBHandle example = new DBHandle();
            IDataReader data = example.Read(sql);
            while (data.Read())
            {
                dataGridView1.Rows.Add(data[0].ToString(), data[2].ToString(), data[3].ToString(), data[4].ToString());
            }
            data.Close();
            example.Close();
            #endregion
        }
        public void Combo()
        {
            #region 查询表格数据语句实现
            comboBox1.SelectedIndex = -1;                                                           // 清空选择项
            comboBox1.Items.Clear();                                                                // 清空数据项

            string sql = $"select distinct OrderID from t_Order where UserID = {Data.UID};";        // 使用 distinct 避免返回重复的值（OrderID）
            DBHandle example = new DBHandle();
            IDataReader data = example.Read(sql);
            while (data.Read())
            {
                comboBox1.Items.Add(data[0].ToString());
            }
            data.Close();
            example.Close();
            #endregion
        }

    }
}
