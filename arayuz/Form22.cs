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
    public partial class Form22 : Form
    {
       
        public Form22()
        {
            InitializeComponent();
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtpassword.Text == "admin123" && txtUsername.Text == "admin")
            {
               

               ;
                this.Close();
                FormMainMenu frm = new FormMainMenu(true);
                frm.Show();
                

            }
            else
            {
                MessageBox.Show("Girdiğiniz parola veya kullanıcı adı hatalı. Tekrar deneyiniz.");
                txtpassword.Clear();
                txtUsername.Clear();
                txtUsername.Focus();

            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtpassword.Clear();
            txtUsername.Focus();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    
    }
}
