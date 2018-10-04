using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenDota.NET.Explorer
{
    public class Explorer
    {
        /// <summary>
        /// Submit arbitrary SQL queries to the database
        /// </summary>
        /// <param name="sql">The PostgreSQL query as percent-encoded string.</param>
        /// <returns></returns>
        public string ExecuteSQL(string sql)
        {
            return ExecuteSQLAsync(sql).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Submit arbitrary SQL queries to the database
        /// </summary>
        /// <param name="sql">The PostgreSQL query as percent-encoded string.</param>
        /// <returns></returns>
        public async Task<string> ExecuteSQLAsync(string sql)
        {
            var client = OpenDotaAPIWrapper.Client;
            using (var response = await client.GetAsync(string.Format("explorer?sql={0}", sql)))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return result;
                }
            }
            throw new Exception("Could not execute the sql query");
        }
    }
}
