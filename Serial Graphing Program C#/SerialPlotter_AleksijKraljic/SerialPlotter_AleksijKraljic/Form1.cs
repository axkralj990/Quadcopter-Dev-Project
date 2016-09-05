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
using ZedGraph;
using System.Diagnostics;
using System.IO;

namespace SerialPlotter_AleksijKraljic
{
    public partial class Form1 : Form
    {
        // serial receive varaible
        string RxString;
        bool RxStringComplete = false;
        // timestamp variable
        double time_ms = 0;
        // stopwatch for recording timestamp
        Stopwatch s_watch = new Stopwatch();
        // range of X-Axis
        double t_range = 4;
        // Min and Max values for Y-Axis
        double Y_max = 5;
        double Y_min = 0;
        // String for storing received data
        string[] measurements;
        string fileName = "measured_data.txt";

        // List for data storage to write to a file
        List<double> M1 = new List<double>();
        List<double> M2 = new List<double>();
        List<double> M3 = new List<double>();
        List<double> M4 = new List<double>();
        List<double> time_M = new List<double>();
        List<string> write_D = new List<string>();

        // new GraphPane for plotting
        GraphPane akMonitor = new GraphPane();

        // Circulat buffers and curve objects for all 4 values received
        RollingPointPairList sensor1 = new RollingPointPairList(500);
        LineItem ak_curve1;
        RollingPointPairList sensor2 = new RollingPointPairList(500);
        LineItem ak_curve2;
        RollingPointPairList sensor3 = new RollingPointPairList(500);
        LineItem ak_curve3;
        RollingPointPairList sensor4 = new RollingPointPairList(500);
        LineItem ak_curve4;

        public Form1()
        {
            InitializeComponent();

            // initial form object states
            btn_connect.Enabled = false;
            btn_disconnect.Enabled = false;
            btn_start.Enabled = false;
            btn_stop.Enabled = false;

            // get and set serial ports
            getAndWritePorts();

            // available baud rates
            string[] bauds = { "300", "1200", "2400", "4800", "9600", "19200", "38400", "57600", "74880", "115200", "230400", "250000"};
            baudBox.DataSource = bauds;
            baudBox.SelectedIndex = 4;

            fileNameBox.Text = fileName;

            // initial form object states
            checkCh1.Enabled = true;
            checkCh2.Enabled = true;
            checkCh3.Enabled = true;
            checkCh4.Enabled = true;
            checkAutoY.Checked = true;
            numericUDmaxY.Enabled = false;
            numericUDminY.Enabled = false;
            numericUDtime.Enabled = true;

            // graph apearance settings
            akMonitor = zedGraphControl1.GraphPane;
            akMonitor.Title.Text = "";
            akMonitor.XAxis.Title.Text = "";
            akMonitor.YAxis.Title.Text = "";
            akMonitor.XAxis.MajorGrid.IsVisible = true;
            akMonitor.YAxis.MajorGrid.IsVisible = true;

            fileNameBox.Enabled = false;
        }

        private void btn_refreshCOM_Click(object sender, EventArgs e)
        {
            getAndWritePorts();
        }

        private void getAndWritePorts()
        {
            // get port names
            string[] avports = SerialPort.GetPortNames();

            // write them to select box
            comBox.DataSource = avports;
            if (comBox.Items.Count > 0)
            {
                // select the first comport 
                comBox.SelectedIndex = 0;
            }
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            serialPort1.PortName = comBox.Text;
            serialPort1.BaudRate = int.Parse(baudBox.SelectedItem.ToString());

            try
            {
                serialPort1.Open();
            }
            catch
            {
                MessageBox.Show("No devices found");
            }

            if (serialPort1.IsOpen)
            {
                btn_connect.Enabled = false;
                btn_disconnect.Enabled = true;
                btn_start.Enabled = true;
                btn_stop.Enabled = false;
                comBox.Enabled = false;
                baudBox.Enabled = false;
                btn_refreshCOM.Enabled = false;
                serialPort1.DataReceived += new SerialDataReceivedEventHandler(SerialPort1_DataReceived);
                serialPort1.Write("b");
                checkCh1.Enabled = true;
                checkCh2.Enabled = true;
                checkCh3.Enabled = true;
                checkCh4.Enabled = true;
            }

        }

        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                RxString += serialPort1.ReadExisting();
                RxStringComplete = false;
                if (RxString.Length > 2)
                {
                    if (RxString.IndexOf("\n") != -1)
                    {
                        RxStringComplete = true;
                        RxString = RxString.Replace("\r\n", "");
                    }
                }
            }

