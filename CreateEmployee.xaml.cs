using Newtonsoft.Json;

namespace Onward;

public partial class CreateEmployee : ContentPage
{
	Employee toSubmit;
	private ServerSocket serverSocket;
	public CreateEmployee()
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
		string json = JsonConvert.SerializeObject(toSubmit);
		Task<string>post = serverSocket.PostAsync(json, "/employees/addemployee");
	}

}