using System;
using System.Collections.Generic;
using System.IO;

namespace NFLModel
{
    public static class TeamReader
    {
        public static List<Team> Go(string filename)
        {
            List<Team> teams = new List<Team>();
            StreamReader reader = new StreamReader(filename);
            
            var line = reader.ReadLine();
            while (line != null)
            {
                teams.Add(new Team(line));
                line = reader.ReadLine();
            }
            reader.Close();

            return teams;
        }
    }

}
