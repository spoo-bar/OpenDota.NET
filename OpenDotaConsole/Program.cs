using OpenDota.NET.Heroes;
using OpenDota.NET.Matches;
using OpenDota.NET.Players;
using System;

namespace OpenDotaConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var matchManager = new MatchManager();
            var match = matchManager.GetMatch(4078566725);
            var proMatchesSummary = matchManager.GetProMatchesDetails();
            var proMatches = matchManager.GetProMatches();
            var pubMatches = matchManager.GetPublicMatches();

            var playerManager = new PlayerManager();
            var proPlayers = playerManager.GetProPlayers();

            var heroManager = new HeroManager();
            var heroesStats = heroManager.GetHeroesStats();

            Console.WriteLine("Hello World!");
        }
    }
}
