using NFLModel;
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        List<Team> Teams = TeamReader.Go("../../../teams.txt");

        GameReader Reader = new GameReader(Teams);

        List<Game> Games = Reader.Go("../../../nfl.csv");

        TeamAnalyzer Analyzer = new TeamAnalyzer(Teams);

        Console.WriteLine("Hello");

    }
}