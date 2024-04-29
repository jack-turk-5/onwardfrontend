namespace Onward;

public partial class CreateLineItem : ContentPage
{
    LineItem toSubmit;
    private ServerSocket serverSocket;
    public CreateLineItem()
	{
        // BindingContext = this;
        toSubmit = new LineItem();
        serverSocket = new();
        InitializeComponent();
    }

    private async void Cancel(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    private void Submit(object sender, EventArgs e)
    {
        toSubmit.Id = (long)Convert.ToDouble(EmpID);
        toSubmit.Name = EmpName.Text;
        toSubmit.Quantity = (int)Convert.ToDouble(EmpQuantity);
        toSubmit.Description = EmpDescription.Text;
        toSubmit.Price = (int)Convert.ToDouble(EmpPrice);

        //Need to add a line here to serialize, need newtonsoft nuget package
        Task<string> post = serverSocket.PostAsync(toSubmit.ToString(), "/lineitem");
    }
}