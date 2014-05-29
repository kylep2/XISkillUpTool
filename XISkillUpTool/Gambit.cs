using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FFACETools;
using System.Runtime.Remoting;

namespace XISkillUpTool
{
    public class Gambit
    {
        public string Name { get; set; }
        public StatTypes TriggerStat { get; set; }
        public dynamic TriggerValue { get; set; }
        private Func<dynamic, dynamic, bool> Comparison;
        public readonly CommandObject Command;
        public readonly bool Engaged;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_stat"></param>
        /// <param name="_value"></param>
        /// <param name="_comparison"></param>
        /// <param name="_command"></param>
        /// <param name="_cmd"></param>
        /// <param name="_name"></param>
        public Gambit(StatTypes _stat, dynamic _value, Func<dynamic, dynamic, bool> _comparison, CommandObject _command, string _name, bool _engaged)
        {
            Command = _command;
            Name = _name;
            TriggerStat = _stat;
            TriggerValue = _value;
            Comparison = _comparison;
            Engaged = _engaged;
        }

        public void Execute(FFACE fface)
        {
            dynamic result = "";
            try
            {
                result = Command.Function.Invoke();
                if (((ObjectHandle)result).Unwrap().GetType() == typeof(string))
                {
                    fface.Windower.SendString("//" + result);
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("/echo Failed to execute gambit: " + this.Name);
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
            /*
            var prefix = "";
            if (Command.Text.StartsWith("/") == false)
            {
                prefix = "//";
            }

            if (Command.Text.StartsWith("//fface") == false)
            {
                fface.Windower.SendString(prefix + Command.Text);
            } else {
            */

            
        }

        public bool Evaluate(FFACEState _ffstate)
        {
            //set currentvalue based on triggerstat and ffstate
            dynamic CurrentValue = -1;
            if (_ffstate.Engaged == Engaged)
            {
                if (TriggerStat.HasFlag(StatTypes.Enemy))
                {
                    if (TriggerStat.HasFlag(StatTypes.HP))
                    {
                        CurrentValue = _ffstate.EnemyHPP;
                    }
                    else if (TriggerStat.HasFlag(StatTypes.Target))
                    {
                        CurrentValue = _ffstate.Target;
                    }
                }
                else if (TriggerStat.HasFlag(StatTypes.Self))
                {
                    if (TriggerStat.HasFlag(StatTypes.Pet) == false)
                    {
                        // self non-pet triggers
                        if (TriggerStat.HasFlag(StatTypes.HP))
                        {
                            if (TriggerStat.HasFlag(StatTypes.Percent))
                            {
                                CurrentValue = _ffstate.SelfHPP;
                            }
                            else
                            {
                                CurrentValue = _ffstate.SelfHP;
                            }
                        }
                        else if (TriggerStat.HasFlag(StatTypes.MP))
                        {
                            if (TriggerStat.HasFlag(StatTypes.Percent))
                            {
                                CurrentValue = _ffstate.SelfMPP;
                            }
                            else
                            {
                                CurrentValue = _ffstate.SelfMP;
                            }
                        }
                        else if (TriggerStat.HasFlag(StatTypes.TP))
                        {
                            CurrentValue = _ffstate.SelfTP;

                        }
                    }
                    else if (TriggerStat.HasFlag(StatTypes.Pet))
                    {
                        if (TriggerStat.HasFlag(StatTypes.TP))
                        {
                            CurrentValue = _ffstate.PetTP;
                        }
                    }
                }
            }//add else if here to check for party/alliance members or pets

            return Comparison(CurrentValue, TriggerValue);
        }

    }
        
    public static class TriggerStats 
    {
        public static StatTypes EnemyHPP = StatTypes.Enemy | StatTypes.HP | StatTypes.Percent;
        public static StatTypes SelfHPP = StatTypes.Self | StatTypes.HP | StatTypes.Percent;
        public static StatTypes SelfHP = StatTypes.Self | StatTypes.HP | StatTypes.Value;
        public static StatTypes SelfMPP = StatTypes.Self | StatTypes.MP | StatTypes.Percent;
        public static StatTypes SelfMP = StatTypes.Self | StatTypes.MP | StatTypes.Value;
        public static StatTypes SelfTP = StatTypes.Self | StatTypes.TP | StatTypes.Percent;
        public static StatTypes PetTP = StatTypes.Pet | StatTypes.TP | StatTypes.Percent;
        public static StatTypes PetHPP = StatTypes.Pet | StatTypes.HP | StatTypes.Percent;
        public static StatTypes EnemyTarget = StatTypes.Enemy | StatTypes.Target | StatTypes.Value;
    }

    [FlagsAttribute]
    public enum StatTypes
    {
        //0x1111
        //  ^^^^-(first 2 digits) HP, MP, TP. 0x01 = hp, 0x10 = mp, 0x11 = tp
        //  ||--Percentage, 1 == true (ie, 75 = 75%)
        //  |---Enemy, 1 == true, 0 == false (self)
        //must be modified to be able to work for party
        //pet value comes from 128 + 32
        Target = 256,
        Pet = 160,
        Value = 64,
        Self = 32,
        HP = 1,
        MP = 2,
        TP = 4,
        Percent = 8,
        Enemy = 16

    }

    public sealed class GambitComparison
    {
        //http://csharpindepth.com/articles/general/singleton.aspx#lock
        private static readonly Lazy<GambitComparison> lazy = new Lazy<GambitComparison>(() => new GambitComparison());
        public static GambitComparison Instance { get { return lazy.Value; } }

        public static Func<dynamic, dynamic, bool> LessThan;
        public static Func<dynamic, dynamic, bool> LessThanOrEqual;
        public static Func<dynamic, dynamic, bool> Equal;
        public static Func<dynamic, dynamic, bool> GreaterThanOrEqual;
        public static Func<dynamic, dynamic, bool> GreaterThan;
        public static Func<dynamic, dynamic, bool> NotEqual;

        private GambitComparison()
        {
            LessThan = 
                delegate(dynamic lhs, dynamic rhs) {
                    return lhs < rhs; 
                };

            LessThanOrEqual = 
                delegate(dynamic lhs, dynamic rhs) { 
                    return lhs <= rhs; 
                };

            Equal = 
                delegate(dynamic lhs, dynamic rhs) { 
                    return lhs == rhs; 
                };

            GreaterThanOrEqual = 
                delegate(dynamic lhs, dynamic rhs) { 
                    return lhs >= rhs; 
                };

            GreaterThan = 
                delegate(dynamic lhs, dynamic rhs) { 
                    return lhs > rhs; 
                };
            NotEqual =
                delegate(dynamic lhs, dynamic rhs) {
                    return lhs != rhs;
                };
        }

    }

    public class FFACEState
    {
        public readonly int EnemyHPP;
        public readonly int SelfHPP;
        public readonly int SelfHP ;
        public readonly int SelfMPP;
        public readonly int SelfMP;
        public readonly int SelfTP;
        public readonly int PetTP;
        public readonly bool Engaged;
        public readonly string Target;

        public FFACEState(FFACE _fface)
        {
            EnemyHPP = _fface.Target.HPPCurrent;
            SelfHPP = _fface.Player.HPPCurrent;
            SelfHP = _fface.Player.HPCurrent;
            SelfMPP = _fface.Player.MPPCurrent;
            SelfMP = _fface.Player.MPCurrent;
            SelfTP = _fface.Player.TPCurrent;
            PetTP = _fface.NPC.TPCurrent(_fface.NPC.PetID(_fface.Player.ID));
            Engaged = (_fface.Player.Status == FFACETools.Status.Fighting);
            Target = _fface.Target.Name;
        }

    }

}
