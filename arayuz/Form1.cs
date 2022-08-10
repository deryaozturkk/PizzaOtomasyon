using Microsoft.Windows.Themes;
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
    public partial class FormMainMenu : Form
    {


        private Form activeForm;
        private Button currentButton;
        private Random random;
        private int tempIndex;
       

        public void reporting(object sender, EventArgs e)
        {
            OpenChieldForm(new Form5(), sender);
        }

        public  FormMainMenu()
        {
            InitializeComponent();

            random = new Random();
            this.Text= string.Empty;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            
        }

        public FormMainMenu(bool form7)
        {
            InitializeComponent();

            if (form7)
            {
                OpenChieldForm(new Form7(), default(object));
            }
        }

        public void OpenChieldForm(Form childForm,object btnSender =null)
        {
            if (activeForm != null)
            {
                activeForm.Close();

            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(childForm);
            this.panel2.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            var aa = "";
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            OpenChieldForm(new Form2(), sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChieldForm(new Form3(), sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChieldForm(new Form4(), sender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChieldForm(new Form5(), sender);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            OpenChieldForm(new Form12(), sender);
        }
    
        public void button6_Click(object sender, EventArgs e)
        {
            OpenChieldForm(new Form22(), sender);
        }

        private void button7_Click(object sender, EventArgs e)
        {

            OpenChieldForm(new Form21(), sender);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void form22ac()
        {
            OpenChieldForm(new Form7() ,default(object));
        }

        private void FormMainMenu_Activated(object sender, EventArgs e)
        {
            var kk = 0;
        }

        //private void button7_Click(object sender, EventArgs e)
        //{
        //    OpenChieldForm(new Form13(), sender);
        //}
    }
}
