using System;

namespace FourInARow
{

    public interface IStrategy
    {
        int NextMove(Board board);
    }

    public class Strategy : IStrategy
    {
        public int NextMove(Board board)
        {
            //TODO: write your code to choose best move on current board
            
            Random r = new Random();

            
            var col = r.Next(board.ColsNumber());
            if(board.boardIsEmpty())
            {
                col = 3;
                return col ;
            }
            if (board.getWinner())
            {
                col = 1;
                return col;
            }      
            return col;
            
            
        }
    }

}