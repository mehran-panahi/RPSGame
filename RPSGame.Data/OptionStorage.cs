using RPSGame.Entity;
using RPSGame.Entity.Enums;

namespace RPSGame.Data
{
    public class OptionStorage
    {
        private static Lazy<OptionStorage> _instance = new Lazy<OptionStorage>(() => new OptionStorage());
        public static OptionStorage Instance => _instance.Value;

        protected OptionStorage()
        {
            Options = new List<Option>(3)
            {
                new Option(type: OptionTypes.Rock, beats: OptionTypes.Scissors),
                new Option(type: OptionTypes.Paper, beats: OptionTypes.Rock),
                new Option(type: OptionTypes.Scissors, beats: OptionTypes.Paper)
            };
        }

        public IEnumerable<Option> Options { get; private set; }
    }
}
