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

    internal static void placePlayer(Player player)
    {
        board[player.Position] = player.Symbol;
    }

    public static void printBoard()
    {
        Console.Clear();

        Console.WriteLine("   A  B  C  D  E  F  G  H  I ");

        for (byte b = 0; b < 9; b++)
        {
            Console.Write(b + 1 + " ");
            for (byte c = 0; c < 9; c++)
                Console.Write(" " + board[(b * 9) + c] + " ");
            Console.WriteLine();
        }
    }

    private static void movePlayerPiece(Player player, string direction)
    {
        board[player.Position + (sbyte)Enum.Parse(typeof(Movement), direction, true)] = board[player.Position];
        board[player.Position] = '▢';
    }

}