            if (RxStringComplete == true)
            {
                splitReceivedString();
                
                this.BeginInvoke(new EventHandler(toBuffer));

                if (saveCheckBox.Checked)
                {
                    try
                    {
                        time_M.Add(time_ms);

                        if (measurements.Length == 1)
                        {
                            M1.Add(Convert.ToDouble(measurements[0]));
                            M2.Add(0);
                            M3.Add(0);
                            M4.Add(0);
                        }
                        else if (measurements.Length == 2)
                        {
                            M1.Add(Convert.ToDouble(measurements[0]));
                            M2.Add(Convert.ToDouble(measurements[1]));
                            M3.Add(0);
                            M4.Add(0);
                        }
                        else if (measurements.Length == 3)
                        {
                            M1.Add(Convert.ToDouble(measurements[0]));
                            M2.Add(Convert.ToDouble(measurements[1]));
                            M3.Add(Convert.ToDouble(measurements[2]));
                            M4.Add(0);
                        }
                        else if (measurements.Length == 4)
                        {
                            M1.Add(Convert.ToDouble(measurements[0]));
                            M2.Add(Convert.ToDouble(measurements[1]));
                            M3.Add(Convert.ToDouble(measurements[2]));
                            M4.Add(Convert.ToDouble(measurements[3]));
                        }
                    }
                    catch { }
                }
                
                RxString = "";
                
            }
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            // button that starts the communication
            serialPort1.Write("a");
            btn_start.Enabled = false;
            btn_stop.Enabled = true;
            btn_disconnect.Enabled = false;
            M1.Clear();
            M2.Clear();
            M3.Clear();
            M4.Clear();
            time_M.Clear();

            timer1.Start();
            timer2.Start();
            s_watch.Start();

            akMonitor.CurveList.Clear();
            sensor1.Clear();
            sensor2.Clear();
            sensor3.Clear();
            sensor4.Clear();

