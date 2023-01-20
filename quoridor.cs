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
        
        Console.Clear();

        // Feel free to add more (:
        var symbols = new List<char> { '★', '❋', '✪', '♥', '♥', '♥', '♥' };
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
            
            break;
        }

    }
}