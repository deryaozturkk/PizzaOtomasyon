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
    public partial class Form16 : Form
    {
        List<malzemestok> malzemelst = new List<malzemestok>();
        public Form16()
        {
            InitializeComponent();
        }

        private void Form16_Load(object sender, EventArgs e)
        {
            string sqld1 = "SELECT * from malzeme_stok";



            using (SqlCommand cmd = new SqlCommand(sqld1, DbClass.BaglantiTestEt()))
            {
                using (SqlDataReader reader1 = cmd.ExecuteReader())
                {
                    while (reader1.Read())
                    {
                        malzemelst.Add(new malzemestok// liste adı sonra class adı
                        {
                            id = Convert.ToInt32(reader1["id"]),
                            malzeme_adi = Convert.ToString(reader1["malzeme_adi"])

                        });
                    }

                    malzemelst.RemoveAt(0);

                    //form açıldığında comboboxta gözükecek değer id'den alınsın
                    comboBox1.ValueMember = "id";                  
                    comboBox1.DisplayMember = "malzeme_adi";
                    comboBox1.DataSource = malzemelst;//liste adı

                }

            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cb = Convert.ToInt32(comboBox1.SelectedValue);
            string sqld = "DELETE FROM malzeme_stok WHERE id = " + cb;

            using (SqlCommand cmd = new SqlCommand(sqld, DbClass.BaglantiTestEt()))
            {
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        malzemelst.Add(new malzemestok
                        {
                            id = Convert.ToInt32(reader["id"]),

                            malzeme_adi = Convert.ToString(reader["malzeme_adi"]),

                            stok = Convert.ToInt32(reader["stok"])
                        });
                    }
                }
            }
           
            textBox2.Text = "Malzeme çıkartıldı.";
            textBox2.Visible = true;

            comboBox1.SelectedValue = 0;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}


