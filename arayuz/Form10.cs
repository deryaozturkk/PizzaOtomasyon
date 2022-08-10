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




    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == " ")
            {
                textBox1.Text = "";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == " ")
            {
                textBox2.Text = "";
            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == " ")
            {
                textBox4.Text = "";
            }
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız!");

                goto nokta;
            }

            string derya = "Insert into icecek_tablosu (icecek,fiyat,stok_durumu) values(@icecek,@fiyat,@stok_durumu)";
            using (SqlCommand cmd = new SqlCommand(derya, DbClass.BaglantiTestEt()))
            {

                cmd.Parameters.Add("icecek", SqlDbType.VarChar).Value = textBox1.Text;
                cmd.Parameters.Add("fiyat", SqlDbType.Decimal).Value = textBox4.Text;
                cmd.Parameters.Add("stok_durumu", SqlDbType.Int).Value = textBox2.Text;
                


                cmd.ExecuteNonQuery();//database'e veri yolluyor.
            }
            textBox3.Text = "Yeni içecekler hazırlandı.";
            textBox3.Visible = true;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";

        nokta: { }
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -2))
            //{
            //    e.Handled = true;
            //}
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
