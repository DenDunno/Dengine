using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.Common;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class Window : GameWindow
{
    public readonly PlayerInput Input;

    public Window(NativeWindowSettings nativeWindowSettings) : base(GameWindowSettings.Default, nativeWindowSettings)
    {
        Input = new PlayerInput(MouseState, KeyboardState);
    }

    public static Vector2i WindowSize { get; private set; }

    protected override void OnUpdateFrame(FrameEventArgs args)
    {
        Stats.Instance.Reset();
        Stats.Instance.Benchmark.Start("Frame");
        
        Stats.Instance.Benchmark.Start("Update");
        base.OnUpdateFrame(args);
        Stats.Instance.Benchmark.Stop("Update");
    }

    protected override void OnRenderFrame(FrameEventArgs args)
    {
        Stats.Instance.Benchmark.Start("Render");
        base.OnRenderFrame(args);
        Stats.Instance.Benchmark.Stop("Render");
        
        Stats.Instance.Benchmark.Start("Swap buffers");
        SwapBuffers();
        Stats.Instance.Benchmark.Stop("Swap buffers");
        
        Stats.Instance.Benchmark.Stop("Frame");
    }

    protected override void OnResize(ResizeEventArgs e)
    {
        base.OnResize(e);
        GL.Viewport(0, 0, Size.X, Size.Y);
        WindowSize = Size;
    }
}