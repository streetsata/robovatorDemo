using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging.Filters;
using AForge.Imaging;
using Robovator.src;
using System.Diagnostics;
using System.IO.Ports;
using HealthCheck;
using System.IO;

namespace Robovator
{
    public partial class MainForm : Form
    {
        private Engine engine = null;
        private SerialPort sp = null;
        private bool isConnected = false;
        private const String AppGuid = "{F7FDED8F-1F2A-4E74-A311-4830BBC9EABF}";

        public MainForm(Engine engine)
        {
            InitializeComponent();

            this.engine = engine;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.engine.OnDeviceNewFrame += engine_OnDeviceNewFrame;

            foreach (String portName in System.IO.Ports.SerialPort.GetPortNames())
                comboBox1.Items.Add(portName);

            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;


            //comboBoxDeviсes.Items.AddRange(engine.getDeviceNames().ToArray());
            //comboBoxDeviсes.SelectedIndex = 0;
            ///////////////////////////////////////////
            UserControlOneMechanism.onDefaultValue += UserControlOneMechanism_onDefaultValue;

            foreach (ProcModule device in engine.Modules)
            {
                UserControlOneMechanism tmpCtrl = new UserControlOneMechanism(device);

                TabPage tmpTabPage = new TabPage(device.DeviceName);
                tmpTabPage.Name = device.DeviceName;
                tmpTabPage.Text = device.DeviceName;
                tmpTabPage.Controls.Add(tmpCtrl);
                tabControl1.TabPages.Add(tmpTabPage);
            }
            //engine.start();
        }

        private void reinitConfig(String configPath)
        {
            INIConfig ini = new INIConfig(configPath);
            Dictionary<String, String> tmpArr = new Dictionary<string, string>();
            //tmpArr.Add("key", "value");
            //tmpArr.Add("key1", "value1");
            //tmpArr.Add("key2", "value2");

            ini["section", "key"] = "value";
            ini["section1", "key1"] = "value1";
            ini["section2", "key2"] = "value2";
            ini["section3", "key3"] = "value3";
        }

        void UserControlOneMechanism_onDefaultValue()
        {

            String configPath = Environment.CurrentDirectory
                + Path.DirectorySeparatorChar
                + "default.ini";
            if (!File.Exists(configPath))
            {
                File.Create(configPath);
                reinitConfig(configPath);
            }
            INIConfig ini = new INIConfig(configPath);

            foreach (ProcModule device in engine.Modules)
            {
                //device.FilterSettings.


            }
        }



        void engine_OnDeviceNewFrame(Bitmap bmp, string deviceName)
        {
            //userControlOneMechanism1.pictureBox1.Image = bmp;

        }

        // Connecting to Cameras
        //private void buttonOnOff_Click(object sender, EventArgs e)
        //{
        //    //buttonOnOff.Text = "Выкл.";
        //    //try
        //    //{
        //    //    if (FinalFrame != null && FinalFrame.IsRunning == true)
        //    //    {
        //    //        buttonOnOff.BackColor = SystemColors.InactiveCaption;
        //    //        buttonOnOff.Text = "Вкл.";
        //    //        FinalFrame.SignalToStop();
        //    //        FinalFrame.WaitForStop();
        //    //        pictureBox1.Image = null;
        //    //        pictureBox1.Invalidate();
        //    //    }
        //    //    else
        //    //    {
        //    //        buttonOnOff.BackColor = SystemColors.ActiveCaption;
        //    //        buttonOnOff.Text = "Выкл.";
        //    //        FinalFrame = new VideoCaptureDevice(CaptureDevice[comboBoxDeviсes.SelectedIndex].MonikerString);
        //    //        FinalFrame.Start();
        //    //    }
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    MessageBox.Show(ex.ToString());
        //    //}
        //}


        // Closing MainForm
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            engine.stop();

            Application.Exit();
        }

        private void filterSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Robovator.Settings filterSetings = new Settings();
            //filterSetings.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (true)
            {
                try
                {
                    sp = new SerialPort();
                    try
                    {
                        sp.PortName = comboBox1.SelectedItem.ToString();
                        sp.BaudRate = 9600;
                        sp.Open();
                        sp.DataReceived += sp_DataReceived;
                        char[] ch = new char[2];
                        ch[0] = 'i';
                        sp.Write(ch, 0, 1);
                        Timer t = new Timer();
                        t.Interval = 3500;
                        t.Tick += (obj, obj2) =>
                        {
                            if (isConnected == false)
                                MessageBox.Show("Выбран не верный порт");
                            t.Stop();
                            if (sp.IsOpen)
                                sp.Close();

                            t.Dispose();
                        };
                        t.Start();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Arduino не подключен!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                //MessageBox.Show("Выберите");
            }
        }

        void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            String line = null;
            try
            {
                line = sp.ReadLine();
                line = line.Trim('\r', '\n', '\t').ToLower();

                if (!String.IsNullOrEmpty(line) && line == AppGuid.ToLower())
                {
                    isConnected = true;

                    sp.DataReceived -= sp_DataReceived;
                    if (sp.IsOpen)
                        sp.Close();
                    SerialPort tmpSp = new SerialPort(sp.PortName);
                    tmpSp.BaudRate = sp.BaudRate;
                    tmpSp.Open();

                    engine.setPort(tmpSp);
                    engine.start();

                    this.Invoke((MethodInvoker)delegate
                    {
                        tabControl1.Visible = true;
                        button1.Visible = false;
                        label1.Visible = false;
                        comboBox1.Visible = false;
                    });
                }
                else
                {
                    //error
                    MessageBox.Show("какая-то ошибка");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
