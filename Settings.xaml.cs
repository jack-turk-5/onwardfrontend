namespace Onward;

public partial class Settings : ContentPage
{
	public Settings()
	{
		InitializeComponent();
	}

	private async void CreateUser(object sender, EventArgs e)
	{
		await Navigation.PushModalAsync(new CreateUser());
	}

	private async void LogOut(object sender, EventArgs e)
	{
		if(Application.Current != null)
		{
			await Navigation.PopToRootAsync();
			Application.Current.MainPage = new AppShell();
		}
	}
}