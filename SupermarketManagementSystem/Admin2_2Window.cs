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
            Table();
        }

        private void Admin2_2Window_Load(object sender, EventArgs e)
        {

        }

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
    }
}
