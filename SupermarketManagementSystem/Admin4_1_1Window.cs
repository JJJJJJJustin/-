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
    public partial class Admin4_1_1Window : Form
    {
        public Admin4_1_1Window()
        {
            InitializeComponent();
        }
        public Admin4_1_1Window(string id)
        {
            InitializeComponent();
            Table(id);
        }
        //public void OnUpdate(string id)
        //{
        //    dataGridView1.Rows.Clear();

        //    string sql = $"select * from t_Stock where ID like '%{id}%';";
        //    DBHandle example = new DBHandle();
        //    IDataReader data = example.Read(sql);
        //    while (data.Read())
        //    {
        //        dataGridView1.Rows.Add(data[0].ToString(), data[1].ToString(), data[2].ToString(), data[3].ToString(), data[4].ToString());
        //    }
        //    data.Close();
        //    example.Close();
        //}
        private void Table(string id)
        {
            dataGridView1.Rows.Clear();

            string sql = $"select * from t_Stock where ID like '%{id}%';";
            DBHandle example = new DBHandle();
            IDataReader data = example.Read(sql);
            while (data.Read())
            {
                dataGridView1.Rows.Add(data[0].ToString(), data[1].ToString(), data[2].ToString(), data[3].ToString(), data[4].ToString());
            }
            data.Close();
            example.Close();
        }
    }
}
