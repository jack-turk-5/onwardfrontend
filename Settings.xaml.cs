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

	private void LogOut(object sender, EventArgs e)
	{
		throw new NotImplementedException();
	}
}