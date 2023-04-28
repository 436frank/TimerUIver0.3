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
using System.Timers;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;

namespace TimerUIver0._3
{

    public partial class Form1 : Form
    {
        private System.Timers.Timer aTimer;

        private FontFamily FFM = new FontFamily("微軟正黑體");     //字型 
        private Boolean receiving;
        private SerialPort comport = new SerialPort();
        private int rxByteCount = 0;
        private delegate void DisplayStr(string str);
        private delegate void renew_user_time(string str);
        private delegate void invokeDelegate();
        private Thread t;
        PointPairList CheckPointList = new PointPairList();//壓力值的線
        double CheckPointListX = 0;
        PointPairList maxCheckPointList = new PointPairList();//壓力最大的點
        double maxCheckPointListX = 0;
        PointPairList minCheckPointList = new PointPairList();//壓力最小的點
        double minCheckPointListX = 0;
        PointPairList leaveCheckPointList = new PointPairList();//壓力離開的點
        double leaveCheckPointListX = 0;
        PointPairList PillarPointList = new PointPairList();//計時點的線(原數據)
        double PillarPointListY = 0;
        PointPairList SpeedPillarPointList = new PointPairList();//計時點的線(速度數據)
        double SpeedPillarPointListY = 0;
        PointPairList AccPillarPointList = new PointPairList();//計時點的線(加速度數據)
        double AccPillarPointListY = 0;
        string user_ID_file_path = Directory.GetCurrentDirectory() + "\\User_ID.txt"; //使用者id的txt路徑
        public Form1()//初始化物件
        {
            InitializeComponent();
            //btnsetDone_Click(null, null);
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.F1)
            {
                
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            system_file_generation();
            cbCOMport_DropDown(sender, e);
            btnComPort_Click(sender, e);
            Init_Graph_ADC();//踏板壓力曲線圖表初始化
            Init_Graph();//速樁時間、速樁速度、速樁加速度圖表初始化
            SetTimer();
            //加入壓力數值
            zedPressure.GraphPane.AddCurve("壓力", CheckPointList, Color.Blue, SymbolType.None);
            zedPressure.GraphPane.AddCurve("最高點", maxCheckPointList, Color.Red, SymbolType.Star);
            zedPressure.GraphPane.AddCurve("最低點", minCheckPointList, Color.Blue, SymbolType.Star);
            zedPressure.GraphPane.AddCurve("離開點", leaveCheckPointList, Color.Green, SymbolType.Star);

            maxCheckPointListX = -200;
            minCheckPointListX = -200;
            leaveCheckPointListX = -200;
            CheckPointListX = -200; //-200;   //初始X座標
            




        }//應用程式開啟時//Form1_Load
        private void renew_time_user(string msg)
        {
            NOW_user_lable.Text = msg;
        }
        private  void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {

        }

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
            var line1 = new PolyObj //離開線
            {
                Points = new[]
    {
                    new PointD(0, 0),

                    new PointD(0, 4095)
                },
                Fill = new Fill(Color.FromArgb(127, Color.Red)),
                ZOrder = ZOrder.E_BehindCurves
            };
            ///*poltting*/
            ZedGraphControl zgc = zedPressure;
            GraphPane myPane = zgc.GraphPane;
            //zgc.PanModifierKeys = Keys.None;    //滑鼠可以拖曳圖表
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
            myPane.Title.Text = "位置與時間";
            myPane.XAxis.Title.Text = "時間(s)";
            myPane.YAxis.Title.Text = "位置(公尺)";
            /*繪製XY虛線*/
            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MajorGrid.IsVisible = true;
            /*設置XY軸刻度的範圍*/
            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 20;
            myPane.XAxis.Scale.MinorStep = 0.2;
            myPane.XAxis.Scale.MajorStep = 1;
            myPane.YAxis.Scale.Min = 0;
            myPane.YAxis.Scale.Max = 100;
            /*更新參數*/
            LineItem pointCurve = zedChartData.GraphPane.AddCurve("原數據", PillarPointList, Color.Red, SymbolType.Circle);
            pointCurve.IsVisible = true;
            pointCurve.Symbol.Type = SymbolType.Circle;

