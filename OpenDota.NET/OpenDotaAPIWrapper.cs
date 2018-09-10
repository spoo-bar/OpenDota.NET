using System;

namespace OpenDota.NET
{
    public class OpenDotaAPIWrapper
    {
        private readonly Uri openDotaAPIUrl = new Uri("https://api.opendota.com/api/");
        private string _apiKey { get; set; }

        public OpenDotaAPIWrapper()
        {

        }

        public OpenDotaAPIWrapper(string apiKey)
        {
            _apiKey = apiKey;
        }


    }
}
