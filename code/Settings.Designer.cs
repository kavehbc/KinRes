namespace KinectRespiratory
{
    partial class Settings
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
            this.cyclesTxt = new System.Windows.Forms.NumericUpDown();
            this.txtFramePerSecond = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.nupErrorTime = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cyclesTxt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFramePerSecond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupErrorTime)).BeginInit();
            this.SuspendLayout();
            // 
            // cyclesTxt
            // 
            this.cyclesTxt.Location = new System.Drawing.Point(208, 109);
            this.cyclesTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cyclesTxt.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.cyclesTxt.Name = "cyclesTxt";
            this.cyclesTxt.Size = new System.Drawing.Size(90, 26);
            this.cyclesTxt.TabIndex = 3;
            this.cyclesTxt.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // txtFramePerSecond
            // 
            this.txtFramePerSecond.Location = new System.Drawing.Point(208, 21);
            this.txtFramePerSecond.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFramePerSecond.Maximum = new decimal(new int[] {
            640,
            0,
            0,
            0});
            this.txtFramePerSecond.Name = "txtFramePerSecond";
            this.txtFramePerSecond.Size = new System.Drawing.Size(90, 26);
            this.txtFramePerSecond.TabIndex = 1;
            this.txtFramePerSecond.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(143, 20);
            this.label9.TabIndex = 29;
            this.label9.Text = "Min Staring Cycles:";
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(210, 66);
            this.txtDuration.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDuration.Maximum = new decimal(new int[] {
            640,
            0,
            0,
            0});
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(88, 26);
            this.txtDuration.TabIndex = 2;
            this.txtDuration.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 20);
            this.label2.TabIndex = 31;
            this.label2.Text = "Recording Duration (min):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 20);
            this.label1.TabIndex = 30;
            this.label1.Text = "Frames Per Second:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(119, 222);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(84, 34);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(210, 222);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 34);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(14, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(287, 2);
            this.label3.TabIndex = 32;
            // 
            // nupErrorTime
            // 
            this.nupErrorTime.DecimalPlaces = 3;
            this.nupErrorTime.Increment = new decimal(new int[] {
            10,
            0,
            0,
            131072});
            this.nupErrorTime.Location = new System.Drawing.Point(207, 153);
            this.nupErrorTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nupErrorTime.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupErrorTime.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            196608});
            this.nupErrorTime.Name = "nupErrorTime";
            this.nupErrorTime.Size = new System.Drawing.Size(90, 26);
            this.nupErrorTime.TabIndex = 33;
            this.nupErrorTime.Value = new decimal(new int[] {
            300,
            0,
            0,
            196608});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 20);
            this.label4.TabIndex = 34;
            this.label4.Text = "Error Correction (ms)";
            // 
            // Settings
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(324, 272);
            this.Controls.Add(this.nupErrorTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cyclesTxt);
            this.Controls.Add(this.txtFramePerSecond);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cyclesTxt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFramePerSecond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupErrorTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown cyclesTxt;
        private System.Windows.Forms.NumericUpDown txtFramePerSecond;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown txtDuration;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nupErrorTime;
        private System.Windows.Forms.Label label4;
    }
}