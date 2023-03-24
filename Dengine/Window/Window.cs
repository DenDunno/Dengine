using MethodTimer;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.Common;
using OpenTK.Graphics.OpenGL;

public class Window : GameWindow
{
    public Window(NativeWindowSettings nativeWindowSettings) : base(GameWindowSettings.Default, nativeWindowSettings)
    {
    }

    [Time("Update")]
    protected override void OnUpdateFrame(FrameEventArgs args)
    {
        base.OnUpdateFrame(args);
    }
    
    protected override void OnRenderFrame(FrameEventArgs args)
    {
        Render(args);
        SwapBuffers();
        Stats.Instance.Reset();
    }

    [Time("Render")]
    private void Render(FrameEventArgs args)
    {
        base.OnRenderFrame(args);
    }
    
    [Time("Swap")]
    public override void SwapBuffers()
    {
        base.SwapBuffers();
    }

    protected override void OnResize(ResizeEventArgs e)
    {
        base.OnResize(e);
        GL.Viewport(0, 0, Size.X, Size.Y);
    }
}