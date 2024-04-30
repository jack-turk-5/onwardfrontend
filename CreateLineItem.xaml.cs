using Newtonsoft.Json;

namespace Onward;

public partial class CreateLineItem : ContentPage
{
    private LineItem toSubmit;
    private readonly ServerSocket serverSocket;
    public CreateLineItem()
	{
        InitializeComponent();
        BindingContext = this;
        toSubmit = new();
        serverSocket = new();
    }

    private async void Cancel(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync(true);
    }

    private async void Submit(object sender, EventArgs e)
    {
        toSubmit.Name = EmpName.Text;
        toSubmit.Quantity = EmpQuantity.Text;
        toSubmit.Description = EmpDescription.Text;
        toSubmit.Price = EmpPrice.Text;

        string json = JsonConvert.SerializeObject(toSubmit);
    	await serverSocket.PostAsync(json, "/lineitems/newlineitem");
		await Navigation.PopModalAsync(true);
    }
}