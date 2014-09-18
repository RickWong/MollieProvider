using MollieProvider.Banktransfer;
using MollieProvider.Bitcoin;
using MollieProvider.Creditcard;
using MollieProvider.Ideal;
using MollieProvider.Mistercash;
using MollieProvider.Paypal;
using MollieProvider.Paysafecard;
using MollieProvider.Sofort;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
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

    public async Task<MollieStatusResponse> CreateTransaction(double amount, string description, string redirectUrl, string webhookUrl = null, CultureInfo locale = null, Dictionary<string, string> metadata = null)
    {
      var requestData = CreateMollieCreateRequest(amount, description, redirectUrl, webhookUrl, locale);
      var response = await CreateTransaction<MollieStatusResponse>(requestData);
      return response;
    }

    public async Task<MollieStatusResponse> GetTransactionStatus(string id)
    {
      var url = molliePaymentsUrl + id;
      var responseString = await SendJsonRequest(url, HttpMethod.Get);
      var response = ParseJsonResponseString<MollieStatusResponse>(responseString);
      switch (response.Method)
      {
        case "banktransfer":
          response = ParseJsonResponseString<MollieBanktransferStatusResponse>(responseString);
          break;
        case "bitcoin":
          response = ParseJsonResponseString<MollieBitcoinStatusResponse>(responseString);
          break;
        case "creditcard":
          response = ParseJsonResponseString<MollieCreditcardStatusResponse>(responseString);
          break;
        case "ideal":
          response = ParseJsonResponseString<MollieIdealStatusResponse>(responseString);
          break;
        case "mistercash":
          response = ParseJsonResponseString<MollieMistercashStatusResponse>(responseString);
          break;
        case "paypal":
          response = ParseJsonResponseString<MolliePaypalStatusResponse>(responseString);
          break;
        case "paysafecard":
          response = ParseJsonResponseString<MolliePaysafecardStatusResponse>(responseString);
          break;
        case "sofort":
          response = ParseJsonResponseString<MollieSofortStatusResponse>(responseString);
          break;
      }

      return response;
    }

    public async Task<MollieRefundResponse> RefundTransaction(string id)
    {
      var response = await RefundTransaction<MollieRefundResponse>(id);
      return response;
    }

    internal async Task<T> CreateTransaction<T>(MollieCreateRequest requestData) where T : MollieStatusResponse
    {
      var response = await SendJsonRequest<T>(molliePaymentsUrl, HttpMethod.Post, requestData);
      return response;
    }

    internal async Task<T> GetTransactionStatus<T>(string id) where T : MollieStatusResponse
    {
      var url = molliePaymentsUrl + id;
      T response = await SendJsonRequest<T>(url, HttpMethod.Get);
      return response;
    }

    internal async Task<T> RefundTransaction<T>(string id) where T : MollieRefundResponse
    {
      var url = molliePaymentsUrl + id + "/refunds";
      T response = await SendJsonRequest<T>(url, HttpMethod.Post);
      return response;
    }

    internal async Task<T> SendJsonRequest<T>(string url, HttpMethod method, object obj = null) where T : class
    {
      var responseString = await SendJsonRequest(url, method, obj);
      T result = ParseJsonResponseString<T>(responseString);
      return result;
    }

    internal MollieCreateRequest CreateMollieCreateRequest(double amount, string description, string redirectUrl, string webhookUrl = null, CultureInfo locale = null, Dictionary<string, string> metadata = null)
    {
      return new MollieCreateRequest
      {
        Amount = amount,
        Description = description,
        RedirectUrl = redirectUrl,
        WebhookUrl = webhookUrl,
        Locale = locale != null && acceptedLocales.Contains(locale.TwoLetterISOLanguageName) ? locale.TwoLetterISOLanguageName : null,
        Metadata = metadata,
      };
    }

    private async Task<string> SendJsonRequest(string url, HttpMethod method, object obj = null)
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
          return await response.Content.ReadAsStringAsync();
        }
      }
    }

    private T ParseJsonResponseString<T>(string responseString) where T : class
    {
      return JsonConvert.DeserializeObject<T>(responseString);
    }
  }
}
