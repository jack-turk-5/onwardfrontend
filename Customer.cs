using System.ComponentModel;
// using Newtonsoft.Json;FIXME need this dependency


namespace Onward;

public class Customer : INotifyPropertyChanged
{
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
    private string role;
    // [JsonProperty(PropertyName = "role")] FIXME need this dependency
    public string Role
    {
        get { return role; }
        set
        {
            if (role != value)
            {
                role = value;
                OnPropertyChanged(nameof(Role));
            }
        }
    }

    public Customer()
    {
        name = "";
        role = "";
    }

    public Customer(string name, string role)
    {
        this.name = name;
        this.role = role;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}