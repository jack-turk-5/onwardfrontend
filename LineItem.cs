using System.ComponentModel;
// using Newtonsoft.Json;FIXME need this dependency

namespace Onward;

public class LineItem : INotifyPropertyChanged
{
    private long id;
    // [JsonProperty(PropertyName = "id")] FIXME need this dependency
    public long Id
    {
        get { return Id; }
        set
        {
            if (id != value)
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
    }
    private string name;
    //[JsonProperty(PropertyName = "name")] FIXME need this dependency
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
    private int quantity;
    //[JsonProperty(PropertyName = "quantity")] FIXME need this dependency
    public int Quantity
    {
        get { return Quantity; }
        set
        {
            if (id != value)
            {
                id = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }
    }
    private string description;
    // [JsonProperty(PropertyName = "role")] FIXME need this dependency
    public string Description
    {
        get { return Description; }
        set
        {
            if (description != value)
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
    }
    private double price;
    // [JsonProperty(PropertyName = "id")] FIXME need this dependency
    public double Price
    {
        get { return Price; }
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
        id = 0;
        name = "";
        quantity = 0;
        description = "";
        price = 0;
    }

    public LineItem(long id, string name, int quantity, string description, double price)
    {
        this.id = id;
        this.name = name;
        this.quantity = quantity;
        this.description = description;
        this.price = price;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