            PillarPointListY = 0;               //初始X座標
            zgc.AxisChange();
            zgc.Refresh();
            /*---------------------- 初始化 圖表2 ----------------------*/
            zgc = zedGraphControl1;//////////
            myPane = zgc.GraphPane;

            myPane.Title.Text = "速度與時間";
            myPane.XAxis.Title.Text = "時間(s)";
            myPane.YAxis.Title.Text = "m/s";
            zgc.IsEnableZoom = true; //true  false
            zgc.IsZoomOnMouseCenter = true; //使用滾輪時以滑鼠所在點進行縮放還是以圖形中心進行縮放 true為以滑鼠所在點進行縮放
            /*設置XY軸標籤 與 文字 大小*/
            myPane.Title.FontSpec.Size = 17;
            myPane.XAxis.Title.FontSpec.Size = 17;
            myPane.YAxis.Title.FontSpec.Size = 17;
            myPane.XAxis.Scale.FontSpec.Size = 17;
            myPane.YAxis.Scale.FontSpec.Size = 17;

            /*繪製XY軸格點*/
            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MajorGrid.IsVisible = true;
            myPane.CurveList.Clear();
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

            /*---------------------- 初始化 圖表3 ----------------------*/
            zgc = zedGraphControl2;//////////
            myPane = zgc.GraphPane;

            myPane.Title.Text = "加速度與時間";
            myPane.XAxis.Title.Text = "時間(s)";
            myPane.YAxis.Title.Text = "m/s^2";
            zgc.IsEnableZoom = true; //true  false
            zgc.IsEnableVZoom = false;
            zgc.IsEnableHPan = false;
            zgc.IsZoomOnMouseCenter = true; //使用滾輪時以滑鼠所在點進行縮放還是以圖形中心進行縮放 true為以滑鼠所在點進行縮放
            /*設置XY軸標籤 與 文字 大小*/
            myPane.Title.FontSpec.Size = 17;
            myPane.XAxis.Title.FontSpec.Size = 17;
            myPane.YAxis.Title.FontSpec.Size = 17;
            myPane.XAxis.Scale.FontSpec.Size = 17;
            myPane.YAxis.Scale.FontSpec.Size = 17;

