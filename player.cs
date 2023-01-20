using System;
using System.Collections.Generic;

namespace GameObjects;

internal enum Movement : sbyte
{
    Left    = -1,
    JLeft   = -2,
    Right   = 1,
    JRight  = 2,
    Up      = -9,
    JUp     = -18,
    Down    = 9,
    JDown   = 18                   
}

public class Player
{

    private static sbyte playerCount = 0;

    internal sbyte Position;

    private static sbyte[] positions = { 4, 76, 36, 44 };

    public string? Name { get; init; }
    private string? PrintName { get; init; }
    public char Symbol { get; init; }

    public Player(string name, char symbol)
    { 
        (Name, Symbol) = (name, symbol);
        PrintName = (Name[Name.Length - 1] == 's') ? $"[ {Name}\' turn ]" : $"[ {Name}\'s turn ]";
        Position = positions[playerCount];
        playerCount++;
    }

    private static void movePlayerPiece(Player player, string direction)
    {
        player.Position += (sbyte)Enum.Parse(typeof(Movement), direction, true);
    }
}