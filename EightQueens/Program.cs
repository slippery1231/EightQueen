using System;

namespace EightQueens
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var board = new Board();
            board.PlaceQueen(0);
            Console.WriteLine("total solutions:" + board.Result);
        }
    }
}
