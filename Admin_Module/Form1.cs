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
				else throw new Exception("Файл не выбран");
				toolStripButton2.Enabled = true;
				button1.Enabled = true;
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
			textBox1.Enabled = false;
			groupBox1.Enabled = false;
			groupBox2.Enabled = false;
			dataGridView1.Left = 0;
			dataGridView1.Top = 20;
			dataGridView1.Width = 800; 
			dataGridView1.Height = 430;
			dataGridView1.Anchor=AnchorStyles.Left|AnchorStyles.Right|AnchorStyles.Left|AnchorStyles.Bottom;
		}

		string path = "input.txt";
		private void button1_Click(object sender, EventArgs e)
		{
			//dataGridView1.Sort(this.dataGridView1.Columns[0], ListSortDirection.Ascending);
			//StreamWriter fout = new StreamWriter(path, false);
			//string s="";
			//int a = radioButton3.Checked? 1:0;
			//s += a+".1.";
			//a=radioButton2.Checked? 1: 0;
			//s += a + ".";
			//string lastChanged = DateTime.Now.ToString();
			//lastChanged = lastChanged.Replace(".", "").Replace(" ", "").Replace(":", "");
			//Text = s;
			//fout.Close();

			Cursor.Current = Cursors.WaitCursor;
			Excel.Application xlApp = new Excel.Application();
			Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"D:\data.xls");
			Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
			Excel.Range xlRange = xlWorksheet.UsedRange;

			xlWorksheet.Cells[1, 1] = Text;
			xlApp.Visible = false;
			xlApp.UserControl = false;
			xlWorkbook.Save();

			//cleanup
			GC.Collect();
			GC.WaitForPendingFinalizers();

			//release com objects to fully kill excel process from running in the background
			Marshal.ReleaseComObject(xlRange);
			Marshal.ReleaseComObject(xlWorksheet);

			//close and release
			xlWorkbook.Close();
			Marshal.ReleaseComObject(xlWorkbook);

			//quit and release
			xlApp.Quit();
			Marshal.ReleaseComObject(xlApp);

			// Set cursor as default arrow
			Cursor.Current = Cursors.Default;
		}

		private void toolStripButton4_Click(object sender, EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;

			Excel.Application xlApp = new Excel.Application();
			Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"D:\data.xls");
			Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
			Excel.Range xlRange = xlWorksheet.UsedRange;

			if (xlRange.Cells[1, 1] != null && xlRange.Cells[1, 1].Value2 != null)
			{
				Text = "New "+xlRange.Cells[1, 1].Value2.ToString();
			}

			//cleanup
			GC.Collect();
			GC.WaitForPendingFinalizers();

			//release com objects to fully kill excel process from running in the background
			Marshal.ReleaseComObject(xlRange);
			Marshal.ReleaseComObject(xlWorksheet);

			//close and release
			xlWorkbook.Close();
			Marshal.ReleaseComObject(xlWorkbook);

			//quit and release
			xlApp.Quit();
			Marshal.ReleaseComObject(xlApp);

			// Set cursor as default arrow
			Cursor.Current = Cursors.Default;

		}
	}
}
