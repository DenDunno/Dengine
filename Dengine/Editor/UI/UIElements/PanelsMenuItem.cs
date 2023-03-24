using ImGuiNET;

public class PanelsMenuItem : UIElement
{
    private readonly IEnumerable<Panel> _panels;
    
    public PanelsMenuItem(IReadOnlyCollection<UIElement> elements)
    {
        _panels = elements.OfType<Panel>().Where(panel => panel is ViewportPanel == false);
    }

    protected override void OnDraw()
    {
        ImGui.BeginMainMenuBar();
        
        if (ImGui.BeginMenu("Panels"))
        {
            foreach (Panel panel in _panels)
            {
                ImGui.Checkbox(panel.Name, ref panel.Enabled);
            }
          
            ImGui.EndMenu();
        }
        
        ImGui.EndMainMenuBar();
    }
}