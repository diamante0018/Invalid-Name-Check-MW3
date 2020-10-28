using InfinityScript;
using System;

namespace InvalidName
{
    class InvalidName : BaseScript
    {
        public InvalidName()
        { 
            base.PlayerConnected += delegate (Entity player)
            {
                if(!canConnect(player.Name))
                {
                    Utilities.ExecuteCommand($"dropclient {player.EntRef} \"Invalid Name Buddy\"");
                }
            };
        }

        public override EventEat OnSay3(Entity player, BaseScript.ChatType type, string name, ref string message)
        {
            if(!isNotControl(message))
            {
                Utilities.ExecuteCommand($"dropclient {player.EntRef} \"Lame Way to Crash Clients\"");
                return EventEat.EatGame;
            }

            return EventEat.EatNone;
        }

        public Boolean canConnect(string Name)
        {
            if (string.IsNullOrWhiteSpace(Name) || Name.Replace(" ", "").Length < 4)
            {
                return false;
            }
            return isNotControl(Name);
        }

        public Boolean isNotControl(string Word)
        {
            foreach(Char c in Word) {
                if (Char.IsControl(c))
                    return false;
            }
            return true;
        }
    }
}