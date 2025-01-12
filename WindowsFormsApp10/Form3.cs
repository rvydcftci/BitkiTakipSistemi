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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        
        private void Form3_Load(object sender, EventArgs e)
        {
            
            int userId = UserInfo.UserId; 
            KullaniciBitkileriniGetir(userId);
        }

        
        private void KullaniciBitkileriniGetir(int userId)
        {
            string connectionString = "Server=AZIZ\\SQLEXPRESS;Database=PlantAutomationDB;Integrated Security=True;"; 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT k.Ad, k.Kategori, k.Sıcaklık, k.Sulama, k.Gübreleme, k.Işık
                    FROM KullaniciBitkileri kb
                    JOIN Bitkiler k ON kb.BitkiId = k.BitkiID
                    WHERE kb.UserId = @UserId;
                ";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@UserId", userId);

                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                
                dataGridView1.DataSource = dataTable;
            }
        }

        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }
    }
}
