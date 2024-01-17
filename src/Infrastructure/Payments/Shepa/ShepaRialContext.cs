using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using NiceShop.Application.Common.Interfaces;

namespace NiceShop.Infrastructure.Payments.Shepa;

public class ShepaRialContext(HttpClient httpClient, IConfiguration configuration) : IShepaRialContext
{
    public async Task<string> GetBankUrl(long amount, string mobile, string email, string description)
    {
        var requestUrl = string.Empty;
        if (configuration["Payments:ShepaRial:IsSandbox"] == "True")
        {
            requestUrl = configuration["Payments:ShepaRial:RequestUrlSandbox"] + "/api/v1/token";
        }
        else
        {
            requestUrl = configuration["Payments:ShepaRial:RequestUrl"] + "/api/v1/token";
        }


        var postData = new Dictionary<string, object>
        {
            { "api", configuration["Payments:ShepaRial:MerchantId"] ?? string.Empty },
            { "amount", amount },
            { "callback", configuration["Payments:ShepaRial:CallBackUrl"] ?? string.Empty },
            { "mobile", mobile },
            { "email", email },
            { "description", description }
        };

        var jsonContent = new StringContent(JsonSerializer.Serialize(postData), Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync(requestUrl, jsonContent);

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();

        return content;
    }
}
