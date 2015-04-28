using Robovator.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Robovator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Engine engine = Engine.getInstance();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(engine));
        }
    }
}
