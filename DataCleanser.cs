using System;
using System.Collections.Generic;
using System.IO;

namespace NFLModel
{
    public class DataCleanser
    {
        public List<Game> Games { get; set; }

        public DataCleanser(List<Game> games)
        {
            Games = games;
        }

        public void Go(string filename)
        {
            StreamWriter writer = new StreamWriter(filename);

            writer.WriteLine("Our Pts,Our Yards,Our TOs,Their Pts,Their Yards,Their TOs");

            foreach(Game game in Games)
            {
                string str1 = game.HomePts + "," + game.HomeYds + "," + game.HomeTOs + "," 
                    + game.AwayPts + "," + game.AwayYds + "," + game.AwayTOs;
                writer.WriteLine(str1);

                string str2 = game.AwayPts + "," + game.AwayYds + "," + game.AwayTOs + "," 
                    + game.HomePts + "," + game.HomeYds + "," + game.HomeTOs;
                writer.WriteLine(str2);
            }
        }
    }
}
