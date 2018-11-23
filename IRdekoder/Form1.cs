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
        int Flag;
        private string in_data;
        private string in_data2;
        private string temp_in_data;
        private string save_time_str;
        int color_index;
        int error = 200;
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
                    buttonPlotBits.Enabled = true;
                    buttonSaveExcel.Enabled = true;
                    buttonTry.Enabled = true;
                    pulselist.Enabled = true;
                    pulse_text.Enabled = true;
                    groupBox2.Enabled = true;
                    groupBox3.Enabled = true;
                    bitlist.Enabled = true;
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
            buttonPlotBits.Enabled = false;
            buttonSaveChart.Enabled = false;
            buttonClearPlot.Enabled = false;
            bitlist.Enabled = false;
            buttonSaveExcel.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            buttonTry.Enabled = false;
            pulselist.Enabled = false;
            pulse_text.Enabled = false;
        }

        void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            in_data2 = serialPort1.ReadExisting();
            in_data += in_data2;
            // save_time_str += in_data2;
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
            textBox3.Visible = false;
            textBox3.Text = "";
        }

        private void buttonSaveTime_Click(object sender, EventArgs e)
        {

            chart1.Series["Signal"].Color = Color.Red;

            FileDialog oDialog = new SaveFileDialog();
            oDialog.DefaultExt = "txt";
            oDialog.FileName = "times";

            List<string> output = Clear(in_data);

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
            if (Flag == 1)
            {
                foreach (var series in chart1.Series)
                {
                    series.Points.Clear();
                }
                Flag = 0;
            }

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
            int temp_val = int_list[5];
            for (int j = 5; j < 17; j++)
            {
                if (int_list[j] > temp_val)
                    temp_val = int_list[j];
            }
            //eliminacja ujemnych i błędnych wartosci
            for (int i = 1; i < int_list.Count; i++)
            {

                if (int_list[i] < 0)
                {
                    int_list.RemoveAt(i);
                    int_list.RemoveAt(i - 1);
                }
                if (int_list[i] > 10 * temp_val)
                {
                    int_list.RemoveAt(i);
                    int_list.RemoveAt(i - 1);
                }
            }
            for (int i = 1; i < int_list.Count; i++)
            {
                time += int_list[i];
                time_list.Add(time);
            }
            MakeChart(time_list);
            temp_in_data = in_data;
            //clear saved data
            save_time_str = in_data;

            in_data = "";
            time_list.Clear();
            int_list.Clear();
        }
        private void MakeChart(List<int> time_list)
        {
            bool isEmpty = !time_list.Any();
            if (isEmpty)
            {
                textBox3.Visible = true;
                textBox3.Text = "No signal received, press key on TV remote";
            }
            else
            {
                textBox3.Visible = false;
                textBox3.Text = "";

                var chart = chart1.ChartAreas[0];
                chart.AxisX.IntervalType = DateTimeIntervalType.Number;

                chart.AxisX.LabelStyle.Format = "";
                chart.AxisY.LabelStyle.Format = "";
                chart.AxisY.LabelStyle.IsEndLabelVisible = true;
                if (time_list[0] > 600)
                    chart.AxisX.Minimum = time_list[0] - 500;
                else
                    chart.AxisX.Minimum = 0;

                chart.AxisX.Maximum = time_list[time_list.Count - 1] + 100;

                chart.AxisY.Maximum = 2;
                chart.AxisY.Minimum = 0;

                chart.AxisX.Interval = 1200;
                chart.AxisY.Interval = 1;

                if (color_index == 2)
                {
                    color_index = 0;
                    textBox3.Visible = true;
                    textBox3.Text = "Maximum number of signals is 2";
                    foreach (var series in chart1.Series)
                    {
                        series.Points.Clear();
                    }
                }

                if (color_index == 0)
                {

                    chart1.Series["Signal"].Color = Color.Red;
                    int temp = 0;
                    time_list.RemoveAt(time_list.Count - 1);
                    //adding points
                    if (time_list[0] > 600)
                        chart1.Series["Signal"].Points.AddXY(time_list[0] - 500, 1);
                    else
                        chart1.Series["Signal"].Points.AddXY(time_list[0], 1);
                    int counttimes = time_list.Count;
                    foreach (int el1 in time_list)
                    {
                        if (temp % 2 == 0)
                        {
                            chart1.Series["Signal"].Points.AddXY(el1, 1);
                            chart1.Series["Signal"].Points.AddXY(el1, 0);
                        }

                        else
                        {
                            if (counttimes - 1 != temp)
                            {
                                chart1.Series["Signal"].Points.AddXY(el1, 0);
                                chart1.Series["Signal"].Points.AddXY(el1, 1);
                            }

                            else
                                chart1.Series["Signal"].Points.AddXY(el1, 0);
                        }
                        temp++;
                    }

                }
                else if (color_index == 1)
                {


                    chart1.Series["Signal2"].Color = Color.Blue;
                    int temp = 0;
                    time_list.RemoveAt(time_list.Count - 1);
                    //adding points
                    if (time_list[0] > 600)
                        chart1.Series["Signal2"].Points.AddXY(time_list[0] - 500, 0);
                    else
                        chart1.Series["Signal2"].Points.AddXY(time_list[0], 0);
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
            textBox3.Visible = false;
            textBox3.Text = "";
        }

        private void buttonPlotBits_Click(object sender, EventArgs e)
        {
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            color_index = 0;
            List<int> int_time_list = new List<int>();
            List<int> sum_time_list = new List<int>();

            List<string> list = new List<string>(
                temp_in_data.Split(new string[] { "\r\n" },
                StringSplitOptions.RemoveEmptyEntries));
            int time = 0;
            int x = 0;
            foreach (string el in list)
            {
                Int32.TryParse(el, out x);
                int_time_list.Add(x);
            }
            int temp_val = int_time_list[5];
            for (int j = 5; j < 17; j++)
            {
                if (int_time_list[j] > temp_val)
                    temp_val = int_time_list[j];
            }
            //eliminacja ujemnych i błędnych wartosci
            for (int i = 1; i < int_time_list.Count; i++)
            {
                if (int_time_list[i] < 0)
                {
                    int_time_list.RemoveAt(i);
                    int_time_list.RemoveAt(i - 1);
                }
                if (int_time_list[i] > 10 * temp_val)
                {
                    int_time_list.RemoveAt(i);
                    int_time_list.RemoveAt(i - 1);
                }
            }

            if (bitlist.Text == "8")
            {

                for (int i = int_time_list.Count - 17; i < int_time_list.Count; i++)
                {
                    time += int_time_list[i];
                    sum_time_list.Add(time);
                }
                MakeChart(sum_time_list);
            }
            else if (bitlist.Text == "16")
            {
                for (int i = int_time_list.Count - 33; i < int_time_list.Count; i++)
                {
                    time += int_time_list[i];
                    sum_time_list.Add(time);

                }
                MakeChart(sum_time_list);
            }
            color_index = 0;
            Flag = 1;
        }

        private void buttonSaveExcel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application App;
            Microsoft.Office.Interop.Excel._Workbook Wb;
            Microsoft.Office.Interop.Excel._Worksheet oS;
            Microsoft.Office.Interop.Excel.Range oRan;
            object misvalue = System.Reflection.Missing.Value;
            int count;
            string count_str;
            try
            {
                count = save_time_str.Count();
                count_str = count.ToString();
                count_str = "A" + count_str;

                List<string> output = Clear(save_time_str);


                List<int> int_time_list = new List<int>();
                List<string> output_temp = new List<string>();

                int x = 0;
                foreach (string el in output)
                {
                    Int32.TryParse(el, out x);
                    int_time_list.Add(x);
                }

                int temp_val = int_time_list[5];
                for (int j = 5; j < 17; j++)
                {
                    if (int_time_list[j] > temp_val)
                        temp_val = int_time_list[j];
                }
                //eliminacja ujemnych i błędnych wartosci
                for (int i = 1; i < int_time_list.Count; i++)
                {
                    if (int_time_list[i] < 0)
                    {
                        int_time_list.RemoveAt(i);
                        int_time_list.RemoveAt(i - 1);
                    }
                    if (int_time_list[i] > 10 * temp_val)
                    {
                        int_time_list.RemoveAt(i);
                        int_time_list.RemoveAt(i - 1);
                    }
                }
                int_time_list.RemoveAt(int_time_list.Count - 1);

                foreach (int el in int_time_list)
                {
                    output_temp.Add(el.ToString());
                }

                string[,] output2 = new string[count, 1];
                int it = 0;
                foreach (string el in output_temp)
                {
                    output2[it, 0] = el;
                    it++;
                }



                App = new Microsoft.Office.Interop.Excel.Application();
                App.Visible = true;

                Wb = (Microsoft.Office.Interop.Excel._Workbook)(App.Workbooks.Add(""));
                oS = (Microsoft.Office.Interop.Excel._Worksheet)Wb.ActiveSheet;

                oS.Cells[1, 1] = "times";

                oS.get_Range("A1", "B1").Font.Bold = true;
                oS.get_Range("A1", "B1").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                oS.get_Range("A2", count_str).Value2 = output2;


                oRan = oS.get_Range("A1", "B1");
                oRan.EntireColumn.AutoFit();

                App.Visible = false;
                App.UserControl = false;
                Wb.SaveAs("test505.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
                    false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                textBox3.Visible = true;
                textBox3.Text = "saved in documents folder";
                Wb.Close();
            }
            catch (UnauthorizedAccessException)
            { }
        }


        private void buttonTry_Click(object sender, EventArgs e)
        {
            if (save_time_str == null)
            {
                textBox3.Visible = true;
                textBox3.Text = "First click plot";
            }
            else
            {


                List<string> output = Clear(save_time_str);

                int x = 0;

                foreach (string el in output)
                {
                    Int32.TryParse(el, out x);
                    int_list.Add(x);
                }
                int temp_val;
                temp_val = int_list[5];
                for (int j = 5; j < 17; j++)
                {
                    if (int_list[j] > temp_val)
                        temp_val = int_list[j];
                }
                for (int i = 0; i < int_list.Count; i++)
                {

                    if (int_list[i] < 0)
                    {
                        int_list.RemoveAt(i - 1);
                        int_list.RemoveAt(i);
                    }

                    if (int_list[i] > temp_val * 10)
                    {
                        int_list.Remove(i);
                        int_list.Remove(i - 1);
                    }

                }

                if (pulselist.Text == "BI Phase Coding")
                {
                    int def,status=1;
                    List<int> mask = new List<int>();
                    def = int_list[1];
                    string code = "";
                    for(int i=0; i<int_list.Count;i++)
                    {
                        if (int_list[i] < def - error || int_list[i] > def + error)
                        {
                            if (int_list[i] < (2 * def - error) || int_list[i] > (2 * def + error))
                                status = 1;
                            else
                            {
                                code = "It's not a BI Phase coding, or try send more time data";
                            }
                        }
                    }

                    if (status == 1)
                    {
                        //maska
                        for (int i = 0; i < int_list.Count; i++)
                        {
                            if (i % 2 == 0)
                                mask.Add(1);
                            else
                                mask.Add(0);
                        }

                        for (int i = 0; i < int_list.Count; i++)
                        {
                            //2x 800
                            if(int_list[i]>def-error && int_list[i]<def+error) //800
                            {
                                if(int_list[i+1] > def - error && int_list[i+1] < def + error) //800
                                {
                                    if (mask[i] == 1 && mask[i + 1] == 0)
                                        code += "1";
                                    else
                                        code += "0";

                                    i++;
                                }
                                
                            }
                            //1x800 i 1x1600 -> 800
                            if (int_list[i] > def - error && int_list[i] < def + error) //800
                            {
                                if (int_list[i + 1] > (2*def - error) && int_list[i + 1] < (2*def + error)) //1600
                                {
                                    if(int_list[i+2] > def - error && int_list[i+2] < def + error) //800
                                    {
                                        if (mask[i + 1] == 0)
                                        {
                                            code += "1";
                                            code += "0";
                                        }
                                        else
                                        {
                                            code += "0";
                                            code += "1";
                                        }
                                        i = i + 2;
                                    }
                                }
                            }
                            //1x800 i 1x1600 -> 1600
                            if (int_list[i] > def - error && int_list[i] < def + error) //800
                            {
                                if (int_list[i + 1] > (2 * def - error) && int_list[i + 1] < (2 * def + error)) //1600
                                {
                                    if (int_list[i + 2] > (2 * def - error) && int_list[i + 2] < (2 * def + error)) //1600
                                    {
                                        if (mask[i + 1] == 0)
                                            code += "1";
                                        else
                                            code += "0";

                                        i = i + 1;
                                    }

                                }
                            }
                            //1600 if previous 1600 
                            if(i>0)
                            {
                                if (int_list[i-1] > (2 * def - error) && int_list[i-1] < (2 * def + error)) //previous 1600
                                {
                                    if (int_list[i] > (2 * def - error) && int_list[i] < (2 * def + error)) //1600
                                    {
                                        if (int_list[i + 1] > (2 * def - error) && int_list[i + 1] < (2 * def + error)) //next 1600
                                        {
                                            if (mask[i] == 0)
                                                code += "1";
                                            else
                                                code += "0";

                                            
                                        }
                                        else if (int_list[i+1] > def - error && int_list[i+1] < def + error) //next 800
                                        {
                                            if (mask[i] == 0)
                                            {
                                                code += "1";
                                                code += "0";
                                            }
                                                
                                            else
                                            {
                                                code += "0";
                                                code += "1";
                                            }
                                            i++;
                                        }
                                    }
                                }
                            }

                        }

                        pulse_text.Text = code;

                    }

                }
                else if (pulselist.Text == "Pulse Distance Coding")
                {
                    int def, temp, temp2 = 0, min, max, counter = 0, status = 1, val = 0, cnt = 0, start_bit = 0;
                    string code = "";
                    def = int_list[4];
                    temp = int_list[5];
                    for (int i = 7; i < int_list.Count; i = i + 2)
                    {
                        if (int_list[i] < temp - error || int_list[i] > temp + error)
                            temp2 = int_list[i];
                    }
                    if (temp < temp2)
                    {
                        min = temp;
                        max = temp2;
                    }
                    else
                    {
                        min = temp2;
                        max = temp;
                    }

                    for (int i = 0; i < 4; i++)
                    {
                        if (i % 2 == 0)
                        {
                            if (int_list[i] > def + error || int_list[i] < def - error)
                            {
                                counter++;
                            }
                        }
                        else
                        {
                            if (int_list[i] > min + error || int_list[i] < min - error)
                            {
                                if (int_list[i] > max + error || int_list[i] < max - error)
                                    counter++;
                            }
                        }
                    }
                    if (counter != 0)
                        start_bit = counter / 2;
                    if (start_bit != 0)
                        code += start_bit.ToString() + "bit start \r\n Binary code: \r\n";
                    else
                        code += "Didn't recognize any start bits";

                    for (int i = counter; i < int_list.Count; i = i + 2)
                    {
                        cnt++;
                        if (status == 1)
                        {
                            if (int_list[i] < def + error && int_list[i] > def - error)
                            {
                                status = 1;
                            }
                            else
                            {
                                status = 0;
                            }
                        }
                        if (status == 1)
                        {
                            if (int_list[i + 1] < min + error && int_list[i + 1] > min - error)
                            {
                                status = 1;
                                val = 0;
                            }
                            else
                            {
                                if (int_list[i + 1] < max + error || int_list[i + 1] > max - error)
                                {
                                    status = 1;
                                    val = 1;
                                }
                                else
                                    status = 0;
                            }
                        }


                        code += val.ToString();
                        if (cnt % 4 == 0)
                            code += " ";

                    }
                    if (status == 1)
                        pulse_text.Text = code;
                    else
                    {
                        code = "Error during reading the code, try again";
                        pulse_text.Text = code;
                    }

                }
                else if (pulselist.Text == "Pulse Lenght Coding")
                {
                    
                }
            }
        }
        static List<string> Clear(string save_time_str)
        {
            List<string> output = new List<string>(
            save_time_str.Split(new string[] { "\r\n" },
            StringSplitOptions.RemoveEmptyEntries));

            output.RemoveAt(0);
            output.RemoveAt(output.Count - 1);

            return output;
        }

    }
}
