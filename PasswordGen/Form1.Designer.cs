﻿namespace PasswordGen
{
	partial class Form1
	{
		/// <summary>
		/// Обязательная переменная конструктора.
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
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(114, 33);
			this.textBox1.Margin = new System.Windows.Forms.Padding(6);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(398, 29);
			this.textBox1.TabIndex = 0;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(37, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 24);
			this.label1.TabIndex = 1;
			this.label1.Text = "Имя";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(37, 66);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 24);
			this.label2.TabIndex = 3;
			this.label2.Text = "Дата";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(114, 66);
			this.textBox2.Margin = new System.Windows.Forms.Padding(6);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(398, 29);
			this.textBox2.TabIndex = 2;
			this.textBox2.Text = "Дата";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(532, 68);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(108, 24);
			this.label3.TabIndex = 4;
			this.label3.Text = "(ддммгггг)";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(54, 139);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(96, 24);
			this.label4.TabIndex = 5;
			this.label4.Text = "ддммгггг";
			this.label4.Click += new System.EventHandler(this.label4_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(54, 174);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(96, 24);
			this.label5.TabIndex = 6;
			this.label5.Text = "ддммгггг";
			this.label5.Click += new System.EventHandler(this.label5_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(54, 207);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(96, 24);
			this.label6.TabIndex = 7;
			this.label6.Text = "ддммгггг";
			this.label6.Click += new System.EventHandler(this.label6_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(54, 241);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(96, 24);
			this.label7.TabIndex = 8;
			this.label7.Text = "ддммгггг";
			this.label7.Click += new System.EventHandler(this.label7_Click);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(54, 277);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(96, 24);
			this.label8.TabIndex = 9;
			this.label8.Text = "ддммгггг";
			this.label8.Click += new System.EventHandler(this.label8_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(206, 96);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(218, 36);
			this.button1.TabIndex = 10;
			this.button1.Text = "Расчитать";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(871, 509);
			this.tabControl1.TabIndex = 11;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.label11);
			this.tabPage1.Controls.Add(this.label10);
			this.tabPage1.Controls.Add(this.textBox1);
			this.tabPage1.Controls.Add(this.label8);
			this.tabPage1.Controls.Add(this.label7);
			this.tabPage1.Controls.Add(this.button1);
			this.tabPage1.Controls.Add(this.label6);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Controls.Add(this.textBox2);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Location = new System.Drawing.Point(4, 33);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(863, 472);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Пароль";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.tabPage1.Enter += new System.EventHandler(this.tabPage1_Enter);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(54, 348);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(96, 24);
			this.label11.TabIndex = 12;
			this.label11.Text = "ддммгггг";
			this.label11.Click += new System.EventHandler(this.label11_Click);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(54, 315);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(96, 24);
			this.label10.TabIndex = 11;
			this.label10.Text = "ддммгггг";
			this.label10.Click += new System.EventHandler(this.label10_Click);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.textBox5);
			this.tabPage2.Controls.Add(this.label9);
			this.tabPage2.Controls.Add(this.textBox4);
			this.tabPage2.Controls.Add(this.textBox3);
			this.tabPage2.Location = new System.Drawing.Point(4, 33);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(863, 472);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Кодировка";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.tabPage2.Enter += new System.EventHandler(this.tabPage2_Enter);
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(128, 4);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(181, 29);
			this.textBox5.TabIndex = 3;
			this.textBox5.Text = "1193046";
			this.textBox5.TextChanged += new System.EventHandler(this.TextBox5_TextChanged);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(421, 3);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(27, 24);
			this.label9.TabIndex = 2;
			this.label9.Text = "->";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(437, 39);
			this.textBox4.Multiline = true;
			this.textBox4.Name = "textBox4";
			this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox4.Size = new System.Drawing.Size(418, 425);
			this.textBox4.TabIndex = 1;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(6, 39);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox3.Size = new System.Drawing.Size(425, 425);
			this.textBox3.TabIndex = 0;
			this.textBox3.TextChanged += new System.EventHandler(this.TextBox3_TextChanged);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(871, 509);
			this.Controls.Add(this.tabControl1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(6);
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.ShowIcon = false;
			this.Text = "Панелька для админов";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
	}
}

