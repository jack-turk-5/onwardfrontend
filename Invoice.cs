using System.ComponentModel;
using Newtonsoft.Json;

namespace Onward;

public class Invoice : INotifyPropertyChanged
{
    [JsonProperty(PropertyName = "customer")]
    private Customer customer;
    public Customer Customer
    {
            get { return customer; }
            set
            {
                if (customer != value)
                {
                    customer = value;
                    OnPropertyChanged(nameof(Customer));
                }
            }
    }
    
    [JsonProperty(PropertyName = "employees")]
    private List<Employee> employees;
    public List<Employee> Employees
    {
            get { return employees; }
            set
            {
                if (employees != value)
                {
                    employees = value;
                    OnPropertyChanged(nameof(Employees));
                }
            }
    }


    [JsonProperty(PropertyName = "items")]
    private List<LineItem> items;
    public List<LineItem> Items
    {
            get { return items; }
            set
            {
                if (items != value)
                {
                    items = value;
                    OnPropertyChanged(nameof(Items));
                }
            }
    }

    [JsonProperty(PropertyName = "date")]
    private string date;
    public string Date
    {
            get { return date; }
            set
            {
                if (date != value)
                {
                    date = value;
                    OnPropertyChanged(nameof(Date));
                }
            }
    }

    [JsonProperty(PropertyName = "invoiceNumber")]
    private string invoiceNumber;
    public string InvoiceNumber
    {
            get { return invoiceNumber; }
            set
            {
                if (invoiceNumber != value)
                {
                    invoiceNumber = value;
                    OnPropertyChanged(nameof(InvoiceNumber));
                }
            }
    }

    [JsonProperty(PropertyName = "misc")]
    private string misc;
    public string Misc
    {
            get { return misc; }
            set
            {
                if (misc != value)
                {
                    misc = value;
                    OnPropertyChanged(nameof(Misc));
                }
            }
    }
    
    

   public Invoice()
   {
        customer = new();
        employees = [];
        items = [];
        date = "";
        invoiceNumber = "";
        misc = "";
   }

   public Invoice(Customer customer, List<Employee> employees, List<LineItem> items, string date, string invoiceNumber, string misc)
   {
        this.customer = customer;
        this.employees = employees;
        this.items = items;
        this.date = date;
        this.invoiceNumber = invoiceNumber;
        this.misc = misc;
   }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
