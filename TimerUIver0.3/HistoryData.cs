using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimerUIver0._3
{
    public partial class HistoryData : Form
    {
        public HistoryData()
        {
            InitializeComponent();
        }

        DataTableCollection TableCollection;
        private void btnFileOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx" })//找EXCEL//Excel 97-2003 Workbook|*.xls|
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFileSelect.Text = openFileDialog.FileName;
                    using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                            });
                            TableCollection = result.Tables;
                            cbSheetSelect.Items.Clear();
                            foreach (DataTable table in TableCollection)
                                cbSheetSelect.Items.Add(table.TableName);



                        }
                    }
                }
            }
        }

        DataTable dt;
        string ReScore;
        string[] RePillar = new string[1000];
        string ReScoreConnect;
        private void cbSheetSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = TableCollection[cbSheetSelect.SelectedItem.ToString()];
            for (int i = 0; i < dt.Rows.Count ; i++)
            {
                ReScore = dt.Rows[i][3].ToString();//秒數
                RePillar[i] = dt.Rows[i][1].ToString();//柱號
                ReScoreConnect += ReScore;
                ReScoreConnect += "\n";
                //RePillarConnect += RePillar;
                //testcut = test.Split('\n');
            }
        }

        /*private string string1;
        public string String1
        {
            set
            {
                string1 = value;
            }
        }*/

        /*public void SetValue()
        {
            this.label1.Text = string1;
        }*/
        private void btnOK_Click(object sender, EventArgs e)
        {
            Form1 lForm1 = (Form1)this.Owner;//把Form2的父窗口指針賦給lForm1 
            lForm1.StrValue = ReScoreConnect;//使用父窗口指針賦值  
            this.Close();
        }
    }
}
