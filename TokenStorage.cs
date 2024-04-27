namespace Onward;

public class TokenStorage
{
    public static async Task<string> GetToken()
    {
        string token = await SecureStorage.GetAsync("jwt-token");
        if (string.IsNullOrEmpty(token))
        {
            throw new Exception("Token is null");
        }
       return token;
    }

    public static async void SaveToken(string token)
    {
        if (string.IsNullOrEmpty(token))
        {
            throw new Exception("Token is null");
        }
        else
        {
            await SecureStorage.SetAsync("jwt-token", token);
        }
    }

    public static async void DeleteToken()
    {
        string token = await SecureStorage.GetAsync("jwt-token");
        if (string.IsNullOrEmpty(token))
        {
            throw new Exception("Token is null");
        }
        else
        {
            SecureStorage.Remove("jwt-token");
        }
    }

}
