using System;
using System.Text.RegularExpressions;
using GameObjects;

namespace MyFirstProgram;

class Quoridor
{

    public static void write(params string[] messages)
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        foreach (string s in messages)
            Console.WriteLine("[ " + s + " ]\n");
        Console.ResetColor();
    }

    static void Main(string[] args)
    {

        Console.Clear();

        Console.ResetColor();

        // Feel free to add more (:
        var symbols = new List<char> { '☻', '♣', '♦', '♥' };
        write("Welcome to Quoridor 1.0", "Instructions in md file");

        byte pCount;

        while (true)
        {
            write("Would you like to play with 2 or 4 players: ");
            pCount = 0;

            try
            {
                pCount = Convert.ToByte(Console.ReadLine());

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

        Func<string, bool> isOnlyWhiteSpace = name => 
        {
            foreach (char c in name)
                if (c != ' ')
                    return false;
            return true;
        };

        Console.Clear();

        for (byte i = 0; i < pCount; i++)
        {
            write($"Enter player {i + 1}\'s name: ");

            string? name = Console.ReadLine();

            if (name == null) 
            {
                i--;
                continue;
            }

            name.Trim();

            if (name == "" || isOnlyWhiteSpace(name))
            {
                i--;
                continue;
            }

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

        for (byte i = 0; i < pCount; i++)
        {
            write($"Chose your symbol {names[i]}: ");

            for (byte j = 0; j < symbols.Count(); j++)
                Console.WriteLine($"{j + 1} ). {symbols[j]}\n");

            try
            {
                byte choice = Convert.ToByte(Console.ReadLine());

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
        bool endGame = false;

        while (endGame == false)
        {
            Board.printBoard();

            var options = players[turns % players.Count()].getOptions();

            while (true)
            {

                Console.WriteLine();
                write(players[turns % players.Count()].PrintName);
                Console.WriteLine();

                for (byte i = 0; i < options.Count(); i++)
                    write($"{i + 1} ). {options[i]}");

                string? inp = Console.ReadLine();

                if (inp == null || inp == "")
                {
                    write("Enter one of the given options:");
                    continue;
                }

                int numInp;
                
                bool isInt = int.TryParse(inp, out numInp);

                if (isInt && numInp > 0 && numInp <= options.Count())
                {
                    inp = options[numInp - 1];

                    if (inp.Contains("wall"))
                        inp = "wall";
                    else if (inp.Contains("left"))
                        inp = "left";
                    else if (inp.Contains("right"))
                        inp = "right";
                    else if (inp.Contains("up"))
                        inp = "up";
                    else if (inp.Contains("down"))
                        inp = "down";
                }
                else
                {

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

                }
                char optionType = Player.validateOption(options, inp);

                if (optionType == 'b')
                {
                    write("Enter one of the given options:");
                    continue;
                } else if (optionType == 'j')
                    inp = $"J{inp}";

                if (optionType == 'w')
                {
                    write("Vertical (tall) or horizontal (flat) wall?");

                    string? wallInp = Console.ReadLine();

                    if (wallInp == null || wallInp == "")
                    {
                        write("Invalid input");
                        continue;
                    }

                    switch (wallInp.ToLower())
                    {
                        case "v":
                        case "ve":
                        case "ver":
                        case "vert":
                        case "verti":
                        case "vertic":
                        case "vertica":
                        case "vertical":
                        case "t":
                        case "ta":
                        case "tal":
                        case "tall":
                            wallInp = "tall";
                            break;
                        case "h":
                        case "ho":
                        case "hor":
                        case "hori":
                        case "horiz":
                        case "horizo":
                        case "horizon":
                        case "horizont":
                        case "horizonta":
                        case "horizontal":
                        case "f":
                        case "fl":
                        case "fla":
                        case "flat":
                            wallInp = "flat";
                            break;
                        default:
                            write("Invalid input");
                            continue;
                    }

                    Board.printBoard();

                    write("Coordinate of upper-left corner of wall:");

                    string? coordInp = Console.ReadLine();

                    if (coordInp == null || coordInp == "" || coordInp.Length != 2 || !Regex.Match(coordInp.ToLower(), "[a-i][1-9]").Success)
                    {
                        write("Invalid input");
                        continue;
                    }

                    if (!Board.placeWall(players[turns % players.Count()], coordInp, wallInp))
                    {
                        write("Invalid input");
                        continue;
                    }

                } else
                    Board.movePlayer(players[turns % players.Count()], inp);

                break;

            }

            foreach (Player p in players)
                if (p.checkForWin())
                {
                    Board.printBoard();
                    write($"{p.Name} reached the goal and won the game!", $"This game lasted for {turns} turns");
                    endGame = true;
                    break;
                }

            turns++;
        }

    }
}