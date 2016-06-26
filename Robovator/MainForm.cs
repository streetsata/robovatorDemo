using log4net;
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

namespace Robovator1._3
{
    public partial class MainForm : Form
    {
        private class FoundObject
        {
            public long objStart;
            public long objLenght;
            public bool isVisible = false;
        }

        private static ILog _logger = LogManager.GetLogger(typeof(MainForm));
        char[] ch = new char[2];
        public static int countEncoder = 0;
        int currentCountEncoder = 0;
        private delegate void LineRecevidEvent(string command);
        long encoderCount = 0;
        int tmpEncoderCount = 0;
        private volatile Queue<FoundObject> quObj = new Queue<FoundObject>();
        private FoundObject currentObj = null;
        private static int codeEnable = 0;        

        //public int countObject
        //{
        //    get { return quObj.Count; }
        //}

        public MainForm()
        {
            InitializeComponent();
            //this.WindowState = FormWindowState.Maximized;
            //this.FormBorderStyle = FormBorderStyle.None;

            try
            {
                serialPort1.PortName = "COM4";
                serialPort1.BaudRate = 9600;
                serialPort1.Open();
                serialPort1.DataReceived += serialPort1_DataReceived;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                MessageBox.Show("No COM PORT!");
            }

        }

        private void newCamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormOfOneCam frm = new FormOfOneCam() { MdiParent = this };
                frm.Show();
                frm.OnObjectFound += frm_OnObjectFound;
                frm.No_Object += frm_No_Object;
            }
            catch (Exception ex)
            {
                _logger.Error("", ex);
            }
        }

        void frm_OnObjectFound()
        {
            currentObj = new FoundObject();
            currentObj.objStart = countEncoder;
            //quObj.Enqueue(fo);
        }

        void frm_No_Object()
        {
            currentObj.objLenght = countEncoder - currentObj.objStart;
            currentObj.objStart = currentObj.objStart + currentObj.objLenght;
            if (currentObj.objLenght != 0 && currentObj.objStart != 0)
                quObj.Enqueue(currentObj);
            currentObj = null;
            textBox1.Text = quObj.Count.ToString();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen) serialPort1.Close();
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string command = serialPort1.ReadLine();
                this.BeginInvoke(new LineRecevidEvent(LineRecevid), command);
            }
            catch (Exception ex)
            {
                _logger.Error("", ex);
            }
        }

        private void LineRecevid(string command)
        {
            try
            {

                //if (countEncoder >= tmpCount + 800 + 1000)
                //    tmpCount = 0;

                //encoderCount = long.Parse(command);

                tmpEncoderCount++;
                if (tmpEncoderCount >= 1)
                {
                    tmpEncoderCount = 0;
                    encoderCount++;
                    countEncoder++;
                    proc();
                }
                //currentCountEncoder = countEncoder;

                //if (tmpCount == 0)
                //    tmpCount = countEncoder;
            }
            catch (Exception ex)
            {
                _logger.Error("", ex);
            }

            label1.Text = encoderCount.ToString();            
        }

        private void proc()
        {
            try
            {
                const long delta = 10;

                if (quObj.Count > 0)
                {
                    FoundObject tmpObj = quObj.Peek();
                    if (countEncoder >= tmpObj.objStart + delta
                        && tmpObj.isVisible == false)
                    {
                        tmpObj.isVisible = true;
                        //quObj.Dequeue();
                        ch[0] = 'q';
                        serialPort1.Write(ch, 0, 1);
                    }
                    else
                    {
                        if (countEncoder >= tmpObj.objStart + tmpObj.objLenght + delta)
                        {
                            quObj.Dequeue();
                            ch[0] = 'w';
                            serialPort1.Write(ch, 0, 1);
                            textBox1.Text = quObj.Count.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error("", ex);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void horizontallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void verticallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
