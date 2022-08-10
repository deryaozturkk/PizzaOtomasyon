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
    public partial class Form14 : Form
    {
        List<pizzaicecektablosu> iceceklst = new List<pizzaicecektablosu>();
        public Form14()
        {
            InitializeComponent();
        }
       
        private void Form14_Load(object sender, EventArgs e)
        {
            string sqld1 = "SELECT * from icecek_tablosu";



            using (SqlCommand cmd = new SqlCommand(sqld1, DbClass.BaglantiTestEt()))
            {
                using (SqlDataReader reader1 = cmd.ExecuteReader())
                {
                    while (reader1.Read())
                    {
                        iceceklst.Add(new pizzaicecektablosu// liste adı sonra class adı
                        {
                            id = Convert.ToInt32(reader1["id"]),
                            icecek = Convert.ToString(reader1["icecek"]),
                            fiyat = Convert.ToDecimal(reader1["fiyat"]),
                            stok_durumu = Convert.ToInt32(reader1["stok_durumu"])
                            

                        });
                    }

                    iceceklst.RemoveAt(0);

                    //form açıldığında comboboxta gözükecek değer id'den alınsın
                    comboBox1.ValueMember = "id";
                    //comboboxta gözükecek textte icecek sütunu görünsün
                    comboBox1.DisplayMember = "icecek";
                    comboBox1.DataSource = iceceklst;//liste adı

                }

            }

            textBox1.Text = Convert.ToString(iceceklst[0].stok_durumu);

        

    }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int cb = Convert.ToInt32(comboBox1.SelectedIndex);

            textBox1.Text = Convert.ToString(iceceklst[cb].stok_durumu);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string der5 = "Update malzeme_stok Set stok = @stok Where id = " + m5;

            int cb = Convert.ToInt32(comboBox1.SelectedValue);

            string sqld = "Update icecek_tablosu set stok_durumu = @stok_durumu Where id = " + cb;

            using (SqlCommand cmd = new SqlCommand(sqld, DbClass.BaglantiTestEt()))
            {
                cmd.Parameters.Add("stok_durumu", SqlDbType.Int).Value = textBox1.Text;
                iceceklst[comboBox1.SelectedIndex].stok_durumu = int.Parse(textBox1.Text);

                cmd.ExecuteNonQuery();
            }


            textBox2.Text = "Stok güncellendi.";
            textBox2.Visible = true;

            //textBox1.Text = "";
            //comboBox1.SelectedValue = 0;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
