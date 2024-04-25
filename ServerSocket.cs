using System.Text;

namespace ShellFlyoutSample;

public class ServerSocket
{
    private readonly string baseUrl = "http://localhost:8080/";
    private readonly HttpClient httpClient;

    public ServerSocket()
    {
        httpClient = new HttpClient();
    }

    public async Task<string> GetAsync(string endpt)
    {
        var url = baseUrl + endpt;
        var response = await httpClient.GetAsync(url);
        return await HandleResponseAsync(response);
    }

    public async Task<string> PutAsync(string data, string endpt)
    {
        var url = baseUrl + endpt;
        StringContent content = new(data, Encoding.UTF8, "application/json");
        var response = await httpClient.PutAsync(url, content);
        return await HandleResponseAsync(response);
    }

    public async Task<string> PostAsync(string data, string endpt)
    {
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
