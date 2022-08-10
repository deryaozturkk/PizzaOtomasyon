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
    public partial class Form12 : Form
    {
        List<pizzasiparistablosu> PLST = new List<pizzasiparistablosu>();

        public Form12()
        {
            InitializeComponent();
        }
        // INNER JOIN ile iki tabloyu birleştiriyoruz
        private void Form12_Load(object sender, EventArgs e)
        {
            //string ij = "SELECT ST.musteri_ad,ST.musteri_soyad,PT.pizzaadi FROM siparis_tablosu ST INNER JOIN pizza_tablosu PT ON ST.pizza_adi = PT.id";

            string sqld = "SELECT ST.id, ST.Siparis_Numarasi, ST.pizza_adet, PT.pizzaadi, IT.icecek, ST.icecek_adedi, ST.adres, ST.fiyat, ST.musteri_ad, " +
                "ST.musteri_soyad, ST.musteri_telefon, ST.saat, ST.siparis_durumu, ST.siparis_ilerlemesi FROM siparis_tablosu ST INNER JOIN pizza_tablosu PT ON " +
                "ST.pizza_adi = PT.id INNER JOIN icecek_tablosu IT ON ST.icecek = IT.id";

            using (SqlCommand cmd = new SqlCommand(sqld, DbClass.BaglantiTestEt()))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PLST.Add(new pizzasiparistablosu
                        {
                            id = Convert.ToInt32(reader["id"]),

                            siparis_numarasi = Convert.ToString(reader["siparis_numarasi"]),

                            pizza_adet= Convert.ToInt32(reader["pizza_adet"]),

                            pizza_adi = Convert.ToString(reader["pizzaadi"]),

                            icecek = Convert.ToString(reader["icecek"]),

                            icecek_adedi = Convert.ToInt32(reader["icecek_adedi"]),

                            adres =Convert.ToString(reader["adres"]),

                            fiyat = Convert.ToDecimal(reader["fiyat"]),

                            musteri_ad= Convert.ToString(reader["musteri_ad"]),

                            musteri_soyad=Convert.ToString(reader["musteri_soyad"]),

                            musteri_telefon = Convert.ToString(reader["musteri_telefon"]),

                            saat = Convert.ToString(reader["saat"]),

                            siparis_durumu =Convert.ToString(reader["siparis_durumu"]),

                            siparis_ilerlemesi = Convert.ToString(reader["siparis_ilerlemesi"])
                        });
                    }
                }
            }

            dataGridView1.DataSource = PLST;

        }
    }
}
