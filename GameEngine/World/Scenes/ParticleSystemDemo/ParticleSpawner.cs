using OpenTK.Mathematics;

public class ParticleSpawner : IGameComponent
{
    private readonly Camera _camera;
    private readonly float _rate = 0.1f;
    private double _clock;

    public ParticleSpawner(Camera camera)
    {
        _camera = camera;
    }

    void IGameComponent.Update(float deltaTime)
    {
        if (WindowSettings.Mouse.IsAnyButtonDown && Timer.Time >= _clock + _rate)
        {
            _clock = Timer.Time;
            SpawnParticle();
        }
    }

    private void SpawnParticle()
    {
        Vector2 worldPosition = _camera.ScreenToWorldCoordinates(WindowSettings.Mouse.Position);
        Vector3 point = new(worldPosition.X, worldPosition.Y, 0);
    }
}