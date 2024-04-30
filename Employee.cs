using System.ComponentModel;
using Newtonsoft.Json;

namespace Onward;

public class Employee : INotifyPropertyChanged
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
    [JsonProperty(PropertyName = "role")]
    private string role;
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

   public Employee()
   {
    name = "";
    role = "";
   }

   public Employee(string name, string role)
   {
    this.name = name;
    this.role = role;
   }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
