using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Robovator.src;
using System.Threading;
using System.IO;

namespace Robovator
{
    public partial class UserControlOneMechanism : UserControl
    {
        private ProcModule device = null;
        private INI ini;
        private Settings set;
        private string defBlobCounterMinWidth;
        private string defBlobCounterMinHeight;
        private string defFilterYmin;
        private string defFilterYmax;
        private string defFilterCbmin;
        private string defFilterCbmax;
        private string defFilterCrmin;
        private string defFilterCrmax;
        private string defFrequencyResponse;

        private Queue<Byte> arr = new Queue<byte>();

        public UserControlOneMechanism(ProcModule device)
        {
            this.device = device;            
            InitializeComponent();
            device.onNewFrame += device_onNewFrame;
            
        }

        void device_onNewFrame(Bitmap bmp)
        {
            pictureBoxMain.Image = bmp;

            this.Invoke((MethodInvoker)delegate
            {
                labelResolutionValue.Text = device.Resolution.ToString();
                labelFPSValue.Text = device.CamFPS.ToString();
                labelCountInFrameValue.Text = device.ObjectCount.ToString();
                labelTotalCountObjectValue.Text = device.TotalObjectCount.ToString();

                int temp = 0;
                if (device.Arr != null)
                { 
                    label1.Text = null;
                    for (int i = 0; i < 240; i++)
                    {
                        temp++;
                        if (temp % 8 != 0)
                            continue;
                        else
                            label1.Text += device.Arr[i].ToString() + "\n";
                    }
                }
            });
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nudTmp = sender as NumericUpDown;
            device.FrequencyResponse = (int)nudTmp.Value;
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            float newMaxValue = (float)e.NewValue / 1000.0f;
            device.FilterSettings.filterYmax = newMaxValue;
        }

        private void multiScroll2_OnMultiScroll(object sender, MultiScroll.MultiScrollEventArgs e)
        {
            float newMinValue = (float)e.NewMinValue / 1000.0F;
            float newMaxValue = (float)e.NewMaxValue / 1000.0f;
            device.FilterSettings.filterCbmin = newMinValue;
            device.FilterSettings.filterCbmax = newMaxValue;
        }

        private void multiScroll3_OnMultiScroll(object sender, MultiScroll.MultiScrollEventArgs e)
        {
            float newMinValue = (float)e.NewMinValue / 1000.0F;
            float newMaxValue = (float)e.NewMaxValue / 1000.0f;
            device.FilterSettings.filterCrmin = newMinValue;
            device.FilterSettings.filterCrmax = newMaxValue;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nudTmp = sender as NumericUpDown;
            device.BlobCounterMinWidth = (int)nudTmp.Value;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nudTmp = sender as NumericUpDown;
            device.BlobCounterMinHeight = (int)nudTmp.Value;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonDefault_Click(object sender, EventArgs e)
        {
            ini = new INI("Settings.ini");
            ini.IniWriteValue("Test_block", "Key", "5");

            if (File.Exists("Settings.ini"))
            {
                ini = new INI("Settings.ini");
                defBlobCounterMinWidth = ini.IniReadValue("Section1", "blobCounterMinWidth");
                defBlobCounterMinHeight = ini.IniReadValue("Section1", "blobCounterMinHeight");
                defFilterYmin = ini.IniReadValue("Section1", "filterYmin");
                defFilterYmax = ini.IniReadValue("Section1", "filterYmax");
                defFilterCbmin = ini.IniReadValue("Section1", "filterCbmin");
                defFilterCbmax = ini.IniReadValue("Section1", "filterCbmax");
                defFilterCrmin = ini.IniReadValue("Section1", "filterCrmin");
                defFilterCrmax = ini.IniReadValue("Section1", "filterCrmax");
                defFrequencyResponse = ini.IniReadValue("Section1", "frequencyResponse");
            }
            else
            {
                int a = 0;
            }
        }
        
        private void buttonSettings_Click(object sender, EventArgs e)
        {
            set = new Settings(device);
            set.ShowDialog();
        }

        private void numericUpDownUnionObject_ValueChanged(object sender, EventArgs e)
        {
            device.UnionObject = (int)numericUpDownUnionObject.Value * 8;
        }


    }
}
