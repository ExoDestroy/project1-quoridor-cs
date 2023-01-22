using System;

namespace GameObjects;

public delegate void MoveDel(Player player, string direction);
public delegate bool PlaceWallDel(Player player, string location, string direction);

public static class Board
{

    public static MoveDel movePlayer = (MoveDel)(movePlayerPiece) + (MoveDel)(Player.movePlayerPosition);
    public static PlaceWallDel placeWall = (PlaceWallDel)(placePlayerWall);
    
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

    private static bool placePlayerWall(Player player, string location, string direction)
    {

        int pos = (int)((Char.GetNumericValue(location[1]) - 1) * 9) + (int)("abcdefghi".IndexOf(location[0]));
        int nextPos;

        if (direction == "flat")
        {
            nextPos = pos + 1;
            if (nextPos % 9 == 0)
                return false;
        }
        else if (direction == "tall")
        {
            nextPos = pos + 9;
            if (nextPos > 80)
                return false;
        }
        else
            throw new Exception();


        if (board[pos] != '■' || board[nextPos] != '■')
            return false;
        else
        {
            board[pos] = '#';
            board[nextPos] = '#';
            player.Walls--;
            return true;
        }

    }

}