using System.Numerics;
using ImGuiNET;
using OpenTK.Graphics.OpenGL;

public class Viewport : Widget
{
    private readonly Framebuffer _framebuffer = new();
    
    public Viewport() : base("Viewport")
    {
        Console.WriteLine(Timer.Time);
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