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
    public partial class Form3 : Form
    {
        
        List<pizzasiparistablosu> pizzasiparislst = new List<pizzasiparistablosu>();
        List<pizzatablosu> pizzalist = new List<pizzatablosu>();
        List<pizzaicecektablosu> iceceklst = new List<pizzaicecektablosu>();

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
            
            //databasedeki sipariş tablosundan verileri çekmek için

            string sqld = "SELECT * From siparis_tablosu";

            using (SqlCommand cmd = new SqlCommand(sqld, DbClass.BaglantiTestEt()))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pizzasiparislst.Add(new pizzasiparistablosu// önce liste adı sonra class
                        {

                            id = Convert.ToInt32(reader["id"]),
                            siparis_numarasi = Convert.ToString(reader["siparis_numarasi"]),
                            pizza_adet = Convert.ToInt32(reader["pizza_adet"]),
                            pizza_adi = Convert.ToString(reader["pizza_adi"]),
                            icecek = Convert.ToString(reader["icecek"]),
                            icecek_adedi = Convert.ToInt32(reader["icecek_adedi"]),
                            adres = Convert.ToString(reader["adres"]),
                            fiyat = Convert.ToDecimal(reader["fiyat"]),
                            musteri_ad = Convert.ToString(reader["musteri_ad"]),
                            musteri_soyad = Convert.ToString(reader["musteri_soyad"]),
                            musteri_telefon = Convert.ToString(reader["musteri_telefon"]),
                            saat=Convert.ToString(reader["saat"]),
                            siparis_durumu = Convert.ToString(reader["siparis_durumu"]),
                            siparis_ilerlemesi = Convert.ToString(reader["siparis_ilerlemesi"])


                        }) ;
                    }


                }


              
                dataGridView1.DataSource = pizzasiparislst;

            }
            // pizza tablosundan id ve pizza adini alıyor.
            string sqld1 = "SELECT * From pizza_tablosu";

            using (SqlCommand cmd = new SqlCommand(sqld1, DbClass.BaglantiTestEt()))
            {
                using (SqlDataReader reader1 = cmd.ExecuteReader())
                {
                    while (reader1.Read())
                    {
                        pizzalist.Add(new pizzatablosu// liste adı sonra class adı
                        {

                            id = Convert.ToInt32(reader1["id"]),
                            pizzaadi = Convert.ToString(reader1["pizzaadi"])

                        });
                    }

                }

            }

            foreach (var item in pizzasiparislst)
            {
                var qq = pizzalist.Where(x => x.id == Convert.ToInt32(item.pizza_adi)).FirstOrDefault();
                item.pizza_adi =qq.pizzaadi;
            }
                
                //for (int i = 0; i < pizzasiparislst.Count; i++)
                //{
                //    int pizzaad = Convert.ToInt32(pizzasiparislst[i].pizza_adi);//id'yi alıyor

                //    pizzasiparislst[i].pizza_adi = pizzalist[pizzaad - 1].pizzaadi;// id'ye karşılık gelen pizzaadini atiyor
                    
                //    //bu yaptğımız işlem ile for döngümüz pizzasiparislst.count kadar dönecek ve bu sırada pizzaad değişkenine pizza_adi'ni atayacak.
                //}


            string sqld2 = "SELECT * From icecek_tablosu";

            using (SqlCommand cmd = new SqlCommand(sqld2, DbClass.BaglantiTestEt()))
            {
                using (SqlDataReader reader2 = cmd.ExecuteReader())
                {
                    while (reader2.Read())
                    {
                        iceceklst.Add(new pizzaicecektablosu
                        {

                            id = Convert.ToInt32(reader2["id"]),
                            icecek = Convert.ToString(reader2["icecek"])

                        });

                    }
                    


                }
                for (int i = 0; i < pizzasiparislst.Count; i++)
                {
                    int icecekad = Convert.ToInt32(pizzasiparislst[i].icecek);//id'yi alıyor

                    pizzasiparislst[i].icecek = iceceklst[icecekad - 1].icecek;// id'ye karşılık gelen icecek adini atiyor

                    //bu yaptğımız işlem ile for döngümüz pizzasiparislst.count kadar dönecek ve bu sırada icecekad değişkenine icecek'i atayacak. 
                }

            }



        }

        
    }
}
