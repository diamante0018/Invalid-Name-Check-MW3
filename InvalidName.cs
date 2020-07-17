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

        public Boolean canConnect(string Name)
        {
            if (string.IsNullOrWhiteSpace(Name) || Name.Replace(" ", "").Length < 3)
            {
                return false;
            }
            return isNotControl(Name);
        }

        public Boolean isNotControl(string Name)
        {
            foreach(Char c in Name) {
                if (Char.IsControl(c))
                    return false;
            }
            return true;
        }
    }
}