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
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;
using System.Web;

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


		private void OpenExcelFile(string path)
		{
			FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read);
			IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
			DataSet db = reader.AsDataSet(new ExcelDataSetConfiguration()
			{
				ConfigureDataTable = (x) => new ExcelDataTableConfiguration()
				{
					UseHeaderRow = false
				}
			});
			tableCollection = db.Tables;
			DataTable table = tableCollection[Convert.ToString(tableCollection[0].TableName)];
			dataGridView1.DataSource = table;
			if (dataGridView1.ColumnCount != 10)
			{
				throw new Exception("Загружаемая таблица имеет неверный формат!"); ;
			}
			dataGridView1.Rows.RemoveAt(0);
			for (int i = 0; i < 10; i++)
				dataGridView1.Columns[i].ValueType = typeof(string);
			dataGridView1.Columns[0].HeaderText = "Номер темы";
			dataGridView1.Columns[1].HeaderText = "Название темы";
			dataGridView1.Columns[2].HeaderText = "Вопрос";
			dataGridView1.Columns[3].HeaderText = "Вариант 1";
			dataGridView1.Columns[4].HeaderText = "Вариант 2";
			dataGridView1.Columns[5].HeaderText = "Вариант 3";
			dataGridView1.Columns[6].HeaderText = "Вариант 4";
			dataGridView1.Columns[7].HeaderText = "Вариант 5";
			dataGridView1.Columns[8].HeaderText = "Вариант 6";
			dataGridView1.Columns[9].HeaderText = "Ответ";
		}
		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			dataGridView1.Visible = false;
			btn_editor.Enabled = false;
			btn_newquestion.Enabled = false;
			button1.Enabled = false;
			button2.Enabled = false;
			textBox1.Enabled = false;
			groupBox1.Enabled = false;
			groupBox2.Enabled = false;
			label2.Enabled = false;
			label2.Text = "Всего вопросов:____";
			try
			{
				DialogResult res = openFileDialog1.ShowDialog();
				if (res == DialogResult.OK)
				{
					filename = openFileDialog1.FileName;
					Text = filename;
					OpenExcelFile(filename);
				}
				else throw new Exception("Файл не был сохранен");
				btn_editor.Enabled = true;
				btn_newquestion.Enabled = true;
				button1.Enabled = true;
				button2.Enabled = true;
				textBox1.Enabled = true;
				groupBox1.Enabled = true;
				groupBox2.Enabled = true;
				label2.Enabled = true;
				label2.Text = "Всего вопросов: " + dataGridView1.RowCount;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка загрузки", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}


		private void Form1_Load(object sender, EventArgs e)
		{
			label2.Enabled = false;
			panel1.Visible = false;
			dataGridView1.Visible = false;
			btn_editor.Enabled = false;
			btn_newquestion.Enabled = false;
			button1.Enabled = false;
			button2.Enabled = false;
			textBox1.Enabled = false;
			groupBox1.Enabled = false;
			groupBox2.Enabled = false;
			dataGridView1.Left = 0;
			dataGridView1.Top = 20;
			dataGridView1.Width = 792;
			dataGridView1.Height = 578;
			dataGridView1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom;
		}

		string path = "input.txt";
		private void button2_Click(object sender, EventArgs e)
		{
			try
			{
				DialogResult res = saveFileDialog1.ShowDialog();
				if (res == DialogResult.OK)
				{
					string filename = saveFileDialog1.FileName;
					Text = filename;
					ExportExcelInterop(filename);
				}
				else throw new Exception("Файл не был сохранен!");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка сохранения таблицы", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

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

				throw;
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
					for (int j = 0; j < dataGridView1.ColumnCount - 1; j++)
					{
						xlWorkSheet.Cells[i + 2, j + 1] = dataGridView1[j, i].Value.ToString();
					}
				}
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
		}
		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				DialogResult res = saveFileDialog1.ShowDialog();
				if (res == DialogResult.OK)
				{
					string filename = saveFileDialog1.FileName;
					Text = filename;
					dataGridView1.Sort(this.dataGridView1.Columns[0], ListSortDirection.Ascending);
					StreamWriter fout = new StreamWriter(path, false);
					string s = "";
					int a = radioButton3.Checked ? 1 : 0;
					s += a + ".1.";
					a = radioButton2.Checked ? 1 : 0;
					s += a + ".";
					string lastChanged = DateTime.Now.ToString();
					lastChanged = lastChanged.Replace(".", "").Replace(" ", "").Replace(":", "");
					Text = s;
					fout.Close();
				}
				else throw new Exception("Файл не был сохранен!");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка сохранения файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}




		}

		private void toolStripButton4_Click(object sender, EventArgs e)
		{

		}
		private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				if (MessageBox.Show("Вы действительно хотите удалить этот вопрос?", "Удаление вопроса", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
				{
					dataGridView1.Rows.RemoveAt(e.RowIndex);
					label2.Text = "Всего вопросов: " + dataGridView1.RowCount;
					MessageBox.Show("Вопрос удален", "Удаление вопроса", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{

		}

		private void btn_editor_Click(object sender, EventArgs e)
		{
			dataGridView1.Visible = true;
			panel1.Visible = false;
			dataGridView1.BringToFront();
		}

		private void btn_main_Click(object sender, EventArgs e)
		{
			panel1.Visible = false;
			dataGridView1.Visible = false;
		}

		private void btn_newquestion_Click(object sender, EventArgs e)
		{
			panel1.Visible = true;
			dataGridView1.Visible = false;
			panel1.BringToFront();
		}

		private void radioButton6_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton6.Checked == true)
			{
				label6.Visible = true;
				numericUpDown2.Visible = true;
			}
			else
			{
				label6.Visible = false;
				numericUpDown2.Visible = false;
			}
		}

		private void numericUpDown3_ValueChanged(object sender, EventArgs e)
		{
			string s = numericUpDown3.Value.ToString();
			textBox5.BackColor = Color.White;
			textBox6.BackColor = Color.White;
			textBox7.BackColor = Color.White;
			textBox8.BackColor = Color.White; 
			textBox9.BackColor = Color.White;
			textBox10.BackColor = Color.White;
			textBox5.ForeColor = Color.Black;
			textBox6.ForeColor = Color.Black;
			textBox7.ForeColor = Color.Black;
			textBox8.ForeColor = Color.Black;
			textBox9.ForeColor = Color.Black;
			textBox10.ForeColor = Color.Black;
			numericUpDown3.BackColor = Color.White;
			numericUpDown3.ForeColor = Color.Black;
			for (int i = 0; i < s.Length; i++)
			{
				switch (s[i])
				{
					case '1':
						if (textBox5.Text != "")
						{
							textBox5.BackColor = Color.Green;
							textBox5.ForeColor = Color.White;
						}
						else
						{
							numericUpDown3.BackColor = Color.Red;
							numericUpDown3.ForeColor = Color.White;
						}
						break;
					case '2':
						if (textBox6.Text!="" && textBox5.Text != "")
						{
							textBox6.BackColor = Color.Green;
							textBox6.ForeColor = Color.White;
						}
						else
						{
							numericUpDown3.BackColor = Color.Red;
							numericUpDown3.ForeColor = Color.White;
						}
						break;
					case '3':
						if (textBox7.Text != "" && textBox6.Text != "" && textBox5.Text != "")
						{
							textBox7.BackColor = Color.Green;
							textBox7.ForeColor = Color.White;
						}
						else
						{
							numericUpDown3.BackColor = Color.Red;
							numericUpDown3.ForeColor = Color.White;
						}
						break;
					case '4':
						if (textBox8.Text != "" && textBox7.Text != "" && textBox6.Text != "" && textBox5.Text != "")
						{
							textBox8.BackColor = Color.Green;
							textBox8.ForeColor = Color.White;
						}
						else
						{
							numericUpDown3.BackColor = Color.Red;
							numericUpDown3.ForeColor = Color.White;
						}
						break;
					case '5':
						if (textBox9.Text != "" && textBox8.Text != "" && textBox7.Text != "" && textBox6.Text != "" && textBox5.Text != "")
						{
							textBox9.BackColor = Color.Green;
							textBox9.ForeColor = Color.White;
						}
						else
						{
							numericUpDown3.BackColor = Color.Red;
							numericUpDown3.ForeColor = Color.White;
						}
						break;
					case '6':
						if (textBox10.Text != ""&&textBox9.Text != "" && textBox8.Text != "" && textBox7.Text != "" && textBox6.Text != "" && textBox5.Text != "")
						{
							textBox10.BackColor = Color.Green;
							textBox10.ForeColor = Color.White;
						}
						else
						{
							numericUpDown3.BackColor = Color.Red;
							numericUpDown3.ForeColor = Color.White;
						}
						break;
					default:
						numericUpDown3.BackColor = Color.Red;
						numericUpDown3.ForeColor = Color.White;
						break;
				}
			}
		}

		private void textBox5_TextChanged(object sender, EventArgs e)
		{
			numericUpDown3_ValueChanged(sender, e);

		}

		private void textBox6_TextChanged(object sender, EventArgs e)
		{
			numericUpDown3_ValueChanged(sender, e);
		}

		private void textBox7_TextChanged(object sender, EventArgs e)
		{
			numericUpDown3_ValueChanged(sender, e);
		}

		private void textBox8_TextChanged(object sender, EventArgs e)
		{
			numericUpDown3_ValueChanged(sender, e);
		}

		private void textBox9_TextChanged(object sender, EventArgs e)
		{
			numericUpDown3_ValueChanged(sender, e);
		}

		private void textBox10_TextChanged(object sender, EventArgs e)
		{
			numericUpDown3_ValueChanged(sender, e);
		}
	}
}
