using System;
using System.Collections.Generic;

namespace NFLModel
{
    public class TeamAnalyzer
    {
        List<Team> Teams { get; set; }
        public TeamAnalyzer(List<Team> teams)
        {
            Teams = teams;
        }
        public void Go()
        {
            foreach (Team team in Teams)
            {
                Calculate(team);
            }
        }
        public void Calculate(Team team)
        {
            float n = 0f;
            float opts = 0;
            float oyds = 0;
            float otos = 0;

            float dpts = 0;
            float dyds = 0;
            float dtos = 0;

            foreach(Game game in team.Games)
            {
                if (game.Home == team)
                {
                    opts += game.HomePts;
                    oyds += game.HomeYds;
                    otos += game.HomeTOs;

                    dpts += game.AwayPts;
                    dyds += game.AwayYds;
                    dtos += game.AwayTOs;
                } 
                else
                {
                    opts += game.AwayPts;
                    oyds += game.AwayYds;
                    otos += game.AwayTOs;

                    dpts += game.HomePts;
                    dyds += game.HomeYds;
                    dtos += game.HomeTOs;
                }
                n++;
            }
            team.OffensiveAverages.Add(opts / n);
            team.OffensiveAverages.Add(oyds / n);
            team.OffensiveAverages.Add(otos / n);

            team.DefensiveAverages.Add(dpts / n);
            team.DefensiveAverages.Add(dyds / n);
            team.DefensiveAverages.Add(dtos / n);
        }
    }
}
