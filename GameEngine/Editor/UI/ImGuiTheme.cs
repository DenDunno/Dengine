using System.Numerics;
using ImGuiNET;

public static class ImGuiTheme
{
    public static void Load()
    {
        ImGuiStylePtr style = ImGui.GetStyle();
        style.ItemSpacing = new Vector2(3, 15);
        style.WindowTitleAlign = Vector2.One * 0.5f;
        style.ItemInnerSpacing = new Vector2(15, 15);
        style.WindowPadding = Vector2.Zero;
    }
}