using System.Drawing;

public class Light : IGameComponent
{
    public readonly Transform Transform;
    [EditorField] private readonly Color _color;
    [EditorField] private readonly float _specular = 0.75f;
    [EditorField] private readonly float _diffuse = 1.65f;
    [EditorField] private readonly float _ambient = 0.4f;
    private readonly List<ShaderBridge> _materials = new();
    private readonly Transform _camera;

    public Light(Transform transform, Transform camera, Color color)
    {
        Transform = transform;
        _camera = camera;
        _color = color;
    }
    
    public void Add(ShaderBridge bridge)
    {
        _materials.Add(bridge);
    }

    void IGameComponent.Update(float deltaTime)
    {
        foreach (ShaderBridge bridge in _materials)
        {
            bridge.SetVector3("lightPosition", Transform.Position);
            bridge.SetVector3("viewPosition", _camera.Position);
            bridge.SetColor("lightColor", _color);
            bridge.SetFloat("specularValue", _specular);
            bridge.SetFloat("diffuseValue", _diffuse);
            bridge.SetFloat("ambientValue", _ambient);
        }
    }
}