using System.Drawing;
using System.Drawing.Imaging;
using System.Numerics;
using Dear_ImGui_Sample;
using ImGuiNET;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using StbImageSharp;
using PixelFormat = OpenTK.Graphics.OpenGL.PixelFormat;

public class Editor : IEngineComponent
{
    private readonly ImGuiController _imGui;
    private readonly PlayModeSwitching _playModeSwitching;
    private readonly UI _ui;
    private int _id;

    public Editor(Window window, World world)
    {
        _ui = new UI(world);
        _imGui = new ImGuiController(window);
        _playModeSwitching = new PlayModeSwitching(window, world);
    }

    public void Initialize()
    {
        _ui.InitStyle();

        _id = GL.GenTexture();
        GL.BindTexture(TextureTarget.Texture2D, _id);
        
        using (Stream stream = File.OpenRead(Paths.GetTexture("Base.png")))
        {
            ImageResult image = ImageResult.FromStream(stream, ColorComponents.RedGreenBlueAlpha); 
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, image.Data);
        }
    }

    public void Update(FrameEventArgs args)
    {
        float deltaTime = (float) args.Time;
        
        _imGui.Update(deltaTime);
        _playModeSwitching.Update(deltaTime);
        _ui.Update(deltaTime);
    }

    public void Draw(FrameEventArgs obj)
    {
        if (_playModeSwitching.IsEditorMode)
        {
            _ui.DrawMain();
            
            ImGui.Image((IntPtr)_id, new Vector2(100, 100), new Vector2(0, 0), new Vector2(1, 1), new Vector4(0, 0, 0, 0), new Vector4(1, 1, 1, 1));
        }
        else if (_playModeSwitching.IsStats)
        {
            _ui.DrawStats();
        }
        
        _imGui.Render();
    }

    public void OnMouseWheel(MouseWheelEventArgs args)
    {
        _imGui.MouseScroll(args.Offset);
    }

    public void OnWindowResize(ResizeEventArgs args)
    {
        _imGui.WindowResized(args.Width, args.Height);
    }
}