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
					UseHeaderRow = true
				}
			});
			tableCollection = db.Tables;
			DataTable table = tableCollection[Convert.ToString(tableCollection[0].TableName)];
			dataGridView1.DataSource = table;
		}
		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			dataGridView1.Visible = false;
			toolStripButton3.Enabled = false;
			toolStripButton2.Enabled = false;
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
					//OpenExcelFile(filename);
					SpireReadExcel(filename);
				}
				else throw new Exception("Файл не выбран");
				toolStripButton2.Enabled = true;
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
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			dataGridView1.Visible = true;
			dataGridView1.BringToFront();
			toolStripButton3.Enabled = true;
			toolStripButton2.Enabled = false;
		}
		private void toolStripButton3_Click(object sender, EventArgs e)
		{
			dataGridView1.Visible = false;
			toolStripButton3.Enabled = false;
			toolStripButton2.Enabled = true;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			label2.Enabled = false;
			dataGridView1.Visible = false;
			toolStripButton2.Enabled = false;
			toolStripButton3.Enabled = false;
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
					CreateExcel(filename);
				}
				else throw new Exception("Файл не был сохранен!");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}
		public void CreateExcel(string filename)
		{

			Cursor.Current = Cursors.WaitCursor;
			Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
			if (xlApp == null)
			{
				MessageBox.Show("Не удается найти excel!! Установите его или редактируйте таблицу в другом редакторе.");
				Marshal.ReleaseComObject(xlApp);
				return;
			}
			Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
			Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
			object misValue = System.Reflection.Missing.Value;

			xlWorkBook = xlApp.Workbooks.Add(misValue);
			xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

			for (int i = 1; i < dataGridView1.RowCount - 1; i++)
			{
				for (int j = 0; j < dataGridView1.ColumnCount - 1; j++)
				{
					xlWorkSheet.Cells[i, j + 1] = dataGridView1[j, i].Value.ToString();
				}
			}
			xlWorkBook.SaveAs(filename, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue,
			misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
			xlWorkBook.Close(0);
			xlApp.Quit();
			Marshal.ReleaseComObject(xlWorkSheet);
			Marshal.ReleaseComObject(xlWorkBook);
			Marshal.ReleaseComObject(xlApp);
			GC.Collect();
			GC.WaitForPendingFinalizers();
			Cursor.Current = Cursors.Default;
			MessageBox.Show("Файл таблицы создан по адресу \"" + filename + "\"");
		}
		private void button1_Click(object sender, EventArgs e)
		{
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

		private void toolStripButton4_Click(object sender, EventArgs e)
		{

		}
	}
}
