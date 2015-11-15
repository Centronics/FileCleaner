namespace FileCleaner
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.FD = new System.Windows.Forms.FolderBrowserDialog();
            this.tb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.OF = new System.Windows.Forms.OpenFileDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.selected = new System.Windows.Forms.ListBox();
            this.deselected = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.ni = new System.Windows.Forms.NotifyIcon(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.tt = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(182, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 31);
            this.button1.TabIndex = 0;
            this.button1.Text = "Обзор папок...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(154, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберите папки для очистки";
            // 
            // tb
            // 
            this.tb.Location = new System.Drawing.Point(219, 64);
            this.tb.Name = "tb";
            this.tb.Size = new System.Drawing.Size(100, 20);
            this.tb.TabIndex = 2;
            this.tb.Text = "3";
            this.tb.TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(84, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Частота очистки:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(325, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "дней (не более 30)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(2, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "Выбранные папки:";
            // 
            // OF
            // 
            this.OF.FileName = "OD";
            this.OF.InitialDirectory = "C:\\";
            this.OF.Multiselect = true;
            this.OF.SupportMultiDottedExtensions = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(2, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 18);
            this.label5.TabIndex = 6;
            this.label5.Text = "Исключения:";
            // 
            // selected
            // 
            this.selected.FormattingEnabled = true;
            this.selected.Location = new System.Drawing.Point(5, 115);
            this.selected.Name = "selected";
            this.selected.Size = new System.Drawing.Size(376, 95);
            this.selected.TabIndex = 7;
            // 
            // deselected
            // 
            this.deselected.FormattingEnabled = true;
            this.deselected.Location = new System.Drawing.Point(5, 234);
            this.deselected.Name = "deselected";
            this.deselected.Size = new System.Drawing.Size(376, 108);
            this.deselected.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(387, 234);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Добавить файл";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(387, 263);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Добавить папку";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(433, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 12;
            this.button5.Text = "Выход";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // ni
            // 
            this.ni.Text = "FileCleaner";
            this.ni.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ni_MouseUp);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(5, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(114, 23);
            this.button4.TabIndex = 13;
            this.button4.Text = "О программе...";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(387, 115);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(112, 23);
            this.button6.TabIndex = 14;
            this.button6.Text = "Удалить папку";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(388, 292);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(111, 23);
            this.button7.TabIndex = 15;
            this.button7.Text = "Удалить элемент";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // tt
            // 
            this.tt.Enabled = true;
            this.tt.Tick += new System.EventHandler(this.tt_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 343);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.deselected);
            this.Controls.Add(this.selected);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FileCleaner";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog FD;
        private System.Windows.Forms.TextBox tb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog OF;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox selected;
        private System.Windows.Forms.ListBox deselected;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.NotifyIcon ni;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Timer tt;
    }
}