            ak_curve1 = akMonitor.AddCurve(null, sensor1, Color.Blue, SymbolType.None);
            ak_curve1.Line.Width = 2;
            ak_curve2 = akMonitor.AddCurve(null, sensor2, Color.Red, SymbolType.None);
            ak_curve2.Line.Width = 2;
            ak_curve3 = akMonitor.AddCurve(null, sensor3, Color.Green, SymbolType.None);
            ak_curve3.Line.Width = 2;
            ak_curve4 = akMonitor.AddCurve(null, sensor4, Color.Orange, SymbolType.None);
            ak_curve4.Line.Width = 2;
        }

        private void displayText(object sender, EventArgs e)
        {
            // method that displays text in textboxes
            //string[] measurements = RxString.Split('_');
            try
            {
                textBox1.Text = measurements[0];
                textBox2.Text = measurements[1];
                textBox3.Text = measurements[2];
                textBox4.Text = measurements[3];
            }
            catch { }
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            // button that stops the communication
            serialPort1.Write("b");
            textBox1.Text = "";
            btn_stop.Enabled = false;
            btn_start.Enabled = true;
            btn_disconnect.Enabled = true;

            timer1.Stop();
            timer2.Stop();
            s_watch.Stop();
            s_watch.Reset();

            if (saveCheckBox.Checked)
            {
                save_measurements();
            }
        }

        private void save_measurements()
        {
            // method used to store recorded data to file
            string folder_path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            
            //string fileName = DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt");

            string path = folder_path + "\\" + fileNameBox.Text;

            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine("=====measurements=====");
                sw.WriteLine("|t|ch1|ch2|ch3|ch4|");

                for (int i=0;i<M1.Count;i++)
                {
                    try
                    {
                        write_D.Add(Convert.ToString(time_M[i]) + "," + Convert.ToString(M1[i]) + "," + Convert.ToString(M2[i]) + "," + Convert.ToString(M3[i]) + "," + Convert.ToString(M4[i]));
                    }
                    catch
                    {
                        write_D.Add("outOfRange");
                    }
                }

                foreach (string line in write_D)
                {
                    sw.WriteLine(line);
                }
            }
        }

        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            // button to disconnect from the device
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();

                btn_connect.Enabled = true;
                btn_disconnect.Enabled = false;
                btn_start.Enabled = false;
                btn_stop.Enabled = false;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }

            checkCh1.Enabled = false;
            checkCh2.Enabled = false;
            checkCh3.Enabled = false;
            checkCh4.Enabled = false;
            comBox.Enabled = true;
            baudBox.Enabled = true;
            btn_refreshCOM.Enabled = true;

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // tasks to perform when the form is being closed
            if (serialPort1.IsOpen) serialPort1.Write("b");
            System.Threading.Thread.Sleep(100);

            DialogResult dialogC = MessageBox.Show("Are you sure you want to exit?","Exit",MessageBoxButtons.YesNo);
            if (dialogC == DialogResult.Yes)
            {
                if (serialPort1.IsOpen) serialPort1.Close();
                Application.ExitThread();
            }
            else if (dialogC == DialogResult.No)
            {
                e.Cancel = true;
            }
            
        }

        
        private void comBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comBox.SelectedItem == null)
            {
                btn_connect.Enabled = false;
            }
            else
            {
                btn_connect.Enabled = true;
            }
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toBuffer(object sender, EventArgs e)
        {
            // method to store received values to a circular buffer that is being drawn on the graph
            //string[] measurements = RxString.Split('_');
            time_ms = Convert.ToDouble(s_watch.ElapsedMilliseconds);
            try
            {
                if (checkCh1.Checked) { sensor1.Add(time_ms / 1000, Convert.ToDouble(measurements[0])); }
                else { sensor1.Clear(); }
                if (checkCh2.Checked && measurements.Length >= 2) { sensor2.Add(time_ms / 1000, Convert.ToDouble(measurements[1])); }
                else { sensor2.Clear(); }
                if (checkCh3.Checked && measurements.Length >= 3) { sensor3.Add(time_ms / 1000, Convert.ToDouble(measurements[2])); }
                else { sensor3.Clear(); }
                if (checkCh4.Checked && measurements.Length >= 4) { sensor4.Add(time_ms / 1000, Convert.ToDouble(measurements[3])); }
                else { sensor4.Clear(); }
            }
            catch { }
        }

        private void plot_data(object sender, EventArgs e)
        {
            // method to plot the received data
            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
            akMonitor.XAxis.Scale.Min = time_ms / 1000 - t_range;
            akMonitor.XAxis.Scale.Max = time_ms / 1000;

            if (!checkAutoY.Checked)
            {
                akMonitor.YAxis.Scale.Max = Y_max;
                akMonitor.YAxis.Scale.Min = Y_min;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // timer that updates the graph
            this.BeginInvoke(new EventHandler(plot_data));
        }
        
        private void checkAutoY_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAutoY.Checked)
            {
                akMonitor.YAxis.Scale.MaxAuto = true;
                akMonitor.YAxis.Scale.MinAuto = true;
                numericUDmaxY.Enabled = false;
                numericUDminY.Enabled = false;
            }
            else
            {
                akMonitor.YAxis.Scale.MaxAuto = false;
                akMonitor.YAxis.Scale.MinAuto = false;
                numericUDmaxY.Enabled = true;
                numericUDminY.Enabled = true;
            }
        }

        private void numericUDtime_ValueChanged(object sender, EventArgs e)
        {
            t_range = Convert.ToDouble(numericUDtime.Value);
        }

        private void numericUDmaxY_ValueChanged(object sender, EventArgs e)
        {
            Y_max = Convert.ToDouble(numericUDmaxY.Value);
        }

        private void numericUDminY_ValueChanged(object sender, EventArgs e)
        {
            Y_min = Convert.ToDouble(numericUDminY.Value);
        }

        private void configDirectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutWindow = new AboutBox1();
            aboutWindow.Show();
        }

        private void splitReceivedString()
        {
            measurements = RxString.Split('_');
        }

        private void saveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (saveCheckBox.Checked == true)
            {
                fileNameBox.Enabled = true;
            }
            else if (saveCheckBox.Checked == false)
            {
                fileNameBox.Enabled = false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (displayCheckBox.Checked)
            {
                this.Invoke(new EventHandler(displayText));
            }
        }
    }
}
