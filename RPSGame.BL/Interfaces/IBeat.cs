using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSGame.BL.Interfaces
{
    public interface IBeat<T>
    {
        IEnumerable<T> Beats(IEnumerable<T> items, ISpecification<T> specification);
    }
}
