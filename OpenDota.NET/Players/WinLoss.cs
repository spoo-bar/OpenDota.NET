using System;
using Newtonsoft.Json.Linq;

namespace OpenDota.NET.Players
{
    public class WinLoss
    {
        public long Win { get; private set; }
        public long Loss { get; private set; }

        internal static WinLoss Deserialize(string result)
        {
            var json = JObject.Parse(result);
            return new WinLoss
            {
                Win = json.Value<long>("win"),
                Loss = json.Value<long>("lose")
            };
        }
    }
}