using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XISkillUpTool
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            //for( int val = 0; val <= 16; val++ )
            //    System.Diagnostics.Debug.WriteLine(string.Format("{0,3} - {1}", 
            //    val, ( (StatTypes)val ).ToString( ) ));
            Form1 form = new Form1();
            //form.Updater.RunWorkerAsync();
            form.Gambits.RunWorkerAsync();
            Application.Run(form);

        }
    }
}
