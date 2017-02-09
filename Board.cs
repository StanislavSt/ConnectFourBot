using System;
using System.Text;

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

        private int RowsNumber()
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