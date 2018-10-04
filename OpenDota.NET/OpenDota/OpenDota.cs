using System;
using System.Threading.Tasks;

namespace OpenDota.NET
{
    public class OpenDotA
    {
        public static MetaData GetMetaData()
        {
            return GetMetaDataAsync().GetAwaiter().GetResult();
        }

        public static async Task<MetaData> GetMetaDataAsync()
        {
            var client = OpenDotaAPIWrapper.Client;
            using (var response = await client.GetAsync("metadata"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return MetaData.Deserialize(result);
                }
            }
            throw new Exception("Could not get meta data");
        }
    }
}
