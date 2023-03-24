
public class EditorStyle
{
    private readonly Icon _icon;
    private readonly IEditorTheme _theme;

    public EditorStyle(Icon icon, IEditorTheme theme)
    {
        _icon = icon;
        _theme = theme;
    }

    public void Load()
    {
        _theme.Load();
        _icon.Load();
    }
}