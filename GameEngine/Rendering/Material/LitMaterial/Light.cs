using System.Drawing;

public class Light : IGameComponent
{
    [EditorField] private readonly Color _color;
    [EditorField] private readonly float _specular = 0.75f;
    [EditorField] private readonly float _diffuse = 1.65f;
    [EditorField] private readonly float _ambient = 0.4f;
    private readonly List<LitMaterial> _materials = new();
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
        _materials.Add((LitMaterial)standartMaterial);
    }

    void IGameComponent.Update(float deltaTime)
    {
        foreach (LitMaterial litMaterial in _materials)
        {
            litMaterial.Bridge.SetVector3("lightPosition", _transform.Position);
            litMaterial.Bridge.SetVector3("viewPosition", _camera.Position);
            litMaterial.Bridge.SetColor("lightColor", _color);
            litMaterial.Bridge.SetFloat("specularValue", _specular);
            litMaterial.Bridge.SetFloat("diffuseValue", _diffuse);
            litMaterial.Bridge.SetFloat("ambientValue", _ambient);
        }
    }
}