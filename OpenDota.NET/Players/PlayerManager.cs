using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace OpenDota.NET.Players
{
    public class PlayerManager
    {
        public IEnumerable<ProPlayer> GetProPlayers()
        {
            return GetProPlayersAsync().GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<ProPlayer>> GetProPlayersAsync()
        {
            var client = OpenDotaAPIWrapper.Client;
            using (var response = await client.GetAsync("proplayers"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    var proPlayers = new List<ProPlayer>();
                    foreach(var proPlayer in JArray.Parse(result))
                    {
                        proPlayers.Add(ProPlayer.Deserialize(proPlayer));
                    }

                    return proPlayers;
                }
            }
            throw new Exception("Could not successfully get proplayers data");
        }

        public Player GetPlayer(int accountId)
        {
            return GetPlayerAsync(accountId).GetAwaiter().GetResult();
        }

        public async Task<Player> GetPlayerAsync(int accountId)
        {
            var client = OpenDotaAPIWrapper.Client;
            using (var response = await client.GetAsync(string.Format("players/{0}", accountId)))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    
                    return Player.Deserialize(result);
                }
            }
            throw new Exception("Could not successfully get player data");
        }

        public WinLoss GetPlayerWinLossCount(int accountId, SearchQuery query = null)
        {
            return GetPlayerWinLossCountAsync(accountId, query).GetAwaiter().GetResult();
        }

        public async Task<WinLoss> GetPlayerWinLossCountAsync(int accountId, SearchQuery query = null)
        {
            var client = OpenDotaAPIWrapper.Client;
            var queryStringParam = SearchQuery.GetQueryString(query);
            using (var response = await client.GetAsync(string.Format("players/{0}/wl?{1}", accountId, queryStringParam)))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return WinLoss.Deserialize(result);
                }
            }
            throw new Exception("Could not successfully get player win loss data");
        }

        public IEnumerable<Match> GetRecentMatches(int accountId)
        {
            return GetRecentMatchesAsync(accountId).GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<Match>> GetRecentMatchesAsync(int accountId)
        {
            var client = OpenDotaAPIWrapper.Client;
            using (var response = await client.GetAsync(string.Format("players/{0}/recentMatches", accountId)))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    var recentMatches = new List<Match>();

                    foreach(var match in JArray.Parse(result))
                    {
                        recentMatches.Add(Match.Deserialize(match));
                    }

                    return recentMatches;
                }
            }
            throw new Exception("Could not successfully get player's recent match data");
        }

        public IEnumerable<Match> GetMatches(int accountId, SearchQuery query = null)
        {
            return GetMatchesAsync(accountId, query).GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<Match>> GetMatchesAsync(int accountId, SearchQuery query = null)
        {
            var client = OpenDotaAPIWrapper.Client;
            var queryStringParam = SearchQuery.GetQueryString(query);
            using (var response = await client.GetAsync(string.Format("players/{0}/matches?{1}", accountId, queryStringParam)))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    var matches = new List<Match>();

                    foreach (var match in JArray.Parse(result))
                    {
                        matches.Add(Match.Deserialize(match));
                    }

                    return matches;
                }
            }
            throw new Exception("Could not successfully get player's match data");
        }

        public IEnumerable<PlayerHeroStats> GetHeroes(int accountId, SearchQuery query = null)
        {
            return GetHeroesAsync(accountId, query).GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<PlayerHeroStats>> GetHeroesAsync(int accountId, SearchQuery query = null)
        {
            var client = OpenDotaAPIWrapper.Client;
            var queryStringParam = SearchQuery.GetQueryString(query);
            using (var response = await client.GetAsync(string.Format("players/{0}/heroes?{1}", accountId, queryStringParam)))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    var heroes = new List<PlayerHeroStats>();

                    foreach (var hero in JArray.Parse(result))
                    {
                        heroes.Add(PlayerHeroStats.Deserialize(hero));
                    }

                    return heroes;
                }
            }
            throw new Exception("Could not successfully get player's heroes data");
        }

        public IEnumerable<Peer> GetPeers(int accountId, SearchQuery query = null)
        {
            return GetPeersAsync(accountId, query).GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<Peer>> GetPeersAsync(int accountId, SearchQuery query = null)
        {
            var client = OpenDotaAPIWrapper.Client;
            var queryStringParam = SearchQuery.GetQueryString(query);
            using (var response = await client.GetAsync(string.Format("players/{0}/peers?{1}", accountId, queryStringParam)))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    var peers = new List<Peer>();

                    foreach (var peer in JArray.Parse(result))
                    {
                        peers.Add(Peer.Deserialize(peer));
                    }

                    return peers;
                }
            }
            throw new Exception("Could not successfully get player's peers data");
        }

        public IEnumerable<ProPeer> GetProPeers(int accountId, SearchQuery query = null)
        {
            return GetProPeersAsync(accountId, query).GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<ProPeer>> GetProPeersAsync(int accountId, SearchQuery query)
        {
            var client = OpenDotaAPIWrapper.Client;
            var queryStringParam = SearchQuery.GetQueryString(query);
            using(var response = await client.GetAsync(string.Format("players/{0}/pros?{1}", accountId, queryStringParam)))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var proPeers = new List<ProPeer>();
                    foreach(var proPeer in JArray.Parse(result))
                    {
                        proPeers.Add(ProPeer.Deserialize(proPeer));
                    }
                    return proPeers;
                }
            }

            throw new Exception("Could not successfully get player's pro peers data");
        }
    }
}
