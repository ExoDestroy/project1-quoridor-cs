using System;
using System.Collections.Generic;

namespace GameObjects;

[Flags]
private internal enum Movements
{
    Left    = -0b_0000_0001,
    JLeft   = -0b_0000_0010                    
}

public class Player
{
    private static int playerCount = 0;

    private Player() { playerCount++ };

    private int Position, Walls = 10;

    private const static int[] positions = { 4, 76, 27, 35 };

    private required string Name { get; init; };
    private required char Symbol { get; init; };

    // private const static string[] = { }

    // private static void movePlayerPiece(int currentPosition, string direction)
    // {

    // }
}