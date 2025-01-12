using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp10
{
     public class MessageBoxManager
    {
        private static MessageBoxManager _instance;
        private MessageBoxManager() { }

        public static MessageBoxManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MessageBoxManager();
                }
                return _instance;
            }
        }

        public bool ShowConfirmationMessage(string message)
        {
            DialogResult result = MessageBox.Show(message, "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }

        public void ShowInformationMessage(string message)
        {
            MessageBox.Show(message, "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        
        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
