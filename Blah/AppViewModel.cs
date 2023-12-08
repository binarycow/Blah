using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Blah;

public class AppViewModel : INotifyPropertyChanged
{
    public AppViewModel()
    {
        SetContentCommand = new Command(value => this.Content = value);
    }

    public PersonViewModel Person { get; } = new PersonViewModel() { FirstName = "Joe", LastName = "Smith" };
    public PlaceViewModel Place { get; } = new PlaceViewModel() { City = "San Diego", State = "CA" };

    public ICommand SetContentCommand { get; }

    private object? content;
    public object? Content
    {
        get => this.content;
        set => this.SetProperty(ref content, value);
    }
    
    
    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}