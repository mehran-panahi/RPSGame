using RPSGame.Data;
using RPSGame.Entity;

namespace RPSGame.BL
{
    public class MachinePlayer : Player
    {

        public MachinePlayer(string playerName)
            : base(playerName)
        {
            //for base class initialization
        }

        public override Option Guess()
        {
            CurrentChoice = CurrentChoice == Option.Default
                 ? OptionStorage.Instance.Options.First()
                 : OptionStorage.Instance.Options.FirstOrDefault(item =>
                     CurrentChoice.Beats.Contains(item.Type));
            return CurrentChoice;
        }

    }
}
