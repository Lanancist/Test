using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Admin
{
	public partial class MainPage : ContentPage
	{
		Button btnpass;
		Entry FIO, Date;
		Label label1, label2, label3, label4, label5, label6, label7;
		public MainPage()
		{
			InitializeComponent();
		}
		protected override void OnAppearing()
		{
			StackLayout stack = new StackLayout();
			Content = stack;
			FIO = new Entry();
			Date = new Entry();
			btnpass = new Button();
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			label5 = new Label();
			label6 = new Label();
			label7 = new Label();
			stack.Children.Add(FIO);
			stack.Children.Add(Date);
			stack.Children.Add(btnpass);
			stack.Children.Add(label1);
			stack.Children.Add(label2);
			stack.Children.Add(label3);
			stack.Children.Add(label4);
			stack.Children.Add(label5);
			stack.Children.Add(label6);
			stack.Children.Add(label7);
			FIO.Placeholder = "123";
			FIO.FontSize = 14;
			Date.Placeholder = "15122013";
			Date.FontSize = 14;
			btnpass.Text = "Рассчитать";
			btnpass.Clicked += btnclick;
			label1.Text = "91-100%: ";
			label2.Text = "76-93%: ";
			label3.Text = "76-90%: ";
			label4.Text = "Пасхалка: Easter egg";
			label5.Text = "Вход без пароля: ";
			label6.Text = "61-89%: ";
			label7.Text = "61-75%: ";
			FIO.TextChanged += TextChanged;
			Date.Text = (DateTime.Now).ToString().Replace(".", "").Replace(" ", "").Replace(":", "").Substring(0, 8);
		}

		private void TextChanged(object sender, TextChangedEventArgs e)
		{
			Date.Text = (DateTime.Now).ToString().Replace(".", "").Replace(" ", "").Replace(":", "").Substring(0, 8);
		}

		public string GenCheatPasswordMain(string FIO)
		{
			if (FIO==null||FIO == ""||FIO.Length > 50)
				return "";
			System.Int32 key1 = 0;
			for (int i = 0; i < FIO.Length; i++)
				key1 += FIO[i];
			key1 *= FIO.Length * (int)FIO[0];
			if (Date.Text.Length != 8)
				return "";
			char[] d = Date.Text.ToArray();
			for (int i = 0; i < d.Length; i++)
				d[i] = (char)('0' + ((d[i] - '0') + 3) % 10);
			if (d[0] == '0') d[0] = '1';
			int key2 = int.Parse(string.Concat(d));
			key1 += key2;
			return key1.ToString();
		}
		public string GenCheatPasswordByType(string FIO, int passType)
		{
			if (FIO == "") return "";
			if (passType == 3) return "Easter egg";
			string s = GenCheatPasswordMain(FIO);
			if (s.Length == 0)
				return "";
			switch (passType)
			{
				//на 91-100
				case 0: return s.Substring(0, 4) + "05" + s.Substring(4);
				//на 76-93
				case 1: return s.Substring(0, 4) + "45" + s.Substring(4);
				//на 76-90
				case 2: return s.Substring(0, 4) + "35" + s.Substring(4);
				//войти без пароля
				case 4: return "0" + string.Concat(s.Substring(0, 4).Reverse()) + string.Concat(s.Substring(4).Reverse()) + "0";
				//на 61-89
				case 5: return s.Substring(0, 4) + "72" + s.Substring(4);
				//на 61-75
				case 6: return s.Substring(0, 4) + "84" + s.Substring(4);
				default: return "";
			}
		}
		private void btnclick(object sender, EventArgs e)
		{
			label1.Text = "91-100%: " + GenCheatPasswordByType(FIO.Text, 0);
			label2.Text = "76-93%: " + GenCheatPasswordByType(FIO.Text, 1);
			label3.Text = "76-90%: " + GenCheatPasswordByType(FIO.Text, 2);
			label4.Text = "Пасхалка: Easter egg";
			label5.Text = "Вход без пароля: " + GenCheatPasswordByType(FIO.Text, 4);
			label6.Text = "61-89%: " + GenCheatPasswordByType(FIO.Text, 5);
			label7.Text = "61-75%: " + GenCheatPasswordByType(FIO.Text, 6);
		}
	}
}
