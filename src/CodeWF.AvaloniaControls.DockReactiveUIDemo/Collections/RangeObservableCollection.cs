using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CodeWF.AvaloniaControls.DockReactiveUIDemo.Collections;

public class RangeObservableCollection<T> : ObservableCollection<T>
{
    public void AddRange(IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            Add(item);
        }
    }
}
