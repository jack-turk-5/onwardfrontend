using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace Onward;

public partial class ViewEmployees : ContentPage
{
	private readonly ServerSocket serverSocket;
	private List<Employee>? employeesDe;
	private ObservableCollection<Employee> employees;

    public ObservableCollection<Employee> Employees
	{  get { return employees; } 
	   set { employees = value; }
	}
	public ViewEmployees()
	{
        serverSocket = new();
		employeesDe = [];
		employees = [];
		PopulateEmployees();
		BindingContext = this;
        InitializeComponent();
	}

	private async void PopulateEmployees()
	{
		var (json, success) = await serverSocket.GetAsync("/employees/getemployees");
		if(success)
		{
            employeesDe = JsonConvert.DeserializeObject<List<Employee>>(json);
			if (employeesDe != null && employeesDe.Count > 0)
			{
				foreach (Employee employee in employeesDe)
				{
					employees.Add(employee);
				}
			}
			else
			{
				await DisplayAlert("Error", "Employee list is null", "Close");
				await Navigation.PopAsync();
            }
		}
		else 
		{
			await DisplayAlert("Error", "Employee list can't be found: " + json, "Close");
            await Navigation.PopAsync();
        }
	}
}