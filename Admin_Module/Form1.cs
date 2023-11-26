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
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			dataGridView1.Visible = true;
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
			dataGridView1.Visible = false;
			toolStripButton3.Enabled = false;
			toolStripButton2.Enabled = false;
		}
	}
}
