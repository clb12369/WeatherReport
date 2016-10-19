using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http;

namespace WeatherReport
{
    class API
    {
        private string url;

        public API(string url)
        {
            this.url = url;
        }

        public virtual async Task<string> GetJSON()
        {
            var http = new HttpClient();
            string reply = await http.GetStringAsync(this.url);
            return reply;
        }

        public async Task<T> GetData<T>()
        {
            string json = await GetJSON();
            T instance = JsonConvert.DeserializeObject<T>(json);
            return instance;
        }
    }

    class DarkSkyAPI
    {

    }
}
