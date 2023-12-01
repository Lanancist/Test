namespace Admin_Module
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btn_load = new System.Windows.Forms.ToolStripButton();
			this.btn_main = new System.Windows.Forms.ToolStripButton();
			this.btn_editor = new System.Windows.Forms.ToolStripButton();
			this.btn_newquestion = new System.Windows.Forms.ToolStripButton();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.label3 = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.button2 = new System.Windows.Forms.Button();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.panel1 = new System.Windows.Forms.Panel();
			this.textBox12 = new System.Windows.Forms.TextBox();
			this.button3 = new System.Windows.Forms.Button();
			this.textBox11 = new System.Windows.Forms.TextBox();
			this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
			this.label14 = new System.Windows.Forms.Label();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.radioButton6 = new System.Windows.Forms.RadioButton();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.toolStrip1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
			this.SuspendLayout();
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.Filter = "Excel|*.xls";
			// 
			// toolStrip1
			// 
			this.toolStrip1.AllowMerge = false;
			this.toolStrip1.CanOverflow = false;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
				this.btn_load,
				this.btn_main,
				this.btn_editor,
				this.btn_newquestion});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(788, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// btn_load
			// 
			this.btn_load.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btn_load.Image = ((System.Drawing.Image)(resources.GetObject("btn_load.Image")));
			this.btn_load.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_load.Name = "btn_load";
			this.btn_load.Size = new System.Drawing.Size(113, 22);
			this.btn_load.Text = "Загрузить таблицу";
			this.btn_load.Click += new System.EventHandler(this.toolStripButton1_Click);
			// 
			// btn_main
			// 
			this.btn_main.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btn_main.Image = ((System.Drawing.Image)(resources.GetObject("btn_main.Image")));
			this.btn_main.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_main.Name = "btn_main";
			this.btn_main.Size = new System.Drawing.Size(55, 22);
			this.btn_main.Text = "Главная";
			this.btn_main.Click += new System.EventHandler(this.btn_main_Click);
			// 
			// btn_editor
			// 
			this.btn_editor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btn_editor.Image = ((System.Drawing.Image)(resources.GetObject("btn_editor.Image")));
			this.btn_editor.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_editor.Name = "btn_editor";
			this.btn_editor.Size = new System.Drawing.Size(112, 22);
			this.btn_editor.Text = "Редактор таблицы";
			this.btn_editor.Click += new System.EventHandler(this.btn_editor_Click);
			// 
			// btn_newquestion
			// 
			this.btn_newquestion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btn_newquestion.Image = ((System.Drawing.Image)(resources.GetObject("btn_newquestion.Image")));
			this.btn_newquestion.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_newquestion.Name = "btn_newquestion";
			this.btn_newquestion.Size = new System.Drawing.Size(127, 22);
			this.btn_newquestion.Text = "Добавление вопроса";
			this.btn_newquestion.Click += new System.EventHandler(this.btn_newquestion_Click);
			// 
			// button1
			// 
			this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button1.Location = new System.Drawing.Point(282, 504);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(244, 67);
			this.button1.TabIndex = 3;
			this.button1.Text = "Сохранить в файл";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox1
			// 
			this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBox1.Location = new System.Drawing.Point(12, 70);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(560, 30);
			this.textBox1.TabIndex = 4;
			this.textBox1.Text = "Тест без названия";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.groupBox1.Controls.Add(this.richTextBox1);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.radioButton2);
			this.groupBox1.Controls.Add(this.radioButton1);
			this.groupBox1.Controls.Add(this.numericUpDown1);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.groupBox1.Location = new System.Drawing.Point(12, 123);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(370, 314);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Настройки выбора вопросов";
			// 
			// richTextBox1
			// 
			this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
			this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.richTextBox1.Location = new System.Drawing.Point(8, 116);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ReadOnly = true;
			this.richTextBox1.Size = new System.Drawing.Size(356, 180);
			this.richTextBox1.TabIndex = 3;
			this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.Location = new System.Drawing.Point(16, 67);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(120, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "Количество вопросов:";
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.radioButton2.Location = new System.Drawing.Point(16, 39);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(240, 19);
			this.radioButton2.TabIndex = 2;
			this.radioButton2.Text = "Выбирать из каждой темы отдельно";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Checked = true;
			this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.radioButton1.Location = new System.Drawing.Point(16, 20);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(155, 19);
			this.radioButton1.TabIndex = 1;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Выбирать из всех тем";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.numericUpDown1.Location = new System.Drawing.Point(142, 64);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(120, 21);
			this.numericUpDown1.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(8, 29);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(168, 20);
			this.label2.TabIndex = 7;
			this.label2.Text = "Всего вопросов:____";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.groupBox2.Controls.Add(this.radioButton4);
			this.groupBox2.Controls.Add(this.textBox2);
			this.groupBox2.Controls.Add(this.radioButton3);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.groupBox2.Location = new System.Drawing.Point(388, 123);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(388, 314);
			this.groupBox2.TabIndex = 8;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Настройки пароля";
			// 
			// radioButton4
			// 
			this.radioButton4.AutoSize = true;
			this.radioButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.radioButton4.Location = new System.Drawing.Point(225, 83);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(91, 19);
			this.radioButton4.TabIndex = 3;
			this.radioButton4.Text = "Выключить";
			this.radioButton4.UseVisualStyleBackColor = true;
			// 
			// textBox2
			// 
			this.textBox2.BackColor = System.Drawing.SystemColors.Control;
			this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBox2.Location = new System.Drawing.Point(19, 133);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(333, 123);
			this.textBox2.TabIndex = 4;
			this.textBox2.Text = resources.GetString("textBox2.Text");
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.BackColor = System.Drawing.Color.Transparent;
			this.radioButton3.Checked = true;
			this.radioButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.radioButton3.Location = new System.Drawing.Point(56, 83);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(82, 19);
			this.radioButton3.TabIndex = 2;
			this.radioButton3.TabStop = true;
			this.radioButton3.Text = "Включить";
			this.radioButton3.UseVisualStyleBackColor = false;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(60, 36);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(137, 17);
			this.label3.TabIndex = 0;
			this.label3.Text = "Пароль на сегодня:";
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			this.dataGridView1.Location = new System.Drawing.Point(613, 24);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(125, 76);
			this.dataGridView1.TabIndex = 10;
			this.dataGridView1.Tag = "0";
			this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
			// 
			// button2
			// 
			this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button2.Location = new System.Drawing.Point(282, 453);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(244, 45);
			this.button2.TabIndex = 9;
			this.button2.Text = "Сохранить в таблицу";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.Filter = "Excel|*.xls";
			this.saveFileDialog1.OverwritePrompt = false;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.textBox12);
			this.panel1.Controls.Add(this.button3);
			this.panel1.Controls.Add(this.textBox11);
			this.panel1.Controls.Add(this.numericUpDown3);
			this.panel1.Controls.Add(this.label14);
			this.panel1.Controls.Add(this.textBox10);
			this.panel1.Controls.Add(this.textBox9);
			this.panel1.Controls.Add(this.textBox8);
			this.panel1.Controls.Add(this.textBox7);
			this.panel1.Controls.Add(this.textBox6);
			this.panel1.Controls.Add(this.textBox5);
			this.panel1.Controls.Add(this.label13);
			this.panel1.Controls.Add(this.label12);
			this.panel1.Controls.Add(this.label11);
			this.panel1.Controls.Add(this.label10);
			this.panel1.Controls.Add(this.label9);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.radioButton6);
			this.panel1.Controls.Add(this.radioButton5);
			this.panel1.Controls.Add(this.numericUpDown2);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.textBox4);
			this.panel1.Controls.Add(this.textBox3);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.panel1.Location = new System.Drawing.Point(496, 29);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(111, 72);
			this.panel1.TabIndex = 11;
			// 
			// textBox12
			// 
			this.textBox12.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.textBox12.BackColor = System.Drawing.SystemColors.Control;
			this.textBox12.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox12.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBox12.ForeColor = System.Drawing.Color.Red;
			this.textBox12.Location = new System.Drawing.Point(-32, -116);
			this.textBox12.Multiline = true;
			this.textBox12.Name = "textBox12";
			this.textBox12.ReadOnly = true;
			this.textBox12.Size = new System.Drawing.Size(463, 78);
			this.textBox12.TabIndex = 27;
			// 
			// button3
			// 
			this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.button3.Location = new System.Drawing.Point(-32, 273);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(201, 37);
			this.button3.TabIndex = 25;
			this.button3.Text = "Добавить вопрос";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// textBox11
			// 
			this.textBox11.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.textBox11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox11.Location = new System.Drawing.Point(68, 223);
			this.textBox11.Multiline = true;
			this.textBox11.Name = "textBox11";
			this.textBox11.ReadOnly = true;
			this.textBox11.Size = new System.Drawing.Size(333, 67);
			this.textBox11.TabIndex = 24;
			this.textBox11.Text = "      Если ответов несколько, введите несколько цифр подряд";
			// 
			// numericUpDown3
			// 
			this.numericUpDown3.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.numericUpDown3.Location = new System.Drawing.Point(-77, 229);
			this.numericUpDown3.Maximum = new decimal(new int[] {
				654321,
				0,
				0,
				0});
			this.numericUpDown3.Name = "numericUpDown3";
			this.numericUpDown3.Size = new System.Drawing.Size(120, 30);
			this.numericUpDown3.TabIndex = 23;
			this.numericUpDown3.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
			// 
			// label14
			// 
			this.label14.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(-190, 231);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(78, 25);
			this.label14.TabIndex = 21;
			this.label14.Text = "Ответ:";
			// 
			// textBox10
			// 
			this.textBox10.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.textBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBox10.Location = new System.Drawing.Point(-216, 194);
			this.textBox10.Name = "textBox10";
			this.textBox10.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox10.Size = new System.Drawing.Size(653, 26);
			this.textBox10.TabIndex = 20;
			this.textBox10.TextChanged += new System.EventHandler(this.textBox10_TextChanged);
			// 
			// textBox9
			// 
			this.textBox9.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.textBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBox9.Location = new System.Drawing.Point(-216, 163);
			this.textBox9.Name = "textBox9";
			this.textBox9.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox9.Size = new System.Drawing.Size(653, 26);
			this.textBox9.TabIndex = 19;
			this.textBox9.TextChanged += new System.EventHandler(this.textBox9_TextChanged);
			// 
			// textBox8
			// 
			this.textBox8.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.textBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBox8.Location = new System.Drawing.Point(-216, 132);
			this.textBox8.Name = "textBox8";
			this.textBox8.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox8.Size = new System.Drawing.Size(653, 26);
			this.textBox8.TabIndex = 18;
			this.textBox8.TextChanged += new System.EventHandler(this.textBox8_TextChanged);
			// 
			// textBox7
			// 
			this.textBox7.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.textBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBox7.Location = new System.Drawing.Point(-216, 101);
			this.textBox7.Name = "textBox7";
			this.textBox7.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox7.Size = new System.Drawing.Size(653, 26);
			this.textBox7.TabIndex = 17;
			this.textBox7.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
			// 
			// textBox6
			// 
			this.textBox6.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBox6.Location = new System.Drawing.Point(-216, 70);
			this.textBox6.Name = "textBox6";
			this.textBox6.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox6.Size = new System.Drawing.Size(653, 26);
			this.textBox6.TabIndex = 16;
			this.textBox6.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
			// 
			// textBox5
			// 
			this.textBox5.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBox5.Location = new System.Drawing.Point(-216, 39);
			this.textBox5.Name = "textBox5";
			this.textBox5.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox5.Size = new System.Drawing.Size(653, 26);
			this.textBox5.TabIndex = 15;
			this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
			// 
			// label13
			// 
			this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(-333, 194);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(111, 25);
			this.label13.TabIndex = 14;
			this.label13.Text = "Вариант 6:";
			// 
			// label12
			// 
			this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(-333, 163);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(111, 25);
			this.label12.TabIndex = 13;
			this.label12.Text = "Вариант 5:";
			// 
			// label11
			// 
			this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(-333, 132);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(111, 25);
			this.label11.TabIndex = 12;
			this.label11.Text = "Вариант 4:";
			// 
			// label10
			// 
			this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(-333, 101);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(111, 25);
			this.label10.TabIndex = 11;
			this.label10.Text = "Вариант 3:";
			// 
			// label9
			// 
			this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(-333, 70);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(111, 25);
			this.label9.TabIndex = 10;
			this.label9.Text = "Вариант 2:";
			// 
			// label8
			// 
			this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(-333, 39);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(111, 25);
			this.label8.TabIndex = 9;
			this.label8.Text = "Вариант 1:";
			// 
			// label7
			// 
			this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(-327, -123);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(269, 25);
			this.label7.TabIndex = 8;
			this.label7.Text = "Это обязательный вопрос?";
			// 
			// radioButton6
			// 
			this.radioButton6.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radioButton6.AutoSize = true;
			this.radioButton6.Location = new System.Drawing.Point(-124, -97);
			this.radioButton6.Name = "radioButton6";
			this.radioButton6.Size = new System.Drawing.Size(66, 29);
			this.radioButton6.TabIndex = 7;
			this.radioButton6.Text = "Нет";
			this.radioButton6.UseVisualStyleBackColor = true;
			this.radioButton6.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
			// 
			// radioButton5
			// 
			this.radioButton5.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.radioButton5.AutoSize = true;
			this.radioButton5.Checked = true;
			this.radioButton5.Location = new System.Drawing.Point(-318, -97);
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.Size = new System.Drawing.Size(57, 29);
			this.radioButton5.TabIndex = 6;
			this.radioButton5.TabStop = true;
			this.radioButton5.Text = "Да";
			this.radioButton5.UseVisualStyleBackColor = true;
			// 
			// numericUpDown2
			// 
			this.numericUpDown2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.numericUpDown2.Location = new System.Drawing.Point(-165, -68);
			this.numericUpDown2.Name = "numericUpDown2";
			this.numericUpDown2.Size = new System.Drawing.Size(120, 30);
			this.numericUpDown2.TabIndex = 5;
			this.numericUpDown2.Value = new decimal(new int[] {
				1,
				0,
				0,
				0});
			this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
			// 
			// label6
			// 
			this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(-324, -66);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(140, 25);
			this.label6.TabIndex = 4;
			this.label6.Text = "Номер темы:";
			// 
			// textBox4
			// 
			this.textBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.textBox4.Location = new System.Drawing.Point(-216, -22);
			this.textBox4.Name = "textBox4";
			this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox4.Size = new System.Drawing.Size(647, 30);
			this.textBox4.TabIndex = 3;
			this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
			// 
			// textBox3
			// 
			this.textBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.textBox3.Location = new System.Drawing.Point(-216, -239);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox3.Size = new System.Drawing.Size(653, 109);
			this.textBox3.TabIndex = 2;
			this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
			// 
			// label5
			// 
			this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(-324, -19);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(68, 25);
			this.label5.TabIndex = 1;
			this.label5.Text = "Тема:";
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(-332, -207);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(84, 25);
			this.label1.TabIndex = 0;
			this.label1.Text = "Вопрос:";
			// 
			// Form1
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(788, 597);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.toolStrip1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "Программа тестирования. Мастер";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton btn_load;
		private System.Windows.Forms.ToolStripButton btn_editor;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.ToolStripButton btn_newquestion;
		private System.Windows.Forms.ToolStripButton btn_main;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numericUpDown2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.RadioButton radioButton6;
		private System.Windows.Forms.RadioButton radioButton5;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox textBox11;
		private System.Windows.Forms.NumericUpDown numericUpDown3;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox textBox12;
	}
}

