using CommunityToolkit.Maui.Views;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace Onward;

public partial class ItemSelector : Popup
{
    private readonly ServerSocket serverSocket;
    private List<LineItem>? lineItemsDe;
    private ObservableCollection<LineItem> lineItems;

    public ObservableCollection<LineItem> LineItems
    {
        get { return lineItems; }
        set { lineItems = value; }
    }

    private List<object> selected;

    public List<object> Selected
    {
        get { return selected; }
        set { selected = value; }
    }
    public ItemSelector()
    {
        serverSocket = new();
        lineItemsDe = [];
        lineItems = [];
        selected = [];
        PopulateLineItems();
        BindingContext = this;
        InitializeComponent();
    }

    private async void PopulateLineItems()
    {
        var (json, success) = await serverSocket.GetAsync("/lineitems/getlineitems");
        if (success)
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
                await CloseAsync("error");
            }
        }
        else
        {
            await CloseAsync("error");
        }
    }

    async void CloseButton(object sender, EventArgs e)
    {
        await CloseAsync(selected);
    }
}