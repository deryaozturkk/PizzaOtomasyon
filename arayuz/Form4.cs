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
    public partial class Form4 : Form
    {
        
        List<customer> customerlst = new List<customer>();
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string sqld = "SELECT * From siparis_tablosu where siparis_numarasi = '" + textBox1.Text + "'";

            using (SqlCommand cmd = new SqlCommand(sqld, DbClass.BaglantiTestEt()))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customerlst.Add(new customer// önce liste adı sonra class
                        {

                            id = Convert.ToInt32(reader["id"]),
                            siparis_numarasi = Convert.ToString(reader["siparis_numarasi"]),
                            adres = Convert.ToString(reader["adres"]),
                            musteri_ad = Convert.ToString(reader["musteri_ad"]),
                            musteri_soyad = Convert.ToString(reader["musteri_soyad"]),
                            musteri_telefon = Convert.ToString(reader["musteri_telefon"]),
                            siparis_durumu = Convert.ToString(reader["siparis_durumu"]),
                            siparis_ilerlemesi = Convert.ToString(reader["siparis_ilerlemesi"])


                        });
                    }


                }

                dataGridView1.DataSource = customerlst;

            }


        }

    }
}
