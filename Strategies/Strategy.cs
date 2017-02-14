using System.Collections.Generic;
using System;
using System.Linq;

namespace FourInARow.Strategies
{
    public class Strategy : IStrategy
    {
        public int NextMove(Board board)
        {
            //TODO: write your code to choose best move on current board
            Random r = new Random();
            var col = r.Next(board.ColsNumber());

            //Always start with the 4th column if you are first
            if(board.IsEmpty)
            {
                col = 3;
                return col ;
            }

            var moves = new List<Tuple<int, int>>();
            for (int i = 0; i < board.ColsNumber(); i ++ )
            {
                if(!board.DoMove(1,i))
                    continue;
                moves.Add(Tuple.Create(i, MinMax(5, board, false)));
                board.UndoMove(i);
            }

            int maxMoveScore = moves.Max(t => t.Item2);
            var bestMoves = moves.Where(t => t.Item2 == maxMoveScore).ToList();
            return bestMoves[0].Item1;
        }

        //To Do:
        private static int MinMax(int depth, Board board, bool maximizingPlayer)
        {
            if (depth <= 0)
                return 0;

            var winner = board.getWinner();
            if (winner == 1)
                return depth;
            if (winner == 2)
                return -depth;
            if (board.IsFull)
                return 0;

            //Are we maximizing or minimizing 
            int bestValue = maximizingPlayer ? -1 : 1;
            for (int i = 0; i < board.ColsNumber(); i++)
            {
                if (!board.DoMove(maximizingPlayer ? 2 : 1, i))
                    continue;
                int v = MinMax(depth - 1, board, !maximizingPlayer);
                bestValue = maximizingPlayer ? Math.Max(bestValue, v) : Math.Min(bestValue, v);
                board.UndoMove(i);
            }

            return bestValue;    
        }
    }

}