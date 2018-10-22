using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Windows.Forms.DataVisualization.Charting;


namespace IRdekoder
{
    public partial class Form1 : Form
    {
        private string in_data;
        private string in_data2;
        int color_index;
        List<int> int_list = new List<int>();
        List<int> time_list = new List<int>();


        public Form1()
        {
            InitializeComponent();
            getAvailablePorts();
            InitializePlot();
        }
        void InitializePlot()
        {

            chart1.Series.Add("Signal");
            chart1.Series.Add("Signal2");

            chart1.Series["Signal"].ChartType = SeriesChartType.Line;
            chart1.Series["Signal2"].ChartType = SeriesChartType.Line;

            chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

            chart1.Series[0].IsVisibleInLegend = false;

        }

        void getAvailablePorts()
        {
            string[] ports = SerialPort.GetPortNames();
            this.portlist.Items.AddRange(ports);
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (portlist.Text == "" || baudlist.Text == "")
                {
                    textBox2.Visible = true;
                    textBox2.Text = "Select the connection properties";
                }
                else
                {
                    serialPort1.PortName = portlist.Text;
                    serialPort1.BaudRate = Convert.ToInt32(baudlist.Text);
                    serialPort1.Parity = Parity.None;
                    serialPort1.StopBits = StopBits.One;
                    serialPort1.DataBits = 8;
                    serialPort1.Handshake = Handshake.None;
                    serialPort1.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                    serialPort1.Open();
                    progressBar1.Value = 100;
                    buttonOpen.Enabled = false;
                    buttonClose.Enabled = true;
                    buttonClear.Enabled = true;
                    buttonPlot.Enabled = true;
                    buttonSaveTime.Enabled = true;
                    buttonSaveChart.Enabled = true;
                    buttonClearPlot.Enabled = true;
                    textBox1.Enabled = true;
                    textBox2.Visible = true;
                    textBox2.Text = "Connected";
                }
            }
            catch (UnauthorizedAccessException)
            {
                textBox2.Visible = true;
                textBox2.Text = "Unauthorized Access";
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            progressBar1.Value = 0;
            buttonClose.Enabled = false;
            buttonOpen.Enabled = true;
            buttonClear.Enabled = false;
            buttonSaveTime.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Clear();
            textBox2.Visible = false;
            buttonPlot.Enabled = false;
            buttonSaveChart.Enabled = false;
            buttonClearPlot.Enabled = false;
        }

        void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            in_data2 = serialPort1.ReadExisting();
            in_data += in_data2;
            this.Invoke(new EventHandler(display_event));
        }

        private void display_event(object sender, EventArgs e)
        {
            textBox1.AppendText(in_data2);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            in_data = "";

            time_list.Clear();
            int_list.Clear();
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            color_index = 0;
        }

        private void buttonSaveTime_Click(object sender, EventArgs e)
        {

            chart1.Series["Signal"].Color = Color.Red;

            FileDialog oDialog = new SaveFileDialog();
            oDialog.DefaultExt = "txt";
            oDialog.FileName = "times";

            List<string> output = new List<string>(
               in_data.Split(new string[] { "\r\n" },
               StringSplitOptions.RemoveEmptyEntries));

            output.RemoveAt(0);

            if (oDialog.ShowDialog() == DialogResult.OK)
            {

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@oDialog.FileName))
                    foreach (string line in output)
                    {
                        file.WriteLine(line);
                    }
            }
        }

        private void buttonPlot_Click(object sender, EventArgs e)
        {

            List<string> list = new List<string>(
                in_data.Split(new string[] { "\r\n" },
                StringSplitOptions.RemoveEmptyEntries));
            int time = 0;
            int x = 0;
            foreach (string el in list)
            {
                Int32.TryParse(el, out x);
                int_list.Add(x);
            }

            for (int i = 1; i < int_list.Count; i++)
            {
                time += int_list[i];
                time_list.Add(time);
            }
            MakeChart(time_list);
            //clear saved data
            in_data = "";
            time_list.Clear();
            int_list.Clear();
        }
        private void MakeChart(List<int>time_list)
        {
            
            var chart = chart1.ChartAreas[0];
            chart.AxisX.IntervalType = DateTimeIntervalType.Number;

            chart.AxisX.LabelStyle.Format = "";
            chart.AxisY.LabelStyle.Format = "";
            chart.AxisY.LabelStyle.IsEndLabelVisible = true;

            chart.AxisX.Minimum = time_list[0] - 500;
            chart.AxisX.Maximum = time_list[time_list.Count - 1] + 100;

            chart.AxisY.Maximum = 2;
            chart.AxisY.Minimum = 0;

            chart.AxisX.Interval = 2000;
            chart.AxisY.Interval = 1;
            
            if(color_index==0)
            {
                chart1.Series["Signal"].Color = Color.Red;
                int temp = 0;
                time_list.RemoveAt(time_list.Count - 1);
                //adding points
                chart1.Series["Signal"].Points.AddXY(time_list[0] - 500, 0);

                foreach (int el1 in time_list)
                {
                    if (temp % 2 == 0)
                    {
                        chart1.Series["Signal"].Points.AddXY(el1, 0);
                        chart1.Series["Signal"].Points.AddXY(el1, 1);
                    }

                    else
                    {
                        chart1.Series["Signal"].Points.AddXY(el1, 1);
                        chart1.Series["Signal"].Points.AddXY(el1, 0);
                    }
                    temp++;
                }
            }
            else if(color_index==1)
            {
                
                
                chart1.Series["Signal2"].Color = Color.Blue;
                int temp = 0;
                time_list.RemoveAt(time_list.Count - 1);
                //adding points

                chart1.Series["Signal2"].Points.AddXY(time_list[0] - 500, 0);

                foreach (int el1 in time_list)
                {
                    if (temp % 2 == 0)
                    {
                        chart1.Series["Signal2"].Points.AddXY(el1, 0);
                        chart1.Series["Signal2"].Points.AddXY(el1, 1);
                    }

                    else
                    {
                        chart1.Series["Signal2"].Points.AddXY(el1, 1);
                        chart1.Series["Signal2"].Points.AddXY(el1, 0);
                    }
                    temp++;
                }
            }
            color_index++;
        }

        private void buttonSaveChart_Click(object sender, EventArgs e)
        {
            FileDialog oDialog = new SaveFileDialog();
            oDialog.FileName = "chart";
            oDialog.Title = "Save Chart As Image File";
            oDialog.DefaultExt = "png";
            oDialog.Filter = "PNG Image|*.png|JPeg Image|*.jpg|BMP Image|*.bmp";

            if (oDialog.ShowDialog() == DialogResult.OK)
            {
                if (oDialog.FilterIndex == 3)
                    chart1.SaveImage(oDialog.FileName, ChartImageFormat.Bmp);
                if (oDialog.FilterIndex == 2)
                    chart1.SaveImage(oDialog.FileName, ChartImageFormat.Jpeg);
                if (oDialog.FilterIndex == 1)
                    chart1.SaveImage(oDialog.FileName, ChartImageFormat.Png);
            }
        }

        private void buttonClearPlot_Click(object sender, EventArgs e)
        {
            in_data = "";

            time_list.Clear();
            int_list.Clear();
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            color_index = 0;
        }
    }
}
