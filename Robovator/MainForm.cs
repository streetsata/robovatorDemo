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
        private static ILog _logger = LogManager.GetLogger(typeof(MainForm));
        char[] ch = new char[2];
        public int countEncoder = 0;

        public MainForm()
        {
            InitializeComponent();

            //int a = 0;
            //if (a != 0)
            //{
                serialPort1.PortName = "COM3";
                serialPort1.BaudRate = 9600;
                serialPort1.Open();
                serialPort1.DataReceived += serialPort1_DataReceived;
            //}
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

        void frm_No_Object()
        {
            ch[0] = 'w';

            serialPort1.Write(ch, 0, 1);            
        }

        void frm_OnObjectFound()
        {
            ch[0] = 'q';
            
            serialPort1.Write(ch, 0, 1);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen) serialPort1.Close();
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string command = serialPort1.ReadLine();
            this.BeginInvoke(new LineRecevidEvent(LineRecevid), command);
        }
        private delegate void LineRecevidEvent(string command);
        private void LineRecevid(string command)
        {
            //countEncoder = Int32.Parse(command);
            label1.Text = command;
        }
    }
}
