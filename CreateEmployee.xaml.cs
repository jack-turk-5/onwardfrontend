using Newtonsoft.Json;

namespace Onward;

public partial class CreateEmployee : ContentPage
{
	Employee toSubmit;
	private ServerSocket serverSocket;
	public CreateEmployee()
	{
		toSubmit = new Employee();
		serverSocket = new();
		InitializeComponent();
	}

	private async void Cancel(object sender, EventArgs e)
	{
		await Navigation.PopModalAsync(true);
	}

	private async void Submit(object sender, EventArgs e)
	{
		toSubmit.Name = EmpName.Text;
		toSubmit.Role = EmpRole.Text;

		string json = JsonConvert.SerializeObject(toSubmit);
    	var (response, success) = await serverSocket.PostAsync(json, "/employees/newemployee");
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