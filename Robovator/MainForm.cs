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

namespace Robovator1._3
{
    public partial class MainForm : Form
    {
        private static ILog _logger = LogManager.GetLogger(typeof(MainForm));

        public MainForm()
        {
            InitializeComponent();            
        }

        private void newCamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormOfOneCam frm = new FormOfOneCam() { MdiParent = this };
                frm.Show();
                frm.OnObjectFound += frm_OnObjectFound;
            }
            catch (Exception ex) 
            {
                _logger.Error("", ex);
            }
        }

        void frm_OnObjectFound()
        {
            int sdfg = 0;
        }
    }
}
