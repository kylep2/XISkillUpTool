using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using FFACETools;

namespace XISkillUpTool
{
    public class GambitBackgroundWorker : BackgroundWorker
    {
        private GambitComparison gambitcomparison;
        public GambitList gambits;
        private FFACE _fface;
        public FFACE fface { get { return _fface; } }

        public GambitBackgroundWorker(FFACE pFFACE)
        {
            _fface = pFFACE;
            gambitcomparison = GambitComparison.Instance;
            gambits = new GambitList();
            //! TODO: programmatically instead of manual
            //gambits.Add(new Gambit(TriggerStats.SelfHPP, 70, GambitComparison.LessThanOrEqual, new CommandObject("/ja Curing Waltz II Higeki", PriorityEnum.Healing), "Self HPP LTE 70: Curing Waltz II"));
            gambits.Add(new Gambit(TriggerStats.SelfTP, 100, GambitComparison.GreaterThanOrEqual, new CommandObject(() => {return "//rampage";}, PriorityEnum.Damaging),"Self TP GTE 100: Rampage", Status.Fighting));
            gambits.Add(new Gambit(TriggerStats.EnemyTarget, "Bloodsucker", GambitComparison.NotEqual, new CommandObject(() => { fface.Windower.SendKeyPress(KeyCode.TabKey); return 0; }, PriorityEnum.Last), "Target Bloodsucker", Status.Standing));
            //gambits.Add(new Gambit(TriggerStats.PetTP, 100, GambitComparison.GreaterThanOrEqual, new CommandObject("//ss", PriorityEnum.Damaging), "PetTP GTE 100: Spiral Spin", true));
            //gambits.Add(new Gambit(TriggerStats.SelfTP, 100, GambitComparison.GreaterThanOrEqual, new CommandObject("Exenterator", PriorityEnum.Damaging), "Self TP GTE 100: Exenterator"));
            //;wait 3;rf;wait 1;presto;wait 1;featherstep
            this.DoWork += GambitBackgroundWorker_DoWork;
            this.RunWorkerCompleted += GambitBackgroundWorker_RunWorkerCompleted;
        }

        public void Run()
        {
            if (!this.IsBusy)
            {
                try
                {
                    this.RunWorkerAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw e;
                }
                
            }
        }

        void GambitBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //create a FFACEState and send it to be evaluated
            System.Threading.Thread.Sleep(100);
        }

        void GambitBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var ffs = new FFACEState(fface);
            var result = gambits.Evaluate(ffs);
            //System.Diagnostics.Debug.WriteLine(DateTime.Now.ToString() + "Gambit returned to main thread, results count: " + result.Count);
            foreach (Gambit g in result)
            {
                fface.Windower.SendString("/echo " + g.Name);
                g.Execute(fface);
                /*int counter = 5;
                while (counter > 0)
                {
                    System.Threading.Thread.Sleep(1000);
                    counter--;
                }*/
                //g.Execute();
            }
            this.Run();
        }
    }
}
