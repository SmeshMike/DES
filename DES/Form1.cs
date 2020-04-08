using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DES
{
    public partial class DesForm : Form
    {
        public DesForm()
        {

            InitializeComponent();
            openFileDialog.Filter = "All files(*.*)|*.*";
            saveFileDialog.Filter = "All files(*.*)|*.*";

        }

        const int lengtKey = 8; //длина ключа 
        

        string keyMass = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"; // строка символов, из которой генерируем ключ

        void keyGenButton_Click(object sender, EventArgs e)
        {
            var key = GenRandomStr(keyMass, lengtKey);
            keyTextBox.Text = key;
        }

        void loadFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            var fileName = openFileDialog.FileName;
            var fileText = System.IO.File.ReadAllText(fileName);
            originalTextBox.Text = fileText;
        }

        void saveFileButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(encryptedTextBox.Text))
            {
                if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                    return;

                var filename = saveFileDialog.FileName;

                System.IO.File.WriteAllText(filename, encryptedTextBox.Text);

                MessageBox.Show("Файл сохранен");
            }

            MessageBox.Show("Нечего сохранять");
        }

        void runButton_Click(object sender, EventArgs e)
        {
            var key = keyTextBox.Text;
            var fillText = FillText(originalTextBox.Text, key);
            var decryptedText = decryptedTextBox.Text;
            var encryptedText = encryptedTextBox.Text;
            if (decryptRadioButton.Checked)
            {
                decryptedText = XOR(fillText, key);
                decryptedTextBox.Text = decryptedText;
            }

            if (encryptRadioButton.Checked)
            {
                encryptedText = XOR(decryptedText, key);
                encryptedTextBox.Text = encryptedText;
            }
            if (!decryptRadioButton.Checked && !encryptRadioButton.Checked)
            {
                decryptedText = XOR(fillText, key);
                decryptedTextBox.Text = decryptedText;
                encryptedText = XOR(decryptedText, key);
                encryptedTextBox.Text = encryptedText;
            }

        }



        static string GenRandomStr(string data, int length)
        {
            Random random = new Random();
            string keyResult = "";

            for (int i = 0; i < length; i++)
            {
                var position = random.Next(0, data.Length - 1);
                keyResult += data[position];
            }

            return keyResult;
        }

        static string FillText(string data, string key)
        {
            while (data.Length % key.Length != 0)
            {
                data += "\0";
            }

            return data;
        }

        string XOR(string text, string key)
        {

            Encoding encodingType;
            if (asciiRadioButton.Checked)
            {
                encodingType = Encoding.ASCII;
            }
            else if (utf8RadioButton.Checked)
            {
                encodingType = Encoding.UTF8;
            }
            else
            {
                encodingType = Encoding.Unicode;
            }

            var textInBytes = encodingType.GetBytes(text);
            var keyInBytes = encodingType.GetBytes(key);


            byte[] res = new byte[textInBytes.Length];
            for (var i = 0; i < textInBytes.Length; i++)
            {
                res[i] = Convert.ToByte(textInBytes[i] ^ keyInBytes[i % keyInBytes.Length]);
            }

            return encodingType.GetString(res);
        }


    }
}