using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace Onward;

public partial class ViewCustomers : ContentPage
{
	private readonly ServerSocket serverSocket;
	private List<Customer>? customersDe;
	private ObservableCollection<Customer> customers;

    public ObservableCollection<Customer> Customers
	{  get { return customers; } 
	   set { customers = value; }
	}
	public ViewCustomers()
	{
        serverSocket = new();
		customersDe = [];
		customers = [];
		PopulateCustomers();
		BindingContext = this;
        InitializeComponent();
	}

	private async void PopulateCustomers()
	{
		var (json, success) = await serverSocket.GetAsync("/customers/getcustomers");
		if(success)
		{
            customersDe = JsonConvert.DeserializeObject<List<Customer>>(json);
			if (customersDe != null && customersDe.Count > 0)
			{
				foreach (Customer customer in customersDe)
				{
					customers.Add(customer);
				}
			}
			else
			{
				await DisplayAlert("Error", "Customer list is null", "Close");
				await Navigation.PopAsync();
            }
		}
		else 
		{
			await DisplayAlert("Error", "Customer list can't be found: " + json, "Close");
            await Navigation.PopAsync();
        }
	}
}