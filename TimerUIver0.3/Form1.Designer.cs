namespace TimerUIver0._3
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.to_txt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnsetDone = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.testWin = new System.Windows.Forms.RichTextBox();
            this.btnStartTiming = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.cbCOMport = new System.Windows.Forms.ComboBox();
            this.btnComPort = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lbFilePath = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbUsingTime = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.zedPressure = new ZedGraph.ZedGraphControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnPressureCurveClear = new System.Windows.Forms.Button();
            this.btnPressureSave = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.zedChartData = new ZedGraph.ZedGraphControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.zedGraphControl2 = new ZedGraph.ZedGraphControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDataSave = new System.Windows.Forms.Button();
            this.btnChartDataClear = new System.Windows.Forms.Button();
            this.btnHistoryData = new System.Windows.Forms.Button();
            this.timerUsingTime = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.NOW_user_lable = new System.Windows.Forms.Label();
            this.USER_ID_combobox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_add_distance = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(266, 668);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "設定";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.to_txt, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnsetDone, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.btnReset, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.button1, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.testWin, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnStartTiming, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 27);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 8;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(262, 639);
            this.tableLayoutPanel2.TabIndex = 0;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // to_txt
            // 
            this.to_txt.ForeColor = System.Drawing.Color.Black;
            this.to_txt.Location = new System.Drawing.Point(3, 420);
            this.to_txt.Name = "to_txt";
            this.to_txt.Size = new System.Drawing.Size(261, 30);
            this.to_txt.TabIndex = 0;
            this.to_txt.Text = "另存所有數據";
            this.to_txt.UseVisualStyleBackColor = true;
            this.to_txt.Click += new System.EventHandler(this.to_txt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "序列埠";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnsetDone
            // 
            this.btnsetDone.ForeColor = System.Drawing.Color.Black;
            this.btnsetDone.Location = new System.Drawing.Point(2, 527);
            this.btnsetDone.Margin = new System.Windows.Forms.Padding(2);
            this.btnsetDone.Name = "btnsetDone";
            this.btnsetDone.Size = new System.Drawing.Size(262, 32);
            this.btnsetDone.TabIndex = 5;
            this.btnsetDone.Text = "數據分析";
            this.btnsetDone.UseVisualStyleBackColor = true;
            this.btnsetDone.Click += new System.EventHandler(this.btnsetDone_Click);
            // 
            // btnReset
            // 
            this.btnReset.ForeColor = System.Drawing.Color.Black;
            this.btnReset.Location = new System.Drawing.Point(2, 491);
            this.btnReset.Margin = new System.Windows.Forms.Padding(2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(263, 31);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "清空數據";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 456);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(261, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "讀取歷史數據";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // testWin
            // 
            this.testWin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testWin.Location = new System.Drawing.Point(3, 83);
            this.testWin.Name = "testWin";
            this.testWin.ReadOnly = true;
            this.testWin.Size = new System.Drawing.Size(261, 331);
            this.testWin.TabIndex = 13;
            this.testWin.Text = "";
            this.testWin.TextChanged += new System.EventHandler(this.testWin_TextChanged);
            // 
            // btnStartTiming
            // 
            this.btnStartTiming.ForeColor = System.Drawing.Color.Black;
            this.btnStartTiming.Location = new System.Drawing.Point(2, 563);
            this.btnStartTiming.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartTiming.Name = "btnStartTiming";
            this.btnStartTiming.Size = new System.Drawing.Size(263, 74);
            this.btnStartTiming.TabIndex = 5;
            this.btnStartTiming.Text = "準備計時";
            this.btnStartTiming.UseVisualStyleBackColor = true;
            this.btnStartTiming.Click += new System.EventHandler(this.btnStartTiming_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel3.Controls.Add(this.cbCOMport, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnComPort, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 33);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(255, 35);
            this.tableLayoutPanel3.TabIndex = 13;
            // 
            // cbCOMport
            // 
            this.cbCOMport.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TimerUIver0._3.Properties.Settings.Default, "comPortName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbCOMport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCOMport.FormattingEnabled = true;
            this.cbCOMport.Location = new System.Drawing.Point(2, 2);
            this.cbCOMport.Margin = new System.Windows.Forms.Padding(2);
            this.cbCOMport.Name = "cbCOMport";
            this.cbCOMport.Size = new System.Drawing.Size(121, 31);
            this.cbCOMport.TabIndex = 1;
            this.cbCOMport.Text = global::TimerUIver0._3.Properties.Settings.Default.comPortName;
            this.cbCOMport.DropDown += new System.EventHandler(this.cbCOMport_DropDown);
            this.cbCOMport.SelectedIndexChanged += new System.EventHandler(this.cbCOMport_SelectedIndexChanged);
            // 
            // btnComPort
            // 
            this.btnComPort.CausesValidation = false;
            this.btnComPort.ForeColor = System.Drawing.Color.Black;
            this.btnComPort.Location = new System.Drawing.Point(127, 2);
            this.btnComPort.Margin = new System.Windows.Forms.Padding(2);
            this.btnComPort.Name = "btnComPort";
            this.btnComPort.Size = new System.Drawing.Size(126, 31);
            this.btnComPort.TabIndex = 12;
            this.btnComPort.Text = "連線";
            this.btnComPort.UseVisualStyleBackColor = true;
            this.btnComPort.Click += new System.EventHandler(this.btnComPort_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(8, 8);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "連線狀態";
            // 
            // lbFilePath
            // 
            this.lbFilePath.AutoSize = true;
            this.lbFilePath.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbFilePath.Location = new System.Drawing.Point(340, 8);
            this.lbFilePath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbFilePath.Name = "lbFilePath";
            this.lbFilePath.Size = new System.Drawing.Size(19, 15);
            this.lbFilePath.TabIndex = 1;
            this.lbFilePath.Text = "....";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(289, 8);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 15);
            this.label8.TabIndex = 1;
            this.label8.Text = "檔案路徑";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lbUsingTime);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lbFilePath);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(280, 667);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1195, 33);
            this.panel1.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(180, 8);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 15);
            this.label7.TabIndex = 4;
            this.label7.Text = "位元組數";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(232, 8);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 15);
            this.label9.TabIndex = 5;
            this.label9.Text = "....";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(68, 8);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "使用時間";
            // 
            // lbUsingTime
            // 
            this.lbUsingTime.AutoSize = true;
            this.lbUsingTime.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbUsingTime.Location = new System.Drawing.Point(120, 8);
            this.lbUsingTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbUsingTime.Name = "lbUsingTime";
            this.lbUsingTime.Size = new System.Drawing.Size(19, 15);
            this.lbUsingTime.TabIndex = 3;
            this.lbUsingTime.Text = "....";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.zedPressure);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(2, 2);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(1191, 320);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "壓力曲線";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // zedPressure
            // 
            this.zedPressure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedPressure.Location = new System.Drawing.Point(2, 27);
            this.zedPressure.Margin = new System.Windows.Forms.Padding(6);
            this.zedPressure.Name = "zedPressure";
            this.zedPressure.ScrollGrace = 0D;
            this.zedPressure.ScrollMaxX = 0D;
            this.zedPressure.ScrollMaxY = 0D;
            this.zedPressure.ScrollMaxY2 = 0D;
            this.zedPressure.ScrollMinX = 0D;
            this.zedPressure.ScrollMinY = 0D;
            this.zedPressure.ScrollMinY2 = 0D;
            this.zedPressure.Size = new System.Drawing.Size(1187, 259);
            this.zedPressure.TabIndex = 0;
            this.zedPressure.Load += new System.EventHandler(this.zedPressure_Load);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.btnPressureCurveClear);
            this.panel3.Controls.Add(this.btnPressureSave);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel3.Location = new System.Drawing.Point(2, 286);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1187, 32);
            this.panel3.TabIndex = 1;
            // 
            // btnPressureCurveClear
            // 
            this.btnPressureCurveClear.BackColor = System.Drawing.Color.Transparent;
            this.btnPressureCurveClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPressureCurveClear.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnPressureCurveClear.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPressureCurveClear.Location = new System.Drawing.Point(987, 0);
            this.btnPressureCurveClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnPressureCurveClear.Name = "btnPressureCurveClear";
            this.btnPressureCurveClear.Size = new System.Drawing.Size(102, 32);
            this.btnPressureCurveClear.TabIndex = 0;
            this.btnPressureCurveClear.Text = "清除";
            this.btnPressureCurveClear.UseVisualStyleBackColor = false;
            this.btnPressureCurveClear.Click += new System.EventHandler(this.btnPressureCurveClear_Click);
            // 
            // btnPressureSave
            // 
            this.btnPressureSave.BackColor = System.Drawing.Color.Transparent;
            this.btnPressureSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPressureSave.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnPressureSave.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPressureSave.Location = new System.Drawing.Point(1089, 0);
            this.btnPressureSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnPressureSave.Name = "btnPressureSave";
            this.btnPressureSave.Size = new System.Drawing.Size(98, 32);
            this.btnPressureSave.TabIndex = 1;
            this.btnPressureSave.Text = "儲存";
            this.btnPressureSave.UseVisualStyleBackColor = false;
            this.btnPressureSave.Click += new System.EventHandler(this.btnPressureSave_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.tabControl1);
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(2, 326);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(1191, 339);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "圖表數據";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(2, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1187, 279);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.zedChartData);
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1179, 243);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "速樁原始數據";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // zedChartData
            // 
            this.zedChartData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedChartData.Location = new System.Drawing.Point(3, 3);
            this.zedChartData.Margin = new System.Windows.Forms.Padding(5);
            this.zedChartData.Name = "zedChartData";
            this.zedChartData.ScrollGrace = 0D;
            this.zedChartData.ScrollMaxX = 0D;
            this.zedChartData.ScrollMaxY = 0D;
            this.zedChartData.ScrollMaxY2 = 0D;
            this.zedChartData.ScrollMinX = 0D;
            this.zedChartData.ScrollMinY = 0D;
            this.zedChartData.ScrollMinY2 = 0D;
            this.zedChartData.Size = new System.Drawing.Size(1173, 237);
            this.zedChartData.TabIndex = 2;
            this.zedChartData.Load += new System.EventHandler(this.zedChartData_Load);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.zedGraphControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 32);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1179, 243);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "速度曲線";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl1.Location = new System.Drawing.Point(3, 3);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(5);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(1173, 237);
            this.zedGraphControl1.TabIndex = 3;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.zedGraphControl2);
            this.tabPage5.Location = new System.Drawing.Point(4, 32);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1179, 243);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "加速度曲線";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // zedGraphControl2
            // 
            this.zedGraphControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl2.Location = new System.Drawing.Point(3, 3);
            this.zedGraphControl2.Margin = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.zedGraphControl2.Name = "zedGraphControl2";
            this.zedGraphControl2.ScrollGrace = 0D;
            this.zedGraphControl2.ScrollMaxX = 0D;
            this.zedGraphControl2.ScrollMaxY = 0D;
            this.zedGraphControl2.ScrollMaxY2 = 0D;
            this.zedGraphControl2.ScrollMinX = 0D;
            this.zedGraphControl2.ScrollMinY = 0D;
            this.zedGraphControl2.ScrollMinY2 = 0D;
            this.zedGraphControl2.Size = new System.Drawing.Size(1173, 237);
            this.zedGraphControl2.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnDataSave);
            this.panel2.Controls.Add(this.btnChartDataClear);
            this.panel2.Controls.Add(this.btnHistoryData);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Location = new System.Drawing.Point(2, 306);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1187, 31);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btnDataSave
            // 
            this.btnDataSave.BackColor = System.Drawing.Color.Transparent;
            this.btnDataSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDataSave.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnDataSave.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDataSave.Location = new System.Drawing.Point(823, 0);
            this.btnDataSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnDataSave.Name = "btnDataSave";
            this.btnDataSave.Size = new System.Drawing.Size(120, 31);
            this.btnDataSave.TabIndex = 3;
            this.btnDataSave.Text = "數據儲存";
            this.btnDataSave.UseVisualStyleBackColor = false;
            this.btnDataSave.Click += new System.EventHandler(this.btnDataSave_Click);
            // 
            // btnChartDataClear
            // 
            this.btnChartDataClear.BackColor = System.Drawing.Color.Transparent;
            this.btnChartDataClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnChartDataClear.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnChartDataClear.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnChartDataClear.Location = new System.Drawing.Point(943, 0);
            this.btnChartDataClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnChartDataClear.Name = "btnChartDataClear";
            this.btnChartDataClear.Size = new System.Drawing.Size(122, 31);
            this.btnChartDataClear.TabIndex = 2;
            this.btnChartDataClear.Text = "清除";
            this.btnChartDataClear.UseVisualStyleBackColor = false;
            this.btnChartDataClear.Click += new System.EventHandler(this.btnChartDataClear_Click);
            // 
            // btnHistoryData
            // 
            this.btnHistoryData.BackColor = System.Drawing.Color.Transparent;
            this.btnHistoryData.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnHistoryData.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnHistoryData.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnHistoryData.Location = new System.Drawing.Point(1065, 0);
            this.btnHistoryData.Margin = new System.Windows.Forms.Padding(2);
            this.btnHistoryData.Name = "btnHistoryData";
            this.btnHistoryData.Size = new System.Drawing.Size(122, 31);
            this.btnHistoryData.TabIndex = 1;
            this.btnHistoryData.Text = "歷史資料";
            this.btnHistoryData.UseVisualStyleBackColor = false;
            // 
            // timerUsingTime
            // 
            this.timerUsingTime.Tick += new System.EventHandler(this.timerUsingTime_Tick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 16;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(280, 700);
            this.tabControl2.TabIndex = 4;
            this.tabControl2.DoubleClick += new System.EventHandler(this.tabControl2_DoubleClick);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.button4);
            this.tabPage6.Controls.Add(this.listBox1);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(272, 674);
            this.tabPage6.TabIndex = 2;
            this.tabPage6.Text = "安裝設定";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(8, 149);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 1;
            this.button4.Text = "確認";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(8, 7);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(115, 136);
            this.listBox1.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button5);
            this.tabPage4.Controls.Add(this.button3);
            this.tabPage4.Controls.Add(this.button2);
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Controls.Add(this.NOW_user_lable);
            this.tabPage4.Controls.Add(this.USER_ID_combobox);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.button_add_distance);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(272, 674);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "使用者設定";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.button3.Location = new System.Drawing.Point(8, 212);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(119, 32);
            this.button3.TabIndex = 7;
            this.button3.Text = "另存所有數據";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.button2.Location = new System.Drawing.Point(8, 154);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 30);
            this.button2.TabIndex = 6;
            this.button2.Text = "讀取歷史速樁數據";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label3.Location = new System.Drawing.Point(8, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "尚未加入檔案";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // NOW_user_lable
            // 
            this.NOW_user_lable.AutoSize = true;
            this.NOW_user_lable.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold);
            this.NOW_user_lable.Location = new System.Drawing.Point(152, 13);
            this.NOW_user_lable.Name = "NOW_user_lable";
            this.NOW_user_lable.Size = new System.Drawing.Size(78, 18);
            this.NOW_user_lable.TabIndex = 4;
            this.NOW_user_lable.Text = "現在使用者";
            this.NOW_user_lable.Click += new System.EventHandler(this.NOW_timer_lable_Click);
            // 
            // USER_ID_combobox
            // 
            this.USER_ID_combobox.FormattingEnabled = true;
            this.USER_ID_combobox.Location = new System.Drawing.Point(6, 45);
            this.USER_ID_combobox.Name = "USER_ID_combobox";
            this.USER_ID_combobox.Size = new System.Drawing.Size(121, 20);
            this.USER_ID_combobox.TabIndex = 3;
            this.USER_ID_combobox.DropDown += new System.EventHandler(this.USER_ID_combobox_DropDown);
            this.USER_ID_combobox.SelectedIndexChanged += new System.EventHandler(this.USER_ID_combobox_SelectedIndexChanged);
            this.USER_ID_combobox.SelectedValueChanged += new System.EventHandler(this.USER_ID_combobox_SelectedValueChanged);
            this.USER_ID_combobox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.USER_ID_combobox_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "目前受測者為:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // button_add_distance
            // 
            this.button_add_distance.BackColor = System.Drawing.Color.Transparent;
            this.button_add_distance.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_add_distance.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_add_distance.Location = new System.Drawing.Point(134, 36);
            this.button_add_distance.Margin = new System.Windows.Forms.Padding(2);
            this.button_add_distance.Name = "button_add_distance";
            this.button_add_distance.Size = new System.Drawing.Size(121, 31);
            this.button_add_distance.TabIndex = 1;
            this.button_add_distance.Text = "新增受測者";
            this.button_add_distance.UseVisualStyleBackColor = false;
            this.button_add_distance.Click += new System.EventHandler(this.button_add_UserID_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(272, 674);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "通信設定";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(280, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1195, 667);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.button5.Location = new System.Drawing.Point(8, 110);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(154, 28);
            this.button5.TabIndex = 8;
            this.button5.Text = "讀取歷史起跑數據";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1475, 700);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Timer UI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnsetDone;
        private System.Windows.Forms.Button btnStartTiming;
        private System.Windows.Forms.Label lbFilePath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private ZedGraph.ZedGraphControl zedPressure;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbUsingTime;
        private System.Windows.Forms.Timer timerUsingTime;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnPressureCurveClear;
        private System.Windows.Forms.Button btnPressureSave;
        private System.Windows.Forms.Button btnChartDataClear;
        private System.Windows.Forms.Button btnHistoryData;
        private System.Windows.Forms.Button btnDataSave;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox testWin;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button to_txt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private ZedGraph.ZedGraphControl zedChartData;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnComPort;
        private System.Windows.Forms.ComboBox cbCOMport;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.TabPage tabPage5;
        private ZedGraph.ZedGraphControl zedGraphControl2;
        private System.Windows.Forms.Button button_add_distance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox USER_ID_combobox;
        private System.Windows.Forms.Label NOW_user_lable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

