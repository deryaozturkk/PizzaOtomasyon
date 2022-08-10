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
    public partial class Form2 : Form
    {
        //globalde değişkenleri tanımladım.
        decimal totalfiyat = 0;
        decimal icecekfiyat = 0;
        decimal promosyonfiyat = 0;
        decimal pizzafiyat = 0;
        int secili_promosyon, secili_icecek, secili_pizza;
        int m1, m2, m3, m4, m5;
        
        //eğer boş karakter girilmeye çalışılırsa girmeye izin verilmesin
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if(textBox2.Text == " ")
            {
                textBox2.Text = "";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == " ")
            {
                textBox3.Text = "";
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == " ")
            {
                textBox4.Text = "";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == " ")
            {
                textBox1.Text = "";
            }
        }

        //oluşturduğum sınıflara ait listeler oluşturdum. 
        List<pizzasiparistablosu> pizzasiparistablosu = new List<pizzasiparistablosu>();
        List<pizzatablosu> pizzatablosu = new List<pizzatablosu>();
        List<pizzaicecektablosu> pizzaicecektablosu = new List<pizzaicecektablosu>();// baştaki classın adı sonraki listenin adı olacak.
        List<promosyontablosu> promosyonlst = new List<promosyontablosu>();
        List<malzemestok> malzemelst = new List<malzemestok>();
        List<customer> customerlst = new List<customer>();

        public Form2()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //databasedeki sipariş tablosundan verileri çekmek için

            string sqld = "SELECT * From siparis_tablosu";

            using (SqlCommand cmd = new SqlCommand(sqld, DbClass.BaglantiTestEt()))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pizzasiparistablosu.Add(new pizzasiparistablosu// önce liste adı sonra class
                        {

                            id = Convert.ToInt32(reader["id"]),
                            siparis_numarasi = Convert.ToString(reader["siparis_numarasi"]),
                            pizza_adet = Convert.ToInt32(reader["pizza_adet"]),
                            pizza_adi = Convert.ToString(reader["pizza_adi"]),
                            icecek = Convert.ToString(reader["icecek"]),
                            icecek_adedi = Convert.ToInt32(reader["icecek_adedi"]),
                            adres = Convert.ToString(reader["adres"]),
                            fiyat = Convert.ToDecimal(reader["fiyat"]),
                            musteri_ad= Convert.ToString(reader["musteri_ad"]),
                            musteri_soyad = Convert.ToString(reader["musteri_soyad"]),
                            musteri_telefon = Convert.ToString(reader["musteri_telefon"]),
                            saat=Convert.ToString(reader["saat"]),
                            siparis_durumu = Convert.ToString(reader["siparis_durumu"]),
                            siparis_ilerlemesi = Convert.ToString(reader["siparis_ilerlemesi"])
                        });
                    }


                }

            }

            string sqld1 = "SELECT * From pizza_tablosu";

            using (SqlCommand cmd = new SqlCommand(sqld1, DbClass.BaglantiTestEt()))
            {
                using (SqlDataReader reader1 = cmd.ExecuteReader())
                {
                    while (reader1.Read())
                    {
                        pizzatablosu.Add(new pizzatablosu// liste adı sonra class adı
                        {

                            id = Convert.ToInt32(reader1["id"]),
                            pizzaadi = Convert.ToString(reader1["pizzaadi"]),
                            malzeme_1 = Convert.ToInt32(reader1["malzeme_1"]),
                            malzeme_2 = Convert.ToInt32(reader1["malzeme_2"]),
                            malzeme_3 = Convert.ToInt32(reader1["malzeme_3"]),
                            malzeme_4 = Convert.ToInt32(reader1["malzeme_4"]),
                            malzeme_5 = Convert.ToInt32(reader1["malzeme_5"]),
                            fiyat = Convert.ToDecimal(reader1["fiyat"])

                        });
                    }
                    // form açıldığında comboboxta gözükecek değer id'den alınsın
                    comboBox1.ValueMember = "id";
                    //comboboxta gözükecek textte pizzaadi listesi görünsün
                    comboBox1.DisplayMember = "pizzaadi";
                    comboBox1.DataSource = pizzatablosu;//liste adı

                }

            }


            string sqld2 = "SELECT * From icecek_tablosu";

            using (SqlCommand cmd = new SqlCommand(sqld2, DbClass.BaglantiTestEt()))
            {
                using (SqlDataReader reader2 = cmd.ExecuteReader())
                {
                    while (reader2.Read())
                    {
                        pizzaicecektablosu.Add(new pizzaicecektablosu
                        {

                            id = Convert.ToInt32(reader2["id"]),
                            icecek = Convert.ToString(reader2["icecek"]),
                            fiyat = Convert.ToDecimal(reader2["fiyat"]),
                            stok_durumu = Convert.ToInt32(reader2["stok_durumu"])



                        });

                    }
                    comboBox2.ValueMember = "id";
                    comboBox2.DisplayMember = "icecek";
                    comboBox2.DataSource = pizzaicecektablosu;
                    //comboboxın 5 değerden sonra kaydırmalı olması için
                    comboBox2.DropDownHeight = comboBox2.ItemHeight * 5;


                }

            }


            string sqld3 = "SELECT * From promosyon_tablosu";

            using (SqlCommand cmd = new SqlCommand(sqld3, DbClass.BaglantiTestEt()))
            {
                using (SqlDataReader reader3 = cmd.ExecuteReader())
                {
                    while (reader3.Read())
                    {
                        promosyonlst.Add(new promosyontablosu
                        {

                            id = Convert.ToInt32(reader3["id"]),
                            promosyon_adi = Convert.ToString(reader3["promosyon_adi"]),
                            promosyon_sos = Convert.ToInt32(reader3["promosyon_sos"]),
                            promosyon_yiyecek = Convert.ToInt32(reader3["promosyon_yiyecek"]),
                            fiyat = Convert.ToDecimal(reader3["fiyat"])

                        });
                    }

                    comboBox3.ValueMember = "id";
                    comboBox3.DisplayMember = "promosyon_adi";
                    comboBox3.DataSource = promosyonlst;

                }

            }

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

                }
            }

   


            // numericUpDownda' form açıldığında gözükecek değer 1 olmalı.
            numericUpDown1.Value = 1;
            numericUpDown2.Value = 1;


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            totalfiyat = totalfiyat - pizzafiyat;//comboboxta bir pizza seçili olduğu için onun girilen fiyatı çıkarılsın.
            secili_pizza = Convert.ToInt32(comboBox1.SelectedIndex);//seçili indexi almak istiyoruz.
            pizzafiyat = Convert.ToDecimal(pizzatablosu[secili_pizza].fiyat * numericUpDown1.Value);// her adet artışında güncellensin.
            totalfiyat = totalfiyat + pizzafiyat;
            label10.Text = Convert.ToString(totalfiyat); //fiyat label10'a atılsın
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            totalfiyat = totalfiyat - promosyonfiyat;
            secili_promosyon = Convert.ToInt32(comboBox3.SelectedIndex);
            promosyonfiyat = Convert.ToDecimal(promosyonlst[secili_promosyon].fiyat * numericUpDown3.Value);
            totalfiyat = totalfiyat + promosyonfiyat;
            label10.Text = Convert.ToString(totalfiyat);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //pizzadan alınacak adet 0 olmasın
            if (numericUpDown1.Value == 0)
            {
                numericUpDown1.Value = 1;
            }

            totalfiyat = totalfiyat - pizzafiyat;
            pizzafiyat = pizzatablosu[secili_pizza].fiyat * numericUpDown1.Value;
            totalfiyat = totalfiyat + pizzafiyat;
            label10.Text = Convert.ToString(totalfiyat);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 11)// eğer promosyon istemiyorum seçildiyse adet 0'dan başka değer olamasın
            {
                numericUpDown2.Value = 0;
            }
            totalfiyat = totalfiyat - icecekfiyat;
            icecekfiyat = pizzaicecektablosu[secili_icecek].fiyat * numericUpDown2.Value;
            totalfiyat = totalfiyat + icecekfiyat;
            label10.Text = Convert.ToString(totalfiyat);
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            string saat = DateTime.Now.Hour + "." + DateTime.Now.Minute + "." + DateTime.Now.Second;


            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız!");

                goto nokta;
            }



            //sipariş gönderildiğinde hangi değerin databasede nereye aktarılacağını belirttik.
            string derya = "Insert into siparis_tablosu (siparis_numarasi,pizza_adet,pizza_adi,icecek,icecek_adedi,adres,fiyat,musteri_ad,musteri_soyad,musteri_telefon,saat,siparis_durumu,siparis_ilerlemesi) values(@siparis_numarasi,@pizza_adet,@pizza_adi,@icecek,@icecek_adedi,@adres,@fiyat,@musteri_ad,@musteri_soyad,@musteri_telefon,@saat,@siparis_durumu,@siparis_ilerlemesi)";
            using (SqlCommand cmd = new SqlCommand(derya, DbClass.BaglantiTestEt()))
            {
                cmd.Parameters.Add("fiyat", SqlDbType.Decimal).Value = totalfiyat;
                cmd.Parameters.Add("siparis_numarasi", SqlDbType.VarChar).Value = FisNo();
                cmd.Parameters.Add("pizza_adet", SqlDbType.Int).Value = numericUpDown1.Value;
                cmd.Parameters.Add("pizza_adi", SqlDbType.Int).Value = comboBox1.SelectedValue;
                cmd.Parameters.Add("icecek", SqlDbType.Int).Value = comboBox2.SelectedValue;
                cmd.Parameters.Add("icecek_adedi", SqlDbType.Int).Value = numericUpDown2.Value;
                cmd.Parameters.Add("adres", SqlDbType.VarChar).Value = textBox1.Text;
                cmd.Parameters.Add("musteri_ad", SqlDbType.VarChar).Value = textBox2.Text;
                cmd.Parameters.Add("musteri_soyad", SqlDbType.VarChar).Value = textBox3.Text; 
                cmd.Parameters.Add("musteri_telefon", SqlDbType.VarChar).Value = textBox4.Text;
                cmd.Parameters.Add("saat", SqlDbType.VarChar).Value = saat;
                cmd.Parameters.Add("siparis_durumu", SqlDbType.VarChar).Value ="sipariş oluşturdu." ;
                cmd.Parameters.Add("siparis_ilerlemesi", SqlDbType.VarChar).Value = "%"+"0";

                cmd.ExecuteNonQuery();//database'e veri yolluyor.
            }


            int i1s;//içecek stoğu
            int d;
            d = Convert.ToInt32(comboBox2.SelectedIndex);
            int db = Convert.ToInt32(pizzaicecektablosu[d].id);
            i1s = Convert.ToInt32(pizzaicecektablosu[d].stok_durumu - numericUpDown2.Value);

            string der6 = "Update icecek_tablosu Set stok_durumu = @stok_durumu Where id = " + db;

            using (SqlCommand cmd = new SqlCommand(der6, DbClass.BaglantiTestEt()))
            {
                cmd.Parameters.Add("stok_durumu", SqlDbType.Int).Value = i1s;

                cmd.ExecuteNonQuery();
            }

            


            int m1s, m2s, m3s, m4s, m5s;
            int c1;
            c1 = Convert.ToInt32(comboBox1.SelectedIndex);

            m1 = Convert.ToInt32(pizzatablosu[c1].malzeme_1);
            m2 = Convert.ToInt32(pizzatablosu[c1].malzeme_2);
            m3 = Convert.ToInt32(pizzatablosu[c1].malzeme_3);
            m4 = Convert.ToInt32(pizzatablosu[c1].malzeme_4);
            m5 = Convert.ToInt32(pizzatablosu[c1].malzeme_5);




            //stok sayısını adet kadar eksiltme
            m1s = Convert.ToInt32(malzemelst[m1 - 1].stok - numericUpDown1.Value);
            m2s = Convert.ToInt32(malzemelst[m2 - 1].stok - numericUpDown1.Value);
            m3s = Convert.ToInt32(malzemelst[m3 - 1].stok - numericUpDown1.Value);
            m4s = Convert.ToInt32(malzemelst[m4 - 1].stok - numericUpDown1.Value);
            m5s = Convert.ToInt32(malzemelst[m5 - 1].stok - numericUpDown1.Value);

            string der = "Update malzeme_stok Set stok = @stok Where id = " + m1;

            using (SqlCommand cmd = new SqlCommand(der, DbClass.BaglantiTestEt()))
            {
                cmd.Parameters.Add("stok", SqlDbType.Int).Value = m1s;

                cmd.ExecuteNonQuery();
            }

            string der2 = "Update malzeme_stok Set stok = @stok Where id = " + m2;

            using (SqlCommand cmd = new SqlCommand(der2, DbClass.BaglantiTestEt()))
            {
                cmd.Parameters.Add("stok", SqlDbType.Int).Value = m2s;

                cmd.ExecuteNonQuery();
            }

            string der3 = "Update malzeme_stok Set stok = @stok Where id = " + m3;

            using (SqlCommand cmd = new SqlCommand(der3, DbClass.BaglantiTestEt()))
            {
                cmd.Parameters.Add("stok", SqlDbType.Int).Value = m3s;

                cmd.ExecuteNonQuery();
            }

            string der4 = "Update malzeme_stok Set stok = @stok Where id = " + m4;

            using (SqlCommand cmd = new SqlCommand(der4, DbClass.BaglantiTestEt()))
            {
                cmd.Parameters.Add("stok", SqlDbType.Int).Value = m4s;

                cmd.ExecuteNonQuery();
            }
            string der5 = "Update malzeme_stok Set stok = @stok Where id = " + m5;

            using (SqlCommand cmd = new SqlCommand(der5, DbClass.BaglantiTestEt()))
            {
                cmd.Parameters.Add("stok", SqlDbType.Int).Value = m5s;

                cmd.ExecuteNonQuery();
            }

            //for(int i = 0; i < pizzatablosu.Count; i++)
            //{
            //    int m1s, m2s, m3s, m4s, m5s;

            //    m1 = Convert.ToInt32(pizzatablosu[i].malzeme_1);
            //    //stok sayısını adet kadar eksiltme
            //    m1s = Convert.ToInt32(malzemelst[m1 - 1].stok - numericUpDown1.Value);




            //    string der = "Update malzeme_stok Set stok = @stok Where ID = " + m1;

            //    using (SqlCommand cmd = new SqlCommand(der, DbClass.BaglantiTestEt()))
            //    {
            //        cmd.Parameters.Add("stok", SqlDbType.Int).Value = m1s;

            //        cmd.ExecuteNonQuery();
            //    }

            //    if (pizzatablosu[i].malzeme_2 != 1 && pizzatablosu[i].malzeme_3 != 1 && pizzatablosu[i].malzeme_4 != 1 &&
            //        pizzatablosu[i].malzeme_5 != 1)
            //    {
            //        m2 = Convert.ToInt32(pizzatablosu[i].malzeme_2);
            //        m2s = Convert.ToInt32(malzemelst[m2 - 1].stok - numericUpDown1.Value);

            //        string der2 = "Update malzeme_stok Set stok = @stok Where ID = " + m2;
            //        using (SqlCommand cmd = new SqlCommand(der2, DbClass.BaglantiTestEt()))
            //        {
            //            cmd.Parameters.Add("stok", SqlDbType.Int).Value = m2s;

            //            cmd.ExecuteNonQuery();
            //        }

            //        m3 = Convert.ToInt32(pizzatablosu[i].malzeme_3);
            //        m3s = Convert.ToInt32(malzemelst[m3 - 1].stok - numericUpDown1.Value);

            //        string der3 = "Update malzeme_stok Set stok = @stok Where ID = " + m3;
            //        using (SqlCommand cmd = new SqlCommand(der3, DbClass.BaglantiTestEt()))
            //        {
            //            cmd.Parameters.Add("stok", SqlDbType.Int).Value = m3s;

            //            cmd.ExecuteNonQuery();
            //        }

            //        m4 = Convert.ToInt32(pizzatablosu[i].malzeme_4);
            //        m4s = Convert.ToInt32(malzemelst[m4 - 1].stok - numericUpDown1.Value);

            //        string der4 = "Update malzeme_stok Set stok = @stok Where ID = " + m4;
            //        using (SqlCommand cmd = new SqlCommand(der4, DbClass.BaglantiTestEt()))
            //        {
            //            cmd.Parameters.Add("stok", SqlDbType.Int).Value = m4s;

            //            cmd.ExecuteNonQuery();
            //        }

            //        m5 = Convert.ToInt32(pizzatablosu[i].malzeme_5);
            //        m5s = Convert.ToInt32(malzemelst[m5 - 1].stok - numericUpDown1.Value);

            //        string der5 = "Update malzeme_stok Set stok = @stok Where ID = " + m5;
            //        using (SqlCommand cmd = new SqlCommand(der5, DbClass.BaglantiTestEt()))
            //        {
            //            cmd.Parameters.Add("stok", SqlDbType.Int).Value = m5s;

            //            cmd.ExecuteNonQuery();
            //        }










            //    }
            //    else if(pizzatablosu[i].malzeme_2 != 1 && pizzatablosu[i].malzeme_3 != 1 && pizzatablosu[i].malzeme_4 != 1 )
            //    {
            //        //m2 = Convert.ToInt32(pizzatablosu[i].malzeme_2);

            //        m2 = Convert.ToInt32(pizzatablosu[i].malzeme_2);
            //        m2s = Convert.ToInt32(malzemelst[m2 - 1].stok - numericUpDown1.Value);

            //        string der2 = "Update malzeme_stok Set stok = @stok Where ID = " + m2;
            //        using (SqlCommand cmd = new SqlCommand(der2, DbClass.BaglantiTestEt()))
            //        {
            //            cmd.Parameters.Add("stok", SqlDbType.Int).Value = m2s;

            //            cmd.ExecuteNonQuery();
            //        }

            //        m3 = Convert.ToInt32(pizzatablosu[i].malzeme_3);
            //        m3s = Convert.ToInt32(malzemelst[m3 - 1].stok - numericUpDown1.Value);

            //        string der3 = "Update malzeme_stok Set stok = @stok Where ID = " + m3;
            //        using (SqlCommand cmd = new SqlCommand(der3, DbClass.BaglantiTestEt()))
            //        {
            //            cmd.Parameters.Add("stok", SqlDbType.Int).Value = m3s;

            //            cmd.ExecuteNonQuery();
            //        }

            //        m4 = Convert.ToInt32(pizzatablosu[i].malzeme_4);
            //        m4s = Convert.ToInt32(malzemelst[m4 - 1].stok - numericUpDown1.Value);

            //        string der4 = "Update malzeme_stok Set stok = @stok Where ID = " + m4;
            //        using (SqlCommand cmd = new SqlCommand(der4, DbClass.BaglantiTestEt()))
            //        {
            //            cmd.Parameters.Add("stok", SqlDbType.Int).Value = m4s;

            //            cmd.ExecuteNonQuery();
            //        }
            //    }
            //    else if (pizzatablosu[i].malzeme_2 != 1 && pizzatablosu[i].malzeme_3 != 1)
            //    {
            //        m2 = Convert.ToInt32(pizzatablosu[i].malzeme_2);
            //        m2s = Convert.ToInt32(malzemelst[m2 - 1].stok - numericUpDown1.Value);

            //        string der2 = "Update malzeme_stok Set stok = @stok Where ID = " + m2;
            //        using (SqlCommand cmd = new SqlCommand(der2, DbClass.BaglantiTestEt()))
            //        {
            //            cmd.Parameters.Add("stok", SqlDbType.Int).Value = m2s;

            //            cmd.ExecuteNonQuery();
            //        }

            //        m3 = Convert.ToInt32(pizzatablosu[i].malzeme_3);
            //        m3s = Convert.ToInt32(malzemelst[m3 - 1].stok - numericUpDown1.Value);

            //        string der3 = "Update malzeme_stok Set stok = @stok Where ID = " + m3;
            //        using (SqlCommand cmd = new SqlCommand(der3, DbClass.BaglantiTestEt()))
            //        {
            //            cmd.Parameters.Add("stok", SqlDbType.Int).Value = m3s;

            //            cmd.ExecuteNonQuery();
            //        }
            //    }
            //    else if (pizzatablosu[i].malzeme_2 !=1 )
            //    {
            //        m2 = Convert.ToInt32(pizzatablosu[i].malzeme_2);
            //        m2s = Convert.ToInt32(malzemelst[m2 - 1].stok - numericUpDown1.Value);

            //        string der2 = "Update malzeme_stok Set stok = @stok Where ID = " + m2;
            //        using (SqlCommand cmd = new SqlCommand(der2, DbClass.BaglantiTestEt()))
            //        {
            //            cmd.Parameters.Add("stok", SqlDbType.Int).Value = m2s;

            //            cmd.ExecuteNonQuery();
            //        }
            //    }

            //    //yukarıda if'te yapılan işlemin alternatifi aşağıdaki if


            //    /*
            //    if (pizzatablosu[i].malzeme_3 == 1)
            //    {

            //    }
            //    else
            //    {
            //        m3 = Convert.ToInt32(pizzatablosu[i].malzeme_3);
            //    }
            //    if (pizzatablosu[i].malzeme_4 == 1)
            //    {

            //    }
            //    else
            //    {
            //        m4 = Convert.ToInt32(pizzatablosu[i].malzeme_4);
            //    }
            //    if (pizzatablosu[i].malzeme_5 == 1)
            //    {

            //    }
            //    else
            //    {
            //        m5 = Convert.ToInt32(pizzatablosu[i].malzeme_5);
            //    }*/




            // gönderilen bilgilerin database'e aktarıldığını söylüyoruz.
            MessageBox.Show("Siparişiniz alındı.");
            //mesaj gittikten sonra formlar ayrılmasın ve değerler sıfırlanılıp sayfa tekrardan yüklensin
            numericUpDown1.Value = 1;
            numericUpDown2.Value = 1;
            numericUpDown3.Value = 1;
            comboBox1.SelectedValue = 1;
            comboBox2.SelectedValue = 1;
            comboBox3.SelectedIndex = 0;
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox1.Text = "";
            totalfiyat = 0;
            icecekfiyat = 0;
            promosyonfiyat = 0;
            pizzafiyat = 0;


        nokta: { }

        } 

    

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            //promosyon istemiyorum seçildiğinde adet 0'dan başka bir şey olmasın.
            int istemiyorum = 0;
            for(int i = 0; i < promosyonlst.Count; i++)
            {
                if (promosyonlst[i].promosyon_adi=="promosyon istemiyorum")
                {
                    istemiyorum = Convert.ToInt32(promosyonlst[i].id);
                }
            }

            int cb = Convert.ToInt32(comboBox3.SelectedValue);

            if (cb == istemiyorum) 
            {
                numericUpDown3.Value = 0;
            }
            totalfiyat = totalfiyat - promosyonfiyat;
            promosyonfiyat = promosyonlst[secili_promosyon].fiyat * numericUpDown3.Value;
            totalfiyat = totalfiyat + promosyonfiyat;
            label10.Text = Convert.ToString(totalfiyat);

            //totalfiyat = totalfiyat - icecekfiyat;
            //icecekfiyat = pizzaicecektablosu[secili_icecek].fiyat * numericUpDown2.Value;
            //totalfiyat = totalfiyat + icecekfiyat;
            //label10.Text = Convert.ToString(totalfiyat);
        }

        //siparis numarasi oluşturuyoruz.
        public string FisNo()
        {
            string fisNo = string.Format("{0}{1}{2}{3}{4}-{5}{6}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);

            return fisNo;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            totalfiyat = totalfiyat - icecekfiyat;
            secili_icecek = Convert.ToInt32(comboBox2.SelectedIndex);
            icecekfiyat = Convert.ToDecimal(pizzaicecektablosu[secili_icecek].fiyat * numericUpDown2.Value);
            totalfiyat = totalfiyat + icecekfiyat;
            label10.Text = Convert.ToString(totalfiyat);
        }
    }
    
}

