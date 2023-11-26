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
namespace User_Module
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		TabPage[] tabPages;
		int n,generateCount;
		bool password,isNamed,fromEveryTheme;

		private void button1_Click(object sender, EventArgs e)
		{
			tabs.Visible = true;
		}

		private void Form1_ResizeEnd(object sender, EventArgs e)
		{
			button1.Top = (this.Height - 100) / 2;
			button1.Left = (this.Width - 200) / 2;
			button1.Width = 200;
			button1.Height = 100;
			tabPages[n].Controls[0].Top = (this.Height - 100) / 2;
			tabPages[n].Controls[0].Left = (this.Width - 200) / 2;
			tabPages[n].Controls[0].Width = 200;
			tabPages[n].Controls[0].Height = 100;
			for (int i = 0; i < n; i++)
			{
				
			}
		}
		string path = "input.txt";
		private void Form1_Load(object sender, EventArgs e)
		{
			tabs.BringToFront();
			tabs.Visible = false;
			tabs.Dock = DockStyle.Fill;
			string line;
			FileInfo filepath = new FileInfo(path);
			if (!filepath.Exists )
			{
				MessageBox.Show("Файл с вопросами не найден!", "Ошибка загрузки", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Close();
				return;
			}
			StreamReader fin = new StreamReader(path);
			string lastChanged = File.GetLastWriteTime(path).ToString();
			lastChanged=lastChanged.Replace(".", "").Replace(" ","").Replace(":","");
			line = fin.ReadLine();
			password = line[0] == '1';
			isNamed = line[1] == '1';
			fromEveryTheme = line[2] == '1';
			string s = line.Substring(3, 14);
			/*
			 * if (lastChanged.Length<14) lastChanged.Insert(9, "0");
			 */
			/////////////////////////////
			///delete it for time check
			lastChanged = lastChanged.Substring(0, lastChanged.Length - 6);
			s = s.Substring(0, s.Length - 6);
			//////////////////////////
			if (s != lastChanged)
			{
				MessageBox.Show("Похоже, кто-то имзенял файл вопросов после того, как он был загружен преподавателем!", "Замечен обман", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				Close();
				return;
			}
			n=line.IndexOf('.');
			s = line.Substring(16,n-16);
			generateCount = int.Parse(s);
			s = line.Substring(n+1);
			n = int.Parse(s);
			Text = fin.ReadLine();
			label1.Text = Text;
			tabPages = new TabPage[n + 1];
			line=fin.ReadLine();
			line=line.Remove(0,1);
			string[] questm = line.Split(new[] { "\";\"" }, StringSplitOptions.None);
			for (int i = 0; i < n; i++)
			{
				tabPages[i] = new TabPage();
				tabPages[i].Text = "Вопрос " + (i + 1);
				tabPages[i].BackColor = Color.White;
				tabPages[i].AutoScroll = true;
				tabs.Controls.Add(tabPages[i]);
				SplitContainer splitter = new SplitContainer();
				tabPages[i].Controls.Add(splitter);
				splitter.Parent = this;
				splitter.Name = "splitter" + i;
				splitter.Visible = true;
				splitter.Enabled = true;
				splitter.Dock = DockStyle.Fill;
				splitter.Orientation = Orientation.Horizontal;
				CheckedListBox answers = new CheckedListBox();
				splitter.Panel2.Controls.Add(answers);
				splitter.Parent = tabPages[i];
				answers.Name = "Check" + i;
				answers.Visible = true;
				answers.Dock = DockStyle.Bottom;
				answers.Top = 30;
				splitter.SplitterDistance = 236;
				answers.BeginUpdate();
				for (int j = 0; j < 6; j++)
					answers.Items.Add("Вариант" + (j + 1), (j + 1) % 2 == 1);
				answers.EndUpdate();
				TextBox quest = new TextBox();
				splitter.Panel1.Controls.Add(quest);
				splitter.Name = "Text" + i;
				splitter.Text = "Text" + i;
				quest.Dock = DockStyle.Fill;
				quest.Multiline = true;
				quest.ReadOnly = true;
				quest.ScrollBars = ScrollBars.Vertical;
				quest.ShortcutsEnabled = false;
				quest.TabIndex = 0;
			}
			tabPages[n] = new TabPage();
			tabPages[n].BackColor = Color.White;
			tabPages[n].Text = "Окончить тест";
			tabPages[n].AutoScroll = true;
			tabs.Controls.Add(tabPages[n]);
			Button btn = new Button();
			tabPages[n].Controls.Add(btn);
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

