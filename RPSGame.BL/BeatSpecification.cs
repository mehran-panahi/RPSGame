using RPSGame.BL.Interfaces;
using RPSGame.Entity;

namespace RPSGame.BL
{
    public class BeatSpecification : ISpecification<Option>
    {
        public bool IsSatisfied(Option primary, Option secondary)
        {
            return primary.Beats.Contains(secondary.Type);
        }
    }
}
