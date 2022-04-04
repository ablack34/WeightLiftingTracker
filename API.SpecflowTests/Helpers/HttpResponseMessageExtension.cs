using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.SpecflowTests.Helpers
{
    public static class HttpResponseMessageExtension
    {
        public static async Task<string> GetBodyAsString(this HttpResponseMessage httpResponseMessage)
        {
            string responseBodyAsString = await httpResponseMessage.Content.ReadAsStringAsync();

            return responseBodyAsString;
        }

        public static async Task<T> GetBodyAs<T>(this HttpResponseMessage httpResponseMessage)
        {
            string responseBody = await httpResponseMessage.GetBodyAsString();

            if (string.IsNullOrEmpty(responseBody))
                throw new Exception("Response Body is null");

            T responseBodyAsMyType = JsonConvert.DeserializeObject<T>(responseBody);

            return responseBodyAsMyType;
        }
    }
}
