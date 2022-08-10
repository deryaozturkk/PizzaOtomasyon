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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {

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
            if (textBox1.Text == " ")
            {
                textBox1.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız!");

                goto nokta;
            }

            string derya = "Insert into malzeme_stok (malzeme_adi,stok) values(@malzeme_adi,@stok)";
            using (SqlCommand cmd = new SqlCommand(derya, DbClass.BaglantiTestEt()))
            {

                cmd.Parameters.Add("malzeme_adi", SqlDbType.VarChar).Value = textBox1.Text;
                cmd.Parameters.Add("stok", SqlDbType.Int).Value = textBox2.Text;
                

                cmd.ExecuteNonQuery();//database'e veri yolluyor.
            }
            textBox3.Text = "Yeni malzemeler hazırlandı.";
            textBox3.Visible = true;

            textBox1.Text = "";
            textBox2.Text = "";



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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
