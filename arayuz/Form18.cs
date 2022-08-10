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
    public partial class Form18 : Form
    {
        List<promosyontablosu> promosyonlst = new List<promosyontablosu>();

        public Form18()
        {
            InitializeComponent();
        }

        private void Form18_Load(object sender, EventArgs e)
        {
            string sqld = "SELECT * FROM promosyon_tablosu";

            using (SqlCommand cmd = new SqlCommand(sqld, DbClass.BaglantiTestEt()))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        promosyonlst.Add(new promosyontablosu
                        {
                            id= Convert.ToInt32(reader["id"]),
                            promosyon_adi=Convert.ToString(reader["promosyon_adi"])
                        });
                    }
                }
            }
            promosyonlst.RemoveAt(0);
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "promosyon_adi";
            comboBox1.DataSource = promosyonlst;
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cb = Convert.ToInt32(comboBox1.SelectedValue);
            string sqld = "DELETE FROM promosyon_tablosu WHERE id ="+ cb;

            using (SqlCommand cmd = new SqlCommand(sqld, DbClass.BaglantiTestEt()))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        promosyonlst.Add(new promosyontablosu
                        {
                            id = Convert.ToInt32(reader["id"]),
                            promosyon_adi = Convert.ToString(reader["promosyon_adi"])
                        });
                    }
                }
            }


            textBox2.Text = "Promosyon çıkarıldı.";
            textBox2.Visible = true;

            comboBox1.SelectedValue = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
