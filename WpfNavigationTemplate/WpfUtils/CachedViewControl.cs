using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace WpfApp1.WpfUtils
{

public class ViewFactory
{
    private Dictionary<Type, object> views = new();

    public object GetView(Type type)
    {
        if (!views.ContainsKey(type))
        {
            views[type] = Activator.CreateInstance(type) ?? throw new Exception($"Could not instantiate View ({type})");
        }

        return views[type];
    }
}

public class CachedViewControl : ContentControl
{
    public CachedViewControl() => Unloaded += (_, _) => Content = null;

    private Type? _viewType;
    private static ViewFactory _viewFactory = new();

    /// <summary>
    /// Type of the view to use as content
    /// </summary>
    public Type ViewType
    {
        get => _viewType ?? throw new Exception($"{nameof(ViewType)} not set");
        set
        {
            _viewType = value;
            Content = _viewFactory.GetView(value);
        }
    }
}

}