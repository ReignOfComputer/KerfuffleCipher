using System;
using System.Drawing;
using System.Windows.Forms;
using KerfuffleCipher;

namespace KerfuffleUI
{
    public partial class KerfuffleUI : Form
    {
        public KerfuffleUI()
        {
            InitializeComponent();
        }

        private void encryptBtn_Click(object sender, EventArgs e)
        {
            if (encryptBox.ForeColor == SystemColors.InactiveCaption)
            {
                MessageBox.Show("No input!");
            }
            else
            {
                outputBox.Text = "";
                outputBox.Text = "Before Encryption: " + encryptBox.Text;
                outputBox.Text = outputBox.Text + Environment.NewLine + Environment.NewLine + "After Encryption:" + Environment.NewLine
                    + Encryption.DisplayMatrix(Encryption.Encrypt(Encryption.InsertGarbledText(encryptBox.Text)));
            }
        }

        private void decryptBtn_Click(object sender, EventArgs e)
        {
            if (decryptBox.ForeColor == SystemColors.InactiveCaption)
            {
                MessageBox.Show("No input!");
            }
            else
            {
                try
                {
                    string message = Decryption.GetMessage(Decryption.Decrypt(Decryption.DisplayArrayFromString(decryptBox.Text)));
                    if (message != string.Empty)
                        outputBox.Text = message;
                    else
                        outputBox.Text = "Invalid Data";
                }
                catch (Exception)
                {
                    outputBox.Text = "Data appears to be malformed or tampered.";
                }
            }
        }

        private void encryptBox_Enter(object sender, EventArgs e)
        {
            if (!(encryptBox.Text == "Message to encrypt"))
                return;
            encryptBox.Text = "";
            encryptBox.ForeColor = SystemColors.WindowText;
        }

        private void encryptBox_Leave(object sender, EventArgs e)
        {
            if (!(encryptBox.Text == ""))
                return;
            this.encryptBox.Text = "Message to encrypt";
            this.encryptBox.ForeColor = SystemColors.InactiveCaption;
        }

        private void decryptBox_Enter(object sender, EventArgs e)
        {
            if (!(decryptBox.Text == "Message to decrypt"))
                return;
            this.decryptBox.Text = "";
            this.decryptBox.ForeColor = SystemColors.WindowText;
        }

        private void decryptBox_Leave(object sender, EventArgs e)
        {
            if (!(decryptBox.Text == ""))
                return;
            this.decryptBox.Text = "Message to decrypt";
            this.decryptBox.ForeColor = SystemColors.InactiveCaption;
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Control || !(e.KeyCode.ToString() == "A"))
                return;
            ((TextBoxBase)sender).SelectAll();
        }
    }
}
