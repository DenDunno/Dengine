using System.Numerics;
using ImGuiNET;
using OpenTK.Windowing.Common;

public class Viewport : WidgetBase
{
    private readonly Window _window;
    private readonly CameraControlling _cameraControlling;
    private readonly Vector2 _offset = new(16, 48);
    private bool _isCameraControlling;

    public Viewport(Window window, CameraControlling cameraControlling) : base("Viewport")
    {
        _window = window;
        _cameraControlling = cameraControlling;
    }

    protected override void OnDraw()
    {
        TryControlCamera();
        
        Framebuffer.Instance.Bind();
        Vector2 size = ImGui.GetWindowSize() - _offset;

        ImGui.Image((IntPtr)Framebuffer.Instance.FramebufferTexture, size);
        Framebuffer.Instance.UnBind();
    }

    private void TryControlCamera()
    {
        if (_isCameraControlling)
        {
            _isCameraControlling = ImGui.IsMouseDown(ImGuiMouseButton.Right);
        }
        else
        {
            _isCameraControlling = ImGui.IsWindowHovered() && ImGui.IsMouseDown(ImGuiMouseButton.Right);
        }
        
        _window.CursorState = _isCameraControlling ? CursorState.Grabbed : CursorState.Normal;
        _cameraControlling.Enabled = _isCameraControlling;
    }
}