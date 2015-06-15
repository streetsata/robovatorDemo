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
        

        public delegate void DefaultValue();
        public static event DefaultValue onDefaultValue;

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
                labelCountEncoderValue.Text = device.FrequencyResponse.ToString();
                labelWightValue.Text = device.BlobCounterMinWidth.ToString();
                labelHeightValue.Text = device.BlobCounterMinHeight.ToString();
                labelUnionObjectValue.Text = device.UnionObject.ToString();
                labelbrightnessValue.Text = device.FilterSettings.filterYmax.ToString();
                labelCbMinValue.Text = device.FilterSettings.filterCbmin.ToString();
                labelCbMaxValue.Text = device.FilterSettings.filterCbmax.ToString();
                labelCrMinValue.Text = device.FilterSettings.filterCrmin.ToString();
                labelCrMaxValue.Text = device.FilterSettings.filterCrmax.ToString();

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


            if (onDefaultValue != null)
                onDefaultValue();
        }
        
        private void buttonSettings_Click(object sender, EventArgs e)
        {
            set = new Settings(device);
            set.ShowDialog();
        }

        private void numericUpDownUnionObject_ValueChanged(object sender, EventArgs e)
        {
            //device.UnionObject = (int)numericUpDownUnionObject.Value * 8;
        }

        private void labelCr_Click(object sender, EventArgs e)
        {
           
        }


    }
}
