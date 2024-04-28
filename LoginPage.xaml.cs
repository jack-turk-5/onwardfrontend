using Microsoft.Maui.Graphics.Win2D;
using System.Net;

namespace Onward;

public partial class LoginPage : ContentPage
{
	private readonly ServerSocket serverSocket;

	public LoginPage()
	{
		serverSocket = new();
		BindingContext = this;
		InitializeComponent();
	}

    public static void LoginError()
    {
         
    }

    private async void LoginAndAuthenticate(object sender, EventArgs e)
	{
		string response = await serverSocket.Login(Username.Text, Password.Text);
		if (response.Equals(HttpStatusCode.OK.ToString()) && Application.Current != null)
		{
            Application.Current.MainPage = new AuthAppShell();
		}
		else
		{
            await DisplayAlert("Error", "Username/Password Incorrect", "Cancel");
        }
	}
}

