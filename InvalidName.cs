using ClanTagExt;
using InfinityScript;
using System.Text.RegularExpressions;

namespace InvalidName
{
    class InvalidName : BaseScript
    {
        private Regex rx = new Regex(@"^[\x00-\x7F]+$");
        public InvalidName()
        { 
            base.PlayerConnected += delegate (Entity player)
            {
                if(!(RegexWay(player.Name) && CheckClanTag(player)))
                {
                    Utilities.ExecuteCommand($"dropclient {player.EntRef} \"Invalid Name Buddy\"");
                }

                CheckLength(player);
            };
        }

        public bool CheckClanTag(Entity player)
        {
            if (string.IsNullOrEmpty(player.GetClanTag()))
                return true;

            return RegexWay(player.GetClanTag().Replace("^", ""));
        }

        public void CheckLength(Entity player)
        {
            if (string.IsNullOrWhiteSpace(player.Name) || player.Name.Replace(" ", "").Length < 4)
            {
                Utilities.ExecuteCommand($"dropclient {player.EntRef} \"Your Name is Too Short\"");
            }
        }

        public override EventEat OnSay3(Entity player, BaseScript.ChatType type, string name, ref string message)
        {
            if(!RegexWay(message.Replace("^", "")))
            {
                Utilities.ExecuteCommand($"dropclient {player.EntRef} \"Lame Way to Crash Clients\"");
                return EventEat.EatGame;
            }

            return EventEat.EatNone;
        }

        public bool RegexWay(string input)
        {
            if(!string.IsNullOrEmpty(input))
                return rx.IsMatch(input);
            return true;
        }
    }
}