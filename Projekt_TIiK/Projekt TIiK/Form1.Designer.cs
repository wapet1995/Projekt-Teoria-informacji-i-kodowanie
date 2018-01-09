namespace Projekt_TIiK
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.TXBox_text = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxEntropia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxLenghText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bt_koduj = new System.Windows.Forms.Button();
            this.bt_dekoduj = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(120, 26);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 31);
            this.button1.TabIndex = 0;
            this.button1.Text = "Wczytaj plik";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(474, 26);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(3);
            this.button2.Size = new System.Drawing.Size(80, 31);
            this.button2.TabIndex = 1;
            this.button2.Text = "Skanuj tekst";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TXBox_text
            // 
            this.TXBox_text.Location = new System.Drawing.Point(14, 69);
            this.TXBox_text.Margin = new System.Windows.Forms.Padding(2);
            this.TXBox_text.Name = "TXBox_text";
            this.TXBox_text.Size = new System.Drawing.Size(319, 326);
            this.TXBox_text.TabIndex = 2;
            this.TXBox_text.Text = "";
            this.TXBox_text.TextChanged += new System.EventHandler(this.TXBox_text_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pobrany tekst:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(350, 69);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(355, 326);
            this.dataGridView1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(374, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Wynik skanowania";
            // 
            // textBoxEntropia
            // 
            this.textBoxEntropia.Location = new System.Drawing.Point(279, 413);
            this.textBoxEntropia.Name = "textBoxEntropia";
            this.textBoxEntropia.ReadOnly = true;
            this.textBoxEntropia.Size = new System.Drawing.Size(114, 20);
            this.textBoxEntropia.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(233, 416);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Entropia:";
            // 
            // textBoxLenghText
            // 
            this.textBoxLenghText.Location = new System.Drawing.Point(140, 414);
            this.textBoxLenghText.Name = "textBoxLenghText";
            this.textBoxLenghText.ReadOnly = true;
            this.textBoxLenghText.Size = new System.Drawing.Size(87, 20);
            this.textBoxLenghText.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 417);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Ilość znaków w tekście:";
            // 
            // bt_koduj
            // 
            this.bt_koduj.Location = new System.Drawing.Point(567, 26);
            this.bt_koduj.Name = "bt_koduj";
            this.bt_koduj.Size = new System.Drawing.Size(63, 31);
            this.bt_koduj.TabIndex = 20;
            this.bt_koduj.Text = "Zakoduj";
            this.bt_koduj.UseVisualStyleBackColor = true;
            this.bt_koduj.Click += new System.EventHandler(this.bt_koduj_Click);
            // 
            // bt_dekoduj
            // 
            this.bt_dekoduj.Location = new System.Drawing.Point(642, 26);
            this.bt_dekoduj.Name = "bt_dekoduj";
            this.bt_dekoduj.Size = new System.Drawing.Size(63, 31);
            this.bt_dekoduj.TabIndex = 21;
            this.bt_dekoduj.Text = "Zdekoduj";
            this.bt_dekoduj.UseVisualStyleBackColor = true;
            this.bt_dekoduj.Click += new System.EventHandler(this.bt_dekoduj_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(411, 403);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Rozmiar pliku przed kodowaniem:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(600, 400);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(411, 420);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Rozmiar pliku po zakodowaniu:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(600, 420);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 24;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(716, 442);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.bt_dekoduj);
            this.Controls.Add(this.bt_koduj);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxLenghText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxEntropia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TXBox_text);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Projekt TIiK";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox TXBox_text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxEntropia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxLenghText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bt_koduj;
        private System.Windows.Forms.Button bt_dekoduj;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
    }
}

