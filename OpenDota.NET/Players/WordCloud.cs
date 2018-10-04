using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace OpenDota.NET.Players
{
    public class WordCloud
    {
        public IEnumerable<WordCount> PlayerWordCount { get; private set; }

        public IEnumerable<WordCount> AllWordCount { get; private set; }

        internal static WordCloud Deserialize(string result)
        {
            var json = JObject.Parse(result);
            return new WordCloud
            {
                PlayerWordCount = GetWordCount(json["my_word_counts"]),
                AllWordCount = GetWordCount(json["all_word_counts"]),
            };
        }

        private static IEnumerable<WordCount> GetWordCount(JToken json)
        {
            var wordCounts = new List<WordCount>();
            foreach(var obj in json)
            {
                wordCounts.Add(WordCount.Deserialize(obj));
            }
            return wordCounts.OrderBy(wc => wc.Count);
        }
    }

    public class WordCount
    {
        public string Word { get; private set; }

        public int Count { get; private set; }

        internal static WordCount Deserialize(JToken obj)
        {
            return new WordCount
            {
                Word = ((JProperty)obj).Name,
                Count = ((JProperty)obj).Value.Value<int>()
            };
        }
    }
}