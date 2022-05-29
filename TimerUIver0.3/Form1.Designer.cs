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
            this.testWin = new System.Windows.Forms.RichTextBox();
            this.btnComPort = new System.Windows.Forms.Button();
            this.cbRacerName = new System.Windows.Forms.ComboBox();
            this.listbData = new System.Windows.Forms.ListBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnRemoveName = new System.Windows.Forms.Button();
            this.btnAddName = new System.Windows.Forms.Button();
            this.tbInputName = new System.Windows.Forms.TextBox();
            this.btnPillarNum = new System.Windows.Forms.Button();
            this.btnChooseSheet = new System.Windows.Forms.Button();
            this.btnImportFile = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnsetDone = new System.Windows.Forms.Button();
            this.btnStartTiming = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.to_txt = new System.Windows.Forms.Button();
            this.listbHint = new System.Windows.Forms.ListBox();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btnPillarDistance = new System.Windows.Forms.Button();
            this.cbCOMport = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbPillarHint = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
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
            this.btnPressureSave = new System.Windows.Forms.Button();
            this.btnPressureCurveClear = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.zedChartData = new ZedGraph.ZedGraphControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDataSave = new System.Windows.Forms.Button();
            this.btnChartDataClear = new System.Windows.Forms.Button();
            this.btnHistoryData = new System.Windows.Forms.Button();
            this.timerUsingTime = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.testWin);
            this.groupBox1.Controls.Add(this.btnComPort);
            this.groupBox1.Controls.Add(this.cbRacerName);
            this.groupBox1.Controls.Add(this.listbData);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.btnRemoveName);
            this.groupBox1.Controls.Add(this.btnAddName);
            this.groupBox1.Controls.Add(this.tbInputName);
            this.groupBox1.Controls.Add(this.btnPillarNum);
            this.groupBox1.Controls.Add(this.btnChooseSheet);
            this.groupBox1.Controls.Add(this.btnImportFile);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnsetDone);
            this.groupBox1.Controls.Add(this.btnStartTiming);
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Controls.Add(this.listbHint);
            this.groupBox1.Controls.Add(this.numericUpDown2);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.btnPillarDistance);
            this.groupBox1.Controls.Add(this.cbCOMport);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lbPillarHint);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(284, 693);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "設定";
            // 
            // testWin
            // 
            this.testWin.Location = new System.Drawing.Point(144, 585);
            this.testWin.Name = "testWin";
            this.testWin.ReadOnly = true;
            this.testWin.Size = new System.Drawing.Size(134, 96);
            this.testWin.TabIndex = 13;
            this.testWin.Text = "";
            this.testWin.TextChanged += new System.EventHandler(this.testWin_TextChanged);
            // 
            // btnComPort
            // 
            this.btnComPort.ForeColor = System.Drawing.Color.Black;
            this.btnComPort.Location = new System.Drawing.Point(214, 53);
            this.btnComPort.Margin = new System.Windows.Forms.Padding(2);
            this.btnComPort.Name = "btnComPort";
            this.btnComPort.Size = new System.Drawing.Size(64, 32);
            this.btnComPort.TabIndex = 12;
            this.btnComPort.Text = "連線";
            this.btnComPort.UseVisualStyleBackColor = true;
            this.btnComPort.Click += new System.EventHandler(this.btnComPort_Click);
            // 
            // cbRacerName
            // 
            this.cbRacerName.FormattingEnabled = true;
            this.cbRacerName.Location = new System.Drawing.Point(8, 116);
            this.cbRacerName.Margin = new System.Windows.Forms.Padding(2);
            this.cbRacerName.Name = "cbRacerName";
            this.cbRacerName.Size = new System.Drawing.Size(271, 31);
            this.cbRacerName.TabIndex = 1;
            // 
            // listbData
            // 
            this.listbData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listbData.FormattingEnabled = true;
            this.listbData.ItemHeight = 23;
            this.listbData.Location = new System.Drawing.Point(9, 585);
            this.listbData.Margin = new System.Windows.Forms.Padding(2);
            this.listbData.Name = "listbData";
            this.listbData.Size = new System.Drawing.Size(118, 96);
            this.listbData.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(77, 87);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(49, 24);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.Visible = false;
            // 
            // btnRemoveName
            // 
            this.btnRemoveName.ForeColor = System.Drawing.Color.Black;
            this.btnRemoveName.Location = new System.Drawing.Point(76, 152);
            this.btnRemoveName.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveName.Name = "btnRemoveName";
            this.btnRemoveName.Size = new System.Drawing.Size(64, 32);
            this.btnRemoveName.TabIndex = 10;
            this.btnRemoveName.Text = "移除";
            this.btnRemoveName.UseVisualStyleBackColor = true;
            this.btnRemoveName.Click += new System.EventHandler(this.btnRemoveName_Click);
            // 
            // btnAddName
            // 
            this.btnAddName.ForeColor = System.Drawing.Color.Black;
            this.btnAddName.Location = new System.Drawing.Point(8, 152);
            this.btnAddName.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddName.Name = "btnAddName";
            this.btnAddName.Size = new System.Drawing.Size(64, 32);
            this.btnAddName.TabIndex = 11;
            this.btnAddName.Text = "新增";
            this.btnAddName.UseVisualStyleBackColor = true;
            this.btnAddName.Click += new System.EventHandler(this.btnAddName_Click);
            // 
            // tbInputName
            // 
            this.tbInputName.Location = new System.Drawing.Point(8, 116);
            this.tbInputName.Margin = new System.Windows.Forms.Padding(2);
            this.tbInputName.Name = "tbInputName";
            this.tbInputName.Size = new System.Drawing.Size(133, 32);
            this.tbInputName.TabIndex = 1;
            this.tbInputName.Visible = false;
            // 
            // btnPillarNum
            // 
            this.btnPillarNum.ForeColor = System.Drawing.Color.Black;
            this.btnPillarNum.Location = new System.Drawing.Point(214, 192);
            this.btnPillarNum.Margin = new System.Windows.Forms.Padding(2);
            this.btnPillarNum.Name = "btnPillarNum";
            this.btnPillarNum.Size = new System.Drawing.Size(64, 32);
            this.btnPillarNum.TabIndex = 9;
            this.btnPillarNum.Text = "確認";
            this.btnPillarNum.UseVisualStyleBackColor = true;
            this.btnPillarNum.Click += new System.EventHandler(this.btnPillarNum_Click);
            // 
            // btnChooseSheet
            // 
            this.btnChooseSheet.ForeColor = System.Drawing.Color.Black;
            this.btnChooseSheet.Location = new System.Drawing.Point(214, 152);
            this.btnChooseSheet.Margin = new System.Windows.Forms.Padding(2);
            this.btnChooseSheet.Name = "btnChooseSheet";
            this.btnChooseSheet.Size = new System.Drawing.Size(64, 32);
            this.btnChooseSheet.TabIndex = 1;
            this.btnChooseSheet.Text = "選擇";
            this.btnChooseSheet.UseVisualStyleBackColor = true;
            this.btnChooseSheet.Click += new System.EventHandler(this.btnChooseSheet_Click);
            // 
            // btnImportFile
            // 
            this.btnImportFile.ForeColor = System.Drawing.Color.Black;
            this.btnImportFile.Location = new System.Drawing.Point(146, 152);
            this.btnImportFile.Margin = new System.Windows.Forms.Padding(2);
            this.btnImportFile.Name = "btnImportFile";
            this.btnImportFile.Size = new System.Drawing.Size(64, 32);
            this.btnImportFile.TabIndex = 1;
            this.btnImportFile.Text = "匯入";
            this.btnImportFile.UseVisualStyleBackColor = true;
            this.btnImportFile.Click += new System.EventHandler(this.btnImportFile_Click);
            // 
            // btnReset
            // 
            this.btnReset.ForeColor = System.Drawing.Color.Black;
            this.btnReset.Location = new System.Drawing.Point(9, 492);
            this.btnReset.Margin = new System.Windows.Forms.Padding(2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(135, 42);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "重新設定";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnsetDone
            // 
            this.btnsetDone.ForeColor = System.Drawing.Color.Black;
            this.btnsetDone.Location = new System.Drawing.Point(144, 492);
            this.btnsetDone.Margin = new System.Windows.Forms.Padding(2);
            this.btnsetDone.Name = "btnsetDone";
            this.btnsetDone.Size = new System.Drawing.Size(135, 42);
            this.btnsetDone.TabIndex = 5;
            this.btnsetDone.Text = "設定完畢";
            this.btnsetDone.UseVisualStyleBackColor = true;
            this.btnsetDone.Click += new System.EventHandler(this.btnsetDone_Click);
            // 
            // btnStartTiming
            // 
            this.btnStartTiming.ForeColor = System.Drawing.Color.Black;
            this.btnStartTiming.Location = new System.Drawing.Point(9, 538);
            this.btnStartTiming.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartTiming.Name = "btnStartTiming";
            this.btnStartTiming.Size = new System.Drawing.Size(269, 42);
            this.btnStartTiming.TabIndex = 5;
            this.btnStartTiming.Text = "準備計時";
            this.btnStartTiming.UseVisualStyleBackColor = true;
            this.btnStartTiming.Click += new System.EventHandler(this.btnStartTiming_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.to_txt);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(10, 394);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(269, 93);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // to_txt
            // 
            this.to_txt.ForeColor = System.Drawing.Color.Black;
            this.to_txt.Location = new System.Drawing.Point(3, 3);
            this.to_txt.Name = "to_txt";
            this.to_txt.Size = new System.Drawing.Size(106, 35);
            this.to_txt.TabIndex = 0;
            this.to_txt.Text = "放入txt";
            this.to_txt.UseVisualStyleBackColor = true;
            this.to_txt.Click += new System.EventHandler(this.to_txt_Click);
            // 
            // listbHint
            // 
            this.listbHint.FormattingEnabled = true;
            this.listbHint.ItemHeight = 23;
            this.listbHint.Location = new System.Drawing.Point(10, 294);
            this.listbHint.Margin = new System.Windows.Forms.Padding(2);
            this.listbHint.Name = "listbHint";
            this.listbHint.Size = new System.Drawing.Size(270, 96);
            this.listbHint.TabIndex = 3;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(147, 228);
            this.numericUpDown2.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(64, 32);
            this.numericUpDown2.TabIndex = 2;
            this.numericUpDown2.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(147, 191);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(64, 32);
            this.numericUpDown1.TabIndex = 1;
            // 
            // btnPillarDistance
            // 
            this.btnPillarDistance.ForeColor = System.Drawing.Color.Black;
            this.btnPillarDistance.Location = new System.Drawing.Point(214, 228);
            this.btnPillarDistance.Margin = new System.Windows.Forms.Padding(2);
            this.btnPillarDistance.Name = "btnPillarDistance";
            this.btnPillarDistance.Size = new System.Drawing.Size(64, 32);
            this.btnPillarDistance.TabIndex = 1;
            this.btnPillarDistance.Text = "確認";
            this.btnPillarDistance.UseVisualStyleBackColor = true;
            this.btnPillarDistance.Click += new System.EventHandler(this.btnPillarDistance_Click);
            // 
            // cbCOMport
            // 
            this.cbCOMport.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TimerUIver0._3.Properties.Settings.Default, "comPortName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbCOMport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCOMport.FormattingEnabled = true;
            this.cbCOMport.Location = new System.Drawing.Point(8, 53);
            this.cbCOMport.Margin = new System.Windows.Forms.Padding(2);
            this.cbCOMport.Name = "cbCOMport";
            this.cbCOMport.Size = new System.Drawing.Size(203, 31);
            this.cbCOMport.TabIndex = 1;
            this.cbCOMport.Text = global::TimerUIver0._3.Properties.Settings.Default.comPortName;
            this.cbCOMport.DropDown += new System.EventHandler(this.cbCOMport_DropDown);
            this.cbCOMport.SelectedIndexChanged += new System.EventHandler(this.cbCOMport_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 230);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 24);
            this.label4.TabIndex = 1;
            this.label4.Text = "速樁間距(m)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 192);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "速樁數量";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 87);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "受測者";
            // 
            // lbPillarHint
            // 
            this.lbPillarHint.AutoSize = true;
            this.lbPillarHint.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbPillarHint.Location = new System.Drawing.Point(7, 262);
            this.lbPillarHint.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbPillarHint.Name = "lbPillarHint";
            this.lbPillarHint.Size = new System.Drawing.Size(64, 18);
            this.lbPillarHint.TabIndex = 1;
            this.lbPillarHint.Text = "速樁提示";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "序列埠";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 23;
            this.listBox1.Location = new System.Drawing.Point(108, 321);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(19, 27);
            this.listBox1.TabIndex = 0;
            this.listBox1.Visible = false;
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
            this.panel1.Location = new System.Drawing.Point(0, 702);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1475, 33);
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
            this.groupBox2.Controls.Add(this.zedPressure);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(288, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(1187, 291);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "壓力曲線";
            // 
            // zedPressure
            // 
            this.zedPressure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedPressure.Location = new System.Drawing.Point(124, 27);
            this.zedPressure.Margin = new System.Windows.Forms.Padding(5);
            this.zedPressure.Name = "zedPressure";
            this.zedPressure.ScrollGrace = 0D;
            this.zedPressure.ScrollMaxX = 0D;
            this.zedPressure.ScrollMaxY = 0D;
            this.zedPressure.ScrollMaxY2 = 0D;
            this.zedPressure.ScrollMinX = 0D;
            this.zedPressure.ScrollMinY = 0D;
            this.zedPressure.ScrollMinY2 = 0D;
            this.zedPressure.Size = new System.Drawing.Size(1061, 262);
            this.zedPressure.TabIndex = 0;
            this.zedPressure.Load += new System.EventHandler(this.zedPressure_Load);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnPressureSave);
            this.panel3.Controls.Add(this.btnPressureCurveClear);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(2, 27);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(122, 262);
            this.panel3.TabIndex = 1;
            // 
            // btnPressureSave
            // 
            this.btnPressureSave.BackColor = System.Drawing.Color.Black;
            this.btnPressureSave.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnPressureSave.Location = new System.Drawing.Point(0, 180);
            this.btnPressureSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnPressureSave.Name = "btnPressureSave";
            this.btnPressureSave.Size = new System.Drawing.Size(122, 41);
            this.btnPressureSave.TabIndex = 1;
            this.btnPressureSave.Text = "儲存";
            this.btnPressureSave.UseVisualStyleBackColor = false;
            this.btnPressureSave.Click += new System.EventHandler(this.btnPressureSave_Click);
            // 
            // btnPressureCurveClear
            // 
            this.btnPressureCurveClear.BackColor = System.Drawing.Color.Black;
            this.btnPressureCurveClear.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnPressureCurveClear.Location = new System.Drawing.Point(0, 221);
            this.btnPressureCurveClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnPressureCurveClear.Name = "btnPressureCurveClear";
            this.btnPressureCurveClear.Size = new System.Drawing.Size(122, 41);
            this.btnPressureCurveClear.TabIndex = 0;
            this.btnPressureCurveClear.Text = "清除";
            this.btnPressureCurveClear.UseVisualStyleBackColor = false;
            this.btnPressureCurveClear.Click += new System.EventHandler(this.btnPressureCurveClear_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.zedChartData);
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(288, 321);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(1185, 372);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "圖表數據";
            // 
            // zedChartData
            // 
            this.zedChartData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedChartData.Location = new System.Drawing.Point(124, 27);
            this.zedChartData.Margin = new System.Windows.Forms.Padding(9, 10, 9, 10);
            this.zedChartData.Name = "zedChartData";
            this.zedChartData.ScrollGrace = 0D;
            this.zedChartData.ScrollMaxX = 0D;
            this.zedChartData.ScrollMaxY = 0D;
            this.zedChartData.ScrollMaxY2 = 0D;
            this.zedChartData.ScrollMinX = 0D;
            this.zedChartData.ScrollMinY = 0D;
            this.zedChartData.ScrollMinY2 = 0D;
            this.zedChartData.Size = new System.Drawing.Size(1059, 343);
            this.zedChartData.TabIndex = 1;
            this.zedChartData.Load += new System.EventHandler(this.zedChartData_Load);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDataSave);
            this.panel2.Controls.Add(this.btnChartDataClear);
            this.panel2.Controls.Add(this.btnHistoryData);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(2, 27);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(122, 343);
            this.panel2.TabIndex = 2;
            // 
            // btnDataSave
            // 
            this.btnDataSave.BackColor = System.Drawing.Color.Black;
            this.btnDataSave.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDataSave.Location = new System.Drawing.Point(0, 220);
            this.btnDataSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnDataSave.Name = "btnDataSave";
            this.btnDataSave.Size = new System.Drawing.Size(122, 41);
            this.btnDataSave.TabIndex = 3;
            this.btnDataSave.Text = "數據儲存";
            this.btnDataSave.UseVisualStyleBackColor = false;
            this.btnDataSave.Click += new System.EventHandler(this.btnDataSave_Click);
            // 
            // btnChartDataClear
            // 
            this.btnChartDataClear.BackColor = System.Drawing.Color.Black;
            this.btnChartDataClear.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnChartDataClear.Location = new System.Drawing.Point(0, 261);
            this.btnChartDataClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnChartDataClear.Name = "btnChartDataClear";
            this.btnChartDataClear.Size = new System.Drawing.Size(122, 41);
            this.btnChartDataClear.TabIndex = 2;
            this.btnChartDataClear.Text = "清除";
            this.btnChartDataClear.UseVisualStyleBackColor = false;
            this.btnChartDataClear.Click += new System.EventHandler(this.btnChartDataClear_Click);
            // 
            // btnHistoryData
            // 
            this.btnHistoryData.BackColor = System.Drawing.Color.Black;
            this.btnHistoryData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnHistoryData.Location = new System.Drawing.Point(0, 302);
            this.btnHistoryData.Margin = new System.Windows.Forms.Padding(2);
            this.btnHistoryData.Name = "btnHistoryData";
            this.btnHistoryData.Size = new System.Drawing.Size(122, 41);
            this.btnHistoryData.TabIndex = 1;
            this.btnHistoryData.Text = "歷史資料";
            this.btnHistoryData.UseVisualStyleBackColor = false;
            this.btnHistoryData.Click += new System.EventHandler(this.btnHistoryData_Click);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1475, 735);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Timer UI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPillarDistance;
        private System.Windows.Forms.ComboBox cbCOMport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnsetDone;
        private System.Windows.Forms.Button btnStartTiming;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ListBox listbHint;
        private System.Windows.Forms.Button btnImportFile;
        private System.Windows.Forms.Button btnPillarNum;
        private System.Windows.Forms.Label lbPillarHint;
        private System.Windows.Forms.ComboBox cbRacerName;
        private System.Windows.Forms.TextBox tbInputName;
        private System.Windows.Forms.Label lbFilePath;
        private System.Windows.Forms.Button btnChooseSheet;
        private System.Windows.Forms.Button btnRemoveName;
        private System.Windows.Forms.Button btnAddName;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listbData;
        private System.Windows.Forms.GroupBox groupBox2;
        private ZedGraph.ZedGraphControl zedPressure;
        private System.Windows.Forms.GroupBox groupBox3;
        private ZedGraph.ZedGraphControl zedChartData;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbUsingTime;
        private System.Windows.Forms.Timer timerUsingTime;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnPressureCurveClear;
        private System.Windows.Forms.Button btnPressureSave;
        private System.Windows.Forms.Button btnChartDataClear;
        private System.Windows.Forms.Button btnHistoryData;
        private System.Windows.Forms.Button btnDataSave;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnComPort;
        private System.Windows.Forms.RichTextBox testWin;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button to_txt;
    }
}

