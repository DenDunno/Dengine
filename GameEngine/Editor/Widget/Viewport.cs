using System.Numerics;
using ImGuiNET;

public class Viewport : WidgetBase
{
    private readonly Framebuffer _framebuffer = new();
    
    public Viewport() : base("Viewport")
    {
        _framebuffer.Init();
    }

    protected override void OnDraw()
    {
        _framebuffer.Bind();
        
        Vector2 size = ImGui.GetWindowSize();
        size.Y -= 40;
        
        ImGui.Image((IntPtr)_framebuffer.framebufferTexture, size);
    }
}