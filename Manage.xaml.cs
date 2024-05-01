namespace Onward;

public partial class Manage : ContentPage
{
	public Manage()
	{
		InitializeComponent();
	}

	private async void ViewInvoices(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new ViewInvoices(), true);
	}

	private async void ViewLineItems(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new ViewLineItems(), true);
	}

	private async void ViewCustomers(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new ViewCustomers(), true);
	}

	private async void ViewEmployees(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new ViewEmployees(), true);
	}
}