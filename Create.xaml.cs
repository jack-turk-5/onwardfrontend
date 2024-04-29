namespace Onward;

public partial class Create : ContentPage
{
	public Create()
	{
		InitializeComponent();
	}
    private async void NewInvoiceClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new CreateInvoice(), true);
    }
    private async void NewLineItemClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new CreateLineItem(), true);
    }
    private async void NewCustomerClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new CreateCustomer(), true);
    }
    private async void NewEmployeeClicked(object sender, EventArgs e)
	{
		await Navigation.PushModalAsync(new CreateEmployee(), true);
	}
}