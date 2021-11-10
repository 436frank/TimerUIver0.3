using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using Excel = Microsoft.Office.Interop.Excel;

namespace TimerUIver0._3
{
    public partial class Form1 : Form
    {
        DateTime DateT1 = DateTime.Now; //使用時間 {開啟.exe後 只接收一次}
        private FontFamily FFM = new FontFamily("微軟正黑體");     //字型 
        private string[] ports = System.IO.Ports.SerialPort.GetPortNames();
        public Form1()
        {
            InitializeComponent();
        }

        //按鈕 匯入EXCEL人員名單-----------------------------------------------------------------------------
        private void btnImportFile_Click(object sender, EventArgs e)            
        {
            try
            {
                //獲取Excel檔案路徑和名稱
                OpenFileDialog odXls = new OpenFileDialog();
                //指定相應的開啟文件的目錄  AppDomain.CurrentDomain.BaseDirectory定位到Debug目錄，再根據實際情況進行目錄調整
                string folderPath = AppDomain.CurrentDomain.BaseDirectory + @"databackup\";
                odXls.InitialDirectory = folderPath;
                // 設定檔案格式  
                odXls.Filter = "Excel files office2003(*.xls)|*.xls|Excel office2010(*.xlsx)|*.xlsx|All files (*.*)|*.*";
                //openFileDialog1.Filter = "圖片檔案(*.jpg)|*.jpg|(*.JPEG)|*.jpeg|(*.PNG)|*.png";
                odXls.FilterIndex = 2;
                odXls.RestoreDirectory = true;
                if (odXls.ShowDialog() == DialogResult.OK)
                {
                    this.lbFilePath.Text = odXls.FileName;
                    //this.textBox1.ReadOnly = true;
                    string sConnString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source={0};" + "Extended Properties='Excel 8.0;HDR=NO;IMEX=1';", odXls.FileName);
                    if ((System.IO.Path.GetExtension(lbFilePath.Text.Trim())).ToLower() == ".xls")
                    {
                        sConnString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "data source=" + odXls.FileName + ";Extended Properties=Excel 5.0;Persist Security Info=False";
                        //sConnString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + txtFilePath.Text.Trim() + ";Extended Properties=\"Excel 8.0;HDR=" + strHead + ";IMEX=1\"";
                    }
                    using (OleDbConnection oleDbConn = new OleDbConnection(sConnString))
                    {
                        oleDbConn.Open();
                        DataTable dt = oleDbConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                        //判斷是否cmb中已有資料，有則清空
                        if (cbRacerName.Items.Count > 0)
                        {
                            cbRacerName.DataSource = null;
                            cbRacerName.Items.Clear();
                        }
                        //遍歷dt的rows得到所有的TABLE_NAME，並Add到cmb中
                        foreach (DataRow dr in dt.Rows)
                        {
                            cbRacerName.Items.Add((String)dr["TABLE_NAME"]);
                        }
                        if (cbRacerName.Items.Count > 0)
                        {
                            cbRacerName.SelectedIndex = 0;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //按鈕 選擇EXCEL人員名單-----------------------------------------------------------------------------
        private void btnChooseSheet_Click(object sender, EventArgs e)       
        {
            OleDbConnection ole = null;
            OleDbDataAdapter da = null;
            DataTable dt2 = null;
            string strConn = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source={0};" + "Extended Properties='Excel 8.0;HDR=NO;IMEX=1';", lbFilePath.Text.Trim());
            if ((System.IO.Path.GetExtension(lbFilePath.Text.Trim())).ToLower() == ".xls")
            {
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "data source=" + lbFilePath.Text.Trim() + ";Extended Properties=Excel 5.0;Persist Security Info=False";
                //sConnString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + txtFilePath.Text.Trim() + ";Extended Properties=\"Excel 8.0;HDR=" + strHead + ";IMEX=1\"";
            }
            string sTableName = cbRacerName.Text.Trim();
            string strExcel = "select * from [" + sTableName + "]";
            try
            {
                ole = new OleDbConnection(strConn);
                ole.Open();
                da = new OleDbDataAdapter(strExcel, ole);
                dt2 = new DataTable();
                da.Fill(dt2);
                this.dataGridView1.DataSource = dt2;
                //因為生成Excel的時候第一行是標題，所以要做如下操作：
                //1.修改DataGridView列頭的名字，
                //2.資料列表中刪除第一行
                for (int i = 0; i < dt2.Columns.Count; i++)
                {
                    //dgvdata.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    //dgvdata.Columns[i].Name = dt.Columns[i].ColumnName;
                    dataGridView1.Columns[i].HeaderCell.Value = dt2.Rows[0][i].ToString();//c# winform 用程式碼修改DataGridView列頭的名字，設定列名,修改列名
                }
                //DataGridView刪除行
                dataGridView1.Rows.Remove(dataGridView1.Rows[0]);//刪除第一行
                //dgvdata.Rows.Remove(dgvdata.CurrentRow);//刪除當前游標所在行
                //dgvdata.Rows.Remove(dgvdata.Rows[dgvdata.Rows.Count - 1]);//刪除最後一行
                //dgvdata.Rows.Clear();//刪除所有行
                ole.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (ole != null)
                    ole.Close();
            }
            cbRacerName.DataSource = dt2;
            cbRacerName.DisplayMember = dt2.Columns[0].ColumnName;
        }

        //標籤 使用時間--------------------------------------------------------------------------------------
        private void timerUsingTime_Tick(object sender, EventArgs e)
        {
            DateTime DateT2 = DateTime.Now;
            TimeSpan ts = DateT2 - DateT1;
            lbUsingTime.Text = ts.ToString(@"hh\:mm\:ss");
        }

        int varChoosePillar = 0, btnLightName = 0;
        //按鈕 確認速樁數量-----------------------------------------------------------------------------------
        private void btnPillarNum_Click(object sender, EventArgs e)
        {
            while (flowLayoutPanel1.Controls.Count > 0)
                foreach (Control item in flowLayoutPanel1.Controls.OfType<Button>())
                {
                    Button btn = (Button)item;
                    flowLayoutPanel1.Controls.Remove(item);
                }
            btnLightName = 0;
            varChoosePillar = Convert.ToInt32(numericUpDown1.Value);
            if (varChoosePillar == 0)
            {
                MessageBox.Show("請先輸入速樁數量", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                lbPillarHint.Text = "速樁數量確認完畢共" + varChoosePillar + "根速樁";
                btnPillarNum.Enabled = false;
            }
            for (int i = 0; i < varChoosePillar; i++)
            {
                ListPillarCheck.Add("3");
                Button btnLight = new Button();
                btnLight.Text = btnLightName.ToString();
                btnLight.TextAlign = ContentAlignment.MiddleCenter;
                btnLight.Font = new Font(FFM, 12, FontStyle.Bold);
                btnLight.Name = "Light " + btnLightName.ToString();
                btnLight.Size = new Size(35, 35);
                btnLight.BackColor = Color.Gray;
                btnLight.FlatStyle = FlatStyle.Flat;
                btnLight.FlatAppearance.BorderSize = 0;
                btnLight.Click += new EventHandler(btnLight_Click);
                btnLightName++;
                flowLayoutPanel1.Controls.Add(btnLight);
            }
        }

        //直接生成按鈕物件------------------------------------------------------------------------------------
        int pillarNumber = 0;
        void btnLight_Click(object sender, EventArgs e)
        {
            
            CheckPillar();
            while (flowLayoutPanel1.Controls.Count > 0)
                foreach (Control item in flowLayoutPanel1.Controls.OfType<Button>())
                {
                    Button btn = (Button)item;
                    flowLayoutPanel1.Controls.Remove(item);
                }
            btnLightName = 0;

            for (int i = 0; i < varChoosePillar; i++)
            {
                Button btnLight = new Button();
                switch (ListPillarCheck[i])
                {
                    case "1":
                        btnLight.Text = btnLightName.ToString();
                        btnLight.TextAlign = ContentAlignment.MiddleCenter;
                        btnLight.Font = new Font(FFM, 12, FontStyle.Bold);
                        btnLight.Name = "Light " + btnLightName.ToString();
                        btnLight.Size = new Size(35, 35);
                        btnLight.BackColor = Color.Gray;
                        btnLight.FlatStyle = FlatStyle.Flat;
                        btnLight.FlatAppearance.BorderSize = 0;
                        btnLight.Click += new EventHandler(btnLight_Click);
                        btnLight.BackColor = Color.Red;
                        btnLightName++;
                        flowLayoutPanel1.Controls.Add(btnLight);
                        break;
                    case "2":
                        btnLight.Text = btnLightName.ToString();
                        btnLight.TextAlign = ContentAlignment.MiddleCenter;
                        btnLight.Font = new Font(FFM, 12, FontStyle.Bold);
                        btnLight.Name = "Light " + btnLightName.ToString();
                        btnLight.Size = new Size(35, 35);
                        btnLight.BackColor = Color.Gray;
                        btnLight.FlatStyle = FlatStyle.Flat;
                        btnLight.FlatAppearance.BorderSize = 0;
                        btnLight.Click += new EventHandler(btnLight_Click);
                        btnLight.BackColor = Color.Green;
                        btnLightName++;
                        flowLayoutPanel1.Controls.Add(btnLight);
                        break;
                    default:
                        btnLight.Text = btnLightName.ToString();
                        btnLight.TextAlign = ContentAlignment.MiddleCenter;
                        btnLight.Font = new Font(FFM, 12, FontStyle.Bold);
                        btnLight.Name = "Light " + btnLightName.ToString();
                        btnLight.Size = new Size(35, 35);
                        btnLight.BackColor = Color.Gray;
                        btnLight.FlatStyle = FlatStyle.Flat;
                        btnLight.FlatAppearance.BorderSize = 0;
                        btnLight.Click += new EventHandler(btnLight_Click);
                        //btnLight.BackColor = Color.Red;
                        btnLightName++;
                        flowLayoutPanel1.Controls.Add(btnLight);
                        break;

                }
            
                /*Button btn = sender as Button;
                btn.BackColor = Color.Green;
                lbPillarHint.Text = btn.Name + "設定完畢";
                if(btn.BackColor == Color.Green)
                {
                    btn.Enabled = false;
                }*/
            }
        }
        string PillarCheck;
        string[] ArrayPillarCut = new string[1000];
        List<string> ListPillarCheck = new List<string>();
        private void CheckPillar()
        {
            comport.Write("#");
            //PillarCheck = comport.ReadExisting();
            PillarCheck = comport.ReadLine();
            Console.WriteLine(PillarCheck);
            ArrayPillarCut = PillarCheck.Split('G');
            for (int i = 0; i < ArrayPillarCut.Length; i++)
            {
                ListPillarCheck[i] = ArrayPillarCut[i];//速樁數量全接收
            }

        }

        string past;
        //按鈕 移除姓名---------------------------------------------------------------------------------------
        private void btnRemoveName_Click(object sender, EventArgs e)
        {
            foreach (string name in cbRacerName.Items)
            {
                //listBox1.Items.Add(name);
                if (cbRacerName.Text == name)
                {
                    past = name;
                }
            }
            cbRacerName.Items.Remove(past);
        }

        int iHint = 1, varContrastValue = 1, varChooseDistanceMax = 0, varPillarNum = 0;
        //按鈕 確認速樁距離-----------------------------------------------------------------------------------
        private void btnPillarDistance_Click(object sender, EventArgs e)
        {
            listbHint.SelectedIndex = listbHint.Items.Count - 1;
            listbHint.SelectedIndex = -1;
            if (varContrastValue == varChoosePillar)        //鎖定速樁距離
            {
                btnPillarDistance.Enabled = false;
            }
            if (Convert.ToInt32(numericUpDown1.Value) <= 0 || Convert.ToInt32(numericUpDown1.Value) == 0)
            {
                MessageBox.Show("請先輸入速樁數量", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                lbPillarHint.Text = "選擇" + varChoosePillar + "個速樁 還有" + Convert.ToInt32(numericUpDown1.Value - iHint) + "次間距須設定";
                //Console.WriteLine("varContrastValue =>" + varContrastValue);      //Debug用語法
                iHint++;
                varContrastValue++;
                if (varPillarNum == varChoosePillar - 1)
                {

                }
                else
                {
                    listbHint.Items.Add(varPillarNum + "~" + (varPillarNum + 1) + "柱距離 : " + numericUpDown2.Value + " m");
                    varPillarNum++;
                }
                listBox1.Items.Add(numericUpDown2.Value);
                if (varChooseDistanceMax <= numericUpDown2.Value)        //取最大的速樁距離
                {
                    varChooseDistanceMax = Convert.ToInt32(numericUpDown2.Value);
                }
            }
        }
        //按鈕 準備計時---------------------------------------------------------------------------------------
        private void btnStartTiming_Click(object sender, EventArgs e)
        {
            if(btnsetDone.Enabled == false)
            {
                listbData.Items.Add("姓名 " + cbRacerName.Text);
                listbData.Items.Add("速樁數量 " + numericUpDown1.Value);
                listbData.Items.Add("------ 速樁距離 ------");
                listbData.Items.AddRange(listBox1.Items);
                listbData.TopIndex = listbData.Items.Count - 1;
                //serialPort1.DiscardInBuffer();
            }
            else
            {
                //MessageBox.Show("設定未完成");
                listbData.Items.Add("設定未完成");
            }
            btnStartTiming.Enabled = false;
            btnsetDone.Enabled = false;



        }
        //下拉選單 COMport------------------------------------------------------------------------------------
        

        RollingPointPairList list1 = new RollingPointPairList(60000); //建立指定容量空的緩衝區
        RollingPointPairList list2 = new RollingPointPairList(60000); //建立指定容量空的緩衝區
        PointPairList points = new PointPairList();
        private Boolean receiving;
        private SerialPort comport = new SerialPort();
        private Int32 totalLength = 0;
        private Thread t;
        delegate void Display(Byte[] buffer);

        //Form1_Load-----------------------------------------------------------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            cbCOMport_DropDown(sender, e);

            /*poltting*/
            GraphPane myPane1 = zedPressure.GraphPane;
            zedPressure.IsZoomOnMouseCenter = true;
            myPane1.Title.Text = "壓力曲線";
            myPane1.XAxis.Title.Text = "毫秒";
            myPane1.YAxis.Title.Text = "壓力值";

            /*設置XY軸標籤 與 文字 大小*/
            myPane1.Title.FontSpec.Size = 30;
            myPane1.XAxis.Title.FontSpec.Size = 30;
            myPane1.YAxis.Title.FontSpec.Size = 30;
            myPane1.XAxis.Scale.FontSpec.Size = 30;
            myPane1.YAxis.Scale.FontSpec.Size = 30;

            /*繪製XY軸格點*/
            myPane1.XAxis.MajorGrid.IsVisible = true;
            myPane1.XAxis.MajorGrid.DashOn = 1000;
            myPane1.YAxis.MajorGrid.IsVisible = true;
            myPane1.YAxis.MajorGrid.DashOn = 1000;
            myPane1.XAxis.MajorGrid.Color = Color.Black;
            myPane1.YAxis.MajorGrid.Color = Color.Black;

            LineItem Curve1 = myPane1.AddCurve("", list1, Color.Blue, SymbolType.None);

            /*設置XY軸刻度的範圍*/
            myPane1.XAxis.Scale.Min = -200;
            myPane1.XAxis.Scale.Max = 600;
            myPane1.YAxis.Scale.Min = 0;
            myPane1.YAxis.Scale.Max = 4096;

            
            zedPressure.PanModifierKeys = Keys.None;    //滑鼠可以拖曳圖表
            zedChartData.PanModifierKeys = Keys.None;    //滑鼠可以拖曳圖表
            //zedPressure.ContextMenuBuilder += MyContextMenuBuilder;
            //zedPressure.ZoomStepFraction = 0.1;
            /*更新參數*/
            zedPressure.AxisChange();

            GraphPane myPane2 = zedChartData.GraphPane;
            zedChartData.IsZoomOnMouseCenter = true;
            myPane2.Title.Text = "速度";
            myPane2.XAxis.Title.Text = "速樁編號";
            myPane2.YAxis.Title.Text = "秒速m/s";

            /*設置XY軸標籤 與 文字 大小*/
            myPane2.Title.FontSpec.Size = 17;
            myPane2.XAxis.Title.FontSpec.Size = 17;
            myPane2.YAxis.Title.FontSpec.Size = 17;
            myPane2.XAxis.Scale.FontSpec.Size = 17;
            myPane2.YAxis.Scale.FontSpec.Size = 17;

            /*繪製XY軸格點*/
            myPane2.XAxis.MajorGrid.IsVisible = true;
            myPane2.XAxis.MajorGrid.DashOn = 1000;
            myPane2.YAxis.MajorGrid.IsVisible = true;
            myPane2.YAxis.MajorGrid.DashOn = 1000;
            myPane2.XAxis.MajorGrid.Color = Color.Black;
            myPane2.YAxis.MajorGrid.Color = Color.Black;

            LineItem Curve2 = myPane2.AddCurve("", list2, Color.Red, SymbolType.Circle);
            

            /*設置XY軸刻度的範圍*/
            myPane2.XAxis.Scale.Min = 1;
            myPane2.XAxis.Scale.Max = 12;
            /*myPane2.YAxis.Scale.Min = 0;
            myPane2.YAxis.Scale.Max = 5;*/
            myPane2.XAxis.Scale.MajorStep = 1;
            //myPane2.YAxis.Scale.MajorStep = 1;
            zedChartData.AxisChange();

        }

        private void DoReceive()
        {
            Byte[] buffer = new Byte[1024];
            while (receiving)//receiving為真時進入迴圈
            {
                if (comport.BytesToRead > 0)//檢查接收緩衝區內是否有資料
                {
                    Int32 length = comport.Read(buffer, 0, buffer.Length);
                    Array.Resize(ref buffer, length);
                    Display d = new Display(DisplayText);
                    this.Invoke(d, new Object[] { buffer });
                    Array.Resize(ref buffer, 1024);
                }
                Thread.Sleep(16);
            }
        }

        byte[] collection = new byte[100000];
        int positionCounter = 0;
        private void DisplayText(Byte[] buffer)
        {
            for (int i = 0; i < buffer.Length; i++)
            {
                collection[i + positionCounter] = buffer[i];
            }
            positionCounter += buffer.Length;
            totalLength = totalLength + buffer.Length;
            label9.Text = totalLength.ToString();
            Thread.Sleep(16);//傳輸過快 導致以下判斷式失靈
            if (comport.BytesToRead == 0)
            {
                this.Invoke(new EventHandler(GetPlottingData));//壓力曲線數據處理
            }


        }

        string[] StrCutting = new string[1000];
        string StrConvert;
        string[] StressArray = new string[1000];
        string[] PillarArray = new string[1000];
        int DataFlag = 0;
        private void GetPlottingData(object sender, EventArgs e)
        {
            StrConvert = System.Text.Encoding.UTF8.GetString(collection, 0, collection.Length);
            StrCutting = StrConvert.Split('\r');

            foreach (var item in StrCutting)
            {
                if (DataFlag == 0 && item == "\n$")// 資料旗標=0且讀取$符號
                {
                    Array.Copy(StrCutting, StressArray, StrCutting.Length);
                    DataFlag = 1;

                }
                if (DataFlag == 1 && item != "\n$")// 資料旗標=1且無$符號
                {
                    //Array.Copy(StrCutting, PillarArray, StrCutting.Length);
                    Array.Copy(StrCutting, 600, PillarArray, 0, StrCutting.Length - 600);
                }
            }

            this.Invoke(new EventHandler(DrawStressCurve));
            this.Invoke(new EventHandler(DrawPillarCurve));
        }

        int DebugCounter = 0;
        int milliSecCounter = -200;
        private void DrawStressCurve(object sender, EventArgs e)
        {
            double Pitch = 0.0;
            if (DebugCounter ==0)
            {
                this.Invoke(new EventHandler(GunTrigger));
                for (int i = 0; i < StressArray.Length; i++)
                {
                    double.TryParse(StressArray[i], out Pitch);//Convertring to double//
                    list1.Add(milliSecCounter, Pitch);
                    milliSecCounter += 2;
                }
            }
            //this.Invoke(new EventHandler(GunTrigger));
            DebugCounter++;
            //Console.WriteLine(DebugCounter);
            /*listbData.Items.Add(DebugCounter);//Debug用
            listbData.TopIndex = listbData.Items.Count - 1;*/
            //繪圖用
            
            if (comport.IsOpen)
            {
                //Console.WriteLine("check");
                /*if (zedGraphControl1.GraphPane.CurveList.Count <= 0)
                    return;*/
                LineItem curve1 = zedPressure.GraphPane.CurveList[0] as LineItem;
                /*if (curve1 == null)
                    return;*/
                IPointListEdit list1 = curve1.Points as IPointListEdit;
                /*if (list1 == null)
                    return;*/
                //if (StrCutting.Length > 15)
                //{
                //}
                


                Scale xScale1 = zedPressure.GraphPane.XAxis.Scale;
                zedPressure.GraphPane.YAxis.Scale.MaxAuto = true;
                zedPressure.GraphPane.YAxis.Scale.MinAuto = true;

                /*if (TickStart1 > xScale1.Max - xScale1.MajorStep)
                {
                    xScale1.Max = TickStart1 + xScale1.MajorStep;
                    xScale1.Min = xScale1.Max - 100;
                    
                }*/

                /*zedPressure.AxisChange();
                zedPressure.Invalidate();*/

            }
        }

        int indexOfPillar = 0;
        byte[] duplicate = new byte[100000];
        int pillar = 1;
        string[] StrCutting2 = new string[1000];
        double PitchPast = 0.0;
        double PitchMS = 0.0, PitchSecond;
        string dataSaveConverter;
        string dataSaveConverter2;
        double velocity = 0;
        private void DrawPillarCurve(object sender, EventArgs e)
        {
            //this.Invoke(new EventHandler(ClearStressCurve));
            //繪圖用
            double PitchCurrent = 0.0;

            if (comport.IsOpen)
            {
                //Console.WriteLine("check");
                /*if (zedGraphControl1.GraphPane.CurveList.Count <= 0)
                    return;*/
                LineItem curve2 = zedChartData.GraphPane.CurveList[0] as LineItem;
                curve2.Symbol.Size = 10;
                //curve2.Symbol.IsVisible = true;
                curve2.Symbol.Fill = new Fill(Color.Red);
                /*if (curve1 == null)
                    return;*/
                IPointListEdit list1 = curve2.Points as IPointListEdit;
                /*if (list1 == null)
                    return;*/



                if (PillarArray[0] != null) //資料不為空
                {
                    double.TryParse(PillarArray[indexOfPillar], out PitchCurrent);//Convertring to double//
                    PitchMS = PitchCurrent - PitchPast;
                    PitchSecond = PitchMS / 1000;
                    velocity = Math.Round(10 / PitchSecond, 2, MidpointRounding.AwayFromZero);
                    if (velocity >= 1000)
                    {
                        velocity = 0;
                    }
                    //list1.Add(pillar, PitchSecond);
                    list1.Add(pillar, velocity);
                    dataSaveConverter += PitchSecond;//存成字串用於切割
                    dataSaveConverter2 += velocity;//存成字串用於切割
                    dataSaveConverter += "\n";
                    dataSaveConverter2 += "\n";
                    PitchPast = PitchCurrent;
                    indexOfPillar++;
                    pillar++;
                }





                Scale xScale1 = zedChartData.GraphPane.XAxis.Scale;
                zedChartData.GraphPane.YAxis.Scale.MaxAuto = true;
                zedChartData.GraphPane.YAxis.Scale.MinAuto = true;

                /*if (TickStart1 > xScale1.Max - xScale1.MajorStep)
                {
                    xScale1.Max = TickStart1 + xScale1.MajorStep;
                    xScale1.Min = xScale1.Max - 100;
                    
                }*/

                zedChartData.AxisChange();
                zedChartData.Invalidate();
            }
        }

        private void ClearStressCurve(object sender, EventArgs e)
        {
            for (int i = 0; i < StrCutting.Length; i++)
            {
                Array.Clear(StrCutting, 0, i);
            }
            zedPressure.GraphPane.CurveList[0].Clear(); //清除曲線資料
            zedPressure.GraphPane.GraphObjList.Clear(); //清除背景填滿
        }

        private void GunTrigger(object sender, EventArgs e)
        {
            const double width = 200.0;
            const double height = 4096.0;
            
            zedPressure.GraphPane.GraphObjList.Add(new ZedGraph.PolyObj
            {
                Points = new[]      //繪製填充用 座標
                {
            new ZedGraph.PointD(0, 0),
            new ZedGraph.PointD(width, 0),
            new ZedGraph.PointD(width, height),
            new ZedGraph.PointD(0, height),
            //new ZedGraph.PointD(1, 0)
        },
                Fill = new ZedGraph.Fill(Color.Transparent, Color.Red, 60.0f),
                ZOrder = ZedGraph.ZOrder.E_BehindCurves
            });
            
            zedPressure.Invalidate();
        }

        //按鈕 壓力曲線 儲存------------------------------------------------------------------------------------
        private void btnPressureSave_Click(object sender, EventArgs e)
        {
            //zedPressure.SaveAs(); //儲存圖片 .emf
            if (File.Exists(@"D:\" + "PressureCurveExcel" + ".xlsx"))
            {
                Excel.Range wRange;
                Excel.Application XlApp = new Microsoft.Office.Interop.Excel.Application();
                if (XlApp == null)
                {
                    MessageBox.Show("Excel is not properly installed");
                    return;
                }
                XlApp.DisplayAlerts = false;
                string FilePath = @"D:\" + "PressureCurveExcel";
                Excel.Workbook Xlworkbook = XlApp.Workbooks.Open(FilePath,
                    0, false, 5, "", "", false,
                    Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "",
                    true, false, 0, true, false, false);
                Excel.Sheets Xlworksheet = Xlworkbook.Worksheets;

                var Xlnewsheet = (Excel.Worksheet)Xlworksheet.Add(Xlworksheet[1],
                    Type.Missing, Type.Missing, Type.Missing);
                try
                {
                    Xlnewsheet.Name = DateTime.Now.ToString("HH.mm.ss");
                }
                catch (Exception)
                {

                    //throw;
                }
                Xlnewsheet.Cells[1, 1] = "日期";
                Xlnewsheet.Cells[1, 2] = "時間";
                Xlnewsheet.Cells[1, 3] = "壓力值";
                Xlnewsheet.Cells[2, 1] = DateTime.Now.ToShortDateString();
                Xlnewsheet.Cells[2, 2] = DateTime.Now.ToShortTimeString();
                for (int i = 0; i < StressArray.Length; i++)//資料儲存
                {
                    Xlnewsheet.Cells[i+2, 3] = StressArray[i];
                    //Xlnewsheet.Cells[i+2, 3] = "123";
                }

                wRange = Xlnewsheet.Range[Xlnewsheet.Cells[1, 1], Xlnewsheet.Cells[15, 10]];
                wRange.Select();
                wRange.Columns.AutoFit();
                Xlnewsheet = (Excel.Worksheet)Xlworkbook.Worksheets.get_Item(1);
                Xlnewsheet.Select();

                Xlworkbook.Save();
                Xlworkbook.Close();


                MessageBox.Show("儲存完畢", "notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {
                string FilerStr = @"D:\" + "PressureCurveExcel";
                Excel.Application ExcelApp = new Excel.Application();
                Excel.Workbook ExcelWB = ExcelApp.Workbooks.Add();
                Excel.Worksheet ExcelWS = new Excel.Worksheet();
                Excel.Range wRange;
                ExcelWS = ExcelWB.Worksheets[1];
                ExcelWS.Name = DateTime.Now.ToString("HH.mm.ss");
                ExcelApp.Cells[1, 1] = "日期";
                ExcelApp.Cells[1, 2] = "時間";
                ExcelApp.Cells[1, 3] = "壓力值";
                ExcelApp.Cells[2, 1] = DateTime.Now.ToShortDateString();
                ExcelApp.Cells[2, 2] = DateTime.Now.ToShortTimeString();
                for (int i = 0; i < StressArray.Length; i++)//資料儲存
                {
                    ExcelApp.Cells[i+2, 3] = StressArray[i];
                    //ExcelApp.Cells[i+2, 3] = "123";
                }
                wRange = ExcelWS.Range[ExcelWS.Cells[1, 1], ExcelWS.Cells[15, 10]];
                wRange.Select();
                wRange.Columns.AutoFit();
                ExcelWB.SaveAs(FilerStr);
                ExcelWS = null;
                ExcelWB.Close();
                ExcelWB = null;
                ExcelApp.Quit();
                ExcelApp = null;
                MessageBox.Show("另存新檔", "notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        string[] testcut = new string[1000];
        string[] testcut2 = new string[1000];
        //按鈕 速樁 數據儲存------------------------------------------------------------------------------------
        private void btnDataSave_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"D:\" + "PillarScoreExcel" + ".xlsx"))
            {
                Excel.Range wRange;
                Excel.Application XlApp = new Microsoft.Office.Interop.Excel.Application();
                if (XlApp == null)
                {
                    MessageBox.Show("Excel is not properly installed");
                    return;
                }
                XlApp.DisplayAlerts = false;
                string FilePath = @"D:\" + "PillarScoreExcel";
                Excel.Workbook Xlworkbook = XlApp.Workbooks.Open(FilePath,
                    0, false, 5, "", "", false,
                    Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "",
                    true, false, 0, true, false, false);
                Excel.Sheets Xlworksheet = Xlworkbook.Worksheets;

                var Xlnewsheet = (Excel.Worksheet)Xlworksheet.Add(Xlworksheet[1],
                    Type.Missing, Type.Missing, Type.Missing);
                try
                {
                    Xlnewsheet.Name = DateTime.Now.ToString("HH.mm.ss");
                }
                catch (Exception)
                {

                    //throw;
                }
                Xlnewsheet.Cells[1, 1] = "日期";
                Xlnewsheet.Cells[4, 1] = "時間";
                Xlnewsheet.Cells[1, 2] = "柱號";
                Xlnewsheet.Cells[1, 3] = "秒數";
                Xlnewsheet.Cells[1, 4] = "速度";
                Xlnewsheet.Cells[2, 1] = DateTime.Now.ToShortDateString();
                Xlnewsheet.Cells[5, 1] = DateTime.Now.ToShortTimeString();
                for (int i = 0; i < 12; i++)
                {
                    Xlnewsheet.Cells[i + 2, 2] = i+1;
                }
                testcut = dataSaveConverter.Split('\n');
                testcut2 = dataSaveConverter2.Split('\n');
                for (int i = 0; i < testcut.Length; i++)//資料儲存
                {
                    
                    Xlnewsheet.Cells[i + 2, 3] = testcut[i];
                    Xlnewsheet.Cells[i + 2, 4] = testcut2[i];
                    //Xlnewsheet.Cells[i+2, 3] = "123";
                }

                wRange = Xlnewsheet.Range[Xlnewsheet.Cells[1, 1], Xlnewsheet.Cells[15, 10]];
                wRange.Select();
                wRange.Columns.AutoFit();
                Xlnewsheet = (Excel.Worksheet)Xlworkbook.Worksheets.get_Item(1);
                Xlnewsheet.Select();

                Xlworkbook.Save();
                Xlworkbook.Close();


                MessageBox.Show("儲存完畢", "notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {
                string FilerStr = @"D:\" + "PillarScoreExcel";
                Excel.Application ExcelApp = new Excel.Application();
                Excel.Workbook ExcelWB = ExcelApp.Workbooks.Add();
                Excel.Worksheet ExcelWS = new Excel.Worksheet();
                Excel.Range wRange;
                ExcelWS = ExcelWB.Worksheets[1];
                ExcelWS.Name = DateTime.Now.ToString("HH.mm.ss");
                ExcelApp.Cells[1, 1] = "日期";
                ExcelApp.Cells[1, 2] = "時間";
                ExcelApp.Cells[1, 3] = "柱號";
                ExcelApp.Cells[1, 4] = "秒數";
                ExcelApp.Cells[2, 1] = DateTime.Now.ToShortDateString();
                ExcelApp.Cells[2, 2] = DateTime.Now.ToShortTimeString();
                for (int i = 0; i < 12; i++)
                {
                    ExcelApp.Cells[i + 2, 3] = i + 1;
                }
                for (int i = 0; i < PillarArray.Length; i++)//資料儲存
                {

                    ExcelApp.Cells[i + 2, 4] = PillarArray[i];
                    //Xlnewsheet.Cells[i+2, 3] = "123";
                }
                wRange = ExcelWS.Range[ExcelWS.Cells[1, 1], ExcelWS.Cells[15, 10]];
                wRange.Select();
                wRange.Columns.AutoFit();
                ExcelWB.SaveAs(FilerStr);
                ExcelWS = null;
                ExcelWB.Close();
                ExcelWB = null;
                ExcelApp.Quit();
                ExcelApp = null;
                MessageBox.Show("另存新檔", "notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        //按鈕 速樁清除---------------------------------------------------------------------------------------
        private void btnChartDataClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < PillarArray.Length; i++)
            {
                Array.Clear(PillarArray, 0, i);
            }
            //positionCounter = 0;
            zedChartData.GraphPane.CurveList[0].Clear(); //清除曲線資料
            //zedChartData.GraphPane.GraphObjList.Clear(); //清除背景填滿
            indexOfPillar = 0;
            pillar = 1;
            PitchPast = 0.0;
            PitchMS = 0.0;
             

            //zedPressure.RestoreScale(zedPressure.GraphPane);
            /*poltting*/
            GraphPane myPane2 = zedChartData.GraphPane;
            zedChartData.IsZoomOnMouseCenter = true;
            myPane2.Title.Text = "平均速度";
            myPane2.XAxis.Title.Text = "速樁";
            myPane2.YAxis.Title.Text = "秒速";

            /*設置XY軸標籤 與 文字 大小*/
            myPane2.Title.FontSpec.Size = 17;
            myPane2.XAxis.Title.FontSpec.Size = 17;
            myPane2.YAxis.Title.FontSpec.Size = 17;
            myPane2.XAxis.Scale.FontSpec.Size = 17;
            myPane2.YAxis.Scale.FontSpec.Size = 17;

            /*繪製XY軸格點*/
            myPane2.XAxis.MajorGrid.IsVisible = true;
            myPane2.XAxis.MajorGrid.DashOn = 1000;
            myPane2.YAxis.MajorGrid.IsVisible = true;
            myPane2.YAxis.MajorGrid.DashOn = 1000;
            myPane2.XAxis.MajorGrid.Color = Color.Black;
            myPane2.YAxis.MajorGrid.Color = Color.Black;

            LineItem Curve2 = myPane2.AddCurve("", list2, Color.Red, SymbolType.Circle);



            /*設置XY軸刻度的範圍*/
            myPane2.XAxis.Scale.Min = 1;
            myPane2.XAxis.Scale.Max = 12;
            myPane2.YAxis.Scale.Min = 0;
            myPane2.YAxis.Scale.Max = 5;
            myPane2.XAxis.Scale.MajorStep = 1;
            //myPane2.YAxis.Scale.MajorStep = 1;*/



            zedChartData.AxisChange();
            zedChartData.Invalidate();
        }

        private string strValue;
        public string StrValue
        {
            set
            {
                strValue = value;
            }
        }
        //按鈕 歷史資料匯入---------------------------------------------------------------------------------------
        private void btnHistoryData_Click(object sender, EventArgs e)
        {
            HistoryData HistoryDataForm = new HistoryData();//產生Form2的物件，才可以使用它所提供的Method
            HistoryDataForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
            HistoryDataForm.ShowDialog();
            cw();
            //MessageBox.Show(strValue);//顯示返回的值  

        }

        string[] ArrayReScore = new string[1000];
        string[] ArrayRePillar = new string[1000];
        private void cw()
        {
            //if(==null) //防呆，避免使用者直接按叉叉關閉
            ArrayReScore = strValue.Split('\n');
            /*foreach (var item in RePillar)
            {
                Console.WriteLine(item);
            }*/
            //ArrayRePillar = RePillarConnect.Split
            /*for (int i = 0; i < ArrayReScore.Length; i++)
            {
                if (ArrayReScore[i] == "$")
                {
                    ArrayReScore[i] = "0";
                }
            }*/
            CreateGraph(zedChartData);
        }

        int Repillar = 1;

        private void cbCOMport_DropDown(object sender, EventArgs e)
        {
            cbCOMport.Items.Clear();
            ports = System.IO.Ports.SerialPort.GetPortNames();
            cbCOMport.Items.AddRange(SerialPort.GetPortNames());
            cbCOMport.SelectedItem = Properties.Settings.Default.comPortName;
        }

        private void btnComPort_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text == "連線")
            {
                btn.Text = "斷開";

                comport = new SerialPort(cbCOMport.SelectedItem.ToString(), 115200, Parity.None, 8, StopBits.One);
                if (!comport.IsOpen)
                {
                    comport.Open();
                    receiving = true;
                    t = new Thread(DoReceive);
                    t.IsBackground = true;
                    t.Start();
                }

            }
            else
            {
                btn.Text = "連線";


            }
        }

        private void CreateGraph(ZedGraphControl zgc)
        {
            double ScorePoint = 0.0;
            // get a reference to the GraphPane
            GraphPane myPane = zgc.GraphPane;

            // Set the Titles
            myPane.Title.Text = "平均速度";
            myPane.XAxis.Title.Text = "柱號";
            myPane.YAxis.Title.Text = "秒數";

            // Make up some data arrays based on the Sine function
            //double x, y1, y2;
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            /*for (int i = 0; i < 36; i++)
            {
                x = (double)i + 5;
                y1 = 1.5 + Math.Sin((double)i * 0.2);
                y2 = 3.0 * (1.5 + Math.Sin((double)i * 0.2));
                list1.Add(x, y1);
                list2.Add(x, y2);
            }*/
            for (int i = 0; i < ArrayReScore.Length; i++)
            {
                double.TryParse(ArrayReScore[i], out ScorePoint);
                //double.TryParse(RePillar[i], out trtest2);

                list1.Add(Repillar, ScorePoint);
                Repillar++;
            }



            //tr = double.Parse(test[0]);

            // Generate a red curve with diamond
            // symbols, and "Porsche" in the legend
            LineItem myCurve = myPane.AddCurve("", list1, Color.Red, SymbolType.Circle);



            /*設置XY軸標籤 與 文字 大小*/
            myPane.Title.FontSpec.Size = 17;
            myPane.XAxis.Title.FontSpec.Size = 17;
            myPane.YAxis.Title.FontSpec.Size = 17;
            myPane.XAxis.Scale.FontSpec.Size = 17;
            myPane.YAxis.Scale.FontSpec.Size = 17;

            /*繪製XY軸格點*/
            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.XAxis.MajorGrid.DashOn = 1000;
            myPane.YAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MajorGrid.DashOn = 1000;
            myPane.XAxis.MajorGrid.Color = Color.Black;
            myPane.YAxis.MajorGrid.Color = Color.Black;

            //LineItem Curve2 = myPane2.AddCurve("", list2, Color.Red, SymbolType.Circle);


            /*設置XY軸刻度的範圍*/
            myPane.XAxis.Scale.Min = 1;
            myPane.XAxis.Scale.Max = 12;
            /*myPane.YAxis.Scale.Min = 0;
            myPane.YAxis.Scale.Max = 5;*/
            myPane.XAxis.Scale.MajorStep = 1;
            //myPane2.YAxis.Scale.MajorStep = 1;*/
            //zedChartData.AxisChange();
            // Generate a blue curve with circle
            // symbols, and "Piper" in the legend
            //LineItem myCurve2 = myPane.AddCurve("",list2, Color.Blue, SymbolType.Circle);
            zgc.PanModifierKeys = Keys.None;
            // Tell ZedGraph to refigure the
            // axes since the data have changed
            zgc.AxisChange();
        }

        //按鈕 壓力曲線清除---------------------------------------------------------------------------------------
        private void btnPressureCurveClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < StressArray.Length; i++)
            {
                Array.Clear(StressArray, 0, i);
            }
            //positionCounter = 0;
            zedPressure.GraphPane.CurveList[0].Clear(); //清除曲線資料
            zedPressure.GraphPane.GraphObjList.Clear(); //清除背景填滿
            milliSecCounter = -200;

            //zedPressure.RestoreScale(zedPressure.GraphPane);
            /*poltting*/
            GraphPane myPane1 = zedPressure.GraphPane;
            myPane1.Title.Text = "壓力曲線";
            myPane1.XAxis.Title.Text = "毫秒";
            myPane1.YAxis.Title.Text = "壓力值";

            /*設置XY軸標籤 與 文字 大小*/
            myPane1.Title.FontSpec.Size = 30;
            myPane1.XAxis.Title.FontSpec.Size = 30;
            myPane1.YAxis.Title.FontSpec.Size = 30;
            myPane1.XAxis.Scale.FontSpec.Size = 30;
            myPane1.YAxis.Scale.FontSpec.Size = 30;

            /*繪製XY軸格點*/
            myPane1.XAxis.MajorGrid.IsVisible = true;
            myPane1.YAxis.MajorGrid.IsVisible = true;
            myPane1.XAxis.MajorGrid.Color = Color.Black;
            myPane1.YAxis.MajorGrid.Color = Color.Black;

            LineItem Curve1 = myPane1.AddCurve("", list1, Color.Blue, SymbolType.None);

            /*設置XY軸刻度的範圍*/
            myPane1.XAxis.Scale.Min = -200;
            myPane1.XAxis.Scale.Max = 600;
            /*myPane1.XAxis.Scale.MinAuto = false;
            myPane1.XAxis.Scale.MaxAuto = false;*/
            myPane1.YAxis.Scale.Min = 0;
            myPane1.YAxis.Scale.Max = 4096;
            /*myPane1.YAxis.Scale.MinAuto = false;
            myPane1.YAxis.Scale.MaxAuto = false;*/
            /*zedPressure.RestoreScale(myPane1);
            zedPressure.ZoomOut(myPane1);*/



            zedPressure.AxisChange();
            zedPressure.Invalidate();



        }

        private void btnAddName_Click(object sender, EventArgs e)
        {
            cbRacerName.Items.Add(cbRacerName.Text);
            /*cbChooseSheetName.Text = tbInputName.Text;
            cbChooseSheetName.Items.Add(tbInputName.Text);*/
        }

        private void btnsetDone_Click(object sender, EventArgs e)
        {
            btnPillarNum.Enabled = false;
            btnPillarDistance.Enabled = false;
            btnChooseSheet.Enabled = false;
            btnImportFile.Enabled = false;
            btnAddName.Enabled = false;
            btnRemoveName.Enabled = false;
            btnsetDone.Enabled = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cbRacerName.Items.Clear();
            cbRacerName.SelectedIndex = -1;
            //numericUpDown1.
            btnStartTiming.Enabled = true;
            btnsetDone.Enabled = true;
            btnPillarNum.Enabled = true;
            btnPillarDistance.Enabled = true;
            btnChooseSheet.Enabled = true;
            btnImportFile.Enabled = true;
            btnAddName.Enabled = true;
            btnRemoveName.Enabled = true;
            iHint = 1;
            varContrastValue = 1;
            varPillarNum = 0;
            listBox1.Items.Clear();
            listbHint.Items.Clear();
            listbData.Items.Clear();
            while (flowLayoutPanel1.Controls.Count > 0)
                foreach (Control item in flowLayoutPanel1.Controls.OfType<Button>())
                {
                    Button btn = (Button)item;
                    flowLayoutPanel1.Controls.Remove(item);
                }
            btnLightName = 0;
        }

        
    }
}

