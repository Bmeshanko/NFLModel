using NFLModel;
using System;
using System.Collections.Generic;

public class Training
{
    public static void Go()
    {
        List<Team> Teams = TeamReader.Go("../../../teams.txt");

        GameReader Reader = new GameReader(Teams);

        List<Game> Games = Reader.Go("../../../nfl.csv");

        DataCleanser Cleanser = new DataCleanser(Games);

        Cleanser.Go("../../../data.txt");
    }
}