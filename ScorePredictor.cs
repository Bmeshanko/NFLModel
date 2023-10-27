using System;

namespace NFLModel
{
    public class ScorePredictor
    {
        public List<Team> Teams { get; set; }
        public ScorePredictor(List<Team> teams)
        {
            Teams = teams;
        }

        public Team FindTeam(String name)
        {
            foreach (Team team in Teams)
            {
                if (team.Name == name) return team;
            }
            return new Team("");
        }

        public void Go(String home, String away)
        {
            Team homeTeam = FindTeam(home);
            Team awayTeam = FindTeam(away);

            if (homeTeam != null && awayTeam != null)
            {
                float ouryards = (homeTeam.OffensiveAverages.ElementAt(1) + awayTeam.DefensiveAverages.ElementAt(1)) / 2;
                float ourtos = (homeTeam.OffensiveAverages.ElementAt(2) + awayTeam.DefensiveAverages.ElementAt(2)) / 2;

                float theirpts = (homeTeam.DefensiveAverages.ElementAt(0) + awayTeam.OffensiveAverages.ElementAt(0)) / 2;
                float theiryards = (homeTeam.DefensiveAverages.ElementAt(1) + awayTeam.OffensiveAverages.ElementAt(1)) / 2;
                float theirtos = (homeTeam.DefensiveAverages.ElementAt(2) + awayTeam.OffensiveAverages.ElementAt(2)) / 2;
                PointsPredictor.ModelInput homeData = new PointsPredictor.ModelInput()
                {
                    Our_Yards = ouryards,
                    Our_TOs = ourtos,
                    Their_Pts = theirpts,
                    Their_Yards = theiryards,
                    Their_TOs = theirtos
                };

                var homeResult = PointsPredictor.Predict(homeData);

                float tempyards = ouryards;
                float temptos = ourtos;

                ouryards = theiryards;
                ourtos = theirtos;

                theirpts = (awayTeam.DefensiveAverages.ElementAt(0) + homeTeam.OffensiveAverages.ElementAt(0)) / 2;
                theiryards = tempyards;
                theirtos = temptos;
                PointsPredictor.ModelInput awayData = new PointsPredictor.ModelInput()
                {
                    Our_Yards = ouryards,
                    Our_TOs = ourtos,
                    Their_Pts = theirpts,
                    Their_Yards = theiryards,
                    Their_TOs = theirtos
                };

                var awayResult = PointsPredictor.Predict(awayData);

                double homePoints = (homeResult.Score * 0.6) 
                    + (homeTeam.OffensiveAverages.ElementAt(0) * 0.2) 
                    + (awayTeam.DefensiveAverages.ElementAt(0) * 0.2);

                double awayPoints = (awayResult.Score * 0.6)
                    + (awayTeam.OffensiveAverages.ElementAt(0) * 0.2)
                    + (homeTeam.DefensiveAverages.ElementAt(0) * 0.2);

                Console.WriteLine(home + $" predicted points: {homePoints}");
                Console.WriteLine(away + $" predicted points: {awayPoints}");
            }
        }
    }
}
