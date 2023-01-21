using System;
using GameObjects;

namespace MyFirstProgram;

class Quoridor
{

    public static void write(params string[] messages)
    {
        foreach (string s in messages)
            Console.WriteLine("[ " + s + " ]\n");
    }

    static void Main(string[] args)
    {

        Console.ResetColor();
        
        Console.Clear();

        Console.ResetColor();

        // Feel free to add more (:
        var symbols = new List<char> { '☻', '♣', '♦', '♥' };
        write("Welcome to Quoridor 1.0", "Instructions in md file");

        sbyte pCount;

        while (true)
        {
            write("Would you like to play with 2 or 4 players: ");
            pCount = 0;

            try
            {
                pCount = Convert.ToSByte(Console.ReadLine());

                if (pCount != 2 && pCount != 4)
                    throw new Exception();
            }
            catch (Exception)
            {
                Console.Clear();
                write("Please enter 2 or 4");
                continue;
            }

            break;
        }

        var names = new List<string>();

        Func<string, bool> isUniqueName = name => 
        {
            foreach (string s in names)
                if (s.Equals(name))
                    return false;
            return true;
        };

        Console.Clear();

        for (sbyte i = 0; i < pCount; i++)
        {
            write($"Enter player {i + 1}\'s name: ");

            string? name = Console.ReadLine();

            if (name == null)
                continue;

            if (isUniqueName(name))
                names.Add(name);
            else
            {
                Console.Clear();
                
                write("Choose a unique name.");
                
                i--;
                continue;
            }

            Console.Clear();
        }

        var players = new List<Player>();

        Console.Clear();

        for (sbyte i = 0; i < pCount; i++)
        {
            write($"Chose your symbol {names[i]}: ");

            for (sbyte j = 0; j < symbols.Count(); j++)
                Console.WriteLine($"{j + 1} ). {symbols[j]}\n");

            try
            {
                sbyte choice = Convert.ToSByte(Console.ReadLine());

                if (choice < 1 || choice > symbols.Count())
                    throw new Exception();

                var p = new Player(names[i], symbols[choice - 1]);
                Board.placePlayer(p);

                players.Add(p);
                symbols.RemoveAt(choice - 1);
            }
            catch (Exception)
            {
                Console.Clear();

                write($"Please choose numbers 1-{symbols.Count()}.");

                i--;
                continue;
            }

            Console.Clear();
        }


        int turns = 0;

        while (true)
        {
            Board.printBoard();

            write(players[turns % players.Count()].PrintName);
            Console.WriteLine();
            
            var options = players[turns % players.Count()].getOptions();

            while (true)
            {

                foreach (String s in options)
                    write(s);

                string? inp = Console.ReadLine();

                if (inp == null)
                    continue;

                // Acceptable inputs
                switch (inp.ToLower())
                {   
                    case "l":
                    case "le":
                    case "lef":
                    case "left":
                    case "move l":
                    case "move le":
                    case "move lef":
                    case "move left":
                        inp = "left";
                        break;
                    case "r":
                    case "ri":
                    case "rig":
                    case "righ":
                    case "right":
                    case "move r":
                    case "move ri":
                    case "move rig":
                    case "move righ":
                    case "move right":
                        inp = "right";
                        break;
                    case "u":
                    case "up":
                    case "move u":
                    case "move up":
                        inp = "up";
                        break;
                    case "d":
                    case "do":
                    case "dow":
                    case "down":
                    case "move d":
                    case "move do":
                    case "move dow":
                    case "move down":
                        inp = "down";
                        break;
                    case "w":
                    case "wa":
                    case "wal":
                    case "wall":
                    case "p":
                    case "pl":
                    case "pla":
                    case "plac":
                    case "place":
                    case "place w":
                    case "place wa":
                    case "place wal":
                    case "place wall":
                        inp = "wall";
                        break;
                    default:
                        write("Enter one of the given options:");
                        continue;
                }

                char optionType = validateOption(options, inp);

                if (optionType == 'b')
                {
                    write("Enter one of the given options:");
                    continue;
                } else if (optionType == 'j')
                    inp = $"J{inp}";

                Player.movePlayer(players[turns % players.Count()], inp);

            }

            Board.printBoard();

            break;
        }

    }
}