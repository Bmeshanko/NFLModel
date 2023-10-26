using System;
using System.Collections.Generic;
using System.IO;

namespace NFLModel
{
    public class GameReader
    {
        public List<Team> Teams { get; set; }

        public GameReader(List<Team> teams) 
        {
            Teams = teams;
        }

        public Team findTeam(String name)
        {
            foreach (var team in Teams)
            {
                if (team.Name == name) return team;
            }
            return new Team("");
        }

        public List<Game> Go(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            List<Game> games = new List<Game>();
            
            // Remove headings
            reader.ReadLine();

            var line = reader.ReadLine();
            while (line != null)
            {
                var values = line.Split(',');
                
                // Home Team, Home Pts, Home Yards, Home TOs, Away Team, Away Pts, Away Yards, Away TOs
                Game game = new Game(
                    findTeam(values[2]), Int32.Parse(values[3]), Int32.Parse(values[4]), Int32.Parse(values[5]),
                    findTeam(values[6]), Int32.Parse(values[7]), Int32.Parse(values[8]), Int32.Parse(values[9]));

                games.Add(game);

                // Add new game to home & away team
                findTeam(values[2]).addGame(game);
                findTeam(values[6]).addGame(game);

                line = reader.ReadLine();
            }
            return games;
        }
    }
}
