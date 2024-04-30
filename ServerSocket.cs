using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace Onward;

public class ServerSocket
{
    private readonly string baseUrl = "http://localhost:8080";
    private readonly HttpClient httpClient;

    public ServerSocket()
    {
        httpClient = new HttpClient();
    }

    public async Task<string> Login(string username, string password)
    {
            string url = baseUrl + "/auth/login";
            var AuthRequest = new { username, password };
            string jsonStr = JsonConvert.SerializeObject(AuthRequest);
            StringContent json = new(jsonStr, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, json);
            if(response.IsSuccessStatusCode)
            {
                string? token = await response.Content.ReadAsStringAsync();
                if(!string.IsNullOrEmpty(token)) 
                {
                    TokenStorage.SaveToken(token);
                }
                else
                {
                    throw new Exception("null token");
                }
                return response.StatusCode.ToString();
            }
            else
            {
                return "wrong";
            }
    }

    public async Task<(string, bool)> GetAsync(string endpt)
    {
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await TokenStorage.GetToken());
        var url = baseUrl + endpt;
        var response = await httpClient.GetAsync(url);
        return await HandleResponseAsync(response);
    }

    public async Task<(string, bool)> PutAsync(string data, string endpt)
    {
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await TokenStorage.GetToken());
        var url = baseUrl + endpt;
        StringContent content = new(data, Encoding.UTF8, "application/json");
        var response = await httpClient.PutAsync(url, content);
        return await HandleResponseAsync(response);
    }

    public async Task<(string, bool)> PostAsync(string data, string endpt)
    {
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await TokenStorage.GetToken());
        var url = baseUrl + endpt;
        StringContent content = new(data, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(url, content);
        return await HandleResponseAsync(response);
    }

    private static async Task<(string, bool)> HandleResponseAsync(HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode && !string.IsNullOrEmpty(response.ToString()))
        {
            string content = await response.Content.ReadAsStringAsync();
            return (content, true);
        }
        else
        {
            return (response.StatusCode.ToString(), false);
        }
    }
}
