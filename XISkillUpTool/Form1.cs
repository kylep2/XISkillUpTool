using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FFACETools;

namespace XISkillUpTool
{
    public partial class Form1 : Form
    {
        public FFACE fface { get; set; }

        //public BackgroundWorker Updater;
        public GambitBackgroundWorker Gambits;
        
        public Form1()
        {
            //Updater = new BackgroundWorker();
            //Updater.DoWork += Updater_DoWork;
            //Updater.RunWorkerCompleted +=Updater_RunWorkerCompleted;

            



            InitializeComponent();
            Process[] pol = Process.GetProcessesByName("pol");
            //make sure pol is running
            if (1 > pol.Length)
            {
                //let the user know what went wrong
                MessageBox.Show("FFXI not found");
                System.Environment.Exit(0);
                //close the form
            }

            //create the instance using the first pol process found
            fface = new FFACE(pol[0].Id);

            Gambits = new GambitBackgroundWorker(fface);


            //RefreshChat();
                
        }


        private void txtCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                btnSend.PerformClick();
            }
            else if (ModifierKeys.HasFlag(Keys.Control) || ModifierKeys.HasFlag(Keys.Alt) || ModifierKeys.HasFlag(Keys.LWin))
            {
                MessageBox.Show("Macro" + e.KeyCode.ToString());
            }

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            //fface.Windower.SendString("/echo string")
            SendWindowerString(txtCommand.Text);
            //fface.Windower.SendString("/sigh");
            txtCommand.Clear();
        }

        private void SendWindowerString(string s)
        {
            fface.Windower.SendString("//" + s);
            
        }

        /*private void RefreshChat()
        {
            while (fface.Chat.IsNewLine == true)
            {
                var cline = fface.Chat.GetNextLine();
                var cline2 = fface.Chat.GetNextLine();
                do
                {
                    if (cline != null && cline2 != null)
                    {
                        toolStripStatusLabel1.Text = cline.Text;
                        if (cline.Type == FFACETools.ChatMode.SkillBoost)
                        {
                            lboxSkillUp.Items.Add(cline.Text);
                        }
                    }
                    cline = fface.Chat.GetNextLine();
                    cline2 = fface.Chat.GetNextLine();
                } while (cline != null && cline2 != null && cline.Index != cline2.Index);
            }
        }*/

        /*private void UpdaterRun()
        {
            Updater.RunWorkerAsync();
        }*/

        private void Updater_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(100);
        }

        private void Updater_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //RefreshChat();
            //UpdatePlayerStats();
            //UpdateTargetStats();
            //UpdaterRun();
        }
    }
}
