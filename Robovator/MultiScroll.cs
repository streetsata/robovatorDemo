using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Robovator
{
    public partial class MultiScroll : UserControl
    {
        public class MultiScrollEventArgs
        {
            public int NewMinValue { get; set; }
            public int NewMaxValue { get; set; }
            //public int OldMinValue { get; set; }
            //public int OldMaxValue { get; set; }
        }

        //public delegate void ScrollEventHandler(object sender, ScrollEventArgs e);
        public delegate void MultiScrollEventHandler(object sender, MultiScrollEventArgs e);
        //public event ScrollEventHandler ScrollA;
        //public event ScrollEventHandler ScrollB;
        public event MultiScrollEventHandler OnMultiScroll;

        private int minValue = 0;
        private int maxValue = 0;

       public int MultiMinValue
        {
            get { return hScrollBarA.Value; }
            set { label1.Text = value.ToString(); hScrollBarA.Value = value; }
        }

        public int MultiMaxValue
        {
            get { return hScrollBarB.Value; }
            set { label2.Text = value.ToString(); hScrollBarB.Value = value; }
        }

        public int MinValue
        {
            get { return minValue; }
            set
            {
                label1.Text = value.ToString();
                hScrollBarA.Minimum = value;
                hScrollBarB.Minimum = value;
                minValue = value;
            }
        }

        public int MaxValue
        {
            get { return maxValue; }
            set
            {
                label2.Text = value.ToString();
                hScrollBarA.Maximum = value;
                hScrollBarB.Maximum = value;
                maxValue = value;
            }
        }

        public MultiScroll()
        {
            InitializeComponent();

            hScrollBarA.Scroll += hScrollBarA_Scroll;
            hScrollBarB.Scroll += hScrollBarB_Scroll;
        }

        void hScrollBarA_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.NewValue >= hScrollBarB.Value - 1)
            {
                //e.NewValue = e.OldValue;
                if (e.NewValue + hScrollBarB.SmallChange > hScrollBarB.Maximum)
                    hScrollBarB.Value = hScrollBarB.Maximum;
                else
                    hScrollBarB.Value = e.NewValue + hScrollBarB.SmallChange;
                label2.Text = hScrollBarB.Value.ToString();
            }
            label1.Text = e.NewValue.ToString();
            if (OnMultiScroll != null)
            {
                OnMultiScroll(sender, new MultiScrollEventArgs()
                {
                    NewMaxValue = hScrollBarB.Value,
                    NewMinValue = hScrollBarA.Value
                });
            }
        }

        void hScrollBarB_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.NewValue <= hScrollBarA.Value + 1)
            {
                //e.NewValue = e.OldValue;
                //if (e.NewValue - hScrollBarA.SmallChange)
                //    hScrollBarA.Value = 0;
                //else
                if (e.NewValue - hScrollBarA.SmallChange > hScrollBarA.Minimum)
                    hScrollBarA.Value = e.NewValue - hScrollBarA.SmallChange;
                label1.Text = hScrollBarA.Value.ToString();
            }
            label2.Text = e.NewValue.ToString();
            if (OnMultiScroll != null)
            {
                OnMultiScroll(sender, new MultiScrollEventArgs()
                {
                    NewMaxValue = hScrollBarB.Value,
                    NewMinValue = hScrollBarA.Value
                });
            }
        }
    }
}
