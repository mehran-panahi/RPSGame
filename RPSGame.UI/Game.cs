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
                    Console.WriteLine($"Winner in this round is {player}");
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
            const int MIN_NUMBER_OF_PLAYERS = 2;
            if (_players == null || _players.Count < MIN_NUMBER_OF_PLAYERS)
            {
                throw new NullReferenceException("At Least two players are required!");
            }

            var options = new List<Option>(_players.Count);
            while (true)
            {
                options.Clear();
                foreach (var player in _players)
                {
                    options.Add(player.Guess());
                }

                var isSame = options.Distinct().Count() == 1;
                if (!isSame)
                {
                    break;
                }
                Console.WriteLine("Selected options are same please try agin!");
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
