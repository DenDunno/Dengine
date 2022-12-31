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

    protected override void OnLoad()
    {
        base.OnLoad();
        Framebuffer.Instance.Init();
    }

    protected override void OnUpdateFrame(FrameEventArgs args)
    {
        Stats.Instance.Reset();
        Stats.Instance.Benchmark.Start("Frame");
        
        Stats.Instance.Benchmark.Start("Update");
        base.OnUpdateFrame(args);
        Stats.Instance.Benchmark.Stop("Update");

        if (KeyboardState.IsKeyDown(Keys.Escape))
        {
            Close();
        }
    }

    protected override void OnRenderFrame(FrameEventArgs args)
    {
        Stats.Instance.Benchmark.Start("Render");
        Render(args);
        Stats.Instance.Benchmark.Stop("Render");
        
        Stats.Instance.Benchmark.Start("Swap buffers");
        SwapBuffers();
        Stats.Instance.Benchmark.Stop("Swap buffers");
        
        Stats.Instance.Benchmark.Stop("Frame");
    }

    private void Render(FrameEventArgs args)
    {
        Framebuffer.Instance.Bind();
        
        GL.Viewport(0, 0, Size.X, Size.Y);
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        GL.Enable(EnableCap.DepthTest);
        GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
        GL.Enable(EnableCap.Blend);
        base.OnRenderFrame(args);
        
        Framebuffer.Instance.UnBind();
    }

    protected override void OnResize(ResizeEventArgs e)
    {
        base.OnResize(e);
        GL.Viewport(0, 0, Size.X, Size.Y);
    }
}