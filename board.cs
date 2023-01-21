using System;

namespace GameObjects;

public static class Board
{
    
    internal static char[] board = 
    {
      '■', '■', '■', '■', '■', '■', '■', '■', '■',
      '■', '■', '■', '■', '■', '■', '■', '■', '■',
      '■', '■', '■', '■', '■', '■', '■', '■', '■',
      '■', '■', '■', '■', '■', '■', '■', '■', '■',
      '■', '■', '■', '■', '■', '■', '■', '■', '■',
      '■', '■', '■', '■', '■', '■', '■', '■', '■',
      '■', '■', '■', '■', '■', '■', '■', '■', '■',
      '■', '■', '■', '■', '■', '■', '■', '■', '■',
      '■', '■', '■', '■', '■', '■', '■', '■', '■'
    };

    internal static void placePlayer(Player player)
    {
        board[player.Position] = player.Symbol;
    }

    public static void printBoard()
    {  
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("   A  B  C  D  E  F  G  H  I ");
        Console.ResetColor();

        for (byte b = 0; b < 9; b++)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(b + 1 + " ");
            Console.ResetColor();
            for (byte c = 0; c < 9; c++)
                Console.Write(" " + board[(b * 9) + c] + " ");
            Console.WriteLine();
        }
    }

    internal static void movePlayerPiece(Player player, string direction)
    {
        board[player.Position + (sbyte)Enum.Parse(typeof(Movement), direction, true)] = board[player.Position];
        board[player.Position] = '■';
    }

}