using Newtonsoft.Json;
using System.Net;

namespace Onward;

public partial class CreateInvoice : ContentPage
{
	private Invoice newInvoice;
	private ServerSocket serverSocket;
	public CreateInvoice()
	{
		BindingContext = this;
		newInvoice = new();
		serverSocket = new();
		InitializeComponent();
		InvDate.Text = DateTime.Now.ToShortDateString();
	}

	private async void Cancel(object sender, EventArgs e)
	{
		await Navigation.PopModalAsync(true);
	}

	private async void Submit(object sender, EventArgs e)
	{
		newInvoice.Customer = new();
		newInvoice.Employees = [];
		newInvoice.Items = [];
		newInvoice.Date = InvDate.Text;
		newInvoice.InvoiceNumber = InvNumber.Text;
		newInvoice.Misc = InvMisc.Text;

		string json = JsonConvert.SerializeObject(newInvoice);
    	var (response, success) = await serverSocket.PostAsync(json, "/invoices/newinvoice");
        if (success)
        {
            await Navigation.PopModalAsync(true);
        }
        else
        {
            await DisplayAlert("Error", "Data not posted: " + response.ToString(), "Close");
        }
    }

}