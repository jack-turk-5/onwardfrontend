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
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            throw new Exception("username/password is null");
        }
        else
        {
            string url = baseUrl + "/auth/login";
            var AuthRequest = new { username = username, password = password };
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
                throw new Exception("Failed to login " + response.StatusCode.ToString() + " " + username + " " + password + " " + url);
            }
        }
    }

    public async Task<string> GetAsync(string endpt)
    {
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await TokenStorage.GetToken());
        var url = baseUrl + endpt;
        var response = await httpClient.GetAsync(url);
        return await HandleResponseAsync(response);
    }

    public async Task<string> PutAsync(string data, string endpt)
    {
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await TokenStorage.GetToken());
        var url = baseUrl + endpt;
        StringContent content = new(data, Encoding.UTF8, "application/json");
        var response = await httpClient.PutAsync(url, content);
        return await HandleResponseAsync(response);
    }

    public async Task<string> PostAsync(string data, string endpt)
    {
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await TokenStorage.GetToken());
        var url = baseUrl + endpt;
        StringContent content = new(data, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(url, content);
        return await HandleResponseAsync(response);
    }

    private static async Task<string> HandleResponseAsync(HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            return content;
        }
        else
        {
            throw new HttpRequestException($"Error: {response.StatusCode}");
        }
    }
}
