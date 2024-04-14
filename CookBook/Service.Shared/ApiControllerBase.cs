using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Service.Shared
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ApiControllerBase: ControllerBase
    {

        public async Task<T> GetModelFromBody<T>()
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var model = await reader.ReadToEndAsync();

                return JsonConvert.DeserializeObject<T>(model);
            }
        }
    }

    
}
