using System.ComponentModel;
using Newtonsoft.Json;

namespace Onward;

public class LineItem : INotifyPropertyChanged
{
    [JsonProperty(PropertyName = "name")]
    private string name;
    public string Name
    {
        get { return name; }
        set
        {
            if (name != value)
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
    }
    
    [JsonProperty(PropertyName = "quantity")]
    private string quantity;
    public string Quantity
    {
        get { return quantity; }
        set
        {
            if (quantity != value)
            {
                quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }
    }
    
    [JsonProperty(PropertyName = "description")]
    private string description;
    public string Description
    {
        get { return description; }
        set
        {
            if (description != value)
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
    }
   
    [JsonProperty(PropertyName = "price")]
    private string price;
    public string Price
    {
        get { return price; }
        set
        {
            if (price != value)
            {
                price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
    }

    public LineItem()
    {
        name = "";
        quantity = "";
        description = "";
        price = "";
    }

    public LineItem(string name, string quantity, string description, string price)
    {
        this.name = name;
        this.quantity = quantity;
        this.description = description;
        this.price = price;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
