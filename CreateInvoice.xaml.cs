using CommunityToolkit.Maui.Views;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace Onward;

public partial class CreateInvoice : ContentPage
{
	private Invoice newInvoice;
	private readonly ServerSocket serverSocket;
    private List<Customer>? customersDe;
    private ObservableCollection<string> customerCompanies;

    public ObservableCollection<string> CustomerCompanies
    {
        get { return customerCompanies; }
        set { customerCompanies = value; }
    }

    private ObservableCollection<string> customerContacts;
    public ObservableCollection<string> CustomerContacts
    {
        get { return customerContacts; }
        set { customerContacts = value; }
    }

    private List<LineItem> items;
    public List<LineItem> Items
    {
        get { return items; }
        set { items = value; }
    }


    public CreateInvoice()
	{
		BindingContext = this;
		newInvoice = new();
		serverSocket = new();
        customersDe = [];
        items = [];
        customerCompanies = [];
        customerCompanies.Add("            ");
        customerContacts = [];
        customerContacts.Add("              ");
        GetCustomers();
        InitializeComponent();
        InvDate.Text = DateTime.Now.ToShortDateString();
        CustomerListView.ItemSelected += (object? sender, SelectedItemChangedEventArgs e) =>
        {
            var customer = (string)e.SelectedItem;
            CustomerBoxEntry.Text = customer;
            customerCompanies.Clear();
            customerContacts.Clear();
            ContactBoxEntry.Text = "";
        };
        ContactListView.ItemSelected += (object? sender, SelectedItemChangedEventArgs e) =>
        {
            var customer = (string)e.SelectedItem;
            ContactBoxEntry.Text = customer;
            customerContacts.Clear();
        };
    }

    private async void GetCustomers()
    {
        var (json, success) = await serverSocket.GetAsync("/customers/getcustomers");
        if (success)
        {
            customersDe = JsonConvert.DeserializeObject<List<Customer>>(json);
            if (customersDe != null && customersDe.Count > 0)
            {
                return;
            }
            else
            {
                await DisplayAlert("Error", "Customer list is null", "Close");
                await Navigation.PopModalAsync();
            }
        }
        else
        {
            await DisplayAlert("Error", "Customer list can't be found: " + json, "Close");
            await Navigation.PopModalAsync();
        }
    }

    private void PopulateCustomers()
    {
        if (customersDe != null && customersDe.Count > 0)
            {
                customerCompanies.Clear();
                foreach (Customer customer in customersDe)
                {
                    if(!customerCompanies.Contains(customer.Company))
                    { 
                        customerCompanies.Add(customer.Company);
                    }
                }
            }
    }

    private void PopulateContacts()
    {
        if (customersDe != null && customersDe.Count > 0)
        {
            customerContacts.Clear();
            foreach (Customer customer in customersDe)
            {
                if(customer.Company.Equals(CustomerBoxEntry.Text) && !customerContacts.Contains(customer.ContactPerson))
                {
                    customerContacts.Add(customer.ContactPerson);
                }
            }
        }
    }

    private async void SelectItems(object sender, EventArgs e)
    {
        var popup = new Popup();
        var itemList = await this.ShowPopupAsync(popup, CancellationToken.None);
        items = itemList as List<LineItem> ?? [];
    }

    private async void Cancel(object sender, EventArgs e)
	{
		await Navigation.PopModalAsync(true);
	}

	private async void Submit(object sender, EventArgs e)
	{
		newInvoice.Customer = new Customer(CustomerBoxEntry.Text, ContactBoxEntry.Text);
		newInvoice.Employees = [];
		newInvoice.Items = items;
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

    private void DisplayCustomers(object sender, EventArgs e)
    {
        PopulateCustomers();
    }

    private void DisplayContacts(object sender, EventArgs e)
    {
        
        PopulateContacts();
    }

}