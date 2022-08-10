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
    public partial class Form15 : Form
    {
        List<promosyontablosu> promosyonlst = new List<promosyontablosu>();

        public Form15()
        {
            InitializeComponent();
        }
        private void Form15_Load(object sender, EventArgs e)
        {
            string sqld1 = "SELECT * from promosyon_tablosu";



            using (SqlCommand cmd = new SqlCommand(sqld1, DbClass.BaglantiTestEt()))
            {
                using (SqlDataReader reader1 = cmd.ExecuteReader())
                {
                    while (reader1.Read())
                    {
                        promosyonlst.Add(new promosyontablosu// liste adı sonra class adı
                        {
                            id = Convert.ToInt32(reader1["id"]),
                            promosyon_adi = Convert.ToString(reader1["promosyon_adi"]),
                            fiyat = Convert.ToDecimal(reader1["fiyat"]),
                            promosyon_stok= Convert.ToInt32(reader1["promosyon_stok"])

                            
                        });
                    }

                    promosyonlst.RemoveAt(0);

                    //form açıldığında comboboxta gözükecek değer id'den alınsın
                    comboBox1.ValueMember = "id";
                    //comboboxta gözükecek textte promosyon_adi sütunu görünsün
                    comboBox1.DisplayMember = "promosyon_adi";
                    comboBox1.DataSource = promosyonlst;//liste adı

                }

            }

            textBox1.Text = Convert.ToString(promosyonlst[0].promosyon_stok);


        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cb = Convert.ToInt32(comboBox1.SelectedIndex);

            textBox1.Text = Convert.ToString(promosyonlst[cb].promosyon_stok);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cb = Convert.ToInt32(comboBox1.SelectedValue);

            string sqld = "Update promosyon_tablosu set promosyon_stok = @promosyon_stok Where id = " + cb;

            using (SqlCommand cmd = new SqlCommand(sqld, DbClass.BaglantiTestEt()))
            {
                cmd.Parameters.Add("promosyon_stok", SqlDbType.Int).Value = textBox1.Text;
                promosyonlst[comboBox1.SelectedIndex].promosyon_stok = int.Parse(textBox1.Text);

                cmd.ExecuteNonQuery();
            }


            textBox2.Text = "Stok güncellendi.";
            textBox2.Visible = true;

            //comboBox1.SelectedValue = 0;
            //textBox1.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

      
    }
}
