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
        public decimal AverageOffensiveTurnovers()
        {
            return 0.0M;
        }
        public decimal AverageOffensiveYards()
        {
            return 0.0M;
        }
        public decimal AverageDefensiveTurnovers()
        {
            return 0.0M;
        }
        public decimal AverageDefensiveYards()
        {
            return 0.0M;
        }
    }
}
