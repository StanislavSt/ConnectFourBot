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


            for(int i = 0 ; i < board.ColsNumber(); i++)
            {
                
                if(board.State(i,0) == FieldState.Me)
                    col = i+1;

            }
            for(int i = 0; i < board.RowsNumber(); i ++ )
            {
                if (board.getWinner_Me(i,col))
                {
                    col = 6;
                    return col;
                }      
            }
            return col;
            
            
        }
    }

}