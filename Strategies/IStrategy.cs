using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourInARow.Strategies
{
    public interface IStrategy
    {
        int NextMove(Board board);
    }
}
