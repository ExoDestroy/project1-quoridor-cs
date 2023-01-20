using System;
using System.Collections.Generic;

namespace GameObjects;

internal enum Movement : sbyte
{
    Left    = -1,
    Right   = 1,
    Up      = -9,
    Down    = 9               
}

public delegate void MoveDel(Player player, string direction);

public class Player
{
    public static MoveDel movePlayer = (MoveDel)(verifyMovement) + (MoveDel)(movePlayerPiece);

    private static sbyte playerCount = 0;

    internal sbyte Position;

    private static sbyte[] positions = { 4, 76, 36, 44 };

    public string? Name { get; init; }
    public string? PrintName { get; init; }
    public char Symbol { get; init; }

    public Player(string name, char symbol)
    { 
        (Name, Symbol) = (name, symbol);
        PrintName = (Name[Name.Length - 1] == 's') ? $"{Name}\' turn" : $"{Name}\'s turn";
        Position = positions[playerCount];
        playerCount++;
    }

    // public string[] printOptions()
    // {
    //     if (Position - 1 >= 0 && Board.board[Position - 1] == '▢' && (Position - 1) % 9 != 9)
    //     {

    //     } else if (Position - 2 >= 0 && Board.board[Position - 2] == '▢' && )
    //     {

    //     }
    // }

    private static void verifyMovement(Player player, string direction)
    {
        switch (direction.ToLower())
        {
            case "l":
            case "le":
            case "lef":
            case "left":
                direction = "Left";
                break;
            case "r":
            case "ri":
            case "rig":
            case "righ":
            case "right":
                direction = "Right";
                break;
            case "u":
            case "up":
                direction = "Up";
                break;
            case "d":
            case "do":
            case "dow":
            case "down":
                direction = "Down";
                break;
        }

        
    }

    private static void movePlayerPiece(Player player, string direction)
    {
        player.Position += (sbyte)Enum.Parse(typeof(Movement), direction);
    }
}