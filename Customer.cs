using System.ComponentModel;
using Newtonsoft.Json;

namespace Onward;

public class Customer : INotifyPropertyChanged
{
    private string company;
    [JsonProperty(PropertyName = "company")]
    public string Company
    {
        get { return company; }
        set
        {
            if (company != value)
            {
                company = value;
                OnPropertyChanged(nameof(Company));
            }
        }
    }
    private string contactPerson;
    [JsonProperty(PropertyName = "contactPerson")]
    public string ContactPerson
    {
        get { return contactPerson; }
        set
        {
            if (contactPerson != value)
            {
                contactPerson = value;
                OnPropertyChanged(nameof(ContactPerson));
            }
        }
    }

    public Customer()
    {
        company = "";
        contactPerson = "";
    }

    public Customer(string name, string role)
    {
        this.company = name;
        this.contactPerson = role;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}