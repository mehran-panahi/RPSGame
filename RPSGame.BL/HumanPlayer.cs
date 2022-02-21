using RPSGame.Data;
using RPSGame.Entity;
using RPSGame.Entity.Enums;

namespace RPSGame.BL
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(string playerName)
            : base(playerName)
        {
            //for base class initialization
        }

        public override Option Guess()
        {
            while (true)
            {
                Console.WriteLine("Choose between Rock, Paper and Scissors: ");
                var userInput = Console.ReadLine();
                var isValid = Enum.TryParse(userInput, true, out OptionTypes chosenOption);
                if (!isValid)
                {
                    Console.WriteLine("Please please enter a valid option!");
                    continue;
                }

                CurrentChoice = OptionStorage.Instance.Options.FirstOrDefault(item => item.Type == chosenOption);
                return CurrentChoice;
            }
        }
    }
}
