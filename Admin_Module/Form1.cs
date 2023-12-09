using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ExcelDataReader;
//using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Web;
using System.Windows.Forms.VisualStyles;
using Microsoft.Office.Interop.Excel;
namespace Admin_Module
{
	public partial class Form1 : Form
	{
		private string filename = string.Empty;
		private DataTableCollection tableCollection = null;
		public Form1()
		{
			InitializeComponent();
		}
		public static string EncodeDecrypt(string str, int secretKey) // Использовать EncodeDecrypt("Cтрока", (ключ) 0x12345...)
		{
			string newStr = "";
			foreach (var c in str)
				newStr += TopSecret(c, secretKey);
			return newStr;
		}
		public static char TopSecret(char character, int secretKey)
		{
			character = (char)(character ^ secretKey); //Производим XOR операцию символа с ключем
			return character;
		}
		private void OpenExcelFile(string path)
		{
			DataSet db;
			using (FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read))
			{
				IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
				db = reader.AsDataSet(new ExcelDataSetConfiguration()
				{
					ConfigureDataTable = (x) => new ExcelDataTableConfiguration()
					{
						UseHeaderRow = false
					}
				});
			}
			//FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read);
			tableCollection = db.Tables;
			System.Data.DataTable table = tableCollection[Convert.ToString(tableCollection[0].TableName)];
			dataGridView1.DataSource = table;
			if (dataGridView1.ColumnCount != 10)
			{
				throw new Exception("Загружаемая таблица имеет неверный формат!"); ;
			}
			dataGridView1.Rows.RemoveAt(0);
			dataGridView1.Columns[0].HeaderText = "Номер темы";
			dataGridView1.Columns[0].ValueType = typeof(string);
			dataGridView1.Columns[1].HeaderText = "Название темы";
			dataGridView1.Columns[1].ValueType = typeof(string);
			dataGridView1.Columns[2].HeaderText = "Вопрос";
			dataGridView1.Columns[2].ValueType = typeof(string);
			dataGridView1.Columns[3].HeaderText = "Вариант 1";
			dataGridView1.Columns[3].ValueType = typeof(string);
			dataGridView1.Columns[4].HeaderText = "Вариант 2";
			dataGridView1.Columns[4].ValueType = typeof(string);
			dataGridView1.Columns[5].HeaderText = "Вариант 3";
			dataGridView1.Columns[5].ValueType = typeof(string);
			dataGridView1.Columns[6].HeaderText = "Вариант 4";
			dataGridView1.Columns[6].ValueType = typeof(string);
			dataGridView1.Columns[7].HeaderText = "Вариант 5";
			dataGridView1.Columns[7].ValueType = typeof(string);
			dataGridView1.Columns[8].HeaderText = "Вариант 6";
			dataGridView1.Columns[8].ValueType = typeof(string);
			dataGridView1.Columns[9].HeaderText = "Ответ";
			dataGridView1.Columns[9].ValueType = typeof(string);
			btn_editor.Enabled = true;
			button1.Enabled = true;
			textBox1.Enabled = true;
			groupBox1.Enabled = true;
			groupBox2.Enabled = true;
			label2.Enabled = true;
			textBox1.ReadOnly = false;
			label2.Text = "Всего вопросов: " + dataGridView1.RowCount;
			numericUpDown1.Minimum = 0;
			numericUpDown1.Maximum = dataGridView1.RowCount;
			numericUpDown2.Maximum = dataGridView1.RowCount;
			dataGridView1.Sort(this.dataGridView1.Columns[0], ListSortDirection.Ascending);
			CheckTable();
			Microsoft.Office.Interop.Excel.Application xlApp;
			try
			{
				xlApp = new Microsoft.Office.Interop.Excel.Application();
				xlApp.Quit();
				Marshal.ReleaseComObject(xlApp);
				GC.Collect();
				GC.WaitForPendingFinalizers();
				btn_newquestion.Enabled = true;
				button2.Enabled = true;
				dataGridView1.ReadOnly = false;
			}
			catch (Exception)
			{
				button2.Enabled = false;
				dataGridView1.ReadOnly = true;
				btn_newquestion.Enabled = false;
				MessageBox.Show("Найти excel не удалось. Вы все еще можете создать файл вопросов для теста, но редактировать таблицу в данной программе у Вас не получится.", "Невозможно сохранить таблицу", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
		private void OpenTestFile(string filename)
		{
			string line;
			string[] questm;
			using (StreamReader reader = new StreamReader(filename))
			{
				line = EncodeDecrypt(reader.ReadLine(), 0x123456);
				questm = line.Split(new[] { '.' }, StringSplitOptions.None);
				textBox1.Text = EncodeDecrypt(reader.ReadLine(), int.Parse(questm[questm.Length - 2]));
			}
			label2.Text = "Всего вопросов: " + int.Parse(questm[6]);
			label2.Enabled = true;
			numericUpDown1.Maximum = int.Parse(questm[5]);
			numericUpDown1.Minimum = int.Parse(questm[5]);
			textBox1.Enabled = true;
			groupBox1.Enabled = true;
			groupBox2.Enabled = true;
			label2.Enabled = false;
			textBox2.Text = questm[questm.Length - 1];
			if (questm[1] == "1")
				radioButton7.Checked = true;
			else
				radioButton8.Checked = true;
			if (questm[2] == "1")
				radioButton2.Checked = true;
			else
				radioButton1.Checked = true;
		}
		bool CheckTable()
		{
			string s = "";
			int b;
			for (int i = 0; i < dataGridView1.RowCount; i++)
			{
				dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
				dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
				if (string.IsNullOrWhiteSpace(dataGridView1[0, i].Value.ToString()))
				{
					s += "Вопрос " + (i + 1) + ": Не прописан номер темы!\n";
					dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkRed;
					dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
				}
				else
				{
					try
					{
						b = int.Parse(dataGridView1[0, i].Value.ToString());
						if (b < 0)
						{
							s += "Вопрос " + (i + 1) + ": Не корректно введен номер темы\n";
							dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkRed;
							dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
						}
					}
					catch (Exception)
					{
						s += "Вопрос " + (i + 1) + ": Не корректно введен номер темы\n";
						dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkRed;
						dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
					}
				}
				if (string.IsNullOrWhiteSpace(dataGridView1[1, i].Value.ToString()))
				{
					s += "Вопрос " + (i + 1) + ": Не прописано название темы!\n";
					dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkRed;
					dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
				}
				if (string.IsNullOrWhiteSpace(dataGridView1[2, i].Value.ToString()))
				{
					s += "Вопрос " + (i + 1) + ": Не прописан текст вопроса!\n";
					dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkRed;
					dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
				}
				if (string.IsNullOrWhiteSpace(dataGridView1[3, i].Value.ToString()))
				{
					dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkRed;
					dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
					s += "Вопрос " + (i + 1) + ": Пропущен вариант ответа 1!\n";
				}
				if (string.IsNullOrWhiteSpace(dataGridView1[9, i].Value.ToString()))
				{
					s += "Вопрос " + (i + 1) + ": Не прописан правильный ответ!\n";
					dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkRed;
					dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
				}
				else
				{
					string answer = dataGridView1[9, i].Value.ToString();
					b = 0;
					foreach (var c in answer)
						if (c < '1' || c > '6')
							b = 1;
					if (b == 1)
					{
						s += "Вопрос " + (i + 1) + ": В ответе содержится некоректный символ\n";
						dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkRed;
						dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
					}
					if ((!string.IsNullOrWhiteSpace(dataGridView1[5, i].Value.ToString()) || answer.Contains("2")) && string.IsNullOrWhiteSpace(dataGridView1[4, i].Value.ToString()))
					{
						s += "Вопрос " + (i + 1) + ": Пропущен вариант ответа 2!\n";
						dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkRed;
						dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
					}
					if ((!string.IsNullOrWhiteSpace(dataGridView1[6, i].Value.ToString()) || answer.Contains("3")) && string.IsNullOrWhiteSpace(dataGridView1[5, i].Value.ToString()))
					{
						dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkRed;
						dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
						s += "Вопрос " + (i + 1) + ": Пропущен вариант ответа 3!\n";
					}
					if ((!string.IsNullOrWhiteSpace(dataGridView1[7, i].Value.ToString()) || answer.Contains("4")) && string.IsNullOrWhiteSpace(dataGridView1[6, i].Value.ToString()))
					{
						dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkRed;
						dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
						s += "Вопрос " + (i + 1) + ": Пропущен вариант ответа 4!\n";
					}
					if ((!string.IsNullOrWhiteSpace(dataGridView1[8, i].Value.ToString()) || answer.Contains("5")) && string.IsNullOrWhiteSpace(dataGridView1[7, i].Value.ToString()))
					{
						s += "Вопрос " + (i + 1) + ": Пропущен вариант ответа 5!\n";
						dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkRed;
						dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
					}
					if (answer.Contains("6") && string.IsNullOrWhiteSpace(dataGridView1[8, i].Value.ToString()))
					{
						s += "Вопрос " + (i + 1) + ": Пропущен вариант ответа 6!\n";
						dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DarkRed;
						dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
					}
				}
			}
			if (s != "")
			{
				MessageBox.Show(s, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return true;
			}
			return false;
		}
		private void ToolStripButton1_Click(object sender, EventArgs e)
		{
			if (btn_newquestion.Enabled)
			{
				if (!(MessageBox.Show("Если вы изменяли файл и не хотите потерять эти изменения, нажмите на кнопку \"" + button2.Text + "\" и следуйте инструкциям. Вы уверены, что хотите загрузить новый файл? ", "Загрузка файла", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
				{
					return;
				}
			}
			dataGridView1.Visible = false;
			WindowState = FormWindowState.Normal;
			btn_editor.Enabled = false;
			btn_newquestion.Enabled = false;
			button1.Enabled = false;
			button2.Enabled = false;
			textBox1.Enabled = false;
			textBox1.ReadOnly = true;
			groupBox1.Enabled = false;
			groupBox2.Enabled = false;
			label2.Enabled = false;
			label2.Text = "Всего вопросов:____";
			try
			{
				if (openFileDialog1.ShowDialog() == DialogResult.OK)
				{
					filename = openFileDialog1.FileName;
					if (filename.EndsWith(".xls"))
						OpenExcelFile(filename);
					else
						OpenTestFile(filename);
					Text = "Программа тестирования. Мастер | " + filename;
				}
				else throw new Exception("Файл не был загружен");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка загрузки", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Text = "Программа тестирования. Мастер";
			}
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			label2.Enabled = false;
			panel1.Visible = false;
			panel1.Dock = DockStyle.Fill;
			dataGridView1.Visible = false;
			btn_editor.Enabled = false;
			btn_newquestion.Enabled = false;
			button1.Enabled = false;
			button2.Enabled = false;
			textBox1.Enabled = false;
			groupBox1.Enabled = false;
			groupBox2.Enabled = false;
		}
		public void ExportExcelInterop(string filename)
		{
			Cursor.Current = Cursors.WaitCursor;
			Microsoft.Office.Interop.Excel.Application xlApp;
			try
			{
				xlApp = new Microsoft.Office.Interop.Excel.Application();
			}
			catch (Exception)
			{
				throw new Exception("Не удается найти Excel!Установите его или редактируйте таблицу в другом редакторе.");
			}
			if (xlApp == null)
			{
				Marshal.ReleaseComObject(xlApp);
				GC.Collect();
				GC.WaitForPendingFinalizers();
				Cursor.Current = Cursors.Default;
				throw new Exception("Не удается найти Excel! Установите его или редактируйте таблицу в другом редакторе.");
			}
			Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
			Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
			try
			{
				object misValue = System.Reflection.Missing.Value;
				xlWorkBook = xlApp.Workbooks.Add(misValue);
				xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
				xlWorkSheet.Cells[1, 1] = "Номер темы";
				xlWorkSheet.Cells[1, 2] = "Название темы";
				xlWorkSheet.Cells[1, 3] = "Вопрос";
				xlWorkSheet.Cells[1, 4] = "Вариант 1";
				xlWorkSheet.Cells[1, 5] = "Вариант 2";
				xlWorkSheet.Cells[1, 6] = "Вариант 3";
				xlWorkSheet.Cells[1, 7] = "Вариант 4";
				xlWorkSheet.Cells[1, 8] = "Вариант 5";
				xlWorkSheet.Cells[1, 9] = "Вариант 6";
				xlWorkSheet.Cells[1, 10] = "Ответ";
				for (int i = 0; i < dataGridView1.RowCount; i++)
				{
					for (int j = 0; j < dataGridView1.ColumnCount; j++)
					{
						xlWorkSheet.Cells[i + 2, j + 1] = dataGridView1[j, i].Value.ToString();
					}
				}
				xlWorkSheet.Columns.AutoFit();
				xlWorkBook.SaveAs(filename, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue,
				misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
				xlWorkBook.Close(0);
				Marshal.ReleaseComObject(xlWorkSheet);
				Marshal.ReleaseComObject(xlWorkBook);
			}
			finally
			{
				xlApp.Quit();
				Marshal.ReleaseComObject(xlApp);
				GC.Collect();
				GC.WaitForPendingFinalizers();
				Cursor.Current = Cursors.Default;
			}
			MessageBox.Show("Файл таблицы создан по адресу \"" + filename + "\"", "Сохранение таблицы вопросов", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			this.BringToFront();
		}
		public int GenKey()
		{
			Random random = new Random();
			return random.Next(0, 16777216);
		}
		private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right && dataGridView1.ReadOnly == false)
			{
				if (MessageBox.Show("Вы действительно хотите удалить этот вопрос?", "Удаление вопроса", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
				{
					dataGridView1.Rows.RemoveAt(e.RowIndex);
					label2.Text = "Всего вопросов: " + dataGridView1.RowCount;
					MessageBox.Show("Вопрос удален", "Удаление вопроса", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}
		private void Btn_editor_Click(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Maximized;
			dataGridView1.Dock = DockStyle.Fill;
			dataGridView1.Visible = true;
			panel1.Visible = false;
			dataGridView1.BringToFront();
			CheckTable();
		}
		private void Btn_main_Click(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Normal;
			panel1.Visible = false;
			dataGridView1.Visible = false;
		}
		private void Btn_newquestion_Click(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Normal;
			panel1.BringToFront();
			NumericUpDown3_ValueChanged(sender, e);
			TextBox3_TextChanged(sender, e);
			TextBox4_TextChanged(sender, e);
			RadioButton6_CheckedChanged(sender, e);
			NumericUpDown2_ValueChanged(sender, e);
			panel1.Visible = true;
			dataGridView1.Visible = false;
		}
		private void RadioButton6_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton6.Checked == true)
			{
				numericUpDown2.Minimum = 1;
				label6.Visible = true;
				numericUpDown2.Visible = true;
			}
			else
			{
				label6.Visible = false;
				numericUpDown2.Visible = false;
				numericUpDown2.Minimum = 0;
				numericUpDown2.Value = 0;
			}
		}
		private void NumericUpDown3_ValueChanged(object sender, EventArgs e)
		{
			string s = numericUpDown3.Value.ToString();
			if ((textBox10.BackColor == Color.DarkRed || !string.IsNullOrWhiteSpace(textBox10.Text)) && string.IsNullOrWhiteSpace(textBox9.Text))
			{
				textBox9.BackColor = Color.DarkRed;
				textBox9.ForeColor = Color.White;
			}
			else
			{
				textBox9.BackColor = Color.White;
				textBox9.ForeColor = Color.Black;
			}
			if ((textBox9.BackColor == Color.DarkRed || !string.IsNullOrWhiteSpace(textBox9.Text)) && string.IsNullOrWhiteSpace(textBox8.Text))
			{
				textBox8.BackColor = Color.DarkRed;
				textBox8.ForeColor = Color.White;
			}
			else
			{
				textBox8.BackColor = Color.White;
				textBox8.ForeColor = Color.Black;
			}
			if ((textBox8.BackColor == Color.DarkRed || !string.IsNullOrWhiteSpace(textBox8.Text)) && string.IsNullOrWhiteSpace(textBox7.Text))
			{
				textBox7.BackColor = Color.DarkRed;
				textBox7.ForeColor = Color.White;
			}
			else
			{
				textBox7.BackColor = Color.White;
				textBox7.ForeColor = Color.Black;
			}
			if ((textBox7.BackColor == Color.DarkRed || !string.IsNullOrWhiteSpace(textBox7.Text)) && string.IsNullOrWhiteSpace(textBox6.Text))
			{
				textBox6.BackColor = Color.DarkRed;
				textBox6.ForeColor = Color.White;
			}
			else
			{
				textBox6.BackColor = Color.White;
				textBox6.ForeColor = Color.Black;
			}
			if (string.IsNullOrWhiteSpace(textBox5.Text))
			{
				textBox5.BackColor = Color.DarkRed;
				textBox5.ForeColor = Color.White;
			}
			else
			{
				textBox5.BackColor = Color.White;
				textBox5.ForeColor = Color.Black;
			}
			numericUpDown3.BackColor = Color.White;
			numericUpDown3.ForeColor = Color.Black;
			for (int i = 0; i < s.Length; i++)
			{
				switch (s[i])
				{
					case '1':
						if (!string.IsNullOrWhiteSpace(textBox5.Text))
						{
							textBox5.BackColor = Color.Green;
							textBox5.ForeColor = Color.White;
						}
						else
						{
							numericUpDown3.BackColor = Color.DarkRed;
							numericUpDown3.ForeColor = Color.White;
						}
						break;
					case '2':
						if (!string.IsNullOrWhiteSpace(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox5.Text))
						{
							textBox6.BackColor = Color.Green;
							textBox6.ForeColor = Color.White;
						}
						else
						{
							numericUpDown3.BackColor = Color.DarkRed;
							numericUpDown3.ForeColor = Color.White;
						}
						break;
					case '3':
						if (!string.IsNullOrWhiteSpace(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox5.Text))
						{
							textBox7.BackColor = Color.Green;
							textBox7.ForeColor = Color.White;
						}
						else
						{
							numericUpDown3.BackColor = Color.DarkRed;
							numericUpDown3.ForeColor = Color.White;
						}
						break;
					case '4':
						if (!string.IsNullOrWhiteSpace(textBox8.Text) && !string.IsNullOrWhiteSpace(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox5.Text))
						{
							textBox8.BackColor = Color.Green;
							textBox8.ForeColor = Color.White;
						}
						else
						{
							numericUpDown3.BackColor = Color.DarkRed;
							numericUpDown3.ForeColor = Color.White;
						}
						break;
					case '5':
						if (!string.IsNullOrWhiteSpace(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox8.Text) && !string.IsNullOrWhiteSpace(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox5.Text))
						{
							textBox9.BackColor = Color.Green;
							textBox9.ForeColor = Color.White;
						}
						else
						{
							numericUpDown3.BackColor = Color.DarkRed;
							numericUpDown3.ForeColor = Color.White;
						}
						break;
					case '6':
						if (!string.IsNullOrWhiteSpace(textBox10.Text) && !string.IsNullOrWhiteSpace(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox8.Text) && !string.IsNullOrWhiteSpace(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox6.Text) && !string.IsNullOrWhiteSpace(textBox5.Text))
						{
							textBox10.BackColor = Color.Green;
							textBox10.ForeColor = Color.White;
						}
						else
						{
							numericUpDown3.BackColor = Color.DarkRed;
							numericUpDown3.ForeColor = Color.White;
						}
						break;
					default:
						numericUpDown3.BackColor = Color.DarkRed;
						numericUpDown3.ForeColor = Color.White;
						break;
				}
			}
		}
		private void TextBox5_TextChanged(object sender, EventArgs e)
		{
			NumericUpDown3_ValueChanged(sender, e);
		}
		private void TextBox6_TextChanged(object sender, EventArgs e)
		{
			NumericUpDown3_ValueChanged(sender, e);
		}
		private void TextBox7_TextChanged(object sender, EventArgs e)
		{
			NumericUpDown3_ValueChanged(sender, e);
		}
		private void TextBox8_TextChanged(object sender, EventArgs e)
		{
			NumericUpDown3_ValueChanged(sender, e);
		}
		private void TextBox9_TextChanged(object sender, EventArgs e)
		{
			NumericUpDown3_ValueChanged(sender, e);
		}
		private void TextBox10_TextChanged(object sender, EventArgs e)
		{
			NumericUpDown3_ValueChanged(sender, e);
		}
		private void Button3_Click(object sender, EventArgs e)
		{
			if (numericUpDown3.BackColor == Color.DarkRed || textBox4.BackColor == Color.DarkRed || textBox3.BackColor == Color.DarkRed)
			{
				MessageBox.Show("Вы заполнили не все поля!", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				tableCollection[0].Rows.Add(numericUpDown2.Value.ToString(), textBox4.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, numericUpDown3.Value.ToString());
				MessageBox.Show("Вопрос добавлен", "Добавление вопроса", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
		private void TextBox3_TextChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(textBox3.Text))
			{
				textBox3.BackColor = Color.DarkRed;
				textBox3.ForeColor = Color.White;
			}
			else
			{
				textBox3.BackColor = Color.White;
				textBox3.ForeColor = Color.Black;
			}
		}
		private void TextBox4_TextChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(textBox4.Text))
			{
				textBox4.BackColor = Color.DarkRed;
				textBox4.ForeColor = Color.White;
			}
			else
			{
				textBox4.BackColor = Color.White;
				textBox4.ForeColor = Color.Black;
			}
		}
		private void NumericUpDown2_ValueChanged(object sender, EventArgs e)
		{
			dataGridView1.Sort(this.dataGridView1.Columns[0], ListSortDirection.Ascending);
			textBox12.Visible = false;
			int k = 0;
			for (int i = 0; i < dataGridView1.RowCount; i++)
			{
				dataGridView1.Rows[i].Selected = false;
				if (dataGridView1.Rows[i].Cells[0].Value != null)
					if (dataGridView1.Rows[i].Cells[0].Value.ToString() == numericUpDown2.Value.ToString())
					{
						dataGridView1.Rows[i].Selected = true;
						k++;
						if (k == 1)
						{
							textBox4.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
						}
						else
						{
							if (dataGridView1.Rows[i].Cells[1].Value.ToString() != textBox4.Text)
							{
								textBox12.Text = "Темы с введенным номером имеют разные названия! Это допустимо, но не желательно.";
								textBox12.Visible = true;
							}
						}
					}
			}
		}
		private void NumericUpDown3_KeyUp(object sender, KeyEventArgs e)
		{
			NumericUpDown3_ValueChanged(sender, e);
		}
		private void Button2_Click(object sender, EventArgs e)
		{
			try
			{
				saveFileDialog1.Filter = "Excel|*.xls";
				if (saveFileDialog1.ShowDialog() == DialogResult.OK)
				{
					string filename = saveFileDialog1.FileName;
					ExportExcelInterop(filename);
				}
				else throw new Exception("Файл не был сохранен!");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка сохранения таблицы", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void Button1_Click(object sender, EventArgs e)
		{
			if (CheckTable())
				return;
			try
			{
				folderBrowserDialog1.SelectedPath = System.Windows.Forms.Application.StartupPath;
				if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
				{
					string filename = folderBrowserDialog1.SelectedPath + "\\test.data";
					dataGridView1.Sort(this.dataGridView1.Columns[0], ListSortDirection.Ascending);
					StreamWriter fout = new StreamWriter(filename, false);
					string s = "", current, previous;
					s += "1.";
					if (radioButton7.Checked)
						s += "1.";
					else
						s += "0.";
					if (radioButton2.Checked)
						s += "1.";
					else
						s += "0.";
					List<int> counts = new List<int>();
					counts.Add(1);
					previous = dataGridView1.Rows[0].Cells[0].Value.ToString();
					for (int i = 1; i < dataGridView1.RowCount; i++)
					{
						current = dataGridView1.Rows[i].Cells[0].Value.ToString();
						if (current == previous)
							counts[counts.Count - 1]++;
						else
							counts.Add(1);
						previous = current;
					}
					if (counts.Count > 0 && dataGridView1.Rows[0].Cells[0].Value.ToString() == "0")
						s += "1.";
					else
						s += "0.";
					string lastChanged = DateTime.Now.ToString();
					lastChanged = lastChanged.Replace(".", "").Replace(" ", "").Replace(":", "");
					lastChanged = lastChanged.Substring(0, lastChanged.Length - 2);
					s += lastChanged + ".";
					s += numericUpDown1.Value.ToString() + ".";
					s += dataGridView1.RowCount.ToString() + ".";
					foreach (var item in counts)
					{
						s += item + ".";
					}
					int key = GenKey();
					s += key + "." + textBox2.Text;
					fout.WriteLine(EncodeDecrypt(s, 0x123456));
					fout.WriteLine(EncodeDecrypt(textBox1.Text, key));
					s = "";
					for (int i = 0; i < dataGridView1.RowCount; i++)
					{
						for (int j = 0; j < dataGridView1.ColumnCount; j++)
							s += '\"' + dataGridView1.Rows[i].Cells[j].Value.ToString() + "\";";
						fout.WriteLine(EncodeDecrypt(s, key));
						s = "";
					}
					fout.Close();
					MessageBox.Show("Файл сохранен", "Сохранение файла", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else throw new Exception("Файл не был сохранен!");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка сохранения файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
