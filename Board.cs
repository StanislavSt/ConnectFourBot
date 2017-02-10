using System;
using System.Text;
using System.Linq;

namespace FourInARow
{
    public class Board
    {
        private int[][] _boardArray;
        private int _mybotId;

        public void SetMyBotId(int myBotId)
        {
            _mybotId = myBotId;
        }

        public void Update(int[][] boardArray)
        {
            _boardArray = boardArray;
        }

        public int ColsNumber()
        {
            return _boardArray[0].Length;
        }

        public bool boardIsEmpty()
        {
            for(int i = 0;i < ColsNumber(); i ++)
            {
                for(int j = 0; j < RowsNumber(); j ++)
                if(State(i,j) != FieldState.Free)
                    return false;
            }
            return true;
        }

        //Check if there is a winner , after the performed move
        public bool getWinner_Me(int row, int col)
        {
            
            Board tempBoard = new Board();
            tempBoard = this;
            tempBoard._boardArray[row][col] = 1;

            for(int i = 0; i < ColsNumber(); i++)
                for(int j = 0 ; j < RowsNumber(); j++)
                {
                    // Check for rows
                    if( tempBoard.State(j,i)==FieldState.Me && tempBoard.State(j,i+1) == FieldState.Me && tempBoard.State(j,i+2) == FieldState.Me && tempBoard.State(j,i+3) == FieldState.Me)
                        return true;

                    //Check for Column
                    else if (tempBoard.State(j,i)==FieldState.Me && tempBoard.State(j+1,i) == FieldState.Me && tempBoard.State(j+2,i) == FieldState.Me && tempBoard.State(j+3,i) == FieldState.Me)
                        return true;
                }
            for(int i = 0; i < ColsNumber(); i++)
                for(int j = 0 ; j < RowsNumber(); j++)
                    for(int d = -1 ; d<=1; d+=2)
                    {
                        if(tempBoard.State(j,i)==FieldState.Me && tempBoard.State(j+1,i+1*d) == FieldState.Me && tempBoard.State(j+2,i+2*d) == FieldState.Me && tempBoard.State(j+3,i+3*d) == FieldState.Me)
                        return true;
                    }
            return false;
        }

        public int RowsNumber()
        {
            return _boardArray.Length;
        }

        public FieldState State(int col, int row)
        {
            if (_boardArray[row][col] == 0) return FieldState.Free;
            if (_boardArray[row][col] == _mybotId) return FieldState.Me;
            return FieldState.Opponent;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < RowsNumber(); i++)
            {
                for (int j = 0; j < ColsNumber(); j++)
                {
                    sb.Append(_boardArray[i][j]).Append(" ");
                }
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }
    }
}