namespace Onward;

public partial class Manage : ContentPage
{
	public Manage()
	{
		InitializeComponent();
	}

	private void ViewInvoices(object sender, EventArgs e)
	{
		throw new NotImplementedException();
	}

	private void ViewLineItems(object sender, EventArgs e)
	{
		throw new NotImplementedException();
	}

	private void ViewCustomers(object sender, EventArgs e)
	{
		throw new NotImplementedException();
	}

	private async void ViewEmployees(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new ViewEmployees(), true);
	}
}