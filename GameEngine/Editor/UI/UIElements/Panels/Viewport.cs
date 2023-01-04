using System.Numerics;
using ImGuiNET;
using OpenTK.Windowing.Common;

public class Viewport : Panel
{
    private readonly Window _window;
    private readonly CameraControlling _cameraControlling;
    private readonly Vector2 _offset = new(16, 48);
    private bool _isCameraControlling;

    public Viewport(Window window, Camera camera) : base("Viewport")
    {
        _window = window;
        _cameraControlling = new CameraControlling(camera.Transform, window.Input);
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
            _cameraControlling.Update(deltaTime);
        }
    }

    protected override void OnPanelDraw()
    {
        UpdateCameraControllingState();
        
        Vector2 size = ImGui.GetWindowSize() - _offset;

        ImGui.Image((IntPtr) Framebuffer.Instance.FramebufferTexture, size, Vector2.UnitY, Vector2.UnitX);
    }

    private void UpdateCameraControllingState()
    {
        if (_isCameraControlling)
        {
            _isCameraControlling = ImGui.IsMouseDown(ImGuiMouseButton.Right);
        }
        else
        {
            _isCameraControlling = ImGui.IsWindowHovered() && ImGui.IsMouseDown(ImGuiMouseButton.Right);
        }
    }
}