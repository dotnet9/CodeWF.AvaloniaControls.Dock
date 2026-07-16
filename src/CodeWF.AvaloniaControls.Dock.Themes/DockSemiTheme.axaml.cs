using System.Collections.Generic;
using System.Globalization;
using Avalonia.Controls;
using Avalonia.Styling;
using CodeWF.AvaloniaControls.Dock.Themes.Locales;
using Irihi.Avalonia.Shared.Helpers;

namespace CodeWF.AvaloniaControls.Dock.Themes;

public class DockSemiTheme : Styles
{
    private static readonly CultureInfo DefaultLocale = new("en-US");

    private static readonly Dictionary<CultureInfo, ResourceDictionary> LocaleResources = new()
    {
        [new CultureInfo("en-US")] = new en_us(),
        [new CultureInfo("zh-CN")] = new zh_cn()
    };

    private static readonly ResourceDictionary DefaultResources = new en_us();

    public CultureInfo? Locale
    {
        get;
        set
        {
            try
            {
                if (TryGetLocaleResources(value, out var resources))
                {
                    field = value;
                    Resources.BulkSetResources(resources);
                    return;
                }

                field = DefaultLocale;
                Resources.BulkSetResources(DefaultResources);
            }
            catch
            {
                field = CultureInfo.InvariantCulture;
            }
        }
    }

    private static bool TryGetLocaleResources(
        CultureInfo? locale,
        out ResourceDictionary resources)
    {
        if (locale is not null && LocaleResources.TryGetValue(locale, out var localeResources))
        {
            resources = localeResources;
            return true;
        }

        resources = DefaultResources;
        return false;
    }
}
