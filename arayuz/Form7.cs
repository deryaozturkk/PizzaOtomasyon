using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arayuz
{
    public partial class Form7 : Form
    {
   
        public Form7()
        {
            InitializeComponent();
           
        }
       

        private void button1_Click(object sender, EventArgs e)//stok güncelle
        {
            if (comboBox1.SelectedIndex == 0)
            {
                Form13 DERYA13 = new Form13();
                DERYA13.Show();
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                Form14 DERYA14 = new Form14();
                DERYA14.Show();
            }
            else if(comboBox1.SelectedIndex==2)
            {
                Form15 DERYA15 = new Form15();
                DERYA15.Show();
            }
        }
        private void button2_Click(object sender, EventArgs e)//ürün çıkar
        {
            if(comboBox3.SelectedIndex == 0)
            {
                Form16 DERYA16 = new Form16();
                DERYA16.Show();
            }
            else if(comboBox3.SelectedIndex == 1)
            {
                Form17 DERYA17 = new Form17();
                DERYA17.Show();
            }
            else if(comboBox3.SelectedIndex==2)
            {
                Form18 DERYA18 = new Form18();
                DERYA18.Show();
            }
            else if(comboBox3.SelectedIndex==3)
            {
                Form19 DERYA19 = new Form19();
                DERYA19.Show();

            }
        }

        private void button3_Click(object sender, EventArgs e)//yeni ürün ekle
        {
            
            if (comboBox4.SelectedIndex == 0)
            {
                Form8 DERYA8 = new Form8();
                DERYA8.Show();
            }
            else if (comboBox4.SelectedIndex == 1)
            {
                Form9 DERYA9 = new Form9();
                DERYA9.Show();
            }
            else if (comboBox4.SelectedIndex == 2)
            {
                Form10 DERYA10 = new Form10();
                DERYA10.Show();
            }
            else if(comboBox4.SelectedIndex==3)
            {
                Form11 DERYA11= new Form11();
                DERYA11.Show();
            }
         

        }
        private void button4_Click(object sender, EventArgs e)//ürün güncelle
        {
            Form20 DERYA20 = new Form20();
            DERYA20.Show();

        }

    }
}
