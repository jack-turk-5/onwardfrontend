using Newtonsoft.Json;

namespace Onward;

public partial class CreateUser : ContentPage
{
	private readonly ServerSocket serverSocket;
	public CreateUser()
	{
		serverSocket = new();
		InitializeComponent();
	}

	private async void Cancel(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync(true);
    }

	private async void Submit(object sender, EventArgs e)
	{
		var NewUser = new { username = Username.Text, email = Email.Text, password = Password.Text, roles = Roles.Text };
		string jsonStr = JsonConvert.SerializeObject(NewUser);
		var (response, success) = await serverSocket.PostAsync(jsonStr, "/auth/addnewuser");
        if (success)
        {
            await Navigation.PopModalAsync(true);
        }
        else
        {
            await DisplayAlert("Error", "Data not posted: " + response.ToString(), "Close");
        }
    }
}