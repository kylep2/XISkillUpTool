using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XISkillUpTool
{
    public class CommandObject
    {
        public readonly string Text;
        public readonly PriorityEnum Priority;
        public CommandObject(string _cmd, PriorityEnum _priority)
        {
            Text = _cmd;
            Priority = _priority;
        }

    }
    public enum PriorityEnum
    {
        Immediate = 0,
        Healing = 1,
        Damaging = 2,
        HealingBuff = 3,
        Debuff = 4,
        Last = 9999
    }
}
