using System.Drawing;

public class Light : IGameComponent
{
    [EditorField] private readonly Color _color;
    private readonly List<StandartMaterial> _materials = new();
    private readonly Transform _transform;
    private readonly Transform _camera;

    public Light(Transform transform, Transform camera, Color color)
    {
        _transform = transform;
        _camera = camera;
        _color = color;
    }
    
    public void Add(Material standartMaterial)
    {
        _materials.Add((StandartMaterial)standartMaterial);
    }

    void IGameComponent.Update(float deltaTime)
    {
        foreach (StandartMaterial standartMaterial in _materials)
        {
            standartMaterial.Bridge.SetVector3("lightPosition", _transform.Position);
            standartMaterial.Bridge.SetVector3("viewPosition", _camera.Position);
            standartMaterial.Bridge.SetColor("lightColor", _color);
        }
    }
}