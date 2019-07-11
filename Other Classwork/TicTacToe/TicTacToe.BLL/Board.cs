using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.BLL
{
    public class Board
    {
        public const int SLOTS = 9;
        private BoardStatus[] _board;

        public Board()
        {
            _board = new BoardStatus[SLOTS];
            Reset();
        }

        //private bool CalcWinner(int position)
        //{
        //    int x = (position - 1) % 3; //TODO make this RC_MAX
        //    int y = (position - 1) / 3;
        //    BoardStatus bs = _board[position - 1];

        //    const int HOR = 0;
        //    const int Ver = 1;
        //    const int LDG = 2;
        //    const int RDG = 3;
        //    const int TEST = 4;
        //    int[] totals = new int[TEST];

        //    //for(int i =0; i < 3; ++1)
        //    //{
        //    //    if (_board[RowFromXY(i, y)] == bs)
        //    //        ++totals[HOR];
        //    //    if (_board[RowFromXY(x, i)] == bs)
        //    //        ++totals[Ver];
        //    //    if (_board[RowFromXY])
        //    //}
        //}

        public void Reset()
        {
            for(int i = 0; i < _board.Length; ++i)
            {
                _board[i] = BoardStatus.none;
            }
        }
        public bool IsValidPosition(int position)
        {
            return (position >= 1 && position <= 9);
        }
        public MoveResult MakeMove(MoveRequest request)
        {
            MoveResult response = MoveResult.Invalid;

            if(IsValidPosition(request.MoveTarget))
            {
                if (_board[request.MoveTarget -1] != BoardStatus.none)
                {
                    response = MoveResult.Unavailable;
                }
                else
                {
                    _board[request.MoveTarget - 1] = request.PlayerLetter == PlayerLetter.O ? BoardStatus.O : BoardStatus.X;
                    response = MoveResult.Success;

                    if (_board.All(bs => bs != BoardStatus.none))
                    {
                        response = MoveResult.Draw;
                    }
                }
            }
            return response;
        }

        public BoardStatus GetPositionStatus(int position)
        {
            BoardStatus response;
            if (IsValidPosition(position))
            {
                response = _board[position - 1];
            }
            else
            {
                throw new Exception("Bad programmer");
            }
            return response;
        }
    }
}
