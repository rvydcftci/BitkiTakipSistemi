using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp10
{
    public partial class Form2 : Form
    {
        private User user = new User(); 

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            string lastUsername = user.GetLastUsername();
            if (!string.IsNullOrEmpty(lastUsername))
            {
                textBox1.Text = lastUsername; 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            user.Username = textBox1.Text;
            user.Password = textBox2.Text;

            if (user.ValidateUser())
            {
               
                UserInfo.UserId = 1;  

                MessageBox.Show("Giriş başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form3 form3 = new Form3();
                form3.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide(); 
        }
    }
}
