namespace SerialPlotter_AleksijKraljic
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
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btn_refreshCOM = new System.Windows.Forms.Button();
            this.btn_connect = new System.Windows.Forms.Button();
            this.btn_disconnect = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.comBox = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.baudBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.checkCh1 = new System.Windows.Forms.CheckBox();
            this.checkCh2 = new System.Windows.Forms.CheckBox();
            this.checkCh3 = new System.Windows.Forms.CheckBox();
            this.checkCh4 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.displayCheckBox = new System.Windows.Forms.CheckBox();
            this.numericUDtime = new System.Windows.Forms.NumericUpDown();
            this.numericUDmaxY = new System.Windows.Forms.NumericUpDown();
            this.numericUDminY = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkAutoY = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configDirectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label7 = new System.Windows.Forms.Label();
            this.fileNameBox = new System.Windows.Forms.TextBox();
            this.saveCheckBox = new System.Windows.Forms.CheckBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUDtime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUDmaxY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUDminY)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_refreshCOM
            // 
            this.btn_refreshCOM.Location = new System.Drawing.Point(5, 18);
            this.btn_refreshCOM.Margin = new System.Windows.Forms.Padding(2);
            this.btn_refreshCOM.Name = "btn_refreshCOM";
            this.btn_refreshCOM.Size = new System.Drawing.Size(109, 21);
            this.btn_refreshCOM.TabIndex = 0;
            this.btn_refreshCOM.Text = "Refresh Ports";
            this.btn_refreshCOM.UseVisualStyleBackColor = true;
            this.btn_refreshCOM.Click += new System.EventHandler(this.btn_refreshCOM_Click);
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(11, 26);
            this.btn_connect.Margin = new System.Windows.Forms.Padding(2);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(125, 21);
            this.btn_connect.TabIndex = 1;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // btn_disconnect
            // 
            this.btn_disconnect.Location = new System.Drawing.Point(11, 51);
            this.btn_disconnect.Margin = new System.Windows.Forms.Padding(2);
            this.btn_disconnect.Name = "btn_disconnect";
            this.btn_disconnect.Size = new System.Drawing.Size(125, 21);
            this.btn_disconnect.TabIndex = 2;
            this.btn_disconnect.Text = "Disconnect";
            this.btn_disconnect.UseVisualStyleBackColor = true;
            this.btn_disconnect.Click += new System.EventHandler(this.btn_disconnect_Click);
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(140, 26);
            this.btn_start.Margin = new System.Windows.Forms.Padding(2);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(124, 21);
            this.btn_start.TabIndex = 3;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(141, 51);
            this.btn_stop.Margin = new System.Windows.Forms.Padding(2);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(123, 21);
            this.btn_stop.TabIndex = 4;
            this.btn_stop.Text = "Stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // comBox
            // 
            this.comBox.FormattingEnabled = true;
            this.comBox.Location = new System.Drawing.Point(4, 61);
            this.comBox.Margin = new System.Windows.Forms.Padding(2);
            this.comBox.Name = "comBox";
            this.comBox.Size = new System.Drawing.Size(109, 21);
            this.comBox.TabIndex = 5;
            this.comBox.SelectedIndexChanged += new System.EventHandler(this.comBox_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 51);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(105, 20);
            this.textBox1.TabIndex = 6;
            // 
            // baudBox
            // 
            this.baudBox.FormattingEnabled = true;
            this.baudBox.Location = new System.Drawing.Point(4, 103);
            this.baudBox.Margin = new System.Windows.Forms.Padding(2);
            this.baudBox.Name = "baudBox";
            this.baudBox.Size = new System.Drawing.Size(109, 21);
            this.baudBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "COM Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 88);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Baud Rate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 35);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Channel 1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 73);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Channel 2";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 89);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(105, 20);
            this.textBox2.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 111);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Channel 3";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(6, 127);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(105, 20);
            this.textBox3.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 149);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Channel 4";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(6, 165);
            this.textBox4.Margin = new System.Windows.Forms.Padding(2);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(105, 20);
            this.textBox4.TabIndex = 15;
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(11, 260);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(508, 325);
            this.zedGraphControl1.TabIndex = 17;
            // 
            // timer1
            // 
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // checkCh1
            // 
            this.checkCh1.AutoSize = true;
            this.checkCh1.Location = new System.Drawing.Point(6, 24);
            this.checkCh1.Name = "checkCh1";
            this.checkCh1.Size = new System.Drawing.Size(74, 17);
            this.checkCh1.TabIndex = 18;
            this.checkCh1.Text = "Channel 1";
            this.checkCh1.UseVisualStyleBackColor = true;
            // 
            // checkCh2
            // 
            this.checkCh2.AutoSize = true;
            this.checkCh2.Location = new System.Drawing.Point(6, 47);
            this.checkCh2.Name = "checkCh2";
            this.checkCh2.Size = new System.Drawing.Size(74, 17);
            this.checkCh2.TabIndex = 19;
            this.checkCh2.Text = "Channel 2";
            this.checkCh2.UseVisualStyleBackColor = true;
            // 
            // checkCh3
            // 
            this.checkCh3.AutoSize = true;
            this.checkCh3.Location = new System.Drawing.Point(6, 70);
            this.checkCh3.Name = "checkCh3";
            this.checkCh3.Size = new System.Drawing.Size(74, 17);
            this.checkCh3.TabIndex = 20;
            this.checkCh3.Text = "Channel 3";
            this.checkCh3.UseVisualStyleBackColor = true;
            // 
            // checkCh4
            // 
            this.checkCh4.AutoSize = true;
            this.checkCh4.Location = new System.Drawing.Point(6, 94);
            this.checkCh4.Name = "checkCh4";
            this.checkCh4.Size = new System.Drawing.Size(74, 17);
            this.checkCh4.TabIndex = 21;
            this.checkCh4.Text = "Channel 4";
            this.checkCh4.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comBox);
            this.groupBox1.Controls.Add(this.baudBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btn_refreshCOM);
            this.groupBox1.Location = new System.Drawing.Point(12, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(124, 134);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial Config";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkCh1);
            this.groupBox2.Controls.Add(this.checkCh2);
            this.groupBox2.Controls.Add(this.checkCh4);
            this.groupBox2.Controls.Add(this.checkCh3);
            this.groupBox2.Location = new System.Drawing.Point(142, 77);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(122, 119);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Channel Select";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.displayCheckBox);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.textBox4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.textBox3);
            this.groupBox3.Location = new System.Drawing.Point(269, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(122, 192);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Data";
            // 
            // displayCheckBox
            // 
            this.displayCheckBox.AutoSize = true;
            this.displayCheckBox.Location = new System.Drawing.Point(6, 18);
            this.displayCheckBox.Name = "displayCheckBox";
            this.displayCheckBox.Size = new System.Drawing.Size(95, 17);
            this.displayCheckBox.TabIndex = 38;
            this.displayCheckBox.Text = "Display Values";
            this.displayCheckBox.UseVisualStyleBackColor = true;
            // 
            // numericUDtime
            // 
            this.numericUDtime.DecimalPlaces = 1;
            this.numericUDtime.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUDtime.Location = new System.Drawing.Point(8, 52);
            this.numericUDtime.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUDtime.Name = "numericUDtime";
            this.numericUDtime.Size = new System.Drawing.Size(104, 20);
            this.numericUDtime.TabIndex = 27;
            this.numericUDtime.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUDtime.ValueChanged += new System.EventHandler(this.numericUDtime_ValueChanged);
            // 
            // numericUDmaxY
            // 
            this.numericUDmaxY.DecimalPlaces = 1;
            this.numericUDmaxY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUDmaxY.Location = new System.Drawing.Point(8, 90);
            this.numericUDmaxY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUDmaxY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUDmaxY.Name = "numericUDmaxY";
            this.numericUDmaxY.Size = new System.Drawing.Size(104, 20);
            this.numericUDmaxY.TabIndex = 28;
            this.numericUDmaxY.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUDmaxY.ValueChanged += new System.EventHandler(this.numericUDmaxY_ValueChanged);
            // 
            // numericUDminY
            // 
            this.numericUDminY.DecimalPlaces = 1;
            this.numericUDminY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUDminY.Location = new System.Drawing.Point(8, 130);
            this.numericUDminY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUDminY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUDminY.Name = "numericUDminY";
            this.numericUDminY.Size = new System.Drawing.Size(104, 20);
            this.numericUDminY.TabIndex = 29;
            this.numericUDminY.ValueChanged += new System.EventHandler(this.numericUDminY_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 37);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Time Range";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 74);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Max Y";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 114);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 33;
            this.label10.Text = "Min Y";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkAutoY);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.numericUDtime);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.numericUDmaxY);
            this.groupBox4.Controls.Add(this.numericUDminY);
            this.groupBox4.Location = new System.Drawing.Point(398, 26);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(122, 162);
            this.groupBox4.TabIndex = 34;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Axis Control";
            // 
            // checkAutoY
            // 
            this.checkAutoY.AutoSize = true;
            this.checkAutoY.Location = new System.Drawing.Point(6, 19);
            this.checkAutoY.Name = "checkAutoY";
            this.checkAutoY.Size = new System.Drawing.Size(80, 17);
            this.checkAutoY.TabIndex = 35;
            this.checkAutoY.Text = "Auto Y Axis";
            this.checkAutoY.UseVisualStyleBackColor = true;
            this.checkAutoY.CheckedChanged += new System.EventHandler(this.checkAutoY_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configDirectionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(529, 24);
            this.menuStrip1.TabIndex = 35;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configDirectionsToolStripMenuItem
            // 
            this.configDirectionsToolStripMenuItem.Name = "configDirectionsToolStripMenuItem";
            this.configDirectionsToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.configDirectionsToolStripMenuItem.Text = "Config Directions";
            this.configDirectionsToolStripMenuItem.Click += new System.EventHandler(this.configDirectionsToolStripMenuItem_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(393, 212);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Output File Name";
            // 
            // fileNameBox
            // 
            this.fileNameBox.Location = new System.Drawing.Point(395, 228);
            this.fileNameBox.Name = "fileNameBox";
            this.fileNameBox.Size = new System.Drawing.Size(123, 20);
            this.fileNameBox.TabIndex = 37;
            // 
            // saveCheckBox
            // 
            this.saveCheckBox.AutoSize = true;
            this.saveCheckBox.Location = new System.Drawing.Point(396, 192);
            this.saveCheckBox.Name = "saveCheckBox";
            this.saveCheckBox.Size = new System.Drawing.Size(123, 17);
            this.saveCheckBox.TabIndex = 40;
            this.saveCheckBox.Text = "Save Measurements";
            this.saveCheckBox.UseVisualStyleBackColor = true;
            this.saveCheckBox.CheckedChanged += new System.EventHandler(this.saveCheckBox_CheckedChanged);
            // 
            // timer2
            // 
            this.timer2.Interval = 50;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 597);
            this.Controls.Add(this.saveCheckBox);
            this.Controls.Add(this.fileNameBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.btn_disconnect);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUDtime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUDmaxY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUDminY)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btn_refreshCOM;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Button btn_disconnect;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.ComboBox comBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox baudBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox4;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkCh1;
        private System.Windows.Forms.CheckBox checkCh2;
        private System.Windows.Forms.CheckBox checkCh3;
        private System.Windows.Forms.CheckBox checkCh4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numericUDtime;
        private System.Windows.Forms.NumericUpDown numericUDmaxY;
        private System.Windows.Forms.NumericUpDown numericUDminY;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox checkAutoY;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configDirectionsToolStripMenuItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox fileNameBox;
        private System.Windows.Forms.CheckBox displayCheckBox;
        private System.Windows.Forms.CheckBox saveCheckBox;
        private System.Windows.Forms.Timer timer2;
    }
}

