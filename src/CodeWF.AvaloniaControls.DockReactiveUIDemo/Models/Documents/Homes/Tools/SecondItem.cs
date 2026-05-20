using CodeWF.AvaloniaControls.DockReactiveUIDemo.Collections;
using ReactiveUI;

namespace CodeWF.AvaloniaControls.DockReactiveUIDemo.Models.Documents.Homes.Tools;

public class SecondItem : ItemBase
{
    public RangeObservableCollection<ThirdItem>? ThirdItemItems
    {
        get;
        set => this.RaiseAndSetIfChanged(ref field, value);
    }
}
