using System;
using Newtonsoft.Json.Linq;
using OpenDota.NET.Extensions;

namespace OpenDota.NET.Players
{
    public class Profile
    {
        public long AccountId { get; private set; }

        public string PersonaName { get; private set; }

        public string Name { get; private set; }

        public long SteamId { get; private set; }

        public Uri Avatar { get; private set; }

        public Uri AvatarMedium { get; private set; }

        public Uri AvatarFull { get; private set; }

        public Uri SteamProfileUrl { get; private set; }

        public DateTime LastLogin { get; private set; }

        public string CountryCode { get; private set; }

        public bool IsContributor { get; private set; }

        internal static Profile Deserialize(JToken json)
        {
            return new Profile
            {
                AccountId = json.Value<long>("account_id", 0),
                SteamId = json.Value<long>("steamid"),
                Avatar = CreateUri(json.Value<string>("avatar")),
                AvatarMedium = CreateUri(json.Value<string>("avatarmedium")),
                AvatarFull = CreateUri(json.Value<string>("avatarfull")),
                SteamProfileUrl = CreateUri(json.Value<string>("profileurl")),
                PersonaName = json.Value<string>("personaname"),
                CountryCode = json.Value<string>("loccountrycode"),
                LastLogin = json.Value<DateTime>("last_login", default(DateTime)),
                Name = json.Value<string>("name"),
                IsContributor = json.Value<bool>("is_contributor")
            };
        }

        private static Uri CreateUri(string givenUri)
        {
            Uri.TryCreate(givenUri, UriKind.Absolute, out Uri uri);
            return uri;
        }
    }
}