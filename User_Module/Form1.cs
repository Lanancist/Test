using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
namespace User_Module
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		int n, generateCount;
		bool ViewAnswers, fromEveryTheme, obligateQuestions, procents, easter = false, canWritePass = true;
		private void Button1_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(textBox2.Tag.ToString()))
			{
				if (textBox2.Text == textBox2.Tag.ToString())
				{
					tabs.Visible = true;
					MaximizeBox = true;
					WindowState = FormWindowState.Maximized;
				}
			}
			else
			{
				tabs.Visible = true;
				MaximizeBox = true;
				WindowState = FormWindowState.Maximized;
			}
		}
		public string GenCheatPasswordMain(string FIO)
		{
			if (FIO.Length > 50 || FIO.Length == 0)
				return "";
			System.Int32 key1 = 0;
			for (int i = 0; i < FIO.Length; i++)
				key1 += FIO[i] * (2 * (i % 2) - 1);
			key1 *= FIO.Length;
			string s = (DateTime.Now).ToString();
			s = s.Replace(".", "").Replace(" ", "").Replace(":", "");
			s = s.Substring(0, 8);
			char[] d = s.ToArray();
			for (int i = 0; i < d.Length; i++)
				d[i] = (char)('0' + ((d[i] - '0') + 3) % 10);
			if (d[0] == '0') d[0] = '1';
			s = string.Concat(d);
			int key2 = int.Parse(s);
			key1 += key2;
			return key1.ToString();
		}
		public string GenCheatPasswordByType(string FIO, int passType)
		{
			if (FIO == "") return "";
			if (passType == 3) return "Easter egg";
			string s = GenCheatPasswordMain(FIO);
			switch (passType)
			{
				//на 5
				case 0: return s.Substring(0, 4) + "05" + s.Substring(4);
				//на 4-5
				case 1: return s.Substring(0, 4) + "45" + s.Substring(4);
				//на 3-5
				case 2: return s.Substring(0, 4) + "35" + s.Substring(4);
				//войти без пароля
				case 4: return "0" + string.Concat(s.Substring(0, 4).Reverse()) + string.Concat(s.Substring(4).Reverse()) + "0";
				default: return "";
			}
		}
		public int GetPassType(string Pass, string FIO)
		{
			string s = GenCheatPasswordMain(FIO);
			string s1 = s.Substring(0, 4), s2 = s.Substring(4);
			if (Pass == s1 + "05" + s2)
				return 0;
			else
				if (Pass == s1 + "45" + s2)
				return 1;
			else
					if (Pass == s1 + "35" + s2)
				return 2;
			else
						if (Pass == "Easter egg")
				return 3;
			else
							if (Pass == "0" + string.Concat(s1.Reverse()) + string.Concat(s2.Reverse()) + "0")
				return 4;
			else
				return -1;
		}
		/// <summary>
		/// добавляется с лист num n случайных чисел таких, что a<=X<b
		/// </summary>
		/// <param name="n"></param>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <param name="num"></param>
		public void GenerateRandomNumbers(int n, int a, int b, ref List<int> num)
		{
			Random rand = new Random();
			int k = 0, c;
			while (k < n && k < b - a)
			{
				c = rand.Next(a, b);
				if (num.Contains(c))
					continue;
				num.Add(c);
				k++;
			}
		}
		private void Tabs_KeyDown(object sender, KeyEventArgs e)
		{
			if (tabs.Visible == true && e.KeyCode == Keys.Enter && tabs.SelectedIndex + 1 < tabs.TabPages.Count)
			{
				tabs.SelectedIndex++;
			}
		}
		private void Anytab_select(object sender, EventArgs e)
		{
			MaximizeBox = true;
		}
		private void TabPage1_Enter(object sender, EventArgs e)
		{
			MaximizeBox = false;
			WindowState = FormWindowState.Normal;
		}
		readonly string path = "test.data";
		private void CheckBox1_CheckedChanged(object sender, EventArgs e)
		{
		}
		private void TextBox2_TextChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Tag.ToString()))
			{
				button1.Enabled = false;
			}
			else
			{
				button1.Enabled = true;
			}
		}
		private void PictureBox1_Click(object sender, EventArgs e)
		{
			if (pictureBox1.Visible) pictureBox1.Visible = false;
		}
		private void Label1_Click(object sender, EventArgs e)
		{
			Random rand = new Random();
			switch (GetPassType(textBox2.Text, textBox1.Text))
			{
				case 0:
					if (canWritePass)
					{
						List<int> numbers = new List<int>();
						int counta = rand.Next((int)(Math.Ceiling(0.91 * 15)), n+ 1);
						GenerateRandomNumbers(counta, 0, n, ref numbers);
						for (int i = 0; i < tabs.TabPages.Count - 1; i++)
						{
							if (numbers.Contains(i))
							{
								if ((tabs.TabPages[i].Controls[0] as SplitContainer).Panel2.Controls[0] is CheckedListBox)
								{
									CheckedListBox c = (tabs.TabPages[i].Controls[0] as SplitContainer).Panel2.Controls[0] as CheckedListBox;
									foreach (var item in tabs.TabPages[i].Tag.ToString())
										c.SetItemCheckState(item - '0' - 1, CheckState.Checked);
								}
								else
								{
									if ((tabs.TabPages[i].Controls[0] as SplitContainer).Panel2.Controls[0] is System.Windows.Forms.RadioButton)
										((tabs.TabPages[i].Controls[0] as SplitContainer).Panel2.Controls[int.Parse(tabs.TabPages[i].Tag.ToString()) - 1] as System.Windows.Forms.RadioButton).Checked = true;
								}
							}
						}
						canWritePass = false;
					}
					break;
				case 1:
					if (canWritePass)
					{
						List<int> numbers = new List<int>();
						int counta = rand.Next((int)(Math.Ceiling(0.76 * 15)), (int)(Math.Ceiling(0.93 * 15)+1));
						GenerateRandomNumbers(counta, 0, n, ref numbers);
						for (int i = 0; i < tabs.TabPages.Count - 1; i++)
						{
							if (numbers.Contains(i))
							{
								if ((tabs.TabPages[i].Controls[0] as SplitContainer).Panel2.Controls[0] is CheckedListBox)
								{
									CheckedListBox c = (tabs.TabPages[i].Controls[0] as SplitContainer).Panel2.Controls[0] as CheckedListBox;
									foreach (var item in tabs.TabPages[i].Tag.ToString())
										c.SetItemCheckState(item - '0' - 1, CheckState.Checked);
								}
								else
								{
									if ((tabs.TabPages[i].Controls[0] as SplitContainer).Panel2.Controls[0] is System.Windows.Forms.RadioButton)
										((tabs.TabPages[i].Controls[0] as SplitContainer).Panel2.Controls[int.Parse(tabs.TabPages[i].Tag.ToString()) - 1] as System.Windows.Forms.RadioButton).Checked = true;
								}
							}
						}
						canWritePass = false;
					}
					break;
				case 2:
					if (canWritePass)
					{
						List<int> numbers = new List<int>();
						int counta = rand.Next((int)(Math.Ceiling(0.76 * 15)), (int)(Math.Ceiling(0.90 * 15)));
						GenerateRandomNumbers(counta, 0, n, ref numbers);
						for (int i = 0; i < tabs.TabPages.Count - 1; i++)
						{
							if (numbers.Contains(i))
							{
								if ((tabs.TabPages[i].Controls[0] as SplitContainer).Panel2.Controls[0] is CheckedListBox)
								{
									CheckedListBox c = (tabs.TabPages[i].Controls[0] as SplitContainer).Panel2.Controls[0] as CheckedListBox;
									foreach (var item in tabs.TabPages[i].Tag.ToString())
										c.SetItemCheckState(item - '0' - 1, CheckState.Checked);
								}
								else
								{
									if ((tabs.TabPages[i].Controls[0] as SplitContainer).Panel2.Controls[0] is System.Windows.Forms.RadioButton)
										((tabs.TabPages[i].Controls[0] as SplitContainer).Panel2.Controls[int.Parse(tabs.TabPages[i].Tag.ToString()) - 1] as System.Windows.Forms.RadioButton).Checked = true;
								}
							}
						}
						canWritePass = false;
					}
					break;
				case 3:
					easter = !easter;
					textBox2.Text = "";
					break;
				case 4:
					textBox2.Text = textBox2.Tag.ToString();
					break;
			}
		}
		public static string EncodeDecrypt(string str, int secretKey, ref int k, bool decode) // Использовать EncodeDecrypt("Cтрока", (ключ) 0x12345...,переменная для сохранения целостности)
		{
			string newStr = "";
			foreach (var c in str)
			{
				newStr += TopSecret(c, secretKey);
				int value;
				if (decode)
				{

					value = (int)newStr.Last();
				}
				else
				{
					value = (int)c;
				}
				while (value != 0)
				{
					if ((value & 1) == 1)
					{
						k++;
						if (k == int.MaxValue)
							k = 0;
					}
					value >>= 1;
				}
			}
			return newStr;

		}
		public static string EncodeDecrypt(string str, int secretKey) // Использовать EncodeDecrypt("Cтрока", (ключ) 0x12345...,переменная для сохранения целостности)
		{
			string newStr = "";
			foreach (var c in str)
				newStr += TopSecret(c, secretKey);
			return newStr;
		}
		public static char TopSecret(char character, int secretKey)
		{
			character = (char)(character ^ secretKey);
			return character;
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			MaximizeBox = false;
			label3.BringToFront();
			label4.BringToFront();
			label5.BringToFront();
			button2.BringToFront();
			tabs.Dock = DockStyle.Fill;
			button1.Width = 200;
			button1.Height = 100;
			button1.Left = (Width - button1.Width) / 2;
			button1.Top = (Height - button1.Height) / 2;
			button2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			button2.Width = 200;
			button2.Height = 100;
			button2.Left = (Width - button2.Width) / 2;
			button2.Top = (Height - button2.Height) / 2;
			button2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			tabs.BringToFront();
			tabs.Visible = false;
			string line;
			FileInfo filepath = new FileInfo(path);
			if (!filepath.Exists)
			{
				MessageBox.Show("Файл \"" + path + "\" не найден!", "Ошибка загрузки", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Close();
				return;
			}
			StreamReader fin = new StreamReader(path);
			int ones = 0;
			line = EncodeDecrypt(fin.ReadLine(), 0x123456,ref ones,true);
			string[] questm = line.Split(new[] { '.' }, StringSplitOptions.None);
			textBox2.Tag = "";
			textBox2.Tag = questm[questm.Length - 1];
			if (string.IsNullOrWhiteSpace(textBox2.Tag.ToString()))
			{
				label2.Enabled = false;
				textBox2.BackColor = SystemColors.Menu;
				textBox2.BorderStyle = BorderStyle.FixedSingle;
			}
			else
				button1.Enabled = false;
			procents = questm[0] == "1";
			ViewAnswers = questm[1] == "1";
			fromEveryTheme = questm[2] == "1";
			obligateQuestions = questm[3] == "1";
			//lastChanged = lastChanged.Substring(0, lastChanged.Length - 2);
			/////////////////////////////
			//delete it for time check
			//lastChanged = lastChanged.Substring(0, lastChanged.Length - 4);
			//questm[4] = questm[4].Substring(0, questm[4].Length - 4);
			//////////////////////////
			/*if (questm[4] != lastChanged)
			{
				MessageBox.Show("Похоже, кто-то имзменял файл вопросов. Попросите преподавателя пересоздать его или взять с другого компьютера.", "Программа предполагает обман", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				Close();
				return;
			}*/
			generateCount = int.Parse(questm[5]);
			n = int.Parse(questm[6]);
			List<int> numbers = new List<int>();
			if (fromEveryTheme)
			{
				if (obligateQuestions)
				{
					int k = int.Parse(questm[7]), a;
					for (int i = 0; i < k; i++)
					{
						numbers.Add(i);
					}
					for (int i = 8; i < questm.Length - 2; i++)
					{
						a = int.Parse(questm[i]);
						GenerateRandomNumbers(generateCount, k, k + a, ref numbers);
						k += a;
					}
				}
				else
				{
					int k = 0, a;
					for (int i = 7; i < questm.Length - 2; i++)
					{
						a = int.Parse(questm[i]);
						GenerateRandomNumbers(generateCount, k, k + a, ref numbers);
						k += a;
					}
				}
			}
			else
			{
				if (obligateQuestions)
				{
					int k = int.Parse(questm[7]);
					for (int i = 0; i < k; i++)
					{
						numbers.Add(i);
					}
					GenerateRandomNumbers(generateCount, k, n, ref numbers);
				}
				else
					GenerateRandomNumbers(generateCount, 0, n, ref numbers);
			}
			int key = int.Parse(questm[questm.Length - 2]);
			Text = EncodeDecrypt(fin.ReadLine(), key,ref ones,true);
			TabPage tabPages;
			SplitContainer splitter;
			Label labelLocal;
			CheckedListBox answers;
			RichTextBox quest;
			System.Windows.Forms.RadioButton radioButton;
			int questnumb = -1;
			for (int i = 0; i < n; i++)
			{
				line = EncodeDecrypt(fin.ReadLine(), key,ref ones,true);
				if (!numbers.Contains(i))
					continue;
				++questnumb;
				line = line.Remove(0, 1);
				line = line.Remove(line.Length - 2, 2);
				questm = line.Split(new[] { "\";\"" }, StringSplitOptions.None);
				tabPages = new TabPage
				{
					Text = "Вопрос " + (questnumb + 1),
					BackColor = Color.White,
					AutoScroll = true,
				};
				tabPages.Enter += new System.EventHandler(this.Anytab_select);
				tabs.TabPages.Add(tabPages);
				splitter = new SplitContainer();
				tabPages.Controls.Add(splitter);
				splitter.Parent = this;
				splitter.Name = "splitter" + questnumb;
				splitter.Visible = true;
				splitter.Enabled = true;
				splitter.Dock = DockStyle.Fill;
				splitter.Orientation = Orientation.Horizontal;
				splitter.Parent = tabPages;
				splitter.SplitterDistance = 236;
				labelLocal = new Label
				{
					Name = "Label" + questnumb,
					Text = questm[1],
					Dock = DockStyle.Top,
					Height = 40,
					TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
					Visible = true
				};
				tabPages.Controls.Add(labelLocal);
				quest = new RichTextBox();
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
				if (questm[9].Length > 1)
				{
					answers = new CheckedListBox();
					splitter.Panel2.Controls.Add(answers);
					answers.BorderStyle = BorderStyle.None;
					answers.CheckOnClick = true;
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
					for (int j = 0; j < 6; j++)
					{
						if (questm[3 + j] != "")
						{
							radioButton = new System.Windows.Forms.RadioButton
							{
								AutoSize = true,
								Location = new System.Drawing.Point(10, 23 * j),
								Name = "radioButton" + questnumb,
								Size = new System.Drawing.Size(85, 17),
								TabStop = true,
								Text = questm[3 + j],
								UseVisualStyleBackColor = true
							};
							splitter.Panel2.Controls.Add(radioButton);
						}
						else
							j = 6;
					}
				}
				tabPages.Tag = questm[9].ToString();
			}
			line = EncodeDecrypt(fin.ReadLine(), key);
			if (ones != int.Parse(line) || !filepath.IsReadOnly)
				MessageBox.Show("Похоже, кто-то имзменял файл вопросов. Получите изначальную версию файла у преподавателя или возьмите с другого компьютераы.", "Программа предполагает обман", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			tabs.TabPages.Remove(tabPage1);
			tabs.TabPages.Add(tabPage1);
			fin.Close();
		}
		private void Button2_Click(object sender, EventArgs e)
		{
			double rightCount = 0;
			label3.Visible = true;
			label4.Visible = true;
			label5.Visible = true;
			label3.Text = "Имя: " + textBox1.Text;
			label4.Text = "Тест: " + Text;
			button2.Visible = false;
			for (int i = 0; i < tabs.TabPages.Count - 1; i++)
			{
				(tabs.TabPages[i].Controls[0] as SplitContainer).Enabled = false;
				if ((tabs.TabPages[i].Controls[0] as SplitContainer).Panel2.Controls[0] is CheckedListBox)
				{
					CheckedListBox c = (tabs.TabPages[i].Controls[0] as SplitContainer).Panel2.Controls[0] as CheckedListBox;
					string answer = tabs.TabPages[i].Tag.ToString();
					double k = 0;
					for (int j = 0; j < answer.Length; j++)
						if (c.CheckedItems.Contains(c.Items[answer[j] - '0' - 1]))
							k += 1;
					if (c.CheckedItems.Count > k)
					{
						if (k == answer.Length)
							tabs.TabPages[i].Controls[1].Text += "\n*Вы дали правильный ответ, но баллы были снижены за лишние выбранные пункты!";
						k -= c.CheckedItems.Count - k;
						if (k < 0) k = 0;
					}
					if (k == answer.Length)
					{
						if (ViewAnswers)
						{
							tabs.TabPages[i].Controls[1].BackColor = Color.Green;
							tabs.TabPages[i].Controls[1].ForeColor = Color.White;
						}
					}
					else
					{
						if (k == 0)
						{
							if (ViewAnswers)
							{
								tabs.TabPages[i].Controls[1].BackColor = Color.DarkRed;
								tabs.TabPages[i].Controls[1].ForeColor = Color.White;
							}
						}
						else
						{
							if (ViewAnswers)
							{
								tabs.TabPages[i].Controls[1].BackColor = Color.Yellow;
								tabs.TabPages[i].Controls[1].ForeColor = Color.Black;
							}
						}
					}
					rightCount += k / answer.Length;
				}
				else
				{
					if ((tabs.TabPages[i].Controls[0] as SplitContainer).Panel2.Controls[0] is System.Windows.Forms.RadioButton)
					{
						int answer = int.Parse(tabs.TabPages[i].Tag.ToString());
						if (((tabs.TabPages[i].Controls[0] as SplitContainer).Panel2.Controls[answer - 1] as System.Windows.Forms.RadioButton).Checked == true)
						{
							rightCount += 1;
							if (ViewAnswers)
							{
								tabs.TabPages[i].Controls[1].BackColor = Color.Green;
								tabs.TabPages[i].Controls[1].ForeColor = Color.White;
							}
						}
						else
						{
							if (ViewAnswers)
							{
								tabs.TabPages[i].Controls[1].BackColor = Color.DarkRed;
								tabs.TabPages[i].Controls[1].ForeColor = Color.White;
							}
						}
					}
				}
			}
			if (easter && (int)((rightCount / (tabs.TabPages.Count - 1)) * 100) >= 90)
			{
				pictureBox1.Visible = true;
			}
			if (procents)
			{
				int result = (int)((rightCount / (tabs.TabPages.Count - 1)) * 100);
				if (result == 60 || result == 75 || result == 90) { result++; }
				label5.Text = result.ToString() + "/100";
			}
			else
			{
				label5.Text = rightCount + " / " + (tabs.TabPages.Count - 1);
			}
		}
	}
}
