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
    public partial class Form5 : Form
    {
        int id;
        

        List<siparis_durum> siparislst = new List<siparis_durum>();

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            //databasedeki sipariş tablosundan verileri çekmek için

            string sqld = "SELECT * From siparis_tablosu";

            using (SqlCommand cmd = new SqlCommand(sqld, DbClass.BaglantiTestEt()))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        siparislst.Add(new siparis_durum// önce liste adı sonra class
                        {

                            id = Convert.ToInt32(reader["id"]),
                            siparis_numarasi = Convert.ToString(reader["siparis_numarasi"]),
                            siparis_durumu=Convert.ToString(reader["siparis_durumu"]),
                            siparis_ilerlemesi= Convert.ToString(reader["siparis_ilerlemesi"])



                        });
                    }


                }



                dataGridView1.DataSource = siparislst;

                
            }
        }

     

        private void button1_Click(object sender, EventArgs e)//hazirlaniyor
        {
            

            string derya = "Update siparis_tablosu Set siparis_durumu = @siparis_durumu, siparis_ilerlemesi = @siparis_ilerlemesi Where id = " + id;
            using (SqlCommand cmd = new SqlCommand(derya, DbClass.BaglantiTestEt()))
            {
             
                cmd.Parameters.Add("siparis_durumu", SqlDbType.VarChar).Value = "sipariş hazırlanıyor.";
                cmd.Parameters.Add("siparis_ilerlemesi", SqlDbType.VarChar).Value = "%" + "35";
               
                cmd.ExecuteNonQuery();//database'e veri yolluyor.


            }
    
        }
        private void button2_Click(object sender, EventArgs e)//yola çıktı
        {
            string derya = "Update siparis_tablosu Set siparis_durumu = @siparis_durumu, siparis_ilerlemesi = @siparis_ilerlemesi Where id = " + id;
            using (SqlCommand cmd = new SqlCommand(derya, DbClass.BaglantiTestEt()))
            {
             
                cmd.Parameters.Add("siparis_durumu", SqlDbType.VarChar).Value = "sipariş yola çıktı.";
                cmd.Parameters.Add("siparis_ilerlemesi", SqlDbType.VarChar).Value = "%"+"70";
               
                cmd.ExecuteNonQuery();//database'e veri yolluyor.
            }
        }

        private void button3_Click(object sender, EventArgs e) //teslim edildi
        {
            string derya = "Update siparis_tablosu Set siparis_durumu = @siparis_durumu, siparis_ilerlemesi = @siparis_ilerlemesi Where id = " + id;
            using (SqlCommand cmd = new SqlCommand(derya, DbClass.BaglantiTestEt()))
            {

                cmd.Parameters.Add("siparis_durumu", SqlDbType.VarChar).Value = "sipariş teslim edildi.";
                cmd.Parameters.Add("siparis_ilerlemesi", SqlDbType.VarChar).Value = "%" + "100";

                cmd.ExecuteNonQuery();//database'e veri yolluyor.
            }
        }

      
        // datagridde herhangi bir hücreye tıkladığınızda bütün satırı seçer
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;



            dataGridView1.Rows[index].Selected = true;



            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];



            id = Convert.ToInt32(row.Cells[0].Value);// bu id değişkeni global olarak tanımlanacak
        }
    }
}
