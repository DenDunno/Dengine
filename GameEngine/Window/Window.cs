using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

public class Window : GameWindow
{
    public event Action<double>? FrameRendering;
    
    public Window(WindowSettings windowSettings) : base(windowSettings.GameWindowSettings, windowSettings.NativeWindowSettings)
    {
    }

    protected override void OnRenderFrame(FrameEventArgs args)
    {
        GL.Clear(ClearBufferMask.ColorBufferBit);

        FrameRendering?.Invoke(args.Time);
        
        SwapBuffers();
        base.OnRenderFrame(args);
    }
}