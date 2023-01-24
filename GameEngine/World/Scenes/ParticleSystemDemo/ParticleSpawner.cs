using System.Drawing;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

public class ParticleSpawner : IGameComponent
{
    private readonly MouseState _mouseInput;
    private readonly Camera _camera;

    public ParticleSpawner(MouseState mouseInput, Camera camera)
    {
        _mouseInput = mouseInput;
        _camera = camera;
    }

    void IGameComponent.Update(float deltaTime)
    {
        if (_mouseInput.IsAnyButtonDown)
        {
            Vector2 worldPosition = _camera.ScreenToWorldCoordinates(_mouseInput.Position);
            Vector3 point = new(worldPosition.X, worldPosition.Y, 0);
            
            Gizmo.Instance.DrawLine(Vector3.Zero, point, Color.Aqua);
        }
    }
}