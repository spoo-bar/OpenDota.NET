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
            matchManager.GetMatch(4078566725);

            var playerManager = new PlayerManager();
            playerManager.GetProPlayers();

            var heroManager = new HeroManager();
            heroManager.GetHeroesStats();

            Console.WriteLine("Hello World!");
        }
    }
}
