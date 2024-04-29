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

	private async void Submit(object sender, EventArgs e)
	{
		var NewUser = new { username = Username.Text, email = Email.Text, password = Password.Text, roles = Roles.Text };
		string jsonStr = JsonConvert.SerializeObject(NewUser);
		await serverSocket.PostAsync(jsonStr, "/auth/addnewuser");
		await Navigation.PopModalAsync(true);
	}
}