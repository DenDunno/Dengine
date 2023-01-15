using System.Numerics;
using ImGuiNET;
using OpenTK.Windowing.Common;

public class ViewportPanel : Panel
{
    private readonly Window _window;
    private readonly CameraControlling _cameraControlling;
    private readonly Vector2 _offset = new(16, 48);
    private bool _isCameraControlling;
    private bool _isHovered;

    public ViewportPanel(Window window, Camera camera) : base("Viewport")
    {
        _window = window;
        _cameraControlling = new CameraControlling(camera, window.Input);
    }

    public override void Update(float deltaTime)
    {
        TryControlCamera(deltaTime);
    }

    private void TryControlCamera(float deltaTime)
    {
        _window.CursorState = _isCameraControlling ? CursorState.Grabbed : CursorState.Normal;

        if (_isCameraControlling)
        {
            _cameraControlling.Move(deltaTime);
            _cameraControlling.Rotate(deltaTime);
        }

        if (_isHovered)
        {
            _cameraControlling.TryZoom(deltaTime);
        }
    }

    protected override void OnPanelDraw()
    {
        UpdateCameraControllingState();
        
        Framebuffer.Instance.Bind();
        Vector2 size = ImGui.GetWindowSize() - _offset;
        Viewport.Set(size);
        
        ImGui.Image((IntPtr) Framebuffer.Instance.FramebufferTexture, size, Vector2.UnitY, Vector2.UnitX);
        Framebuffer.Instance.UnBind();
    }

    private void UpdateCameraControllingState()
    {
        _isHovered = ImGui.IsWindowHovered();
        
        if (_isCameraControlling)
        {
            _isCameraControlling = ImGui.IsMouseDown(ImGuiMouseButton.Right);
        }
        else
        {
            _isCameraControlling = _isHovered && ImGui.IsMouseDown(ImGuiMouseButton.Right);
        }
    }
}