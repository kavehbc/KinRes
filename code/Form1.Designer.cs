namespace KinectRespiratory
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.xtop = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.yTop = new System.Windows.Forms.NumericUpDown();
            this.xBottom = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.yBottom = new System.Windows.Forms.NumericUpDown();
            this.btnRestetdigram = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clmnTimeFrame = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnSlope = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPeak = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmnAmplitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnInVar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnExVar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnPeakVar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslTimeStamp = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslRecords = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslAmp = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslAmpStd = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslCycle = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslCycleStd = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDepthImageAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDiagramAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.peaksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.depthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.showLegendsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStopDiagram = new System.Windows.Forms.Button();
            this.btnShowDigram = new System.Windows.Forms.Button();
            this.video = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.video)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(551, 555);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(71, 35);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Record";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(628, 555);
            this.btnStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(71, 35);
            this.btnStop.TabIndex = 11;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // chart1
            // 
            chartArea1.AxisX.Interval = 10D;
            chartArea1.AxisX.Maximum = 60D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.Title = "Time Spans (sec)";
            chartArea1.AxisY.Interval = 2D;
            chartArea1.AxisY.Maximum = 20D;
            chartArea1.AxisY.Minimum = -20D;
            chartArea1.AxisY.Title = "Depth Distance (mm)";
            chartArea1.CursorX.Interval = 0.2D;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(551, 30);
            this.chart1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Depth";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series2.Legend = "Legend1";
            series2.Name = "Peaks";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(848, 424);
            this.chart1.TabIndex = 10;
            this.chart1.Text = "chart1";
            // 
            // xtop
            // 
            this.xtop.Location = new System.Drawing.Point(68, 563);
            this.xtop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xtop.Maximum = new decimal(new int[] {
            640,
            0,
            0,
            0});
            this.xtop.Name = "xtop";
            this.xtop.Size = new System.Drawing.Size(56, 22);
            this.xtop.TabIndex = 6;
            this.xtop.Value = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.xtop.ValueChanged += new System.EventHandler(this.xtop_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 564);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "X Left:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(256, 564);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "Y Top:";
            // 
            // yTop
            // 
            this.yTop.Location = new System.Drawing.Point(310, 563);
            this.yTop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.yTop.Maximum = new decimal(new int[] {
            480,
            0,
            0,
            0});
            this.yTop.Name = "yTop";
            this.yTop.Size = new System.Drawing.Size(56, 22);
            this.yTop.TabIndex = 8;
            this.yTop.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.yTop.ValueChanged += new System.EventHandler(this.yTop_ValueChanged);
            // 
            // xBottom
            // 
            this.xBottom.Location = new System.Drawing.Point(192, 563);
            this.xBottom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xBottom.Maximum = new decimal(new int[] {
            640,
            0,
            0,
            0});
            this.xBottom.Name = "xBottom";
            this.xBottom.Size = new System.Drawing.Size(56, 22);
            this.xBottom.TabIndex = 7;
            this.xBottom.Value = new decimal(new int[] {
            320,
            0,
            0,
            0});
            this.xBottom.ValueChanged += new System.EventHandler(this.xBottom_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(128, 564);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "X Right:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(371, 564);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 17);
            this.label6.TabIndex = 23;
            this.label6.Text = "Y Bottom:";
            // 
            // yBottom
            // 
            this.yBottom.Location = new System.Drawing.Point(447, 563);
            this.yBottom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.yBottom.Maximum = new decimal(new int[] {
            480,
            0,
            0,
            0});
            this.yBottom.Name = "yBottom";
            this.yBottom.Size = new System.Drawing.Size(56, 22);
            this.yBottom.TabIndex = 9;
            this.yBottom.Value = new decimal(new int[] {
            280,
            0,
            0,
            0});
            this.yBottom.ValueChanged += new System.EventHandler(this.yBottom_ValueChanged);
            // 
            // btnRestetdigram
            // 
            this.btnRestetdigram.Location = new System.Drawing.Point(1270, 554);
            this.btnRestetdigram.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRestetdigram.Name = "btnRestetdigram";
            this.btnRestetdigram.Size = new System.Drawing.Size(130, 34);
            this.btnRestetdigram.TabIndex = 3;
            this.btnRestetdigram.Text = "&Reset";
            this.btnRestetdigram.UseVisualStyleBackColor = true;
            this.btnRestetdigram.Click += new System.EventHandler(this.btnRestetdigram_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnTimeFrame,
            this.clmnValue,
            this.clmnSlope,
            this.clmnPeak,
            this.clmnAmplitude,
            this.clmnInVar,
            this.clmnExVar,
            this.clmnPeakVar});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(16, 594);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1383, 172);
            this.dataGridView1.TabIndex = 36;
            // 
            // clmnTimeFrame
            // 
            this.clmnTimeFrame.HeaderText = "Time (s)";
            this.clmnTimeFrame.Name = "clmnTimeFrame";
            // 
            // clmnValue
            // 
            this.clmnValue.HeaderText = "Value (mm)";
            this.clmnValue.Name = "clmnValue";
            // 
            // clmnSlope
            // 
            this.clmnSlope.HeaderText = "Slope";
            this.clmnSlope.Name = "clmnSlope";
            // 
            // clmnPeak
            // 
            this.clmnPeak.HeaderText = "Peak";
            this.clmnPeak.Name = "clmnPeak";
            // 
            // clmnAmplitude
            // 
            this.clmnAmplitude.HeaderText = "Amplitude (mm)";
            this.clmnAmplitude.Name = "clmnAmplitude";
            // 
            // clmnInVar
            // 
            this.clmnInVar.HeaderText = "Inhale Variability (s)";
            this.clmnInVar.Name = "clmnInVar";
            // 
            // clmnExVar
            // 
            this.clmnExVar.HeaderText = "Exhale Variability (s)";
            this.clmnExVar.Name = "clmnExVar";
            // 
            // clmnPeakVar
            // 
            this.clmnPeakVar.HeaderText = "Peaks Variability (s)";
            this.clmnPeakVar.Name = "clmnPeakVar";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslTimeStamp,
            this.tsslRecords,
            this.tsslAmp,
            this.tsslAmpStd,
            this.tsslCycle,
            this.tsslCycleStd});
            this.statusStrip1.Location = new System.Drawing.Point(0, 768);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1412, 25);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 37;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslTimeStamp
            // 
            this.tsslTimeStamp.Name = "tsslTimeStamp";
            this.tsslTimeStamp.Size = new System.Drawing.Size(89, 20);
            this.tsslTimeStamp.Text = "Time Stamp";
            this.tsslTimeStamp.ToolTipText = "Time Stamp";
            // 
            // tsslRecords
            // 
            this.tsslRecords.Name = "tsslRecords";
            this.tsslRecords.Size = new System.Drawing.Size(57, 20);
            this.tsslRecords.Text = "Recods";
            // 
            // tsslAmp
            // 
            this.tsslAmp.Name = "tsslAmp";
            this.tsslAmp.Size = new System.Drawing.Size(79, 20);
            this.tsslAmp.Text = "Amplitude";
            // 
            // tsslAmpStd
            // 
            this.tsslAmpStd.Name = "tsslAmpStd";
            this.tsslAmpStd.Size = new System.Drawing.Size(131, 20);
            this.tsslAmpStd.Text = "Amplitude StdDev";
            // 
            // tsslCycle
            // 
            this.tsslCycle.Name = "tsslCycle";
            this.tsslCycle.Size = new System.Drawing.Size(50, 20);
            this.tsslCycle.Text = "Cycles";
            // 
            // tsslCycleStd
            // 
            this.tsslCycleStd.Name = "tsslCycleStd";
            this.tsslCycleStd.Size = new System.Drawing.Size(96, 20);
            this.tsslCycleStd.Text = "Cycle StdDev";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1412, 28);
            this.menuStrip1.TabIndex = 41;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveDepthImageAsToolStripMenuItem,
            this.saveDiagramAsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // saveDepthImageAsToolStripMenuItem
            // 
            this.saveDepthImageAsToolStripMenuItem.Name = "saveDepthImageAsToolStripMenuItem";
            this.saveDepthImageAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveDepthImageAsToolStripMenuItem.Size = new System.Drawing.Size(321, 26);
            this.saveDepthImageAsToolStripMenuItem.Text = "&Save depth image as...";
            this.saveDepthImageAsToolStripMenuItem.Click += new System.EventHandler(this.saveDepthImageAsToolStripMenuItem_Click);
            // 
            // saveDiagramAsToolStripMenuItem
            // 
            this.saveDiagramAsToolStripMenuItem.Name = "saveDiagramAsToolStripMenuItem";
            this.saveDiagramAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveDiagramAsToolStripMenuItem.Size = new System.Drawing.Size(321, 26);
            this.saveDiagramAsToolStripMenuItem.Text = "Save &diagram as...";
            this.saveDiagramAsToolStripMenuItem.Click += new System.EventHandler(this.saveDiagramAsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.X)));
            this.toolStripMenuItem1.Size = new System.Drawing.Size(321, 26);
            this.toolStripMenuItem1.Text = "Export to Ex&cel...";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(318, 6);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(321, 26);
            this.toolStripMenuItem4.Text = "Settings...";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(318, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(321, 26);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.peaksToolStripMenuItem,
            this.depthToolStripMenuItem,
            this.toolStripMenuItem5,
            this.showLegendsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // peaksToolStripMenuItem
            // 
            this.peaksToolStripMenuItem.Checked = true;
            this.peaksToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.peaksToolStripMenuItem.Name = "peaksToolStripMenuItem";
            this.peaksToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.peaksToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.peaksToolStripMenuItem.Text = "&Peaks";
            this.peaksToolStripMenuItem.Click += new System.EventHandler(this.peaksToolStripMenuItem_Click);
            // 
            // depthToolStripMenuItem
            // 
            this.depthToolStripMenuItem.Checked = true;
            this.depthToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.depthToolStripMenuItem.Name = "depthToolStripMenuItem";
            this.depthToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.depthToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.depthToolStripMenuItem.Text = "&Depth";
            this.depthToolStripMenuItem.Click += new System.EventHandler(this.depthToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(181, 6);
            // 
            // showLegendsToolStripMenuItem
            // 
            this.showLegendsToolStripMenuItem.Checked = true;
            this.showLegendsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showLegendsToolStripMenuItem.Name = "showLegendsToolStripMenuItem";
            this.showLegendsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.L)));
            this.showLegendsToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.showLegendsToolStripMenuItem.Text = "&Legends";
            this.showLegendsToolStripMenuItem.Click += new System.EventHandler(this.showLegendsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(158, 26);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // btnStopDiagram
            // 
            this.btnStopDiagram.Image = global::KinectRespiratory.Properties.Resources.stop1normalred;
            this.btnStopDiagram.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStopDiagram.Location = new System.Drawing.Point(1133, 554);
            this.btnStopDiagram.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStopDiagram.Name = "btnStopDiagram";
            this.btnStopDiagram.Size = new System.Drawing.Size(131, 34);
            this.btnStopDiagram.TabIndex = 2;
            this.btnStopDiagram.Text = "S&top";
            this.btnStopDiagram.UseVisualStyleBackColor = true;
            this.btnStopDiagram.Click += new System.EventHandler(this.btnStopDiagram_Click);
            // 
            // btnShowDigram
            // 
            this.btnShowDigram.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnShowDigram.Image = global::KinectRespiratory.Properties.Resources.play;
            this.btnShowDigram.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowDigram.Location = new System.Drawing.Point(997, 554);
            this.btnShowDigram.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnShowDigram.Name = "btnShowDigram";
            this.btnShowDigram.Size = new System.Drawing.Size(130, 34);
            this.btnShowDigram.TabIndex = 1;
            this.btnShowDigram.Text = "&Start";
            this.btnShowDigram.UseVisualStyleBackColor = true;
            this.btnShowDigram.Click += new System.EventHandler(this.btnShowDigram_Click);
            // 
            // video
            // 
            this.video.Image = global::KinectRespiratory.Properties.Resources.Microsoft_Kinect_2;
            this.video.Location = new System.Drawing.Point(16, 30);
            this.video.Margin = new System.Windows.Forms.Padding(4);
            this.video.Name = "video";
            this.video.Size = new System.Drawing.Size(512, 424);
            this.video.TabIndex = 1;
            this.video.TabStop = false;
            this.video.Paint += new System.Windows.Forms.PaintEventHandler(this.video_Paint1);
            this.video.MouseDown += new System.Windows.Forms.MouseEventHandler(this.video_MouseDown1);
            this.video.MouseMove += new System.Windows.Forms.MouseEventHandler(this.video_MouseMove1);
            this.video.MouseUp += new System.Windows.Forms.MouseEventHandler(this.video_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1412, 793);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnRestetdigram);
            this.Controls.Add(this.btnStopDiagram);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.yBottom);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.xBottom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.yTop);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.xtop);
            this.Controls.Add(this.btnShowDigram);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.video);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1430, 1361);
            this.MinimumSize = new System.Drawing.Size(1422, 832);
            this.Name = "Form1";
            this.Text = "Kinect Respiratory Signal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.video)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox video;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnShowDigram;
        private System.Windows.Forms.NumericUpDown xtop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown yTop;
        private System.Windows.Forms.NumericUpDown xBottom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown yBottom;
        private System.Windows.Forms.Button btnStopDiagram;
        private System.Windows.Forms.Button btnRestetdigram;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslRecords;
        private System.Windows.Forms.ToolStripStatusLabel tsslAmp;
        private System.Windows.Forms.ToolStripStatusLabel tsslAmpStd;
        private System.Windows.Forms.ToolStripStatusLabel tsslCycle;
        private System.Windows.Forms.ToolStripStatusLabel tsslCycleStd;
        private System.Windows.Forms.ToolStripStatusLabel tsslTimeStamp;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDepthImageAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDiagramAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem peaksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem depthToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem showLegendsToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnTimeFrame;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnSlope;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmnPeak;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnAmplitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnInVar;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnExVar;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnPeakVar;
    }
}

