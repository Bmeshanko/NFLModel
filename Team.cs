using System;
using System.Collections.Generic;
using System.IO;

namespace NFLModel
{
    public class Team
    {
        public string Name { get; set; }
        public List<Game> Games { get; set; }
        public Team(string name)
        {
            Name = name;
            Games = new List<Game>();
        }

        public void addGame(Game game)
        {
            Games.Add(game);
        }
    }
}
