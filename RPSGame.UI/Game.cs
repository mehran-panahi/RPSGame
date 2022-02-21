using RPSGame.BL;
using RPSGame.Entity;
using RPSGame.Entity.Enums;

namespace RPSGame.UI
{
    public class Game
    {
        private const int NUMBER_OF_SCORES_TO_WIN = 3;
        private List<Player> _players;
        private GameMode _gameMode;


        public void Start()
        {
            Initialize();
            while (true)
            {
                var options = GetPlayersOptions();
                var hasWinner = HasWinner(options, out var finalWinner);
                if (hasWinner)
                {
                    Console.WriteLine($"Final Winner is {finalWinner.Name} with {finalWinner.Score} scores.");
                    Console.Read();
                    break;
                }
            }

        }

        private bool HasWinner(IEnumerable<Option> options, out Player finalWinner)
        {
            finalWinner = null;
            var filter = new OptionFilter();
            var winnerOption = filter.Beats(options, new BeatSpecification()).ToArray();
            foreach (var player in _players)
            {
                if (winnerOption.Contains(player.CurrentChoice))
                {
                    player.AddScore();
                    Console.WriteLine($"Winner option was {player.CurrentChoice} and {player} won this round.");
                }

                if (player.Score < NUMBER_OF_SCORES_TO_WIN)
                {
                    continue;
                }

                finalWinner = player;
                return true;
            }

            return false;
        }


        private IEnumerable<Option> GetPlayersOptions()
        {
            if (_players == null)
            {
                throw new NullReferenceException("At Least one player is required!");
            }

            var options = new List<Option>(_players.Count);
            while (true)
            {
                options.Clear();
                foreach (var player in _players)
                {
                    options.Add(player.Guess());
                }

                if (options.Distinct().Count() > 1)
                {
                    break;
                }
            }

            return options;
        }


        private void Initialize()
        {
            _gameMode = GetGameMode();
            if (_gameMode == GameMode.SinglePlayer)
            {
                _players = new List<Player>(2)
                    {
                        new MachinePlayer("Machine Player"),
                        new HumanPlayer("Player One")
                    };
            }
            else
            {
                _players = new List<Player>(2)
                    {
                        new HumanPlayer("Player One"),
                        new HumanPlayer("Player Two")
                    };
            }
        }

        private GameMode GetGameMode()
        {
            while (true)
            {
                Console.Write("Please choose \"1\" for Single player or \"2'\" for Multi Player: ");
                var userInput = Console.ReadLine();
                var isValid = Enum.TryParse(userInput, true, out GameMode gameMode);
                if (!isValid)
                {
                    Console.WriteLine("Please please enter a valid option!");
                    continue;
                }

                return gameMode;
            }
        }
    }
}
