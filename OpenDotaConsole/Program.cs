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
            var query = new PlayerWinLossQuery
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

            var heroManager = new HeroManager();
            var heroesStats = heroManager.GetHeroesStats();

            Console.WriteLine("Hello World!");
        }
    }
}
