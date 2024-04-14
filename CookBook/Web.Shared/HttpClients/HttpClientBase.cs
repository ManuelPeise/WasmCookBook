using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

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

        public virtual async Task<bool> SendPostRequest<T>(string url, T model)
        {
            var requestUrl = $"{_client.BaseAddress}{url}";
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            using (var request = new HttpRequestMessage
            {
                RequestUri = new Uri(requestUrl),
                Method = HttpMethod.Post,
                Content = content 

            })
            {
                var response = await _client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
