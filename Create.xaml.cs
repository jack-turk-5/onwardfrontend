namespace Onward;

public partial class Create : ContentPage
{
	public Create()
	{
		InitializeComponent();
	}

	private async void NewEmployeeClicked(object sender, EventArgs e)
	{
		await Navigation.PushModalAsync(new CreateEmployee(), true);
	}
}