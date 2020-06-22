using System;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace GoBarber.Web.Helpers
{
  public static class HttpHelper
  {
    public static async Task<object> HttpGetAsync<T>(string url)
    {
      try
      {
        var client = new HttpClient();

        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "");

        var response = await client.GetAsync(url);
        var contents = response.Content.ReadAsStringAsync().Result;

        var result = JsonConvert.DeserializeObject<T>(contents);

        return result;
      }
      catch (Exception)
      {

        throw;
      }
    }

    public static async Task<object> HttpPostAsync<T>(string url, object input)
    {
      try
      {
        string postData = System.Text.Json.JsonSerializer.Serialize(input);

        var client = new HttpClient();

        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "");

        var response = await client.PostAsync(url, new StringContent(postData, Encoding.UTF8, "application/json"));
        var contents = response.Content.ReadAsStringAsync().Result;

        var result = JsonConvert.DeserializeObject<T>(contents);

        return result;
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}
