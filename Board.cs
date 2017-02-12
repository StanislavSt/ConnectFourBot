using System;
using System.Text;
using System.Linq;

namespace FourInARow
{
    /// <summary>
    /// A game board
    /// </summary>
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

        //Check if there if I'm the winner on the board
        public bool getWinner()
        {
            //Check for horizontal and vertical winner
            for(int i = 0; i < this.ColsNumber() ; i++)
                for(int j = 0 ; j < this.RowsNumber() ; j++)
                {
                        // Horizontal win
                        if(i < 4)
                            if (this.State(j, i) == FieldState.Me
                                && this.State(j, i + 1) == FieldState.Me
                                && this.State(j, i + 2) == FieldState.Me
                                && this.State(j, i + 3) == FieldState.Me)
                                return true;
                        //Vertical win 
                        if(j < 3)
                           if (this.State(j,i)==FieldState.Me 
                                && this.State(j,i+1) == FieldState.Me 
                                && this.State(j,i+2) == FieldState.Me 
                                && this.State(j,i+3) == FieldState.Me)
                        return true;
                }
            //Check the diagonals
            for (int j = 0; j < 2; j++)
                for(int i = 0 ; i <3 ; i++)
                    if (this.State(j, i) == FieldState.Me
                                && this.State(j+1, i + 1) == FieldState.Me
                                && this.State(j+2, i + 2) == FieldState.Me
                                && this.State(j+3, i + 3) == FieldState.Me)
                        return true;
            for (int j = 3; j < 5; j++)
                for(int i = 0 ; i <3 ; i++)
                    if (this.State(j, i) == FieldState.Me
                                && this.State(j - 1, i + 1) == FieldState.Me
                                && this.State(j - 2, i + 2) == FieldState.Me
                                && this.State(j - 3, i + 3) == FieldState.Me)
                        return true;
           //If no winner found
            return false;
        }

        public int RowsNumber()
        {
            return _boardArray.Length;
        }

        public FieldState State(int row, int col)
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