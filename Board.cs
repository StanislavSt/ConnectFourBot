using System;
using System.Linq;
using System.Text;

namespace FourInARow
{
    /// <summary>
    /// A game board
    /// </summary>
    public class Board
    {
        private int[][] _boardArray;
        private int _mybotId;

        /// <summary>
        /// Updates the Id of the bot 
        /// </summary>
        /// It can be either 1 or 2
        /// <param name="myBotId"></param>
        public void SetMyBotId(int myBotId)
        {
            _mybotId = myBotId;
        }

        /// <summary>
        /// Update the board
        /// </summary>
        /// <param name="boardArray">board in a matrix format</param>
        public void Update(int[][] boardArray)
        {
            _boardArray = boardArray;
        }

        public int ColsNumber()
        {
            return _boardArray[0].Length;
        }

        /// <summary>
        /// Check if the board is empty
        /// </summary>
        /// <returns></returns>
        public bool boardIsEmpty()
        {
            //Check for each field if it is empty
            for(int i = 0;i < ColsNumber(); i ++)
                for(int j = 0; j < RowsNumber(); j ++)
                    if(State(j,i) != FieldState.Free)
                        return false;
            //Board is not empty
            return true;
        }

       /// <summary>
       /// returns 'true' if there is a winner
       /// </summary>
       /// <returns></returns>
        public bool getWinner()
        {
            FieldState tempState =  new FieldState();
            //Check for horizontal and vertical winner
            for(int i = 0; i < this.ColsNumber() ; i++)
                for(int j = 0 ; j < this.RowsNumber() ; j++)
                {
                    // Horizontal win
                    if (i < 4)
                    {
                        if (this.State(j, i) != FieldState.Free)
                        {
                            tempState = this.State(j, i);
                            if (this.State(j, i + 1) == tempState
                                    && this.State(j, i + 2) == tempState
                                    && this.State(j, i + 3) == tempState)
                                return true;
                        } 
                    }
                    //Vertical win 
                    if (j < 3)
                    {
                        if (this.State(j, i) != FieldState.Free)
                        {
                            tempState = this.State(j, i);
                            if (this.State(j + 1, i) == tempState
                                    && this.State(j + 2, i) == tempState
                                    && this.State(j + 3, i) == tempState)
                                return true;
                        }
                    }
                }
            //Check the diagonals
            for (int j = 0; j < 3; j++)
                for (int i = 0; i < 4; i++)
                {
                    if (this.State(j, i) != FieldState.Free)
                    {
                        tempState = this.State(j, i);
                        if (this.State(j + 1, i + 1) == tempState
                                    && this.State(j + 2, i + 2) == tempState
                                    && this.State(j + 3, i + 3) == tempState)
                            return true;
                    }
                }
            for (int j = 3; j < 6; j++)
                for (int i = 0; i < 4; i++)
                {
                    if (this.State(j, i) != FieldState.Free)
                    {
                        tempState = this.State(j, i);
                        if (this.State(j - 1, i + 1) == tempState
                                    && this.State(j - 2, i + 2) == tempState
                                    && this.State(j - 3, i + 3) == tempState)
                            return true;
                    }
                }
           //If no winner found
            return false;
        }

        public int RowsNumber()
        {
            return _boardArray.Length;
        }
        /// <summary>
        /// Returns the state for the given position
        /// </summary>
        /// <param name="row">Row</param>
        /// <param name="col">Column</param>
        /// <returns></returns>
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