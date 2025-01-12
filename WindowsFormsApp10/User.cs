using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

public class User
{
    private const string FilePath = "last_username.txt"; // Kullanıcı adını saklayacak dosya yolu

    public string Username { get; set; }
    public string Password { get; set; }
    public int UserId { get; set; } = 1; // Kullanıcı ID'sini sabit olarak ekliyoruz

    // Kullanıcı doğrulama metodu
    public bool ValidateUser()
    {
        bool isValid = false;

        string connectionString = "Server=AZIZ\\SQLEXPRESS;Database=PlantAutomationDB;Integrated Security=True;";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            try
            {
                conn.Open();

                
                string query = "SELECT COUNT(1) FROM [dbo].[kullanicigiris] WHERE username = @Username AND password = @Password";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", this.Username);
                cmd.Parameters.AddWithValue("@Password", this.Password);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count == 1)
                {
                    SaveLastUsername(this.Username); 
                    isValid = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }
        }

        return isValid;
    }

    
    private void SaveLastUsername(string username)
    {
        try
        {
            File.WriteAllText(FilePath, username);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Kullanıcı adı kaydedilemedi: " + ex.Message);
        }
    }

   
    public string GetLastUsername()
    {
        try
        {
            if (File.Exists(FilePath))
            {
                return File.ReadAllText(FilePath);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Son kullanıcı adı yüklenemedi: " + ex.Message);
        }

        return string.Empty;
    }
}