using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arayuz
{
    public partial class Form19 : Form
    {
        List<pizzatablosu> pizzalst = new List<pizzatablosu>();
        public Form19()
        {
            InitializeComponent();
        }

        private void Form19_Load(object sender, EventArgs e)
        {
            string sqld = "SELECT * FROM pizza_tablosu";
            using(SqlCommand  cmd = new SqlCommand(sqld, DbClass.BaglantiTestEt()))
            {
                using(SqlDataReader reader= cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pizzalst.Add(new pizzatablosu
                        {
                        id = Convert.ToInt32(reader["id"]),
                        pizzaadi = Convert.ToString(reader["pizzaadi"])
                        });

                    }
                }
            }
            pizzalst.RemoveAt(0);
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "pizzaadi";
            comboBox1.DataSource = pizzalst;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cb = Convert.ToInt32(comboBox1.SelectedValue);
            string sqld = "DELETE FROM pizza_tablosu WHERE id= "+ cb;
            using (SqlCommand cmd = new SqlCommand(sqld, DbClass.BaglantiTestEt()))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pizzalst.Add(new pizzatablosu
                        {                           
                            id = Convert.ToInt32(reader["id"]),
                            pizzaadi = Convert.ToString(reader["pizzaadi"])
                          
                        });

                    }
                }
            }
            textBox2.Text = "Pizza çıkarıldı.";
            textBox2.Visible = true;

            comboBox1.SelectedValue = 0;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
