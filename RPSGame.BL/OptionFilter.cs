using RPSGame.BL.Interfaces;
using RPSGame.Entity;

namespace RPSGame.BL
{
    public class OptionFilter : IBeat<Option>
    {
        public IEnumerable<Option> Beats(IEnumerable<Option> items, ISpecification<Option> specification)
        {
            foreach (var option in items)
            {
                var isSatisfied = items.Any(item => specification.IsSatisfied(option, item));
                if (isSatisfied)
                {
                    yield return option;
                }

            }
        }
    }
}
