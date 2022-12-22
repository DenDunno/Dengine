using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

public class Window : GameWindow
{
    public readonly PlayerInput Input;
    
    public Window(NativeWindowSettings nativeWindowSettings) : base(GameWindowSettings.Default, nativeWindowSettings)
    {
        Input = new PlayerInput(MouseState, KeyboardState);
    }

    protected override void OnUpdateFrame(FrameEventArgs args)
    {
        Benchmark.Instance.Start("Frame");
        Benchmark.Instance.Start("Update");
        base.OnUpdateFrame(args);
        Benchmark.Instance.Stop("Update");

        if (KeyboardState.IsKeyDown(Keys.Escape))
        {
            Close();
        }
    }

    protected override void OnRenderFrame(FrameEventArgs args)
    {
        Benchmark.Instance.Start("Render");
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        GL.Enable(EnableCap.DepthTest);
        GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
        GL.Enable(EnableCap.Blend);
        base.OnRenderFrame(args);
        Benchmark.Instance.Stop("Render");
        
        Benchmark.Instance.Start("Swap buffers");
        SwapBuffers();
        Benchmark.Instance.Stop("Swap buffers");
        
        Benchmark.Instance.Stop("Frame");
    }

    protected override void OnResize(ResizeEventArgs e)
    {
        base.OnResize(e);
        GL.Viewport(0, 0, Size.X, Size.Y);
    }
}