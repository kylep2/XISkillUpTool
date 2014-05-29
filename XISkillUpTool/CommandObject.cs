using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XISkillUpTool
{
    public class CommandObject
    {
        public readonly Func<dynamic> Function;
        public readonly PriorityEnum Priority;
        public CommandObject(Func<dynamic> _cmd, PriorityEnum _priority)
        {
            Function = _cmd;
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
