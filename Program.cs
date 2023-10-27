using NFLModel;
using System;
using System.Collections.Generic;

public partial class Program
{
    public static void Main()
    {
        // Read List of Teams
        List<Team> Teams = TeamReader.Go("../../../teams.txt");

        // Read List of Games
        GameReader Reader = new GameReader(Teams);

        List<Game> Games = Reader.Go("../../../nfl.csv");

        // Analyze Team Stats
        TeamAnalyzer Analyzer = new TeamAnalyzer(Teams);

        Analyzer.Go();

        ScorePredictor Predictor = new ScorePredictor(Teams);
        Predictor.Go("Buffalo Bills", "Tampa Bay Buccaneers");
    }
}