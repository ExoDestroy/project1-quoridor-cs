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

public class Player
{
    private static byte playerCount = 0;

    internal sbyte Position;

    private static byte[] positions = { 4, 76, 36, 44 };

    public string Name { get; init; }
    public string PrintName { get; init; }
    public char Symbol { get; init; }
    internal sbyte Walls { get; set; } = 10;

    private int winCondition = playerCount;

    public Player(string name, char symbol)
    { 
        (Name, Symbol) = (name, symbol);
        PrintName = (Name[Name.Length - 1] == 's') ? $"{Name}\' turn  {Symbol}" : $"{Name}\'s turn  {Symbol}";
        Position = (sbyte)positions[playerCount];
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

        if (Walls > 0)
            options.Add($"Place wall ({Walls} left)");

        return options;

    }

    public static char validateOption(List<string> options, string input)
    {
        foreach (String s in options)
            if (s.Contains(input))
                if (s[0] == 'J')
                    return 'j';
                else if (s[0] == 'P')
                    return 'w';
                else
                    return 'g';
        return 'b';
    }

    public bool checkForWin()
    {
        switch (winCondition)
        {
            case 0:
                return Position > 71;
            case 1:
                return Position < 9;
            case 2:
                return Position % 9 == 8;
            case 3:
                return Position % 9 == 0;
            default:
                throw new Exception();
        }
    }

    internal static void movePlayerPosition(Player player, string direction)
    {
        player.Position += (sbyte)(Enum.Parse(typeof(Movement), direction, true));
    }
}