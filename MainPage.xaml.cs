using System.Net;

namespace Onward;

public partial class MainPage : ContentPage
{
	private readonly ServerSocket serverSocket;

	public MainPage()
	{
		serverSocket = new();
		InitializeComponent();
	}

	private async void LoginAndAuthenticate(object sender, EventArgs e)
	{
		var response = await serverSocket.Login(Username.Text, Password.Text);
		if (response.Equals(HttpStatusCode.OK))
		{
			Application.Current.MainPage = new AppShell();
		}
	}
}

