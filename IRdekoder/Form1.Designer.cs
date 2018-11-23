namespace IRdekoder
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.portlist = new System.Windows.Forms.ComboBox();
            this.baudlist = new System.Windows.Forms.ComboBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonSaveTime = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonPlot = new System.Windows.Forms.Button();
            this.buttonSaveChart = new System.Windows.Forms.Button();
            this.buttonClearPlot = new System.Windows.Forms.Button();
            this.bitlist = new System.Windows.Forms.ComboBox();
            this.buttonPlotBits = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonSaveExcel = new System.Windows.Forms.Button();
            this.pulselist = new System.Windows.Forms.ComboBox();
            this.pulse_text = new System.Windows.Forms.TextBox();
            this.buttonTry = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // portlist
            // 
            this.portlist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portlist.FormattingEnabled = true;
            this.portlist.Location = new System.Drawing.Point(26, 34);
            this.portlist.Name = "portlist";
            this.portlist.Size = new System.Drawing.Size(121, 21);
            this.portlist.TabIndex = 0;
            // 
            // baudlist
            // 
            this.baudlist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.baudlist.FormattingEnabled = true;
            this.baudlist.Items.AddRange(new object[] {
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600"});
            this.baudlist.Location = new System.Drawing.Point(153, 34);
            this.baudlist.Name = "baudlist";
            this.baudlist.Size = new System.Drawing.Size(121, 21);
            this.baudlist.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(292, 31);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(98, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonClear);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(26, 396);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(151, 277);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Receive";
            // 
            // buttonClear
            // 
            this.buttonClear.Enabled = false;
            this.buttonClear.Location = new System.Drawing.Point(6, 248);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(138, 23);
            this.buttonClear.TabIndex = 1;
            this.buttonClear.Text = "Clear All";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(6, 19);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(138, 223);
            this.textBox1.TabIndex = 0;
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(26, 61);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(75, 23);
            this.buttonOpen.TabIndex = 4;
            this.buttonOpen.Text = "Open Port";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Enabled = false;
            this.buttonClose.Location = new System.Drawing.Point(107, 61);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 5;
            this.buttonClose.Text = "Close Port";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonSaveTime
            // 
            this.buttonSaveTime.Enabled = false;
            this.buttonSaveTime.Location = new System.Drawing.Point(183, 404);
            this.buttonSaveTime.Name = "buttonSaveTime";
            this.buttonSaveTime.Size = new System.Drawing.Size(75, 41);
            this.buttonSaveTime.TabIndex = 6;
            this.buttonSaveTime.Text = "Save times to txt";
            this.buttonSaveTime.UseVisualStyleBackColor = true;
            this.buttonSaveTime.Click += new System.EventHandler(this.buttonSaveTime_Click);
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox2.ForeColor = System.Drawing.Color.Red;
            this.textBox2.Location = new System.Drawing.Point(396, 30);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(292, 24);
            this.textBox2.TabIndex = 7;
            this.textBox2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Port name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Baud rate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(289, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Status";
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(26, 90);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(1585, 300);
            this.chart1.TabIndex = 11;
            this.chart1.Text = "chart1";
            // 
            // buttonPlot
            // 
            this.buttonPlot.Enabled = false;
            this.buttonPlot.Location = new System.Drawing.Point(183, 545);
            this.buttonPlot.Name = "buttonPlot";
            this.buttonPlot.Size = new System.Drawing.Size(75, 41);
            this.buttonPlot.TabIndex = 12;
            this.buttonPlot.Text = "Plot";
            this.buttonPlot.UseVisualStyleBackColor = true;
            this.buttonPlot.Click += new System.EventHandler(this.buttonPlot_Click);
            // 
            // buttonSaveChart
            // 
            this.buttonSaveChart.Enabled = false;
            this.buttonSaveChart.Location = new System.Drawing.Point(183, 498);
            this.buttonSaveChart.Name = "buttonSaveChart";
            this.buttonSaveChart.Size = new System.Drawing.Size(75, 41);
            this.buttonSaveChart.TabIndex = 13;
            this.buttonSaveChart.Text = "Save Chart";
            this.buttonSaveChart.UseVisualStyleBackColor = true;
            this.buttonSaveChart.Click += new System.EventHandler(this.buttonSaveChart_Click);
            // 
            // buttonClearPlot
            // 
            this.buttonClearPlot.Enabled = false;
            this.buttonClearPlot.Location = new System.Drawing.Point(183, 592);
            this.buttonClearPlot.Name = "buttonClearPlot";
            this.buttonClearPlot.Size = new System.Drawing.Size(75, 41);
            this.buttonClearPlot.TabIndex = 14;
            this.buttonClearPlot.Text = "Clear Plot";
            this.buttonClearPlot.UseVisualStyleBackColor = true;
            this.buttonClearPlot.Click += new System.EventHandler(this.buttonClearPlot_Click);
            // 
            // bitlist
            // 
            this.bitlist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bitlist.Enabled = false;
            this.bitlist.FormattingEnabled = true;
            this.bitlist.Items.AddRange(new object[] {
            "8",
            "16"});
            this.bitlist.Location = new System.Drawing.Point(6, 39);
            this.bitlist.Name = "bitlist";
            this.bitlist.Size = new System.Drawing.Size(152, 21);
            this.bitlist.TabIndex = 15;
            // 
            // buttonPlotBits
            // 
            this.buttonPlotBits.Enabled = false;
            this.buttonPlotBits.Location = new System.Drawing.Point(6, 66);
            this.buttonPlotBits.Name = "buttonPlotBits";
            this.buttonPlotBits.Size = new System.Drawing.Size(152, 41);
            this.buttonPlotBits.TabIndex = 16;
            this.buttonPlotBits.Text = "Plot bits";
            this.buttonPlotBits.UseVisualStyleBackColor = true;
            this.buttonPlotBits.Click += new System.EventHandler(this.buttonPlotBits_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Number of last changes";
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox3.ForeColor = System.Drawing.Color.Red;
            this.textBox3.Location = new System.Drawing.Point(519, 30);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(634, 24);
            this.textBox3.TabIndex = 18;
            this.textBox3.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bitlist);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.buttonPlotBits);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(292, 396);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(164, 122);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Last 8/16 changes analysis";
            // 
            // buttonSaveExcel
            // 
            this.buttonSaveExcel.Enabled = false;
            this.buttonSaveExcel.Location = new System.Drawing.Point(183, 451);
            this.buttonSaveExcel.Name = "buttonSaveExcel";
            this.buttonSaveExcel.Size = new System.Drawing.Size(75, 41);
            this.buttonSaveExcel.TabIndex = 20;
            this.buttonSaveExcel.Text = "save times to excel";
            this.buttonSaveExcel.UseVisualStyleBackColor = true;
            this.buttonSaveExcel.Click += new System.EventHandler(this.buttonSaveExcel_Click);
            // 
            // pulselist
            // 
            this.pulselist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pulselist.Enabled = false;
            this.pulselist.FormattingEnabled = true;
            this.pulselist.Items.AddRange(new object[] {
            "BI Phase Coding",
            "Pulse Distance Coding",
            "Pulse Lenght Coding"});
            this.pulselist.Location = new System.Drawing.Point(30, 38);
            this.pulselist.Name = "pulselist";
            this.pulselist.Size = new System.Drawing.Size(152, 21);
            this.pulselist.TabIndex = 21;
            // 
            // pulse_text
            // 
            this.pulse_text.Enabled = false;
            this.pulse_text.Location = new System.Drawing.Point(200, 13);
            this.pulse_text.Multiline = true;
            this.pulse_text.Name = "pulse_text";
            this.pulse_text.ReadOnly = true;
            this.pulse_text.Size = new System.Drawing.Size(138, 93);
            this.pulse_text.TabIndex = 2;
            // 
            // buttonTry
            // 
            this.buttonTry.Enabled = false;
            this.buttonTry.Location = new System.Drawing.Point(30, 65);
            this.buttonTry.Name = "buttonTry";
            this.buttonTry.Size = new System.Drawing.Size(152, 41);
            this.buttonTry.TabIndex = 22;
            this.buttonTry.Text = "Try read binary code";
            this.buttonTry.UseVisualStyleBackColor = true;
            this.buttonTry.Click += new System.EventHandler(this.buttonTry_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Coding type";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.buttonTry);
            this.groupBox3.Controls.Add(this.pulse_text);
            this.groupBox3.Controls.Add(this.pulselist);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(474, 397);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(344, 121);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Read binary code from plot";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1623, 685);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.buttonSaveExcel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.buttonClearPlot);
            this.Controls.Add(this.buttonSaveChart);
            this.Controls.Add(this.buttonPlot);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.buttonSaveTime);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.baudlist);
            this.Controls.Add(this.portlist);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IR dekoder";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox portlist;
        private System.Windows.Forms.ComboBox baudlist;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonSaveTime;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button buttonPlot;
        private System.Windows.Forms.Button buttonSaveChart;
        private System.Windows.Forms.Button buttonClearPlot;
        private System.Windows.Forms.ComboBox bitlist;
        private System.Windows.Forms.Button buttonPlotBits;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonSaveExcel;
        private System.Windows.Forms.ComboBox pulselist;
        private System.Windows.Forms.TextBox pulse_text;
        private System.Windows.Forms.Button buttonTry;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

