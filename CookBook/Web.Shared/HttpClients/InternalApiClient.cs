using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Shared.HttpClients
{
    public class InternalApiClient : HttpClientBase
    {
        public InternalApiClient(HttpClient client) : base(client)
        {

        }
    }
}
