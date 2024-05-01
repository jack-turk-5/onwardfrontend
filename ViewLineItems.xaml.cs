using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace Onward;

public partial class ViewLineItems : ContentPage
{
	private readonly ServerSocket serverSocket;
	private List<LineItem>? lineItemsDe;
	private ObservableCollection<LineItem> lineItems;

    public ObservableCollection<LineItem> LineItems
	{  get { return lineItems; } 
	   set { lineItems = value; }
	}
	public ViewLineItems()
	{
        serverSocket = new();
		lineItemsDe = [];
		lineItems = [];
		PopulateLineItems();
		BindingContext = this;
        InitializeComponent();
	}

	private async void PopulateLineItems()
	{
		var (json, success) = await serverSocket.GetAsync("/lineitems/getlineitems");
		if(success)
		{
            lineItemsDe = JsonConvert.DeserializeObject<List<LineItem>>(json);
			if (lineItemsDe != null && lineItemsDe.Count > 0)
			{
				foreach (LineItem lineItem in lineItemsDe)
				{
					lineItems.Add(lineItem);
				}
			}
			else
			{
				await DisplayAlert("Error", "Line Item list is null", "Close");
				await Navigation.PopAsync();
            }
		}
		else 
		{
			await DisplayAlert("Error", "Line Item list can't be found: " + json, "Close");
            await Navigation.PopAsync();
        }
	}
}