using System;

namespace EightQueens
{
    internal class Board
    {
        private const int Size = 8;
        private readonly int[] _queen = new int[Size]; // 皇后所在列的位置
        public int Result = 0; // 紀錄結果個數
        private readonly bool[] _columns = new bool[Size]; // 紀錄列是否被占用
        private readonly bool[] _diagonalLeftToRight = new bool[2 * Size - 1]; // 紀錄對角線(左上右下)是否被占用
        private readonly bool[] _diagonalRightToLeft = new bool[2 * Size - 1]; // 紀錄對角線(右上左下)是否被占用

        public void PlaceQueen(int row)
        {
            if (row == Size)
            {
                Result += 1;
                PrintResult(Result);
                return;
            }

            for (var column = 0; column < Size; column++)
            {
                if (CheckIsSafe(row, column))
                {
                    _queen[row] = column;
                    _columns[column] = true;
                    _diagonalLeftToRight[row - column + Size - 1] = true;
                    _diagonalRightToLeft[row + column] = true;
                    PlaceQueen(row + 1);

                    // 回頭修正
                    _diagonalRightToLeft[row + column] = false;
                    _diagonalLeftToRight[row - column + Size - 1] = false;
                    _columns[column] = false;
                }
            }
        }

        /// <summary>
        ///印出結果 
        /// </summary>
        /// <param name="result"></param>
        private void PrintResult(int result)
        {
            Console.WriteLine("Solution: " + result);
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    if (_queen[i] == j)
                    {
                        Console.Write("Q ");
                    }
                    else
                    {
                        Console.Write(". ");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        /// <summary>
        ///檢查該位置是否安全 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        private bool CheckIsSafe(int row, int column)
        {
            return !_columns[column] && !_diagonalLeftToRight[row - column + Size - 1] &&
                   !_diagonalRightToLeft[row + column];
        }
    }
}