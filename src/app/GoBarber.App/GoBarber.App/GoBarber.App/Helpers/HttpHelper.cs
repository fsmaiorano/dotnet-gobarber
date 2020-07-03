using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GoBarber.App.Helpers
{
    public static class HttpHelper
    {
        public static async Task<object> HttpGetAsync<T>(string url, string token = "")
        {
            try
            {
                var client = new HttpClient();

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await client.GetAsync(url);
                var contents = response.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<T>(contents);

                return result;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public static async Task<object> HttpPostAsync<T>(object input, string url, string token = "")
        {
            try
            {
                string postData = JsonConvert.SerializeObject(input);

                var client = new HttpClient();

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

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
