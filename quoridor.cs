using System;
using GameObjects;

namespace MyFirstProgram;

class Quoridor
{
    public delegate int movePlayer(int currentPosition, string direction);

    public static void write(params string[] messages)
    {
        foreach (string s in messages)
            Console.WriteLine("[ " + s + " ]\n");
    }

    static void Main(string[] args)
    {
        
        // Feel free to add more (:
        var symbols = new List<char> { '★', '❋', '✪', '♧', '♥', '●', '◆' };

        write("Welcome to Quoridor 1.0", "Instructions in md file");

        int pCount;

        while (true)
        {
            write("Would you like to play with 2 or 4 players: ");
            pCount = 0;

            try
            {
                pCount = Convert.ToInt16(Console.ReadLine());

                if (pCount != 2 && pCount != 4)
                    throw new Exception();
            }
            catch (Exception)
            {
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

        var players = new List<Player>();
        string? name;

        for (int i = 0; i < pCount; i++)
        {
            write($"Enter player {i + 1}\'s name: ");

            name = Console.ReadLine();

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

            players.Add(new Player(name, symbols[i]));
        }

        foreach (Player p in players)
            Console.WriteLine($"{p.Name}\t{p.Symbol}");
    }
}