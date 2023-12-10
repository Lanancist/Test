using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordGen
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			label4.Text = "91-100%: ";
			label5.Text = "76-93%: ";
			label6.Text = "76-90%: ";
			label7.Text = "Пасхалка: Easter egg";
			label8.Text = "Вход без пароля: ";
			textBox2.Text = (DateTime.Now).ToString().Replace(".", "").Replace(" ", "").Replace(":", "").Substring(0, 8);
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			label4.Text = "91-100%: " + GenCheatPasswordByType(textBox1.Text, 0);
			label5.Text = "76-93%: " + GenCheatPasswordByType(textBox1.Text, 1);
			label6.Text = "76-90%: " + GenCheatPasswordByType(textBox1.Text, 2);
			label7.Text = "Пасхалка: Easter egg";
			label8.Text = "Вход без пароля: " + GenCheatPasswordByType(textBox1.Text, 4);
		}
		public string GenCheatPasswordMain(string FIO)
		{
			if (FIO.Length > 50 || FIO.Length == 0)
				return "";
			System.Int32 key1 = 0;
			for (int i = 0; i < FIO.Length; i++)
				key1 += FIO[i] * (2 * (i % 2) - 1);
			key1 *= FIO.Length;
			string s = textBox2.Text;
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
		private void TextBox3_TextChanged(object sender, EventArgs e)
		{
			textBox4.Text = "";
			foreach (var c in textBox3.Text)
				textBox4.Text += (char)(c ^ int.Parse(textBox5.Text));
		}

		private void TextBox5_TextChanged(object sender, EventArgs e)
		{
			if (textBox5.Text == "")
				textBox5.Text = "1193046";
			else
				TextBox3_TextChanged(sender,e);
		}

		private void tabPage2_Enter(object sender, EventArgs e)
		{
			textBox5.Text = "1193046";
		}
	}
}
