XISkillUpTool
=============
A project I've been working on to automate common tasks in Final Fantasy XI.
My idea is to create a system similar to FFXII with "Gambits".

In this application, a Gambit is a coupling of a trigger value and an action.

For example:
* Trigger a weaponskill at 100% tp to get through a WS quest or a magian trial.
* Target a certain npc when battle ends.
* Heal yourself or another party member when HP falls below x%.
* Create a macro for any action supported by FFACE - access any and all FFACE functionality.
* Trigger an existing macro in Windower based upon a Gambit trigger value.

Usage:
Triggers are currently defined in GambitBackgroundWorker.cs

ToDo:
* Create Gambits through UI.

Known Issues:
* PetTP trigger is not working.

Thanks:
Thanks to RZN for inspiring me to program, and for FFACE (http://www.ffevo.net)
and thanks to all the developers of Windower (http://www.windower.net)
The communities at both sites and on IRC are very helpful and still active with a game that's over 12 years old.

