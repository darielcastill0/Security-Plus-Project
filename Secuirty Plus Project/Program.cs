using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Secuirty_Plus_Project
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MessageBox.Show("Please select a csv file before continuing");
            OpenFileDialog open = new OpenFileDialog();


            open.Filter = "CSV Files (*.csv)|*.csv|Excel SpreadSheet (*.xlsx)|*.xlsx";
            open.ShowDialog();
            string file = open.FileName;
            Application.Run(new Form1(file));
            
            
        }
    }
}
