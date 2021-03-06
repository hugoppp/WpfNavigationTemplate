using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp1.WpfUtils
{

public abstract class NotifyPropertyChanged : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public bool SetProperty<T>(ref T property, T value, [CallerMemberName] string propertyName = null!)
    {
        if (EqualityComparer<T>.Default.Equals(property, value)) return false;

        property = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    public virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null!)
    {
        OnPropertyChanged(propertyName);
    }

    private void OnPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
}

}