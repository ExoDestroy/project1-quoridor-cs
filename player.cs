using System;
using System.Collections.Generic;

namespace GameObjects;

internal enum Movement : sbyte
{
    Left    = -1,
    Right   = 1,
    Up      = -9,
    Down    = 9,
    JLeft    = -2,
    JRight   = 2,
    JUp      = -18,
    JDown    = 18
}

public delegate void MoveDel(Player player, string direction);

public class Player
{
    public static MoveDel movePlayer = (MoveDel)(Board.movePlayerPiece) + (MoveDel)(Player.movePlayerPosition);

    private static byte playerCount = 0;

    internal sbyte Position;

    private static byte[] positions = { 4, 76, 36, 44 };

    public string Name { get; init; }
    public string PrintName { get; init; }
    public char Symbol { get; init; }

    public Player(string name, char symbol)
    { 
        (Name, Symbol) = (name, symbol);
        PrintName = (Name[Name.Length - 1] == 's') ? $"{Name}\' turn" : $"{Name}\'s turn";
        Position = positions[playerCount];
        playerCount++;
    }

    public List<string> getOptions()
    {

        var options = new List<string>();

        if (Position - 1 >= 0 && Board.board[Position - 1] == '■' && (Position - 1) % 9 != 8)
            options.Add("Move left");
        else if (Position - 2 >= 0 && Board.board[Position - 2] == '■' && Board.board[Position - 1] != '#' && Position % 9 > 1)
            options.Add("Jump over player left");

        if (Position + 1 < 81 && Board.board[Position + 1] == '■' && (Position + 1) % 9 != 0)
            options.Add("Move right");
        else if (Position + 2 < 81 && Board.board[Position + 2] == '■' && Board.board[Position + 1] != '#' && Position % 9 < 7)
            options.Add("Jump over player right");

        if (Position - 9 >= 0 && Board.board[Position - 9] == '■')
            options.Add("Move up");
        else if (Position - 18 >= 0 && Board.board[Position - 18] == '■' && Board.board[Position - 9] != '#')
            options.Add("Jump over player up");

        if (Position + 9 < 81 && Board.board[Position + 9] == '■')
            options.Add("Move down");
        else if (Position + 18 < 81 && Board.board[Position + 18] == '■' && Board.board[Position + 9] != '#')
            options.Add("Jump over player down");

        return options;

    }

    public char validateOption(List<string> options, string input)
    {
        foreach (String s in options)
            if (s.Contains(input))
                if (s[0] == 'J')
                    return 'j'
                else
                    return 'g';
        return 'b';
    }

    private static void movePlayerPosition(Player player, string direction)
    {
        player.Position += (sbyte)Enum.Parse(typeof(Movement), direction, true);
    }
}