            /*繪製XY軸格點*/
            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MajorGrid.IsVisible = true;
            myPane.CurveList.Clear();
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
        private void Set_Data_S()
        {
            try
            {
                int num = int.Parse(textBox1.Text);
                int num2 = int.Parse(textBox2.Text);
                btnComPort.Text = "鎖定";
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                // TextBox中的文本轉換為int變量成功，執行相應的操作
            }
            catch (Exception ex)
            {
                // 轉換失敗，顯示錯誤消息
                MessageBox.Show("請輸入有效的數字！");
            }

        }
        private void Set_not_Data_S()
        {
            btnComPort.Text = "確認";
            textBox1.Enabled = true;
            textBox2.Enabled = true;
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
        double[] time_data_d= { };
        double[] pos_data_d= {};
        int max_time_point;
        int min_time_point;
        int leave_time_point;
        int leave_time_val;
        int time_i;
        char charHintMark = '$';
        private void DoReceive()         //COMPORT接收資料
        {
            int all_point = 1200;
            int now_point=0;
            int max_data_val = 0;
            int min_data_val = 0;
            int[] intadc_data;
            Byte[] buffer = new Byte[1024];
            

            string temp_msg = "";
            string hintMark = "$";
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
                                    maxCheckPointList.Clear();
                                    maxCheckPointListX = -200;
                                    minCheckPointList.Clear();
                                    minCheckPointListX = -200;
                                    leaveCheckPointList.Clear();
                                    leaveCheckPointListX = -200;
                                    max_time_point = 0;
                                    min_time_point = 0;
                                    leave_time_val=0;
                                    now_point = 0;
                                    max_data_val = 0;
                                    min_data_val = 0;
                                    

                                    leave_time_point = 0;
                                    time_i =0;
                                    Array.Resize(ref time_data_d,0);
                                    Array.Resize(ref adc_data,0);
                                    Array.Resize(ref pos_data_d, 1);
                                    
                                    pos_data_d[pos_data_d.Length - 1] = time_i;
                                }
                                
                                time_ms_NEWDATA = Int32.Parse(datas[i].TrimStart(charHintMark));
                                time_ms_NEWDATA = time_ms_NEWDATA / 1000;
                                PillarPointList.Add(Convert.ToDouble(time_ms_NEWDATA),pos_data_d[time_i]);
                                PillarPointListY++;//

                                Array.Resize(ref time_data, time_data.Length + 1);
                                Array.Resize(ref time_data_d, time_data_d.Length + 1);
                                Array.Resize(ref pos_data_d, pos_data_d.Length + 1);
                                time_data[time_data.Length - 1] = datas[i];
                                time_data_d[time_data_d.Length - 1] = Convert.ToDouble(datas[i].TrimStart(charHintMark))/1000;
                                time_i = time_i + 1;
                                pos_data_d[pos_data_d.Length - 1] = time_i*10f;


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
                                    
                                    intadc_data = Array.ConvertAll(adc_data, s => int.Parse(s));
                                    max_data_val = intadc_data.Max();
                                    min_data_val = intadc_data.Min();
                                    for (int data_cnt=1199;data_cnt>=0;data_cnt--)
                                    {
                                        int now_intadc_data= intadc_data[data_cnt];
                                        if (now_intadc_data == max_data_val)
                                        {
                                            Console.WriteLine("離開踏板前最高的時間點 ={0}", data_cnt*2-200);
                                            Console.WriteLine("離開踏板前最高的數值 ={0}", max_data_val);
                                            max_time_point = data_cnt;
                                            maxCheckPointList.Add(data_cnt*2-200, max_data_val);
                                            break;
                                        }
                                    }
                                    for (int data_cnt =0; data_cnt <=1199 ; data_cnt++)
                                    {
                                        int now_intadc_data = intadc_data[data_cnt];
                                        if (now_intadc_data == min_data_val)
                                        {
                                            min_time_point = data_cnt;
                                            Console.WriteLine("離開踏板後最低的時間點 ={0}", data_cnt*2-200);
                                            Console.WriteLine("離開踏板後最低的數值 ={0}", min_data_val);
                                            min_time_point = data_cnt;
                                            minCheckPointList.Add(data_cnt * 2-200, min_data_val);
                                            break;
                                        }
                                    }
                                    leave_time_point = (min_time_point - max_time_point)/2;
                                    leaveCheckPointList.Add((leave_time_point+max_time_point)*2-200, Convert.ToDouble(adc_data[leave_time_point + max_time_point]));
                                    Console.WriteLine("離開踏板時間點 ={0}", (leave_time_point + max_time_point) * 2 - 200);
                                    PillarPointList[0].X = ((leave_time_point + max_time_point) * 2 - 200) /1000f; ;
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
        }
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
        private void USER_ID_combobox_SelectedValueChanged(object sender, EventArgs e)
        {
            Console.WriteLine("re_text");
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
        private void btnPressureCurveClear_Click(object sender, EventArgs e)//按鈕 壓力曲線清除
        {
            Init_Graph_ADC();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            testWin.Clear();
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
        private void btnsetDone_Click(object sender, EventArgs e)
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


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void NOW_timer_lable_Click(object sender, EventArgs e)
        {

        }

        private void USER_ID_combobox_Format(object sender, KeyEventArgs e)
        {
            NOW_user_lable.Text = USER_ID_combobox.Text;

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PointPairList OldPointList = new PointPairList();
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "請選擇檔案";
            dialog.Filter = "文字檔案(*.txt)|*.txt";//設定檔案型別
            double[] tmpX = {  };
            double[] tmpY = {  };
            int tmp_cnt = 0;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string filename = dialog.FileName;
                using (StreamReader sr = new StreamReader(filename)) 
                {
                    string line = "";

                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line != "")
                        {
                            
                            Array.Resize(ref tmpX,tmpX.Length+1);
                            Array.Resize(ref tmpY,tmpY.Length+1);
                            tmpX[tmpX.Length - 1] = Convert.ToDouble(line)/1000;
                            tmpY[tmpY.Length - 1] = 10f * tmp_cnt;
                            OldPointList.Add(Convert.ToDouble(line)/1000, 10f * tmp_cnt);
                            tmp_cnt++;
                        }
                    }
                }
                CubicSplineInterpolation old_cc = new CubicSplineInterpolation(tmpX,tmpY);
                zedChartData.GraphPane.AddCurve("位置old", old_cc.GetPositionPointList(), Color.Brown, SymbolType.None);
                zedGraphControl1.GraphPane.AddCurve("壓力old", old_cc.GetSpeedPointList(), Color.Brown, SymbolType.None);
                zedGraphControl2.GraphPane.AddCurve("acc_old", old_cc.GetAccelerationPointList(), Color.Brown, SymbolType.None);

                //zedChartData.GraphPane.AddCurve("1", OldPointList, Color.Blue, SymbolType.Circle);
                label3.Text = filename;

            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            PointPairList OldPointList = new PointPairList();
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "請選擇檔案";
            dialog.Filter = "文字檔案(*.txt)|*.txt";//設定檔案型別
            int tmp_cnt = 0;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string filename = dialog.FileName;
                using (StreamReader sr = new StreamReader(filename))
                {
                    string line = "";

                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line != "")
                        {
                            OldPointList.Add(2 * tmp_cnt-200, Convert.ToDouble(line));
                            tmp_cnt++;
                        }
                    }
                }
                zedPressure.GraphPane.AddCurve("1", OldPointList, Color.Brown, SymbolType.None);
                label3.Text = filename;

            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.FileName = DateTime.Now.ToString("yyyy-MM-dd HH-mm") + USER_ID_combobox.Text;

