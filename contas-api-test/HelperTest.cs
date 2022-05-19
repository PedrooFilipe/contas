using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using contas_api_model.Model;
using Newtonsoft.Json;

namespace contas_api_test
{
    public static class HelperTest
    {
        public static StringContent CreateContentString<T>(T data)
        {
            var jsonContent = JsonConvert.SerializeObject(data);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            contentString.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return contentString;
        }

        public static async Task<RestResponse<T>> DeserializeObject<T>(HttpResponseMessage response) where T : class
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            RestResponse<T> data = JsonConvert.DeserializeObject<RestResponse<T>>(jsonString.Replace("'\'", ""));
            return data;
        }
    }
}