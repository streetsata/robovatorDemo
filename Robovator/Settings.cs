using Robovator.src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Robovator
{
    public partial class Settings : Form
    {
        private ProcModule device = null;

        public Settings(ProcModule device)
        {            
            InitializeComponent();
            this.device = device;

            init(this.device);
        }

        private void init(ProcModule _device)
        {
            _device.BlobCounterMinHeight = device.BlobCounterMinHeight;
            _device.BlobCounterMinWidth = device.BlobCounterMinWidth;
            _device.FilterSettings.filterYmin = device.FilterSettings.filterYmin;
            _device.FilterSettings.filterYmax = device.FilterSettings.filterYmax;
            _device.FilterSettings.filterCbmin = device.FilterSettings.filterCbmin;
            _device.FilterSettings.filterCbmax = device.FilterSettings.filterCbmax;
            _device.FilterSettings.filterCrmax = device.FilterSettings.filterCrmax;
            
        }

        private void numericUpDownCountEncoder_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nudTmp = sender as NumericUpDown;
            //device.FrequencyResponse = (int)nudTmp.Value;
            numericUpDownCountEncoder.Value = nudTmp.Value;
        }

        private void numericUpDownMinWidth_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nudTmp = sender as NumericUpDown;
            device.BlobCounterMinWidth = (int)nudTmp.Value;
        }

        private void numericUpDownHeight_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nudTmp = sender as NumericUpDown;
            device.BlobCounterMinHeight = (int)nudTmp.Value;
        }

        private void hScrollBrightnessFilter_Scroll(object sender, ScrollEventArgs e)
        {
            float newMaxValue = (float)e.NewValue / 1000.0f;
            device.FilterSettings.filterYmax = newMaxValue;
        }

        private void multiScrollCbFilter_OnMultiScroll(object sender, MultiScroll.MultiScrollEventArgs e)
        {
            float newMinValue = (float)e.NewMinValue / 1000.0F;
            float newMaxValue = (float)e.NewMaxValue / 1000.0f;
            device.FilterSettings.filterCbmin = newMinValue;
            device.FilterSettings.filterCbmax = newMaxValue;
        }

        private void multiScrollCrFilter_OnMultiScroll(object sender, MultiScroll.MultiScrollEventArgs e)
        {
            float newMinValue = (float)e.NewMinValue / 1000.0F;
            float newMaxValue = (float)e.NewMaxValue / 1000.0f;
            device.FilterSettings.filterCrmin = newMinValue;
            device.FilterSettings.filterCrmax = newMaxValue;
        }
    }
}
