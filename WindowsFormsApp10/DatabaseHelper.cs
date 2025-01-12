using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace WindowsFormsApp10
{
    class DatabaseHelper
    {
        private string connectionString = @"Server=AZIZ\SQLEXPRESS;Database=PlantAutomationDB;Integrated Security=True;";

        // Bitkiyi kaydedip ID'sini döndüren metot
        public int SaveBitkiAndGetID(Bitki bitki)
        {
            int bitkiID = -1;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Bitkiler (Ad, Kategori, Sıcaklık, Sulama, Gübreleme, Işık) OUTPUT INSERTED.BitkiID " +
                                   "VALUES (@Ad, @Kategori, @Sıcaklık, @Sulama, @Gübreleme, @Işık)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Ad", bitki.Ad);
                        cmd.Parameters.AddWithValue("@Kategori", bitki.Kategori);
                        cmd.Parameters.AddWithValue("@Sıcaklık", bitki.Sıcaklık);
                        cmd.Parameters.AddWithValue("@Sulama", bitki.Sulama);
                        cmd.Parameters.AddWithValue("@Gübreleme", bitki.Gübreleme);
                        cmd.Parameters.AddWithValue("@Işık", bitki.Işık);

                        // Kaydedilen BitkiID'yi al
                        bitkiID = (int)cmd.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    MessageBoxManager.Instance.ShowErrorMessage("Hata: " + ex.Message);
                }
            }

            return bitkiID;
        }

        // Kullanıcı ve bitki bağlantısını kaydetmek
        public void LinkUserToBitki(string userID, int bitkiID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO KullaniciBitkileri (KullaniciID, BitkiID) VALUES (@KullaniciID, @BitkiID)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@KullaniciID", userID);
                        cmd.Parameters.AddWithValue("@BitkiID", bitkiID);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBoxManager.Instance.ShowErrorMessage("Hata: " + ex.Message);
                }
            }
        }
    }
}
