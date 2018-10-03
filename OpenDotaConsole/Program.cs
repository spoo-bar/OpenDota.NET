using OpenDota.NET.Heroes;
using OpenDota.NET.Matches;
using OpenDota.NET.Players;
using System;
using System.Collections.Generic;

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
            var player = playerManager.GetPlayer(186347237);
            var query = new SearchQuery
            {
                AgainstHeroIDs = new List<int> { },
                DaysPrevious = TimeSpan.FromDays(4),
                ExcludedAccountIDs = new List<long> { },
                GameMode = GameMode.CaptainsMode,
                Having = 2,
                HeroId = 1234,
                IncludedAccountIDs = new List<long> { },
                IncludedHeroIDs = new List<int> { },
                IsRadiant = true,
                LaneRoleId = 1,
                Limit = 20,
                LobbyType = LobbyType.RankedTeam,
                Offset = 1,
                RegionId = 1,
                Significant = true,
                SortByDescending = false,
                Won = true
            };
            var playerWL = playerManager.GetPlayerWinLossCount(186347237, query);
            var recentMatches = playerManager.GetRecentMatches(186347237);
            var matches = playerManager.GetMatches(186347237, new SearchQuery { Limit = 1, Projects = new List<string> { "heroes" } });
            var heroes = playerManager.GetHeroes(186347237);
            var peers = playerManager.GetPeers(186347237);
            var proPeers = playerManager.GetProPeers(186347237);
            var stats = playerManager.GetStats(186347237);
            var counts = playerManager.GetCounts(186347237);

            var heroManager = new HeroManager();
            var heroesStats = heroManager.GetHeroesStats();

            Console.WriteLine("Hello World!");
        }
    }
}
