using Newtonsoft.Json;
using System.Net;

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
    	var (response, success) = await serverSocket.PostAsync(json, "/customers/newcustomer");

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