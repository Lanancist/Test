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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
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
			MaximizeBox = true;
			WindowState = FormWindowState.Maximized;
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


		private void tabs_KeyDown(object sender, KeyEventArgs e)
		{
			if (tabs.Visible == true && e.KeyCode == Keys.Enter && tabs.SelectedIndex + 1 < tabs.TabPages.Count)
			{
				tabs.SelectedIndex++;
			}
		}

		private void anytab_select(object sender, EventArgs e)
		{
			MaximizeBox = true;
		}

		private void tabPage1_Enter(object sender, EventArgs e)
		{
			MaximizeBox = false;
			WindowState = FormWindowState.Normal;
		}

		string path = "test.data";

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{

		}

		public static string EncodeDecrypt(string str, int secretKey)
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
			button1.Width = 200;
			button1.Height = 100;
			button1.Left = (Width - button1.Width) / 2;
			button1.Top = (Height - button1.Height) / 2;
			button2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			button2.Width = 200;
			button2.Height = 100;
			button2.Left = (Width - button1.Width) / 2;
			button2.Top = (Height - button1.Height) / 2;
			button2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			tabs.Dock = DockStyle.Fill;
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
			string lastChanged = File.GetLastWriteTime(path).ToString();
			lastChanged = lastChanged.Replace(".", "").Replace(" ", "").Replace(":", "");
			line = EncodeDecrypt(fin.ReadLine(), 0x123456);
			string[] questm = line.Split(new[] { '.' }, StringSplitOptions.None); ;
			password = questm[0] == "1";
			isNamed = questm[1] == "1";
			fromEveryTheme = questm[2] == "1";
			obligateQuestions = questm[3] == "1";
			lastChanged = lastChanged.Substring(0, lastChanged.Length - 2);
			/////////////////////////////
			///delete it for time check
			//lastChanged = lastChanged.Substring(0, lastChanged.Length - 4);
			//questm[4] = questm[4].Substring(0, questm[4].Length - 4);
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
					for (int i = 0; i <= k; i++)
					{
						numbers.Add(i);
					}
					for (int i = 8; i < questm.Length - 1; i++)
					{
						a = int.Parse(questm[i]);
						GenerateRandomNumbers(generateCount, k + 1, k + a, ref numbers);
						k += a;
					}

				}
				else
				{
					int k = 0, a;
					for (int i = 7; i < questm.Length - 1; i++)
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
					for (int i = 0; i < a; i++)
					{
						numbers.Add(i);
					}
					GenerateRandomNumbers(generateCount, a + 1, n, ref numbers);
				}
				else
					GenerateRandomNumbers(generateCount, 0, n, ref numbers);
			}
			n = int.Parse(questm[6]);
			int key = int.Parse(questm[questm.Length - 1]);
			Text = EncodeDecrypt(fin.ReadLine(), key);
			TabPage tabPages;
			SplitContainer splitter;
			Label labelLocal;
			CheckedListBox answers;
			RichTextBox quest;
			System.Windows.Forms.RadioButton radioButton;
			int questnumb = -1;
			for (int i = 0; i < n; i++)
			{
				line = EncodeDecrypt(fin.ReadLine(), key);
				if (!numbers.Contains(i))
					continue;
				++questnumb;
				line = line.Remove(0, 1);
				line = line.Remove(line.Length - 2, 2);
				questm = line.Split(new[] { "\";\"" }, StringSplitOptions.None);
				tabPages = new TabPage();
				tabPages.Text = "Вопрос " + (questnumb + 1);
				tabPages.BackColor = Color.White;
				tabPages.AutoScroll = true;
				tabPages.Enter += new System.EventHandler(this.anytab_select);
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
				labelLocal = new Label();
				labelLocal.Name = "Label" + questnumb;
				labelLocal.Text = questm[1];
				labelLocal.Dock = DockStyle.Top;
				labelLocal.Height = 40;
				labelLocal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
				labelLocal.Visible = true;
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
							radioButton = new System.Windows.Forms.RadioButton();
							radioButton.AutoSize = true;
							radioButton.Location = new System.Drawing.Point(10, 23 * j);
							radioButton.Name = "radioButton" + questnumb;
							radioButton.Size = new System.Drawing.Size(85, 17);
							radioButton.TabStop = true;
							radioButton.Text = questm[3 + j];
							radioButton.UseVisualStyleBackColor = true;
							splitter.Panel2.Controls.Add(radioButton);
						}
						else
							j = 6;
					}
				}
				tabPages.Tag = questm[9].ToString();
			}

			tabs.TabPages.Remove(tabPage1);
			tabs.TabPages.Add(tabPage1);
			fin.Close();
		}
		private void button2_Click(object sender, EventArgs e)
		{
			float rightCount = 0;
			label3.Visible = true;
			label4.Visible = true;
			label5.Visible = true;
			label3.Text = "Имя: "+ textBox1.Text;
			label4.Text = "Тест: " + Text;
			tabs.Enabled = false;
			button2.Visible = false;
			for (int i = 0; i < tabs.TabPages.Count - 1; i++)
			{
				if ((tabs.TabPages[i].Controls[0] as SplitContainer).Panel2.Controls[0] is CheckedListBox)
				{
					CheckedListBox c = (tabs.TabPages[i].Controls[0] as SplitContainer).Panel2.Controls[0] as CheckedListBox;
					string answer = tabs.TabPages[i].Tag.ToString();
					for (int j = 0; j < answer.Length; j++)
					{
						if (c.CheckedItems.Contains(answer[j]))
						{
							rightCount++;
						}
					}
				}
				else
				{
					if ((tabs.TabPages[i].Controls[0] as SplitContainer).Panel2.Controls[0] is System.Windows.Forms.RadioButton)
					{
						int answer = int.Parse(tabs.TabPages[i].Tag.ToString());
						if (((tabs.TabPages[i].Controls[0] as SplitContainer).Panel2.Controls[answer - 1] as System.Windows.Forms.RadioButton).Checked == true)
						{
							rightCount++;
						}
					}

				}
			}

			int result = (int)((float)(rightCount / tabs.TabPages.Count)) * 100;
			if (result == 60|| result == 75|| result == 90) { result++; }
			label5.Text= result.ToString()+"/100";
		}
	}

}
