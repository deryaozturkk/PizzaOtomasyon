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
    public partial class Form8 : Form
    {
        List<malzemestok> malzemelst = new List<malzemestok>();
        List<malzemestok> malzemelst2 = new List<malzemestok>();
        List<malzemestok> malzemelst3 = new List<malzemestok>();
        List<malzemestok> malzemelst4 = new List<malzemestok>();
        List<malzemestok> malzemelst5 = new List<malzemestok>();
        List<pizzatablosu> pizzatablosu = new List<pizzatablosu>();

        public Form8()
        {
            InitializeComponent();
        }


        private void Form8_Load(object sender, EventArgs e)
        {
   
            string sqld4 = "Select * FROM malzeme_stok";
            using (SqlCommand cmd = new SqlCommand(sqld4, DbClass.BaglantiTestEt()))
            {
                using (SqlDataReader reader4 = cmd.ExecuteReader())// readerler değişken adı. hepsinin değişik isimli olmasının bir anlamı yok
                {
                    while (reader4.Read())
                    {
                        malzemelst.Add(new malzemestok
                        {

                            id = Convert.ToInt32(reader4["id"]),
                            malzeme_adi = Convert.ToString(reader4["malzeme_adi"]),
                            stok = Convert.ToInt32(reader4["stok"]),

                        });
                    }
                    // aldığımız verileri comboboxa aktarıyotuz.
                    comboBox2.ValueMember = "id";
                    comboBox2.DisplayMember = "malzeme_adi";
                    comboBox2.DataSource = malzemelst;



                }
            }


            string sqld5 = "Select * FROM malzeme_stok";
            using (SqlCommand cmd = new SqlCommand(sqld5, DbClass.BaglantiTestEt()))
            {
                using (SqlDataReader reader4 = cmd.ExecuteReader())// readerler değişken adı. hepsinin değişik isimli olmasının bir anlamı yok
                {
                    while (reader4.Read())
                    {
                        malzemelst2.Add(new malzemestok
                        {

                            id = Convert.ToInt32(reader4["id"]),
                            malzeme_adi = Convert.ToString(reader4["malzeme_adi"]),
                            stok = Convert.ToInt32(reader4["stok"]),

                        });
                    }
                    // aldığımız verileri comboboxa aktarıyotuz.
                    comboBox3.ValueMember = "id";
                    comboBox3.DisplayMember = "malzeme_adi";
                    comboBox3.DataSource = malzemelst2;



                }
            }


            string sqld6 = "Select * FROM malzeme_stok";
            using (SqlCommand cmd = new SqlCommand(sqld6, DbClass.BaglantiTestEt()))
            {
                using (SqlDataReader reader4 = cmd.ExecuteReader())// readerler değişken adı. hepsinin değişik isimli olmasının bir anlamı yok
                {
                    while (reader4.Read())
                    {
                        malzemelst3.Add(new malzemestok
                        {

                            id = Convert.ToInt32(reader4["id"]),
                            malzeme_adi = Convert.ToString(reader4["malzeme_adi"]),
                            stok = Convert.ToInt32(reader4["stok"]),

                        });
                    }
                    // aldığımız verileri comboboxa aktarıyotuz.
                    comboBox4.ValueMember = "id";
                    comboBox4.DisplayMember = "malzeme_adi";
                    comboBox4.DataSource = malzemelst3;



                }
            }
            string sqld7 = "Select * FROM malzeme_stok";
            using (SqlCommand cmd = new SqlCommand(sqld7, DbClass.BaglantiTestEt()))
            {
                using (SqlDataReader reader4 = cmd.ExecuteReader())
                {
                    while (reader4.Read())
                    {
                        malzemelst4.Add(new malzemestok
                        {

                            id = Convert.ToInt32(reader4["id"]),
                            malzeme_adi = Convert.ToString(reader4["malzeme_adi"]),
                            stok = Convert.ToInt32(reader4["stok"]),

                        });
                    }
                    // aldığımız verileri comboboxa aktarıyotuz.
                    comboBox5.ValueMember = "id";
                    comboBox5.DisplayMember = "malzeme_adi";
                    comboBox5.DataSource = malzemelst4;



                }
            }



            string sqld8 = "Select * FROM malzeme_stok";
            using (SqlCommand cmd = new SqlCommand(sqld8, DbClass.BaglantiTestEt()))
            {
                using (SqlDataReader reader4 = cmd.ExecuteReader())
                {
                    while (reader4.Read())
                    {
                        malzemelst5.Add(new malzemestok
                        {

                            id = Convert.ToInt32(reader4["id"]),
                            malzeme_adi = Convert.ToString(reader4["malzeme_adi"]),
                            stok = Convert.ToInt32(reader4["stok"]),

                        });
                    }
                    // aldığımız verileri comboboxa aktarıyotuz.
                    comboBox6.ValueMember = "id";
                    comboBox6.DisplayMember = "malzeme_adi";
                    comboBox6.DataSource = malzemelst5;



                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız!");

                goto nokta;
            }

            string derya = "Insert into pizza_tablosu (pizzaadi,malzeme_1,malzeme_2,malzeme_3,malzeme_4,malzeme_5,fiyat) values(@pizzaadi,@malzeme_1,@malzeme_2,@malzeme_3,@malzeme_4,@malzeme_5,@fiyat)";
            using (SqlCommand cmd = new SqlCommand(derya, DbClass.BaglantiTestEt()))
            {
               
                cmd.Parameters.Add("pizzaadi", SqlDbType.VarChar).Value =textBox1.Text;
                cmd.Parameters.Add("malzeme_1", SqlDbType.Int).Value = comboBox2.SelectedValue;
                cmd.Parameters.Add("malzeme_2", SqlDbType.Int).Value = comboBox3.SelectedValue;
                cmd.Parameters.Add("malzeme_3", SqlDbType.Int).Value = comboBox4.SelectedValue;
                cmd.Parameters.Add("malzeme_4", SqlDbType.Int).Value = comboBox5.SelectedValue;
                cmd.Parameters.Add("malzeme_5", SqlDbType.Int).Value = comboBox6.SelectedValue;
                cmd.Parameters.Add("fiyat", SqlDbType.Decimal).Value = textBox3.Text;

                cmd.ExecuteNonQuery();//database'e veri yolluyor.
            }
            textBox2.Text = "Yeni pizza oluşturuldu.";
            textBox2.Visible = true;

            textBox1.Text = "";
            textBox3.Text = "";
            comboBox2.SelectedValue = 0;
            comboBox3.SelectedValue = 0;
            comboBox4.SelectedValue = 0;
            comboBox5.SelectedValue = 0;
            comboBox6.SelectedValue = 0;


        nokta: { }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == " ")
            {
                textBox1.Text = "";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {           
            if (textBox1.Text == " ")
            {
                textBox1.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
             
            this.Hide();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
        }

    
    }
}
