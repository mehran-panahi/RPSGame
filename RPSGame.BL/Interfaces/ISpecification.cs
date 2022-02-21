using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSGame.BL.Interfaces
{
    public interface ISpecification<T>
    {
        bool IsSatisfied(T primary, T secondary);
    }
}
