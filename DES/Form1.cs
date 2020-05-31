using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DES
{
    public partial class DesForm : Form
    {
        private bool[,] boolSplittedTex;


        static int[] ip = new int[64]{
            57, 49, 41, 33, 25, 17, 9, 1,
            59, 51, 43, 35, 27, 19, 11, 3,
            61, 53, 45, 37, 29, 21, 13, 5,
            63, 55, 47, 39, 31, 23, 15, 7,
            56, 48, 40, 32, 24, 16, 8, 0,
            58, 50, 42, 34, 26, 18, 10, 2,
            60, 52, 44, 36, 28, 20, 12, 4,
            62, 54, 46, 38, 30, 22, 14, 6 };

        static int[] P = new int[32]  {
            15,  6, 19, 20,
            28, 11, 27, 16,
            0, 14, 22, 25,
            4, 17, 30,  9,
            1,  7, 23, 13,
            31, 26,  2,  8,
            18, 12, 29,  5,
            21, 10,  3, 24 };


        static int[] H = new int[48] {
            31,  0,  1,  2,  3,  4,
            3,  4,  5,  6,  7,  8,
            7,  8,  9, 10, 11, 12,
            11, 12, 13, 14, 15, 16,
            15, 16, 17, 18, 19, 20,
            19, 20, 21, 22, 23, 24,
            23, 24, 25, 26, 27, 28,
            27, 28, 29, 30, 31,  0};
        static int[] perm2 = new int[48] {
            13, 16, 10, 23,  0,  4,
            2, 27, 14,  5, 20,  9,
            22, 18, 11,  3, 25,  7,
            15,  6, 26, 19, 12,  1,
            40, 51, 30, 36, 46, 54,
            29, 39, 50, 44, 32, 47,
            43, 48, 38, 55, 33, 52,
            45, 41, 49, 35, 28, 31
        };
        static int[] IP1 = new int[64] {
            7,  39, 15, 47, 23, 55, 31, 63,
            6,  38, 14, 46, 22, 54, 30, 62,
            5,  37, 13, 45, 21, 53, 29, 61,
            4,  36, 12, 44, 20, 52, 28, 60,
            3,  35, 11, 43, 19, 51, 27, 59,
            2,  34, 10, 42, 18, 50, 26, 58,
            1,  33,  9, 41, 17, 49, 25, 57,
            0,  32,  8, 40, 16, 48, 24, 56
        };

        static int[] expansion = new int[48] {  32,  1,  2,  3,  4,  5,  4,  5,
                                                 6,  7,  8,  9,  8,  9, 10, 11,
                                                12, 13, 12, 13, 14, 15, 16, 17,
                                                16, 17, 18, 19, 20, 21, 20, 21,
                                                22, 23, 24, 25, 24, 25, 26, 27,
                                                28, 29, 28, 29, 30, 31, 32,  1 };

        static byte[,,] s_block = new byte[8, 4, 16]{
            {{14, 4, 13, 1, 2, 15, 11, 8, 3, 10, 6, 12, 5, 9, 0, 7},
                {0, 15, 7, 4, 14, 2, 13, 1, 10, 6, 12, 11, 9, 5, 3, 8},
                {4, 1, 14, 8, 13, 6, 2, 11, 15, 12, 9, 7, 3, 10, 5, 0},
                {15, 12, 8, 2, 4, 9, 1, 7, 5, 11, 3, 14, 10, 0, 6, 13}},

            {{15, 1, 8, 14, 6, 11, 3, 4, 9, 7, 2, 13, 12, 0, 5, 10},
                {3, 13, 4, 7, 15, 2, 8, 14, 12, 0, 1, 10, 6, 9, 11, 5},
                {0, 14, 7, 11, 10, 4, 13, 1, 5, 8, 12, 6, 9, 3, 2, 15},
                {13, 8, 10, 1, 3, 15, 4, 2, 11, 6, 7, 12, 0, 5, 14, 9}},

            {{10, 0, 9, 14, 6, 3, 15, 5, 1, 13, 12, 7, 11, 4, 2, 8},
                {13, 7, 0, 9, 3, 4, 6, 10, 2, 8, 5, 14, 12, 11, 15, 1},
                {13, 6, 4, 9, 8, 15, 3, 0, 11, 1, 2, 12, 5, 10, 14, 7},
                {1, 10, 13, 0, 6, 9, 8, 7, 4, 15, 14, 3, 11, 5, 2, 12}},

            {{7, 13, 14, 3, 0, 6, 9, 10, 1, 2, 8, 5, 11, 12, 4, 15},
                {13, 8, 11, 5, 6, 15, 0, 3, 4, 7, 2, 12, 1, 10, 14, 9},
                {10, 6, 9, 0, 12, 11, 7, 13, 15, 1, 3, 14, 5, 2, 8, 4},
                {3, 15, 0, 6, 10, 1, 13, 8, 9, 4, 5, 11, 12, 7, 2, 14}},

            {{2, 12, 4, 1, 7, 10, 11, 6, 8, 5, 3, 15, 13, 0, 14, 9},
                {14, 11, 2, 12, 4, 7, 13, 1, 5, 0, 15, 10, 3, 9, 8, 6},
                {4, 2, 1, 11, 10, 13, 7, 8, 15, 9, 12, 5, 6, 3, 0, 14},
                {11, 8, 12, 7, 1, 14, 2, 13, 6, 15, 0, 9, 10, 4, 5, 3}},

            {{12, 1, 10, 15, 9, 2, 6, 8, 0, 13, 3, 4, 14, 7, 5, 11},
                {10, 15, 4, 2, 7, 12, 9, 5, 6, 1, 13, 14, 0, 11, 3, 8},
                {9, 14, 15, 5, 2, 8, 12, 3, 7, 0, 4, 10, 1, 13, 11, 6},
                {4, 3, 2, 12, 9, 5, 15, 10, 11, 14, 1, 7, 6, 0, 8, 13}},

            {{4, 11, 2, 14, 15, 0, 8, 13, 3, 12, 9, 7, 5, 10, 6, 1},
                {13, 0, 11, 7, 4, 9, 1, 10, 14, 3, 5, 12, 2, 15, 8, 6},
                {1, 4, 11, 13, 12, 3, 7, 14, 10, 15, 6, 8, 0, 5, 9, 2},
                {6, 11, 13, 8, 1, 4, 10, 7, 9, 5, 0, 15, 14, 2, 3, 12}},

            {{13, 2, 8, 4, 6, 15, 11, 1, 10, 9, 3, 14, 5, 0, 12, 7},
                {1, 15, 13, 8, 10, 3, 7, 4, 12, 5, 6, 11, 0, 14, 9, 2},
                {7, 11, 4, 1, 9, 12, 14, 2, 0, 6, 10, 13, 15, 3, 5, 8},
                {2, 1, 14, 7, 4, 10, 8, 13, 15, 12, 9, 0, 3, 5, 6, 11}}};

        static int[] permutation_func = new int[32] {   16,  7, 20, 21, 29, 12, 28, 17,
                                                         1, 15, 23, 26,  5, 18, 31, 10,
                                                         2,  8, 24, 14, 32, 27,  3,  9,
                                                        19, 13, 30,  6, 22, 11,  4, 25};

        static int[] final_permutation = new int[64] {  40, 8, 48, 16, 56, 24, 64, 32,
                                                        39, 7, 47, 15, 55, 23, 63, 31,
                                                        38, 6, 46, 14, 54, 22, 62, 30,
                                                        37, 5, 45, 13, 53, 21, 61, 29,
                                                        36, 4, 44, 12, 52, 20, 60, 28,
                                                        35, 3, 43, 11, 51, 19, 59, 27,
                                                        34, 2, 42, 10, 50, 18, 58, 26,
                                                        33, 1, 41,  9, 49, 17, 57, 25 };

        static int[] perm_key56 = new int[56] { 56, 48, 40, 32, 24, 16,  8,
                                               0, 57, 49, 41, 33, 25, 17,
                                               9,  1, 58, 50, 42, 34, 26,
                                              18, 10,  2, 59, 51, 43, 35,
                                              62, 54, 46, 38, 30, 22, 14,
                                               6, 61, 53, 45, 37, 29, 21,
                                              13,  5, 60, 52, 44, 36, 28,
                                              20, 12,  4, 27, 19, 11,  3 };

        static int[] sc = new int[16] { 1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1 };



        public DesForm()
        {

            InitializeComponent();
            openFileDialog.Filter = "All files(*.*)|*.*";
            saveFileDialog.Filter = "Text files(*.txt)|*.txt";

        }

        
        int lenghtKey = 8; //длина ключа 
        

        string keyMass = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"; // строка символов, из которой генерируем ключ

        void keyGenButton_Click(object sender, EventArgs e)
        {
            var key = GenRandomStr(keyMass, lenghtKey);
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
            if (!string.IsNullOrEmpty(decryptedTextBox.Text))
            {
                if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                    return;

                var filename = saveFileDialog.FileName;

                System.IO.File.WriteAllText(filename, decryptedTextBox.Text);

                MessageBox.Show("Файл сохранен");
            }

            MessageBox.Show("Нечего сохранять");
        }

        void runButton_Click(object sender, EventArgs e)
        {
            var key = keyTextBox.Text;
            SetKeyLength();
            var filledText = FillText(originalTextBox.Text);
            var decryptedText = decryptedTextBox.Text;
            var encryptedText = encryptedTextBox.Text;
            

            if (xorRadioButton.Checked)
            {
                if (encryptRadioButton.Checked)
                {
                    encryptedText = XOR(filledText, key);
                    encryptedTextBox.Text = encryptedText;
                }

                else if (decryptRadioButton.Checked)
                {
                    decryptedText = XOR(encryptedText, key);
                    decryptedTextBox.Text = decryptedText;
                }
                else
                {
                    decryptedText = XOR(filledText, key);
                    encryptedTextBox.Text = decryptedText;
                    encryptedText = XOR(decryptedText, key);
                    decryptedTextBox.Text = encryptedText;
                }
            }
            else if (desRadioButton.Checked)
            {
                if (encryptRadioButton.Checked)
                {
                    encryptedTextBox.Text = "";
                    var splittedText = SplitIntoBlocks(filledText);
                    //boolSplittedTex = new bool[splittedText.Length, 64];
                    for (int i = 0; i < lenghtKey; i++)
                    {
                        var temp= ConvertToBit(splittedText[i]);// /переводим текст в биты
                        //for (int j = 0; j < 64; j++)
                        //{
                        //    boolSplittedTex[i, j] = temp[j];
                        //}
                        encryptedTextBox.Text += CryptBlock(temp, key, true);
                    }
                }

                else if (decryptRadioButton.Checked)
                { 
                    decryptedTextBox.Text = "";
                    encryptedText = FillText(encryptedText);
                    var splittedText = SplitIntoBlocks(encryptedText);
                    //boolSplittedTex = new bool[splittedText.Length, 64];
                    for (int i = 0; i < splittedText.Length; i++)
                    {
                        var temp = ConvertToBit(splittedText[i]);// /переводим текст в биты
                        //for (int j = 0; j < 64; j++)
                        //{
                        //    boolSplittedTex[i, j] = temp[j];
                        //}

                        decryptedTextBox.Text += CryptBlock(temp, key, false);
                    }
                }

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

        string FillText(string data)
        {
            while (data.Length % lenghtKey != 0)
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


        private static bool[] XOR2(bool[] input, bool[] key)
        {
            var res = new bool[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                res[i] = (input[i] ^ key[i]);
            }
            return res;

        }

        string CryptBlock(bool[] inp_64, string key64, bool isCrypt)
        {
            bool[] outb = new bool[64];
            Work(inp_64, outb, key64, isCrypt);

            bool[] boolBuffer = new bool[8];


            byte[] byteBuffer = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    boolBuffer[j] = outb[i * 8 + j];
                }

                byteBuffer[i] = BitToByte(boolBuffer);
            }

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

            return encodingType.GetString(byteBuffer);
        }

        private void Work(bool[] inp, bool[] out_64, string key_64, bool is_crypt)
        {
            bool[] pin = new bool[64];
            bool[][] ekey = new bool[16][];
            for (int i = 0; i < 16; i++)
                ekey[i] = new bool[48];
            Permutation(inp, pin, ip, 64);//начальная перестановка
            bool[] l = new bool[32]; 
            bool[] r = new bool[32];// левый и правый блок (сети Фейстеля)
            SplitOnRL(pin, l, r);
            FillKey(key_64, ekey, is_crypt);//получаем 16-ключей(по 48 бит каждый)

            //  for (uint n=0; n<16;)
            for (int n = 0; n < 16;)
            {
                if (n % 2 == 0)
                {
                    F(l, r, ekey[n++]);
                }
                else
                    F(r, l, ekey[n++]);
            }
            bool[] pin_ = new bool[64];
            ConnectBlocks(l, r, pin_);
            Permutation(pin, out_64, IP1, 64);
        }
        private static void F(bool[] L_32, bool[] R_32, bool[] key_48)//функция для шифрования
        {
            int x, y;
            byte[] s = new byte[8];

            bool[,] B = new bool[8, 6];
            bool[,] B_;// = new bool[8, 4];
            bool[] cb = new bool[32];
            bool[] R_48 = new bool[48];

            Permutation(R_32, R_48, H, 48);//расширяем 32-битный правый блок  до 48-битного
            var R = XOR2(R_48, key_48);//ксорим с 48-битным ключём

            for (y = 0; y < 8; y++)
            for (x = 0; x < 6; x++)
                B[y, x] = R_48[y * 6 + x];//разбиваем на 8 блоков по 6 бит каждый


            for (y = 0; y < 8; y++)
            {
                //массив в битовом представдении для нахождения номера строки, берется первый и последний элемент из 6 битного блока
                bool[] i = new bool[4] {  B[y, 0], B[y, 5], false, false };
                //массив в битовом представлении для нахождения номера столбца, берется со  2 по 5 элемент из 6 битного блока
                bool[] j = new bool[4] {  B[y, 1], B[y, 2], B[y, 3], B[y, 4] };
                var i_ = BitToByte(i);//переводим в байт
                if (i_ != 0)
                    i_--;
                var j_ = BitToByte(j);//переводим в байт
                if (j_ != 0)
                    j_--;

                    s[y] = s_block[y, i_, j_];//находим элемент в S-таблицах(в значении в байтах)
                    //= ByteToBool(s);//переводим в битовый формат размер 64 бита

            }
            B_ = ByteToBool(s);
            for (y = 0; y < 8; y++)
            for (x = 0; x < 4; x++) cb[y * 4 + x] = B_[x, y];//переводим в одномерный массив
            bool[] new_R = new bool[32];
            Permutation(cb, new_R, P, 32);
            L_32 = XOR2(L_32, new_R);
        }

        private void FillKey(string key, bool[][] ekey16_48, bool is_crypt)
        {
            var bitKey64 = ConvertToBit(key);

            int[] new_bit_key = new int[64];
            int count = 0;


            for (int i = 0; i < key.Length; i++)
            {
                if (bitKey64[i] == true)
                    count++;
            }

            if (count%2==0)
            {
                if (bitKey64[bitKey64.Length - 1] == true)
                    bitKey64[bitKey64.Length - 1] = false;
                else
                    bitKey64[bitKey64.Length - 1] = true;
            }

            bool[] bitKey56 = new bool[56];
            bool[] pkey = new bool[56];
            Permutation(bitKey64, bitKey56, perm_key56, 56);

            bool[] l = new bool[28]; bool[] r = new bool[28];
            SplitOnRL(bitKey56, l, r);
            for (uint n = 0; n < 16; n++)
            {
                LShift(l, sc[n]);
                LShift(r, sc[n]);
                ConnectBlocks(l, r, pkey);
                Permutation(pkey, ekey16_48[is_crypt ? n : 15 - n], perm2, 48);
            }

        }


        private static void Permutation(bool[] input, bool[] output, int[] table, uint size)
        {
            for (int n = 0; n < size; n++) 
                output[n] = input[table[n]];
        }

        string[] SplitIntoBlocks(string text)
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
            var keyInBytes = encodingType.GetBytes(keyTextBox.Text);

            //var data = new string[text.Length / 8];
            var data = new string[text.Length / keyInBytes.Length];

            // int lengthOfBlock = 8;
            int lengthOfBlock = keyInBytes.Length;

            for (int i = 0; i < data.Length; i++)
                data[i] = text.Substring(i * lenghtKey, lenghtKey);
            return data;
        }

        private bool[] ConvertToBit(string s)
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
            var input_bin = encodingType.GetBytes(s);
            var bits = new BitArray(input_bin);
            bool[] a = new bool[bits.Length];
            int i = 0;
            foreach (var bit in bits)
            {
                a[i] = Convert.ToBoolean(bit);
                i++;
            }
            //int[,] BIT = new int[input_bin.Length, 8];//массив бит (текст из байт -> в биты) 
            //for (int i = 0; i < input_bin.Length; i++)
            //{

            //    for (int j = 0; j < 8; j++)
            //    {
            //        BIT[i, j] = (input_bin[i] >> j) & 0x01;
            //    }
            //}
            //bool[] a = new bool[64]; int[] new_Bit = new int[64];
            //for (int y = 0; y < 8; y++)
            //for (int x = 0; x < 8; x++)
            //    new_Bit[y * 8 + x] = BIT[y, x];//переводим в одномерный массив
            //for (int i = 0; i < BIT.Length; i++)
            //    a[i] = Convert.ToBoolean(new_Bit[i]);
            return a;
        }

        private static void Сutblocks(bool[] Block, bool[] R, bool[] L, int size)
        {
            for (int i = 0; i < Block.Length / 2; i++) L[i] = Block[i];
            for (int i = Block.Length / 2; i < Block.Length; i++) R[i - size] = Block[i];

        }

        private static void SplitOnRL(bool[] Block, bool[] R, bool[] L)
        {
            for (int i = 0; i < Block.Length / 2; i++)
                L[i] = Block[i];
            for (int i = Block.Length / 2; i < Block.Length; i++)
                R[i - Block.Length / 2] = Block[i];

        }

        private static void LShift(bool[] array, int step)// сдвиговая функция
        {
            bool[] buff = new bool[28];
            for (uint n = 0; n < 28; n++)
            {
                buff[n] = array[(n + step) % 28];
                array[n] = buff[n];
            }
        }


        private static void ConnectBlocks(bool[] l, bool[] r, bool[] array)
        {
            for (int i = 0; i < array.Length / 2; i++) 
                array[i] = l[i];
            for (int i = array.Length / 2; i < array.Length; i++)
                array[i] = r[i- array.Length / 2];
        }

        private static byte BitToByte(bool[] mas)//перевод из битов в байты
        {
            byte new_mas = 0;

            for (int i = 0, m =1; i < mas.Length; i++, m*=2)
            {

                    if (mas[i] == true)
                    {
                        new_mas += (byte)m;
                    }

                    if (mas[i] == false)
                    {
                        new_mas += (byte) 0;
                    }

            }
            return new_mas;
        }

        private static bool[,] ByteToBool(byte[] a)// перевод из байтов в bool
        {
            bool[,] b = new bool[4, 8];
            for (int i = 0; i < 4; i++)
            for (int j = 0; j < 8; j++)
                b[i, j] = Convert.ToBoolean(a[i]);
            return b;
        }


        void SetKeyLength()
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
                encodingType = Encoding.UTF8;
            }

            lenghtKey = encodingType.GetBytes(keyTextBox.Text).Length;
            
        }
    }
}