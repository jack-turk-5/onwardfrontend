namespace Onward;

public partial class CreateInvoice : ContentPage
{
	Invoice newInvoice;
	private ServerSocket serverSocket;
	public CreateInvoice()
	{
		// BindingContext = this;
		newInvoice = new Invoice();
		serverSocket = new();
		InitializeComponent();
	}

	private async void Cancel(object sender, EventArgs e)
	{
		await Navigation.PopModalAsync();
	}

	private void Submit(object sender, EventArgs e)
	{
		newInvoice.Name = InvoiceName.Text;
		newInvoice.Role = InvoiceRole.Text;

		//Need to add a line here to serialize, need newtonsoft nuget package
		Task<string>post = serverSocket.PostAsync(newInvoice.ToString(), "/invoice");
	}

}