using System;

namespace NFLModel
{
    public class Game
    {
        public Team Home { get; set; }
        public int HomePts { get; set; }
        public int HomeYds { get; set; }
        public int HomeTOs { get; set; }

        public Team Away { get; set; }
        public int AwayPts { get; set; }
        public int AwayYds { get; set; }
        public int AwayTOs { get; set; }

        public Game(Team home, int homePts, int homeYds, int homeTOs, Team away, int awayPts, int awayYds, int awayTOs)
        {
            Home = home;
            HomePts = homePts;
            HomeYds = homeYds;
            HomeTOs = homeTOs;

            Away = away;
            AwayPts = awayPts;
            AwayYds = awayYds;
            AwayTOs = awayTOs;
        }
    }
}
