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
        private Boolean receiving;
        private SerialPort comport = new SerialPort();
        private int rxByteCount = 0;
        private delegate void DisplayStr(string str);
        private delegate void invokeDelegate();
        private Thread t;
        PointPairList CheckPointList = new PointPairList();
        double CheckPointListX = 0;
        PointPairList PillarPointList = new PointPairList();
        double PillarPointListY = 0;
        PointPairList speedPointList = new PointPairList();
        double speedPointListX = 0;
        PointPairList accelerationList = new PointPairList();
        double accelerationListX = 0;
        string user_ID_file_path = Directory.GetCurrentDirectory() + "\\User_ID.txt"; //使用者id的txt路徑

        public Form1()//初始化物件
        {
            InitializeComponent();
            
        }  
        private void Form1_Load(object sender, EventArgs e)
        {
            system_file_generation();
            cbCOMport_DropDown(sender, e);
            btnComPort_Click(sender, e);
            Init_Graph_ADC();//踏板壓力曲線圖表初始化
            Init_Graph();//速樁時間、速樁速度、速樁加速度圖表初始化
            //加入壓力數值
            zedPressure.GraphPane.AddCurve("壓力", CheckPointList, Color.Blue, SymbolType.None);
            CheckPointListX = -200; //-200;   //初始X座標

            zedChartData.GraphPane.AddCurve("test", PillarPointList, Color.Red, SymbolType.Circle);
            PillarPointListY = 0;               //初始X座標

        }//應用程式開啟時//Form1_Load
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close_Comport();
        } //應用程式關閉時
        private void PlotFinalize(ZedGraphControl zgc)
        {
            zgc.AxisChange();
            zgc.Refresh();
        }
        private void Init_Graph_ADC()
        {
            var poly1 = new PolyObj
            {
                Points = new[]
                {
                    new PointD(0, 0),
                    new PointD(100, 0),
                    new PointD(100, 4095),
                    new PointD(0, 4095)
                },
                Fill = new Fill(Color.FromArgb(127, Color.Red)),
                ZOrder = ZOrder.E_BehindCurves
            };
            ///*poltting*/
            ZedGraphControl zgc = zedPressure;
            GraphPane myPane = zgc.GraphPane;
            zgc.PanModifierKeys = Keys.None;    //滑鼠可以拖曳圖表
            zgc.IsShowPointValues = true;       //滑鼠經過圖表上的點時是否氣泡顯示該點所對應的值
            zgc.IsEnableZoom = true;            //允許橫向縮放
            /*加入標題*/
            myPane.Title.Text = "壓力曲線";
            myPane.XAxis.Title.Text = "毫秒";
            myPane.YAxis.Title.Text = "壓力值";
            /*繪製XY虛線*/
            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MajorGrid.IsVisible = true;
            /*加入 紅色區塊 */
            myPane.GraphObjList.Clear();
            myPane.GraphObjList.Add(poly1);
            /*設置XY軸刻度的範圍*/
            myPane.XAxis.Scale.Min = -200;
            myPane.XAxis.Scale.Max = 2200;
            myPane.XAxis.Scale.MinorStep = 20;
            myPane.XAxis.Scale.MajorStep = 200;
            myPane.YAxis.Scale.Min = 0;
            myPane.YAxis.Scale.Max = 4095;
            /*更新參數*/
            zgc.AxisChange();   
            zgc.Refresh();
        }     //踏板壓力曲線圖表初始化
        private void Setting_Graph(ZedGraphControl zgc)
        {
            
        }
        private void Init_Graph()
        {
            /*---------------------- 初始化 圖表1 ----------------------*/
            ZedGraphControl zgc = zedChartData;
            GraphPane myPane = zgc.GraphPane;

            zgc.PanModifierKeys = Keys.None;    //滑鼠可以拖曳圖表
            zgc.IsShowPointValues = true;       //滑鼠經過圖表上的點時是否氣泡顯示該點所對應的值
            zgc.IsEnableZoom = true;            //允許橫向縮放
            /*加入標題*/
            myPane.Title.Text = "原數據";
            myPane.XAxis.Title.Text = "時間(s)";
            myPane.YAxis.Title.Text = "速樁";
            /*繪製XY虛線*/
            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MajorGrid.IsVisible = true;
            /*設置XY軸刻度的範圍*/
            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 20;
            myPane.XAxis.Scale.MinorStep = 0.2;
            myPane.XAxis.Scale.MajorStep = 1;
            myPane.YAxis.Scale.Min = 0;
            myPane.YAxis.Scale.Max = 30;
            /*更新參數*/
            zgc.AxisChange();
            zgc.Refresh();
            /*---------------------- 初始化 圖表2 ----------------------*/
            zgc = zedGraphControl1;//////////
            myPane = zgc.GraphPane;

            myPane.Title.Text = "數據1";
            myPane.XAxis.Title.Text = "速樁";
            myPane.YAxis.Title.Text = "m/s";
            zgc.IsEnableZoom = true; //true  false
            zgc.IsZoomOnMouseCenter = true; //使用滾輪時以滑鼠所在點進行縮放還是以圖形中心進行縮放 true為以滑鼠所在點進行縮放
            /*設置XY軸標籤 與 文字 大小*/
            myPane.Title.FontSpec.Size = 17;
            myPane.XAxis.Title.FontSpec.Size = 17;
            myPane.YAxis.Title.FontSpec.Size = 17;
            myPane.XAxis.Scale.FontSpec.Size = 17;
            myPane.YAxis.Scale.FontSpec.Size = 17;
            speedPointListX = 0;   //初始X座標
            /*繪製XY軸格點*/
            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.XAxis.MajorGrid.DashOn = 1000;
            myPane.YAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MajorGrid.DashOn = 1000;
            myPane.XAxis.MajorGrid.Color = Color.Black;
            myPane.YAxis.MajorGrid.Color = Color.Black;
            myPane.CurveList.Clear();
            speedPointList.Clear();
            myPane.AddCurve("test", speedPointList, Color.Red, SymbolType.Circle);

            /*設置XY軸刻度的範圍*/
            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 12;
            myPane.YAxis.Scale.Min = 0;
            myPane.YAxis.Scale.Max = 50;
            myPane.XAxis.Scale.MajorStep = 1;
            //myPane.YAxis.Scale.MajorStep = 1;

            zgc.PanModifierKeys = Keys.None;    //滑鼠可以拖曳圖表
            zgc.AxisChange();
            zgc.Refresh();

            /*---------------------- 初始化 圖表2 ----------------------*/
            zgc = zedGraphControl2;//////////
            myPane = zgc.GraphPane;

            myPane.Title.Text = "";
            myPane.XAxis.Title.Text = "速樁";
            myPane.YAxis.Title.Text = "m/s^2";
            zgc.IsEnableZoom = true; //true  false
            zgc.IsZoomOnMouseCenter = true; //使用滾輪時以滑鼠所在點進行縮放還是以圖形中心進行縮放 true為以滑鼠所在點進行縮放
            /*設置XY軸標籤 與 文字 大小*/
            myPane.Title.FontSpec.Size = 17;
            myPane.XAxis.Title.FontSpec.Size = 17;
            myPane.YAxis.Title.FontSpec.Size = 17;
            myPane.XAxis.Scale.FontSpec.Size = 17;
            myPane.YAxis.Scale.FontSpec.Size = 17;
            speedPointListX = 0;   //初始X座標
            /*繪製XY軸格點*/
            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.XAxis.MajorGrid.DashOn = 1000;
            myPane.YAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MajorGrid.DashOn = 1000;
            myPane.XAxis.MajorGrid.Color = Color.Black;
            myPane.YAxis.MajorGrid.Color = Color.Black;
            myPane.CurveList.Clear();
            speedPointList.Clear();
            myPane.AddCurve("test", speedPointList, Color.Red, SymbolType.Circle);

            /*設置XY軸刻度的範圍*/
            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 12;
            myPane.YAxis.Scale.Min = 0;
            myPane.YAxis.Scale.Max = 50;
            myPane.XAxis.Scale.MajorStep = 1;
            //myPane.YAxis.Scale.MajorStep = 1;

            zgc.PanModifierKeys = Keys.None;    //滑鼠可以拖曳圖表
            zgc.AxisChange();
            zgc.Refresh();
        }
        private void Open_Comport()
        {
            try
            {
                btnComPort.Text = "斷開";
                cbCOMport.Enabled = false;
                if (comport.IsOpen)
                    comport.Close();
                comport.PortName = Properties.Settings.Default.comPortName;
                comport.BaudRate = 115200;
                comport.Parity = Parity.None;
                comport.DataBits = 8;
                comport.StopBits = StopBits.One;
                comport.ReadBufferSize = 81920;

                if (!comport.IsOpen)
                    comport.Open();

                receiving = true;
                t = new Thread(DoReceive);
                t.Start();
            }
            catch (Exception ex)
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close_Comport();
            }
        }   //開啟COMPORT
        private void Close_Comport()
        {
            receiving = false;
            btnComPort.Text = "連線";
            cbCOMport.Enabled = true;
            if (comport.IsOpen)
                comport.Close();
        }  //關閉COMPORT

        string[] time_data = { };
        string[] adc_data = { };
        private void DoReceive()         //COMPORT接收資料
        {
            int all_point = 1200;
            int now_point=0;
            int max_data_val = 0;
            int min_data_val = 0;
            Byte[] buffer = new Byte[1024];
            

            string temp_msg = "";
            string hintMark = "$";
            char charHintMark ='$';
            float time_ms_NEWDATA;
            bool judg;//判斷結果
            while (receiving)//receiving為真時進入迴圈
            {
                try
                {
                    if (comport.BytesToRead > 0)//檢查接收緩衝區內是否有資料
                    {
                        Int32 length = comport.Read(buffer, 0, buffer.Length);   //把資料存在Int32的length
                        int cnt = 0;
                        Array.Resize(ref buffer, length);
                        rxByteCount += buffer.Length;
                        //顯示bytes
                        this.Invoke(new invokeDelegate(DisplayRx));
                        //顯示資料
                        string msg = Encoding.Default.GetString(buffer);
                        DisplayStr dstr = new DisplayStr(DisplayText); 
                        this.Invoke(dstr, new Object[] { msg });
                        //
                        msg = temp_msg + msg;
                        string[] datas= msg.Trim().Split('\n');
                        
                        if (msg.Substring(msg.Length - 1, 1) != "\n")
                        {
                            temp_msg = datas[datas.Length - 1];
                            cnt = datas.Length - 1;
                        }
                        else
                        {
                            temp_msg = "";
                            cnt = datas.Length;
                        }

                        //cnt = datas.Length;
                        for (int i = 0; i < cnt; i++)
                        {
                            judg = datas[i].Contains(hintMark);

                            
                            //Console.Write($"judg= {judg}  ");//預覽輸出
                            if (judg)
                            {
                                if (datas[i] == "$0")
                                {
                                    PillarPointList.Clear();
                                    PillarPointListY = 0;
                                    CheckPointList.Clear();
                                    CheckPointListX = -200;
                                }
                                
                                time_ms_NEWDATA = Int32.Parse(datas[i].TrimStart(charHintMark));
                                time_ms_NEWDATA = time_ms_NEWDATA / 1000;
                                PillarPointList.Add(Convert.ToDouble(time_ms_NEWDATA), PillarPointListY);
                                PillarPointListY++;//

                                Array.Resize(ref time_data, time_data.Length + 1);
                                time_data[time_data.Length - 1] = datas[i];

                                //Console.Write($"PillarPointListY= {Convert.ToDouble(datas[i].TrimStart(charHintMark))}  ");//預覽輸出
                                // Console.Write($"PillarPointListY/1000= {time_ms_NEWDATA}  ");//預覽輸出

                            }
                            else
                            {
                                CheckPointList.Add(CheckPointListX, Convert.ToDouble(datas[i]));
                                CheckPointListX += 2;//
                                now_point++;
                                Array.Resize(ref adc_data, adc_data.Length + 1);
                                adc_data[adc_data.Length - 1] = datas[i];
                               // Console.WriteLine(string.Join("\n",adc_data));
                               //Console.WriteLine(now_point);//確認1200筆數
                                if (now_point == all_point)
                                {
                                    int[] intadc_data = Array.ConvertAll(adc_data, s => int.Parse(s));
                                    max_data_val = intadc_data.Max();
                                    min_data_val = intadc_data.Min();
                                    for (int data_cnt=1199;data_cnt>=0;data_cnt--)
                                    {
                                        int now_intadc_data= intadc_data[data_cnt];
                                        if (now_intadc_data == max_data_val)
                                        {
                                            Console.WriteLine("離開踏板前最高的時間點 ={0}",data_cnt);
                                            Console.WriteLine("離開踏板前最高的數值 ={0}",max_data_val);
                                        }
                                    }
                                    for (int data_cnt =0; data_cnt <=1199 ; data_cnt++)
                                    {
                                        int now_intadc_data = intadc_data[data_cnt];
                                        if (now_intadc_data == min_data_val)
                                        {
                                            Console.WriteLine("離開踏板後最低的時間點 ={0}", data_cnt);
                                            Console.WriteLine("離開踏板後最低的數值 ={0}", min_data_val);
                                        }
                                    }
                                }
                            }

                        }
                           
                            //Console.Write($"msg = {msg}");
                        //this.Invoke(new EventHandler(GetPlottingData));//壓力曲線數據處理
                        Array.Resize(ref buffer, 1024);
                    }
                    Thread.Sleep(16);
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Invoke(new invokeDelegate(Close_Comport));
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void to_txt_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.FileName = DateTime.Now.ToString("yyyy-MM-dd HH-mm");

                saveFile.Filter = "文字檔案(*.txt)|*.txt";//設定檔案型別
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    /////////////////////////////////存ADC值////////////////////////
                    StreamWriter sw_adc = new StreamWriter(saveFile.FileName.Replace(".txt", "_ADC.txt"), false);
                    foreach (string data in adc_data)
                    {
                        sw_adc.WriteLine(data);
                    }
                    sw_adc.Close();
                    /////////////////////////////////存時間////////////////////////
                    StreamWriter sw_time = new StreamWriter(saveFile.FileName.Replace(".txt", "_time.txt"), false);
                    for (int i = 0; i < time_data.Length - 1; i++)
                    {
                        sw_time.WriteLine(time_data[i]);
                    }
                    sw_time.Close();
                    //////////////////////////////////截圖//////////////////////////
                    Bitmap myImage = new Bitmap(this.Width, this.Height);
                    Graphics g = Graphics.FromImage(myImage);
                    g.CopyFromScreen(new Point(this.Location.X, this.Location.Y), new Point(0, 0), new Size(this.Width, this.Height));
                    IntPtr dc1 = g.GetHdc();
                    g.ReleaseHdc(dc1);
                    myImage.Save(saveFile.FileName.Replace(".txt", "_picture.jpg"));
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Exception: ");
                MessageBox.Show("找不到路徑", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }//輸出存檔
        private void system_file_generation()  //產生系統文件
        {
            var CurrentDirectory = Directory.GetCurrentDirectory();
            FileStream fs;
            fs = new FileStream(user_ID_file_path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);
        }
        private void button_add_UserID_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = File.AppendText(user_ID_file_path))
            {
                sw.WriteLine(USER_ID_combobox.Text);
            }
        }
        private void USER_ID_combobox_DropDown(object sender, EventArgs e)   //受測者下拉選單事件
        {
            string ReadLine;
            bool fileExist = File.Exists(user_ID_file_path);
            USER_ID_combobox.Items.Clear();

            if (!fileExist)
            {
                Console.WriteLine("偵測路徑 " + user_ID_file_path);
                Console.WriteLine("此路徑沒那個檔案");
                StreamWriter sw = new StreamWriter(user_ID_file_path);
            }
            else
            {
                Console.WriteLine("偵測路徑 " + user_ID_file_path);
                Console.WriteLine("此路徑已有那個檔案");
                StreamReader sr = new StreamReader(user_ID_file_path);
                while ((ReadLine= sr.ReadLine()) != null)
                {
                    USER_ID_combobox.Items.Add(ReadLine);
                }
                sr.Close(); 
            }
            //Console.WriteLine("File");
        }
        private void USER_ID_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void DisplayRx()
        {
            label9.Text = rxByteCount.ToString();
        }
        private void DisplayText(string msg)
        {
            testWin.Text += msg;
        }
        private void btnImportFile_Click(object sender, EventArgs e) //按鈕 匯入EXCEL人員名單
        {
            
        }
        private void btnChooseSheet_Click(object sender, EventArgs e)//按鈕 選擇EXCEL人員名單
        {
           
        }
        private void timerUsingTime_Tick(object sender, EventArgs e) //標籤 使用時間
        {

        }
        private void btnPillarNum_Click(object sender, EventArgs e)  //按鈕 確認速樁數量
        {
           
           
        }


        private void btnStartTiming_Click(object sender, EventArgs e)
        {

        } //按鈕 準備計時
        private void GetPlottingData(object sender, EventArgs e)
        {
        }


        
        private void btnPressureSave_Click(object sender, EventArgs e)  //按鈕 壓力曲線 儲存
        {
         
 
        }
        private void btnDataSave_Click(object sender, EventArgs e)      //按鈕 速樁 數據儲存
        {

        }
        private void btnChartDataClear_Click(object sender, EventArgs e)//按鈕 速樁清除
        {
            Init_Graph();
        }
        private void cbCOMport_DropDown(object sender, EventArgs e)
        {
            cbCOMport.Items.Clear();
            cbCOMport.Items.AddRange(SerialPort.GetPortNames());
            cbCOMport.SelectedItem = Properties.Settings.Default.comPortName;
        }
        private void cbCOMport_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }
        private void btnComPort_Click(object sender, EventArgs e)
        {
            if (btnComPort.Text == "連線")
            {
                Open_Comport();
            }
            else
            {
                Close_Comport();
            }
        }
        private void testWin_TextChanged(object sender, EventArgs e)
        {
            testWin.SelectionStart = testWin.Text.Length;
            testWin.ScrollToCaret();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            zedPressure.Refresh();
            zedChartData.Refresh();

        }
        private void zedChartData_Load(object sender, EventArgs e)
        {

        }
        private void zedPressure_Load(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tbInputName_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbRacerName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
               
        private void btnPressureCurveClear_Click(object sender, EventArgs e)//按鈕 壓力曲線清除
        {
            Init_Graph_ADC();
        }
        private void btnAddName_Click(object sender, EventArgs e)
        {

        }
        private void btnsetDone_Click(object sender, EventArgs e)
        {
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
        
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private int tab_cnt = 0;
        private void tabControl2_DoubleClick(object sender, EventArgs e)
        {            

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }



        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}