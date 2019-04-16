using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace OpenDota.NET
{
    public class OpenDotaAPIWrapper
    {
        private readonly static Uri openDotaAPIUrl = new Uri("https://api.opendota.com/api/");

        private static HttpClient _client = null;
        private static object lockObj= new object();

        internal static HttpClient Client
        {
            get
            {
                lock (lockObj) {
                    if (_client == null)
                    {
                        _client = new HttpClient();
                        _client.BaseAddress = openDotaAPIUrl;
                        _client.DefaultRequestHeaders.Accept.Clear();
                        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    }
                }
                return _client;
            }
        }
    }
}