                saveFile.Filter = "文字檔案(*.txt)|*.txt";//設定檔案型別
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    /////////////////////////////////存ADC值////////////////////////
                    StreamWriter sw_adc = new StreamWriter(saveFile.FileName.Replace(".txt", "_ADC.txt"), false);
                    foreach (string data in adc_data)
                    {
                        sw_adc.WriteLine(data);
                    }
                    //sw_adc.WriteLine("離開踏板前最高的時間點" + max_time_point);
                    //sw_adc.WriteLine("離開踏板前最低的時間點" + min_time_point);
                    //sw_adc.WriteLine("離開踏板的時間點" + leave_time_point);
                    sw_adc.Close();
                    /////////////////////////////////存時間////////////////////////
                    StreamWriter sw_time = new StreamWriter(saveFile.FileName.Replace(".txt", "_time.txt"), false);
                    for (int i = 0; i < time_data.Length - 1; i++)
                    {
                        sw_time.WriteLine(time_data[i].TrimStart(charHintMark));
                    }
                    sw_time.Close();
                    //////////////////////////////////截圖//////////////////////////
                    Bitmap bmp = new Bitmap(zedPressure.ClientSize.Width, zedPressure.ClientSize.Height);
                    Bitmap bmp2 = new Bitmap(zedChartData.ClientSize.Width, zedChartData.ClientSize.Height);
                    Graphics g = Graphics.FromImage(bmp);
                    Graphics g2 = Graphics.FromImage(bmp2);
                    zedPressure.DrawToBitmap(bmp, zedPressure.ClientRectangle);
                    zedChartData.DrawToBitmap(bmp2, zedChartData.ClientRectangle);
                    bmp.Save(saveFile.FileName.Replace(".txt", "_picture1.jpg"));                
                    bmp2.Save(saveFile.FileName.Replace(".txt", "_picture2.jpg"));
                    //Bitmap myImage = new Bitmap(this.Width, this.Height);
                    //Graphics g = Graphics.FromImage(myImage);
                    //g.CopyFromScreen(new Point(this.Location.X, this.Location.Y), new Point(0, 0), new Size(this.Width, this.Height));
                    //IntPtr dc1 = g.GetHdc();
                    //g.ReleaseHdc(dc1);
                    //myImage.Save(saveFile.FileName.Replace(".txt", "_picture.jpg"));
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

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (btnComPort.Text == "確認")
            {
                Set_Data_S();
            }
            else
            {
                Set_not_Data_S();
            }
        }

        private void btnHistoryData_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            CubicSplineInterpolation cc = new CubicSplineInterpolation(time_data_d, pos_data_d);
            //zedChartData.GraphPane.CurveList[0].Clear();
            //zedGraphControl1.GraphPane.CurveList.Clear();
            //zedGraphControl2.GraphPane.CurveList.Clear();
            zedChartData.GraphPane.AddCurve("位置", cc.GetPositionPointList(), Color.Blue, SymbolType.None);
            zedGraphControl1.GraphPane.AddCurve("速度", cc.GetSpeedPointList(), Color.Blue, SymbolType.None);
            zedGraphControl2.GraphPane.AddCurve("加速度", cc.GetAccelerationPointList(), Color.Red, SymbolType.None);


        }

        private void button6_Click(object sender, EventArgs e)
        {
            testWin.Clear();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }

    public class CubicSplineInterpolation
    {
        private double[] data_t;
        private double[] data_s;
        private int n;
        private int m;
        private int nn;
        private int size;
        private double[,] M_array;
        private double[] S_array;
        private double[,] coeff;

        public CubicSplineInterpolation()
        {
            //        %data_t = [0.5, 1.760, 3.571, 5.314, 6.975, 8.495, 9.604, 10.767 ,11.913, 12.709, 13.707, 14.701];   % 蘇景暉
            //        %data_t = [0.5, 1.608, 3.145, 4.523, 5.801, 6.950, 7.796, 8.689 ,9.584 ,10.193, 11.004 ,11.620];   % 楊以丞
            //        %data_t = [0.45, 1.859, 4.116, 6.487, 8.461, 10.139, 11.424 ,12.864 ,14.454, 15.547, 16.909 ,18.293];   % 黃祥璽
            //double[] dt_t = { 0.53f, 1.389f, 3.034f, 4.575f, 6.028f, 7.455f, 8.561f, 9.722f, 10.929f, 11.848f, 12.986f, 14.106f };//林立中
            //double[] dt_s = { 0f, 3.5f, 12.5f, 22f, 31f, 39f, 45f, 51f, 57f, 61f, 66f, 70f };            
            double[] dt_t = { 0.2f, 1.34f, 1.961f, 2.581f,3.12f};//王謙
            double[] dt_s = { 0f, 1.5f, 4.5f, 7.5f, 10f}; //王謙
            this.initialization(dt_t, dt_s);
        }
        public CubicSplineInterpolation(double[] data_t, double[] data_s)
        {
            this.initialization(data_t, data_s);
        }
        private void initialization(double[] data_t, double[] data_s)
        {
            this.n = data_t.Length;
            //if (data_s.Length != n && n < 1)
            //    throw new Exception("Data Length Error");
            this.m = this.n - 1;
            this.nn = 4 * this.m - 1;
            this.size = 50;
            this.M_array = new double[nn, nn];
            this.S_array = new double[nn];
            this.data_t = data_t;
            this.data_s = data_s;
            CalculateMatrix();
        }
        public void CalculateMatrix()
        {
            M_array[0, 0] = (3 * data_t[0]) * data_t[0];
            M_array[0, 1] = 2 * data_t[0];
            M_array[0, 2] = 1;
            M_array[0, 3] = 0;
            S_array[0] = 0;

            M_array[1, 0] = data_t[0] * data_t[0] * data_t[0];
            M_array[1, 1] = data_t[0] * data_t[0];
            M_array[1, 2] = data_t[0];
            M_array[1, 3] = 1;
            S_array[1] = data_s[0];

            for (int j = 1; j < m; j++)
            {
                double t_cnt = data_t[j];
                if (j < m - 1)
                {
                    //% contnuation of speed
                    M_array[j * 4 - 2, (j - 1) * 4] = 3 * t_cnt * t_cnt;
                    M_array[j * 4 - 2, (j - 1) * 4 + 1] = 2 * t_cnt;
                    M_array[j * 4 - 2, (j - 1) * 4 + 2] = 1;
                    M_array[j * 4 - 2, (j - 1) * 4 + 3] = 0;
                    M_array[j * 4 - 2, (j - 1) * 4 + 4] = -3 * t_cnt * t_cnt;
                    M_array[j * 4 - 2, (j - 1) * 4 + 5] = -2 * t_cnt;
                    M_array[j * 4 - 2, (j - 1) * 4 + 6] = -1;
                    M_array[j * 4 - 2, (j - 1) * 4 + 7] = 0;
                    //% contnuation of acceleration
                    M_array[j * 4 - 1, (j - 1) * 4] = 6 * t_cnt;
                    M_array[j * 4 - 1, (j - 1) * 4 + 1] = 2;
                    M_array[j * 4 - 1, (j - 1) * 4 + 2] = 0;
                    M_array[j * 4 - 1, (j - 1) * 4 + 3] = 0;
                    M_array[j * 4 - 1, (j - 1) * 4 + 4] = -6 * t_cnt;
                    M_array[j * 4 - 1, (j - 1) * 4 + 5] = -2;
                    M_array[j * 4 - 1, (j - 1) * 4 + 6] = 0;
                    M_array[j * 4 - 1, (j - 1) * 4 + 7] = 0;
                    //% passing data points
                    M_array[j * 4, (j - 1) * 4] = t_cnt * t_cnt * t_cnt;
                    M_array[j * 4, (j - 1) * 4 + 1] = t_cnt * t_cnt;
                    M_array[j * 4, (j - 1) * 4 + 2] = t_cnt;
                    M_array[j * 4, (j - 1) * 4 + 3] = 1;
                    M_array[j * 4 + 1, (j) * 4] = t_cnt * t_cnt * t_cnt;
                    M_array[j * 4 + 1, (j) * 4 + 1] = t_cnt * t_cnt;
                    M_array[j * 4 + 1, (j) * 4 + 2] = t_cnt;
                    M_array[j * 4 + 1, (j) * 4 + 3] = 1;
                }
                else
                {
                    //% contnuation of speed
                    M_array[j * 4 - 2, (j - 1) * 4] = 3 * t_cnt * t_cnt;
                    M_array[j * 4 - 2, (j - 1) * 4 + 1] = 2 * t_cnt;
                    M_array[j * 4 - 2, (j - 1) * 4 + 2] = 1;
                    M_array[j * 4 - 2, (j - 1) * 4 + 3] = 0;
                    M_array[j * 4 - 2, (j - 1) * 4 + 4] = -2 * t_cnt;
                    M_array[j * 4 - 2, (j - 1) * 4 + 5] = -1;
                    M_array[j * 4 - 2, (j - 1) * 4 + 6] = 0;

                    //% contnuation of acceleration
                    M_array[j * 4 - 1, (j - 1) * 4] = 6 * t_cnt;
                    M_array[j * 4 - 1, (j - 1) * 4 + 1] = 2;
                    M_array[j * 4 - 1, (j - 1) * 4 + 2] = 0;
                    M_array[j * 4 - 1, (j - 1) * 4 + 3] = 0;
                    M_array[j * 4 - 1, (j - 1) * 4 + 4] = -2;
                    M_array[j * 4 - 1, (j - 1) * 4 + 5] = 0;
                    M_array[j * 4 - 1, (j - 1) * 4 + 6] = 0;

                    //% passing data points
                    M_array[j * 4, (j - 1) * 4] = t_cnt * t_cnt * t_cnt;
                    M_array[j * 4, (j - 1) * 4 + 1] = t_cnt * t_cnt;
                    M_array[j * 4, (j - 1) * 4 + 2] = t_cnt;
                    M_array[j * 4, (j - 1) * 4 + 3] = 1;

                    M_array[j * 4 + 1, (j) * 4] = t_cnt * t_cnt;
                    M_array[j * 4 + 1, (j) * 4 + 1] = t_cnt;
                    M_array[j * 4 + 1, (j) * 4 + 2] = 1;
                }
                S_array[j * 4 - 2] = 0;
                S_array[j * 4 - 1] = 0;
                S_array[j * 4] = data_s[j];
                S_array[j * 4 + 1] = data_s[j];
            }
            M_array[m * 4 - 2, (m - 1) * 4] = data_t[n - 1] * data_t[n - 1];
            M_array[m * 4 - 2, (m - 1) * 4 + 1] = data_t[n - 1];
            M_array[m * 4 - 2, (m - 1) * 4 + 2] = 1;
            S_array[m * 4 - 2] = data_s[n - 1];

            coeff = Matrix.Product(Matrix.Gauss_jordan_elimination(M_array), S_array);
        }

        public PointPairList GetPositionPointList()
        {
            return GetPointList("pos");
        }
        public PointPairList GetSpeedPointList()
        {
            return GetPointList("vel");
        }
        public PointPairList GetAccelerationPointList()
        {
            return GetPointList("acc");
        }

        private PointPairList GetPointList(string mode)
        {            
            if (coeff == null)
                throw new Exception("coeff error");
            double[] scat = new double[(size + 1) * m];
            double[] tcat = new double[(size + 1) * m];

            for (int j = 0; j < m; j++)
            {
                double t1 = data_t[j], t2 = data_t[j + 1];
                double[] tp = get_point(t1, t2, size);
                double[,] sp = new double[size + 1, 1];
                if (j < m - 1)
                {
                    double[,] tmp = new double[size + 1, 4];
                    for (int i = 0; i < size + 1; i++)
                    {   
                        switch (mode)
                        {
                            case "pos":
                                tmp[i, 0] = tp[i] * tp[i] * tp[i];
                                tmp[i, 1] = tp[i] * tp[i];
                                tmp[i, 2] = tp[i];
                                tmp[i, 3] = 1;
                                break;
                            case "vel":
                                tmp[i, 0] = 3 * tp[i] * tp[i];
                                tmp[i, 1] = 2 * tp[i];
                                tmp[i, 2] = 1;
                                tmp[i, 3] = 0;
                                break;
                            case "acc":
                                tmp[i, 0] = 6 * tp[i];
                                tmp[i, 1] = 2;
                                tmp[i, 2] = 0;
                                tmp[i, 3] = 0;
                                break;
                        }
                    }
                    double[,] tmp2 = new double[4, 1];
                    Array.Copy(coeff, j * 4, tmp2, 0, 4);
                    sp = Matrix.Product(tmp, tmp2);
                }
                else
                {
                    double[,] tmp = new double[size + 1, 3];
                    for (int i = 0; i < size + 1; i++)
                    {
                        switch (mode)
                        {
                            case "pos":
                                tmp[i, 0] = tp[i] * tp[i];
                                tmp[i, 1] = tp[i];
                                tmp[i, 2] = 1;
                                break;
                            case "vel":
                                tmp[i, 0] = 2 * tp[i];
                                tmp[i, 1] = 1;
                                tmp[i, 2] = 0;
                                break;
                            case "acc":
                                tmp[i, 0] = 2;
                                tmp[i, 1] = 0;
                                tmp[i, 2] = 0;
                                break;
                        }
                    }
                    double[,] tmp2 = new double[3, 1];
                    Array.Copy(coeff, j * 4, tmp2, 0, 3);
                    sp = Matrix.Product(tmp, tmp2);
                
                }

                for (int i = 0; i < size + 1; i++)
                {
                    scat[(size + 1) * j + i] = sp[i, 0];
                    tcat[(size + 1) * j + i] = tp[i];
                }

            }
            return new PointPairList(tcat, scat);
        }

        private static double[] get_point(double a, double b, int size)
        {
            double[] resilt = new double[size + 1];
            double spacing = (double)(b - a) / size;
            for (int i = 0; i < size + 1; ++i)
            {
                resilt[i] = a + i * spacing;
            }
            return resilt;
        }
    }
    public class Matrix
    {
        public static double[,] Product(double[,] matrixA, double[,] matrixB)
        {
            int aRows = matrixA.GetLength(0);
            int aCols = matrixA.GetLength(1);
            int bRows = matrixB.GetLength(0);
            int bCols = matrixB.GetLength(1);
            if (aCols != bRows)
                throw new Exception("Non-conformable matrices");
            double[,] result = new double[aRows, bCols];
            for (int i = 0; i < aRows; ++i)
                for (int j = 0; j < bCols; ++j)
                    for (int k = 0; k < aCols; ++k)
                        result[i,j] += matrixA[i,k] * matrixB[k,j];
            return result;
        }
        public static double[,] Product(double[,] matrixA, double[] matrixB)
        {
            int aRows = matrixA.GetLength(0);
            int aCols = matrixA.GetLength(1);
            int bRows = matrixB.Length;
            int bCols = 1;
            if (aCols != bRows)
                throw new Exception("Non-conformable matrices");
            double[,] result = new double[aRows, bCols];
            for (int i = 0; i < aRows; ++i)
                for (int j = 0; j < bCols; ++j)
                    for (int k = 0; k < aCols; ++k)
                        result[i, j] += matrixA[i, k] * matrixB[k];
            return result;
        }
        private static double[][] MatrixMult(double[][] matrix1, double[][] matrix2)
        {

            //矩陣中沒有元素的情況
            if (matrix1.Length == 0 || matrix2.Length == 0)
            {
                return new double[][] { };
            }
            //matrix1是m*n矩陣，matrix2是n*p矩陣，則result是m*p矩陣
            int m = matrix1.Length, n = matrix2.Length, p = matrix2[0].Length;
            double[][] result = new double[m][];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new double[p];
            }
            //矩陣乘法：c[i,j]=Sigma(k=1→n,a[i,k]*b[k,j])
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < p; j++)
                {
                    //對乘加法則
                    for (int k = 0; k < n; k++)
                    {
                        result[i][j] += (matrix1[i][k] * matrix2[k][j]);
                    }
                }
            }
            return result;
        }
        public static string AsString(double[,] matrix)
        {
            string s = "";
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                    s += matrix[i,j].ToString("F3").PadLeft(8) + " ";
                s += Environment.NewLine;
            }
            return s;
        }
        public static string AsString(double[] matrix)
        {
            string s = "";
            for (int i = 0; i < matrix.Length; ++i)
            {
                s += matrix[i].ToString("F3").PadLeft(8) + " ";
                s += Environment.NewLine;
            }
            return s;
        }
        public static double[,] Gauss_jordan_elimination(double[,] matrix)
        {
            int size = matrix.GetLength(0);
            double[,] new_matrix = new double[size, size * 2];

            // 填好參數化的部分
            for (int i = 0; i < size; ++i)
            {
                Array.Copy(matrix, i * matrix.GetLength(0), new_matrix, i * new_matrix.GetLength(1), size);
                new_matrix[i, size + i] = 1;
            }

            // 開始進行高斯喬登消去法
            // 內容幾乎與高斯消去法相同
            for (int i = 0; i < size; ++i)
            {
                if (new_matrix[i, i] == 0)
                    for (int j = i + 1; j < size; ++j)
                        if (new_matrix[j, i] != 0)
                        {
                            for (int k = i; k < size * 2; ++k)
                                swap(ref new_matrix[i, k], ref new_matrix[j, k]);
                            break;
                        }

                // 反矩陣不存在。
                //  if (matrix[i][i] == 0) return false;

                double t = new_matrix[i, i];
                for (int k = i; k < size * 2; ++k)
                    new_matrix[i, k] /= t;

                // 消去時，所有橫條通通消去。
                for (int j = 0; j < size; ++j)
                    if (i != j && new_matrix[j, i] != 0)
                    {
                        double tmp = new_matrix[j, i];
                        for (int k = i; k < size * 2; ++k)
                            new_matrix[j, k] -= new_matrix[i, k] * tmp;
                    }
            }
            double[,] result = new double[size, size];

            for (int i = 0; i < size; ++i)
                Array.Copy(new_matrix, size + i * new_matrix.GetLength(1), result, i * result.GetLength(0), size);

            return result;
        }
        private static void swap(ref double matrix_a, ref double matrix_b)
        {
            double c = matrix_a;
            matrix_a = matrix_b;
            matrix_b = c;
        }      
    }    
}