using Newtonsoft.Json;

namespace Onward;

public partial class CreateCustomer : ContentPage
{
    private Customer toSubmit;
    private ServerSocket serverSocket;
    public CreateCustomer()
    {
        // BindingContext = this;
        InitializeComponent();
        toSubmit = new();
        serverSocket = new();
    }

    private async void Cancel(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync(true);
    }

    private async void Submit(object sender, EventArgs e)
    {
        toSubmit.Company = CustCompany.Text;
        toSubmit.ContactPerson = CustContactPerson.Text;
        string json = JsonConvert.SerializeObject(toSubmit);
    	await serverSocket.PostAsync(json, "/customers/newcustomer");
		await Navigation.PopModalAsync(true);
    }

}