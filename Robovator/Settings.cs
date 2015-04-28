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
            //_device.FrequencyResponse = device.FrequencyResponse;
            //_device.BlobCounterMinHeight = device.BlobCounterMinHeight;
            //_device.BlobCounterMinWidth = device.BlobCounterMinWidth;
            //_device.UnionObject = device.UnionObject;
            //_device.FilterSettings.filterYmin = device.FilterSettings.filterYmin;
            //_device.FilterSettings.filterYmax = device.FilterSettings.filterYmax;
            //_device.FilterSettings.filterCbmin = device.FilterSettings.filterCbmin;
            //_device.FilterSettings.filterCbmax = device.FilterSettings.filterCbmax;
            //_device.FilterSettings.filterCrmax = device.FilterSettings.filterCrmax;
            //_device.FilterSettings.filterCbmin = device.FilterSettings.filterCrmin;

            numericUpDownCountEncoder.Value = _device.FrequencyResponse;
            numericUpDownMinWidth.Value = _device.BlobCounterMinHeight;
            numericUpDownHeight.Value = _device.BlobCounterMinHeight;
            numericUpDownUnionObject.Value = (int)_device.UnionObject;

            float tmpfilterBrightnessVal = 0;
            if (_device.FilterSettings.filterYmax == 1000)
                multiScrollCbFilter.MultiMinValue = (int)_device.FilterSettings.filterCbmin;
            else
            {
                tmpfilterBrightnessVal = _device.FilterSettings.filterYmax * 1000.0f;
                hScrollBrightnessFilter.Value = (int)tmpfilterBrightnessVal;
            }
            //hScrollBrightnessFilter.Value = (int)_device.FilterSettings.filterYmax;
            //hScrollBrightnessFilter.Mu = (int)_device.FilterSettings.filterYmax;

            float tmpfilterCbminVal = 0;
             if (_device.FilterSettings.filterCbmin == -500 || _device.FilterSettings.filterCbmin == 500)
                 multiScrollCbFilter.MultiMinValue = (int)_device.FilterSettings.filterCbmin;
             else
             {
                 tmpfilterCbminVal = _device.FilterSettings.filterCbmin * 1000.0f;
                 multiScrollCbFilter.MultiMinValue = (int)tmpfilterCbminVal;
             }

            float tmpfilterCbmaxVal = 0;
            if (_device.FilterSettings.filterCbmax == -500 || _device.FilterSettings.filterCbmax == 500)
                multiScrollCbFilter.MultiMaxValue = (int)_device.FilterSettings.filterCbmax;
            else
            {
                tmpfilterCbmaxVal = _device.FilterSettings.filterCbmax * 1000.0f;
                multiScrollCbFilter.MultiMaxValue = (int)tmpfilterCbmaxVal;
            }

            float tmpfilterCrminVal = 0;
            if (_device.FilterSettings.filterCrmin == -500 || _device.FilterSettings.filterCrmin == 500)
                multiScrollCrFilter.MultiMinValue = (int)_device.FilterSettings.filterCrmin;
            else
            {
                tmpfilterCrminVal = _device.FilterSettings.filterCrmin * 1000.0f;
                multiScrollCrFilter.MultiMinValue = (int)tmpfilterCrminVal;
            }

            float tmpfilterCrmaxVal = 0;
            if (_device.FilterSettings.filterCrmax == -500 || _device.FilterSettings.filterCrmax == 500)
                multiScrollCrFilter.MultiMaxValue = (int)_device.FilterSettings.filterCrmax;
            else
            {
                tmpfilterCrmaxVal = _device.FilterSettings.filterCrmax * 1000.0f;
                multiScrollCrFilter.MultiMaxValue = (int)tmpfilterCrmaxVal;
            }
            //multiScrollCbFilter.MultiMaxValue = (int)_device.FilterSettings.filterCbmax;
        //    multiScrollCrFilter.MultiMinValue = (int)_device.FilterSettings.filterCrmin;
        //    multiScrollCrFilter.MultiMaxValue = (int)_device.FilterSettings.filterCrmax;
        }

        private void numericUpDownCountEncoder_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nudTmp = sender as NumericUpDown;
            device.FrequencyResponse = (int)nudTmp.Value;
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

        private void numericUpDownUnionObject_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nudTmp = sender as NumericUpDown;
            device.UnionObject = (int)nudTmp.Value;
        }

        private void multiScrollCbFilter_Load(object sender, EventArgs e)
        {
            
        }
    }
}
