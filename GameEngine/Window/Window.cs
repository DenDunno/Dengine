using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

public class Window : GameWindow
{
    private UpdateCycle _updateCycle = null!;

    public Window(WindowSettings windowSettings) : base(windowSettings.GameWindowSettings, windowSettings.NativeWindowSettings)
    {
    }
    
    public void Run(UpdateCycle updateCycle)
    {
        _updateCycle = updateCycle;
        Run();
    }

    protected override void OnUpdateFrame(FrameEventArgs args)
    {
        base.OnUpdateFrame(args);
        
        if (KeyboardState.IsKeyDown(Keys.Escape))
        {
            Close();
        }
    }

    protected override void OnRenderFrame(FrameEventArgs args)
    {
        base.OnRenderFrame(args);
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        GL.Enable(EnableCap.DepthTest);

        _updateCycle.Update((float)args.Time);

        SwapBuffers();
    }
}