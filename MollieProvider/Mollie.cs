using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MollieProvider
{
  public class Mollie
  {
    public string Key { get; private set; }

    private readonly string molliePaymentsUrl = "https://api.mollie.nl/v1/payments/";
    private readonly string[] acceptedLocales = new string[] { "nl", "fr", "de", "es", "en" };

    public Mollie(string key)
    {
      Key = key;
    }

    public virtual async Task<T> CreateTransaction<T>(MollieCreateRequest requestData) where T : class
    {
      var result = await SendJsonRequest<T>(molliePaymentsUrl, HttpMethod.Post, requestData);
      return result;
    }

    public virtual async Task<T> GetTransactionStatus<T>(string id) where T : class
    {
      var url = molliePaymentsUrl + id;
      T response = await SendJsonRequest<T>(url, HttpMethod.Get);
      return response;
    }

    public virtual async Task<T> RefundTransaction<T>(string id) where T : class
    {
      var url = molliePaymentsUrl + id + "/refunds";
      T response = await SendJsonRequest<T>(url, HttpMethod.Post);
      return response;
    }

    protected async Task<T> SendJsonRequest<T>(string url, HttpMethod method, object obj = null) where T : class
    {
      using (var client = new HttpClient())
      {
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        using (var request = new HttpRequestMessage(method, url))
        {
          request.Headers.Add("Authorization", "Bearer " + Key);

          if (method == HttpMethod.Post || method == HttpMethod.Put)
          {
            var settings = new JsonSerializerSettings
            {
              NullValueHandling = NullValueHandling.Ignore,
              ContractResolver = new CamelCasePropertyNamesContractResolver(),
            };

            var data = JsonConvert.SerializeObject(obj, settings);
            request.Content = new StringContent(data, Encoding.UTF8, "application/json");
          }


          var response = await client.SendAsync(request);
          var responseString = await response.Content.ReadAsStringAsync();
          T result = JsonConvert.DeserializeObject<T>(responseString);
          return result;
        }
      }
    }
  }
}
