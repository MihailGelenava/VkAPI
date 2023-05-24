using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace VkAPI.Utils
{
    public static class ApiUtils
    {
        public static T GetContent<T>(RestResponse response)
        {
            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        public static JToken GetFieldFromResponse(RestResponse response, string fieldName)
        {
            JObject responseObj = JObject.Parse(response.Content);

            return responseObj["response"][fieldName];
        }
    }
}
