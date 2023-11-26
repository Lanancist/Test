using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
		int n = 5;
		private void Form1_Load(object sender, EventArgs e)
		{
			tabs.BringToFront();
			tabs.Dock = DockStyle.Fill;
			tabPages = new TabPage[n + 1];
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
				answers.Dock = DockStyle.Fill;
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

