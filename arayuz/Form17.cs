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
    public partial class Form17 : Form
    {
        List<pizzaicecektablosu> iceceklst = new List<pizzaicecektablosu>();

        public Form17()
        {
            InitializeComponent();
        }

        private void Form17_Load(object sender, EventArgs e)
        {
            string sqld = "SELECT * FROM icecek_tablosu";

            using (SqlCommand cmd = new SqlCommand(sqld, DbClass.BaglantiTestEt()))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        iceceklst.Add(new pizzaicecektablosu
                        {
                            id= Convert.ToInt32(reader["id"]),
                            icecek= Convert.ToString(reader["icecek"]),
                            

                        });

                    }
                    iceceklst.RemoveAt(0);
                    comboBox1.ValueMember = "id";
                    comboBox1.DisplayMember = "icecek";
                    comboBox1.DataSource = iceceklst;

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cb = Convert.ToInt32(comboBox1.SelectedValue);
            string sqld = "DELETE FROM icecek_tablosu WHERE id= " + cb;

            using (SqlCommand cmd = new SqlCommand(sqld, DbClass.BaglantiTestEt()))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        iceceklst.Add(new pizzaicecektablosu
                        {
                            id = Convert.ToInt32(reader["id"]),
                            icecek = Convert.ToString(reader["icecek"]),
                            fiyat = Convert.ToDecimal(reader["fiyat"]),
                            stok_durumu = Convert.ToInt32(reader["stok_durumu"])


                        });

                    }
                }
            }
            textBox2.Text = "İçecek çıkartıldı.";
            textBox2.Visible = true;

            comboBox1.SelectedValue = 0;

        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
        
    
      
}

