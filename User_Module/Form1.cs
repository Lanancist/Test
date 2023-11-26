using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
namespace User_Module
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		//TabPage[] tabPages;
		int n, generateCount;
		bool password, isNamed, fromEveryTheme, obligateQuestions;

		private void button1_Click(object sender, EventArgs e)
		{
			tabs.Visible = true;
		}
		public void GenerateRandomNumbers(int n, int a, int b, ref List<int> num)
		{
			Random rand = new Random();
			int k = 0, c;
			while (k < n)
			{
				c = rand.Next(a, b + 1);
				if (num.Contains(c))
					continue;
				num.Add(c);
				k++;
			}

		}


		private void Form1_ResizeEnd(object sender, EventArgs e)
		{
			button1.Top = (this.Height - 100) / 2;
			button1.Left = (this.Width - 200) / 2;
			button1.Width = 200;
			button1.Height = 100;
			if (tabs.TabPages[n + 1].Controls[0] is Button)
			{
				tabs.TabPages[n + 1].Controls[0].Top = (this.Height - 100) / 2;
				tabs.TabPages[n + 1].Controls[0].Left = (this.Width - 200) / 2;
				tabs.TabPages[n + 1].Controls[0].Width = 200;
				tabs.TabPages[n + 1].Controls[0].Height = 100;
			}

		}
		string path = "input.txt";
		private void Form1_Load(object sender, EventArgs e)
		{
			tabs.BringToFront();
			tabs.Visible = true;
			tabs.Dock = DockStyle.Fill;
			string line;
			FileInfo filepath = new FileInfo(path);
			if (!filepath.Exists)
			{
				MessageBox.Show("Файл с вопросами не найден!", "Ошибка загрузки", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Close();
				return;
			}
			StreamReader fin = new StreamReader(path);
			string lastChanged = File.GetLastWriteTime(path).ToString();
			lastChanged = lastChanged.Replace(".", "").Replace(" ", "").Replace(":", "");
			line = fin.ReadLine();
			string[] questm = line.Split(new[] { '.' }, StringSplitOptions.None); ;
			password = questm[0] == "1";
			isNamed = questm[1] == "1";
			fromEveryTheme = questm[2] == "1";
			obligateQuestions = questm[3] == "1";
			/*
			 * if (lastChanged.Length<14) lastChanged.Insert(9, "0");
			 */
			/////////////////////////////
			///delete it for time check
			lastChanged = lastChanged.Substring(0, lastChanged.Length - 6);
			questm[4] = questm[4].Substring(0, questm[4].Length - 6);
			//////////////////////////
			if (questm[4] != lastChanged)
			{
				MessageBox.Show("Похоже, кто-то имзменял файл вопросов. Попросите преподавателя пересоздать его или взять с другого компьютера.", "Замечен обман", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				Close();
				return;
			}
			generateCount = int.Parse(questm[5]);
			List<int> numbers = new List<int>();
			if (fromEveryTheme)
			{
				if (obligateQuestions)
				{
					int k = int.Parse(questm[7]) - 1, a;
					for (int i = 8; i < questm.Length; i++)
					{
						a = int.Parse(questm[i]);
						GenerateRandomNumbers(generateCount, k + 1, k + a, ref numbers);
						k += a;
					}
				}
				else
				{
					int k = 0, a;
					for (int i = 7; i < questm.Length; i++)
					{
						a = int.Parse(questm[i]);
						GenerateRandomNumbers(generateCount, k + 1, k + a, ref numbers);
						k += a;
					}
				}

			}
			else
			{
				if (obligateQuestions)
				{
					int a = int.Parse(questm[7]) - 1;
					GenerateRandomNumbers(generateCount, a + 1, n, ref numbers);
				}
				else
					GenerateRandomNumbers(generateCount, 0, n, ref numbers);
			}

			n = int.Parse(questm[6]);
			if (isNamed)
			{
				Text = fin.ReadLine();
				label1.Text = Text;
			}

			TabPage tabPages;
			int questnumb=0;
			for (int i = 0; i < n; i++)
			{
				if (numbers.Contains(i))
					continue;
				++questnumb;
				line = fin.ReadLine();
				line = line.Remove(0, 1);
				line = line.Remove(line.Length - 1, 1);
				questm = line.Split(new[] { "\";\"" }, StringSplitOptions.None);
				tabPages = new TabPage();
				tabPages.Text = "Вопрос " + (questnumb + 1);
				tabPages.BackColor = Color.White;
				tabPages.AutoScroll = true;
				tabs.TabPages.Add(tabPages);
				SplitContainer splitter = new SplitContainer();
				tabPages.Controls.Add(splitter);
				splitter.Parent = this;
				splitter.Name = "splitter" + questnumb;
				splitter.Visible = true;
				splitter.Enabled = true;
				splitter.Dock = DockStyle.Fill;
				splitter.Orientation = Orientation.Horizontal;
				splitter.Parent = tabPages;
				splitter.SplitterDistance = 236;
				Label label1 = new Label();
				label1.Name = "Label" + questnumb;
				label1.Text = questm[2] + '\n' + "Вопрос " + (questnumb + 1);
				label1.Dock = DockStyle.Top;
				label1.Height = 40;
				label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
				label1.Visible = true;
				tabPages.Controls.Add(label1);
				RichTextBox quest = new RichTextBox();
				splitter.Panel1.Controls.Add(quest);
				quest.Name = "Text" + questnumb;
				quest.Text = questm[2];
				quest.Top = 100;
				quest.Dock = DockStyle.Fill;
				quest.Multiline = true;
				quest.ReadOnly = true;
				quest.BorderStyle = BorderStyle.None;
				quest.ScrollBars = RichTextBoxScrollBars.Vertical;
				quest.WordWrap = true;
				quest.ShortcutsEnabled = false;
				quest.TabIndex = 0;
				if (questm[9].Length > 1)
				{
					CheckedListBox answers = new CheckedListBox();
					splitter.Panel2.Controls.Add(answers);
					answers.BorderStyle = BorderStyle.None;
					answers.Name = "Check" + questnumb;
					answers.Visible = true;
					answers.Dock = DockStyle.Fill;
					answers.BeginUpdate();
					for (int j = 0; j < 6; j++)
					{
						if (questm[3 + j] != "")
							answers.Items.Add(questm[3 + j], 0);
						else
							j = 6;
					}
					answers.EndUpdate();
				}
				else
				{
					RadioButton radioButton;
					for (int j = 0; j < 6; j++)
					{
						if (questm[3 + j] != "")
						{
							radioButton = new RadioButton();
							radioButton.AutoSize = true;
							radioButton.Location = new System.Drawing.Point(10, 23 * j);
							radioButton.Name = "radioButton" + questnumb;
							radioButton.Size = new System.Drawing.Size(85, 17);
							radioButton.TabIndex = j;
							radioButton.TabStop = true;
							radioButton.Text = questm[3 + j];
							radioButton.UseVisualStyleBackColor = true;
							splitter.Panel2.Controls.Add(radioButton);
						}
						else
							j = 6;
					}

				}

			}
			tabPages = new TabPage();
			tabPages.BackColor = Color.White;
			tabPages.Text = "Окончить тест";
			tabPages.AutoScroll = true;
			tabs.TabPages.Add(tabPages);
			Button btn = new Button();
			tabPages.Controls.Add(btn);
			btn.Name = "btnEnd";
			btn.Text = "Завершить тест";
			btn.Visible = true;
			btn.Enabled = true;
			btn.Top = (this.Height - 100) / 2;
			btn.Left = (this.Width - 200) / 2;
			btn.Width = 200;
			btn.Height = 100;

		}
	}

}

