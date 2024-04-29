namespace Onward;

public partial class CreateCustomer : ContentPage
{
    Employee toSubmit;
    private ServerSocket serverSocket;
    public CreateCustomer()
    {
        // BindingContext = this;
        toSubmit = new Employee();
        serverSocket = new();
        InitializeComponent();
    }

    private async void Cancel(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    private void Submit(object sender, EventArgs e)
    {
        toSubmit.Name = EmpName.Text;
        toSubmit.Role = EmpRole.Text;

        //Need to add a line here to serialize, need newtonsoft nuget package
        Task<string> post = serverSocket.PostAsync(toSubmit.ToString(), "/customers");
    }

}