using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace OpenDota.NET.Players
{
    public class WardMap
    {
        public IEnumerable<Ward> ObserverWards { get; private set; }

        public IEnumerable<Ward> SentryWards { get; private set; }

        internal static WardMap Deserialize(string result)
        {
            var json = JObject.Parse(result);
            return new WardMap
            {
                ObserverWards = GetWards(json["obs"]),
                SentryWards = GetWards(json["sen"]),
            };
        }

        private static IEnumerable<Ward> GetWards(JToken json)
        {
            var wards = new List<Ward>();

            foreach(var jObj in json)
            {
                wards.Add(Ward.Deserialize(jObj));
            }

            return wards;
        }
    }

    public class Ward
    {
        public int Key { get; private set; }

        public IEnumerable<KeyValuePair<int, int>> Values { get; private set; }

        internal static Ward Deserialize(JToken jObj)
        {
            var ward = new Ward();
            ward.Key = Convert.ToInt32(((JProperty)jObj).Name);
            ward.Values = GetValues(((JProperty)jObj).Value);
            return ward;
        }

        private static IEnumerable<KeyValuePair<int, int>> GetValues(JToken jObj)
        {
            var values = new List<KeyValuePair<int, int>>();

            foreach(var vObj in jObj)
            {
                values.Add(new KeyValuePair<int, int>(
                    Convert.ToInt32(((JProperty)vObj).Name),
                    vObj.Values().First().Value<int>()
                    ));
            }

            return values;
        }
    }
}