using System;

namespace GameObjects;

public static class Board
{
    private static char[] board = 
    {
      '▢', '▢', '▢', '▢', '▢', '▢', '▢', '▢', '▢',
      '▢', '▢', '▢', '▢', '▢', '▢', '▢', '▢', '▢',
      '▢', '▢', '▢', '▢', '▢', '▢', '▢', '▢', '▢',
      '▢', '▢', '▢', '▢', '▢', '▢', '▢', '▢', '▢',
      '▢', '▢', '▢', '▢', '▢', '▢', '▢', '▢', '▢',
      '▢', '▢', '▢', '▢', '▢', '▢', '▢', '▢', '▢',
      '▢', '▢', '▢', '▢', '▢', '▢', '▢', '▢', '▢',
      '▢', '▢', '▢', '▢', '▢', '▢', '▢', '▢', '▢',
      '▢', '▢', '▢', '▢', '▢', '▢', '▢', '▢', '▢'
    };

    public static void printBoard()
    {
        Console.Clear();

        Console.WriteLine("   A  B  C  D  E  F  G  H  I ");

        for (byte b = 0; b < 9; b++)
        {
            Console.Write(b + 1 + " ");
            for (byte c = 0; c < 9; c++)
                Console.Write(board[(b * 9) + c] + " ");
            Console.WriteLine();
        }
    }

    private static void movePlayerPiece(int currentPosition, string direction)
    {

    }
}