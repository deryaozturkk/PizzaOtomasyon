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
    public partial class Form13 : Form
    {
    
        List<malzemestok> malzemelst = new List<malzemestok>();


        public Form13()
        {
            InitializeComponent();
        }

        private void Form13_Load(object sender, EventArgs e)
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

                            malzeme_adi =Convert.ToString(reader1["malzeme_adi"]),

                            stok = Convert.ToInt32(reader1["stok"])


                        });
                    }

                    malzemelst.RemoveAt(0);

                    //form açıldığında comboboxta gözükecek değer id'den alınsın
                    comboBox1.ValueMember = "id";
                    //comboboxta gözükecek textte malzeme_adi sütunu görünsün
                    comboBox1.DisplayMember = "malzeme_adi";
                    comboBox1.DataSource = malzemelst;//liste adı

                }

            }

            textBox1.Text = Convert.ToString(malzemelst[0].stok);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cb = Convert.ToInt32(comboBox1.SelectedIndex);

            textBox1.Text = Convert.ToString(malzemelst[cb].stok);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string der5 = "Update malzeme_stok Set stok = @stok Where id = " + m5;

            int cb = Convert.ToInt32(comboBox1.SelectedValue);

            string sqld = "Update malzeme_stok set stok = @stok Where id = '" + cb + "'";
            //string sqlD2 = string.Format("UPDATE MALZEME_STOK SET STOK = @STOKADI WHERE ID = {0} alkfjaslkfjsal {0} asflsalaf {0} {1}", cb,3.ToString());
            //string sqlD3 = "UPDATE MALZEME_STOK SET STOK = @STOKADI WHERE ID = @CBID ";

            //injection

            using (SqlCommand cmd = new SqlCommand(sqld, DbClass.BaglantiTestEt()))
            {
                cmd.Parameters.Add("@stok", SqlDbType.Int).Value = textBox1.Text;
                //cmd.Parameters.Add("@CBID", SqlDbType.Int).Value = Convert.ToInt32(cb);
                malzemelst[comboBox1.SelectedIndex].stok = int.Parse(textBox1.Text);///////////**********************************
                cmd.ExecuteNonQuery();
            }


            textBox2.Text = "Stok güncellendi.";
            textBox2.Visible = true;

            //MessageBox.Show("Güncelledi");
            //Form13 frm = new Form13();
            //this.Hide();
            //frm.Show();



            //comboBox1.SelectedValue = 0;
            //textBox1.Text = "";


        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
