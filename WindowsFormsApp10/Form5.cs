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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            
            int userId = UserInfo.UserId;

            
            MessageBox.Show($"User ID: {userId} ile giriş yapıldı.");
        }

        
        private void KaydetBitki(int selectedBitkiId)
        {
            string connectionString = "Server=AZIZ\\SQLEXPRESS;Database=PlantAutomationDB;Integrated Security=True;"; 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    INSERT INTO KullaniciBitkileri (UserId, BitkiId, Ad, Kategori, Sıcaklık, Sulama, Gübreleme, Işık)
                    SELECT 
                        @UserId, 
                        BitkiID, 
                        Ad, 
                        Kategori, 
                        Sıcaklık, 
                        Sulama, 
                        Gübreleme, 
                        Işık
                    FROM Bitkiler
                    WHERE BitkiID = @SelectedBitkiId;
                ";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", UserInfo.UserId);  
                command.Parameters.AddWithValue("@SelectedBitkiId", selectedBitkiId);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Bitki başarıyla kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            int selectedBitkiId = 1; 

            bool confirm = MessageBoxManager.Instance.ShowConfirmationMessage("Bu bitkiyi seçmek istediğinize emin misiniz?");
            if (confirm)
            {
                KaydetBitki(selectedBitkiId); 
            }
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            int selectedBitkiId = 2; 

            bool confirm = MessageBoxManager.Instance.ShowConfirmationMessage("Bu bitkiyi seçmek istediğinize emin misiniz?");
            if (confirm)
            {
                KaydetBitki(selectedBitkiId);
            }
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            int selectedBitkiId = 3; 

            bool confirm = MessageBoxManager.Instance.ShowConfirmationMessage("Bu bitkiyi seçmek istediğinize emin misiniz?");
            if (confirm)
            {
                KaydetBitki(selectedBitkiId);
            }
        }

        
        private void button4_Click(object sender, EventArgs e)
        {
            int selectedBitkiId = 4; 

            bool confirm = MessageBoxManager.Instance.ShowConfirmationMessage("Bu bitkiyi seçmek istediğinize emin misiniz?");
            if (confirm)
            {
                KaydetBitki(selectedBitkiId);
            }
        }

        
        private void button5_Click(object sender, EventArgs e)
        {
            int selectedBitkiId = 5; 

            bool confirm = MessageBoxManager.Instance.ShowConfirmationMessage("Bu bitkiyi seçmek istediğinize emin misiniz?");
            if (confirm)
            {
                KaydetBitki(selectedBitkiId);
            }
        }

        
        private void button6_Click(object sender, EventArgs e)
        {
            int selectedBitkiId = 6; 

            bool confirm = MessageBoxManager.Instance.ShowConfirmationMessage("Bu bitkiyi seçmek istediğinize emin misiniz?");
            if (confirm)
            {
                KaydetBitki(selectedBitkiId);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }
    }
}
