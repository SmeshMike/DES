namespace DES
{
    partial class DesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.originalTextBox = new System.Windows.Forms.TextBox();
            this.encryptedTextBox = new System.Windows.Forms.TextBox();
            this.decryptedTextBox = new System.Windows.Forms.TextBox();
            this.keyTextBox = new System.Windows.Forms.TextBox();
            this.keyGenButton = new System.Windows.Forms.Button();
            this.loadFileButton = new System.Windows.Forms.Button();
            this.saveFileButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.encryptRadioButton = new System.Windows.Forms.RadioButton();
            this.decryptRadioButton = new System.Windows.Forms.RadioButton();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.codeType = new System.Windows.Forms.GroupBox();
            this.unicodeRadioButton = new System.Windows.Forms.RadioButton();
            this.utf8RadioButton = new System.Windows.Forms.RadioButton();
            this.asciiRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.desRadioButton = new System.Windows.Forms.RadioButton();
            this.xorRadioButton = new System.Windows.Forms.RadioButton();
            this.codeType.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // originalTextBox
            // 
            this.originalTextBox.Location = new System.Drawing.Point(12, 30);
            this.originalTextBox.Multiline = true;
            this.originalTextBox.Name = "originalTextBox";
            this.originalTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.originalTextBox.Size = new System.Drawing.Size(350, 300);
            this.originalTextBox.TabIndex = 0;
            // 
            // encryptedTextBox
            // 
            this.encryptedTextBox.Location = new System.Drawing.Point(417, 30);
            this.encryptedTextBox.Multiline = true;
            this.encryptedTextBox.Name = "encryptedTextBox";
            this.encryptedTextBox.Size = new System.Drawing.Size(350, 300);
            this.encryptedTextBox.TabIndex = 1;
            // 
            // decryptedTextBox
            // 
            this.decryptedTextBox.Location = new System.Drawing.Point(822, 30);
            this.decryptedTextBox.Multiline = true;
            this.decryptedTextBox.Name = "decryptedTextBox";
            this.decryptedTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.decryptedTextBox.Size = new System.Drawing.Size(350, 300);
            this.decryptedTextBox.TabIndex = 2;
            // 
            // keyTextBox
            // 
            this.keyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.keyTextBox.Location = new System.Drawing.Point(12, 414);
            this.keyTextBox.Name = "keyTextBox";
            this.keyTextBox.Size = new System.Drawing.Size(350, 26);
            this.keyTextBox.TabIndex = 3;
            this.keyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // keyGenButton
            // 
            this.keyGenButton.Font = new System.Drawing.Font("PMingLiU-ExtB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyGenButton.Location = new System.Drawing.Point(12, 456);
            this.keyGenButton.Name = "keyGenButton";
            this.keyGenButton.Size = new System.Drawing.Size(350, 23);
            this.keyGenButton.TabIndex = 4;
            this.keyGenButton.Text = "Сгенерировать ключ";
            this.keyGenButton.UseVisualStyleBackColor = true;
            this.keyGenButton.Click += new System.EventHandler(this.keyGenButton_Click);
            // 
            // loadFileButton
            // 
            this.loadFileButton.Font = new System.Drawing.Font("PMingLiU-ExtB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadFileButton.Location = new System.Drawing.Point(417, 414);
            this.loadFileButton.Name = "loadFileButton";
            this.loadFileButton.Size = new System.Drawing.Size(350, 23);
            this.loadFileButton.TabIndex = 5;
            this.loadFileButton.Text = "Загрузить файл";
            this.loadFileButton.UseVisualStyleBackColor = true;
            this.loadFileButton.Click += new System.EventHandler(this.loadFileButton_Click);
            // 
            // saveFileButton
            // 
            this.saveFileButton.Font = new System.Drawing.Font("PMingLiU-ExtB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveFileButton.Location = new System.Drawing.Point(417, 456);
            this.saveFileButton.Name = "saveFileButton";
            this.saveFileButton.Size = new System.Drawing.Size(350, 23);
            this.saveFileButton.TabIndex = 6;
            this.saveFileButton.Text = "Сохранить файл";
            this.saveFileButton.UseVisualStyleBackColor = true;
            this.saveFileButton.Click += new System.EventHandler(this.saveFileButton_Click);
            // 
            // runButton
            // 
            this.runButton.Font = new System.Drawing.Font("PMingLiU-ExtB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runButton.Location = new System.Drawing.Point(822, 456);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(338, 23);
            this.runButton.TabIndex = 7;
            this.runButton.Text = "Выполнить";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // encryptRadioButton
            // 
            this.encryptRadioButton.Font = new System.Drawing.Font("PMingLiU-ExtB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.encryptRadioButton.Location = new System.Drawing.Point(828, 414);
            this.encryptRadioButton.Name = "encryptRadioButton";
            this.encryptRadioButton.Size = new System.Drawing.Size(110, 23);
            this.encryptRadioButton.TabIndex = 8;
            this.encryptRadioButton.TabStop = true;
            this.encryptRadioButton.Text = "Зашифровать";
            this.encryptRadioButton.UseVisualStyleBackColor = true;
            // 
            // decryptRadioButton
            // 
            this.decryptRadioButton.Font = new System.Drawing.Font("PMingLiU-ExtB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decryptRadioButton.Location = new System.Drawing.Point(1044, 414);
            this.decryptRadioButton.Name = "decryptRadioButton";
            this.decryptRadioButton.Size = new System.Drawing.Size(116, 23);
            this.decryptRadioButton.TabIndex = 9;
            this.decryptRadioButton.TabStop = true;
            this.decryptRadioButton.Text = "Расшифровать";
            this.decryptRadioButton.UseVisualStyleBackColor = true;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // codeType
            // 
            this.codeType.Controls.Add(this.unicodeRadioButton);
            this.codeType.Controls.Add(this.utf8RadioButton);
            this.codeType.Controls.Add(this.asciiRadioButton);
            this.codeType.Location = new System.Drawing.Point(822, 346);
            this.codeType.Name = "codeType";
            this.codeType.Size = new System.Drawing.Size(350, 53);
            this.codeType.TabIndex = 10;
            this.codeType.TabStop = false;
            this.codeType.Text = "Вид кодировки";
            // 
            // unicodeRadioButton
            // 
            this.unicodeRadioButton.AutoSize = true;
            this.unicodeRadioButton.Location = new System.Drawing.Point(270, 23);
            this.unicodeRadioButton.Name = "unicodeRadioButton";
            this.unicodeRadioButton.Size = new System.Drawing.Size(74, 17);
            this.unicodeRadioButton.TabIndex = 2;
            this.unicodeRadioButton.Text = "UNICODE";
            this.unicodeRadioButton.UseVisualStyleBackColor = true;
            // 
            // utf8RadioButton
            // 
            this.utf8RadioButton.AutoSize = true;
            this.utf8RadioButton.Location = new System.Drawing.Point(140, 23);
            this.utf8RadioButton.Name = "utf8RadioButton";
            this.utf8RadioButton.Size = new System.Drawing.Size(52, 17);
            this.utf8RadioButton.TabIndex = 1;
            this.utf8RadioButton.Text = "UTF8";
            this.utf8RadioButton.UseVisualStyleBackColor = true;
            // 
            // asciiRadioButton
            // 
            this.asciiRadioButton.AutoSize = true;
            this.asciiRadioButton.Checked = true;
            this.asciiRadioButton.Location = new System.Drawing.Point(6, 23);
            this.asciiRadioButton.Name = "asciiRadioButton";
            this.asciiRadioButton.Size = new System.Drawing.Size(52, 17);
            this.asciiRadioButton.TabIndex = 0;
            this.asciiRadioButton.TabStop = true;
            this.asciiRadioButton.Text = "ASCII";
            this.asciiRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.desRadioButton);
            this.groupBox1.Controls.Add(this.xorRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(417, 346);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 53);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Вид кодировки";
            // 
            // desRadioButton
            // 
            this.desRadioButton.AutoSize = true;
            this.desRadioButton.Location = new System.Drawing.Point(297, 23);
            this.desRadioButton.Name = "desRadioButton";
            this.desRadioButton.Size = new System.Drawing.Size(47, 17);
            this.desRadioButton.TabIndex = 1;
            this.desRadioButton.Text = "DES";
            this.desRadioButton.UseVisualStyleBackColor = true;
            // 
            // xorRadioButton
            // 
            this.xorRadioButton.AutoSize = true;
            this.xorRadioButton.Checked = true;
            this.xorRadioButton.Location = new System.Drawing.Point(6, 23);
            this.xorRadioButton.Name = "xorRadioButton";
            this.xorRadioButton.Size = new System.Drawing.Size(48, 17);
            this.xorRadioButton.TabIndex = 0;
            this.xorRadioButton.TabStop = true;
            this.xorRadioButton.Text = "XOR";
            this.xorRadioButton.UseVisualStyleBackColor = true;
            // 
            // DesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 491);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.codeType);
            this.Controls.Add(this.decryptRadioButton);
            this.Controls.Add(this.encryptRadioButton);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.saveFileButton);
            this.Controls.Add(this.loadFileButton);
            this.Controls.Add(this.keyGenButton);
            this.Controls.Add(this.keyTextBox);
            this.Controls.Add(this.decryptedTextBox);
            this.Controls.Add(this.encryptedTextBox);
            this.Controls.Add(this.originalTextBox);
            this.Name = "DesForm";
            this.Text = "Алгоритм DES by smeshmike";
            this.codeType.ResumeLayout(false);
            this.codeType.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox originalTextBox;
        private System.Windows.Forms.TextBox encryptedTextBox;
        private System.Windows.Forms.TextBox decryptedTextBox;
        private System.Windows.Forms.TextBox keyTextBox;
        private System.Windows.Forms.Button keyGenButton;
        private System.Windows.Forms.Button loadFileButton;
        private System.Windows.Forms.Button saveFileButton;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.RadioButton encryptRadioButton;
        private System.Windows.Forms.RadioButton decryptRadioButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox codeType;
        private System.Windows.Forms.RadioButton unicodeRadioButton;
        private System.Windows.Forms.RadioButton utf8RadioButton;
        private System.Windows.Forms.RadioButton asciiRadioButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton desRadioButton;
        private System.Windows.Forms.RadioButton xorRadioButton;
    }
}

