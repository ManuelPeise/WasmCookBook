using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Shared.HttpClients
{
    public abstract class HttpClientBase
    {
        protected HttpClient _client;

        protected HttpClientBase(HttpClient client)
        {
            _client = client;
        }

        public virtual async Task<T?> SendGetRequest<T>(string url)
        {
            var requestUrl = $"{_client.BaseAddress}{url}";

            using (var request = new HttpRequestMessage(HttpMethod.Get, requestUrl))
            {
                var response = await _client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    return (T)Convert.ChangeType(JsonConvert.DeserializeObject<T>(json), typeof(T));
                }
            }

            return default(T);
        }
    }
}
