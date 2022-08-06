
public class PointLight : IUpdatable
{
    private readonly Transform _transform;
    private readonly ShaderProgram[] _lightningShaders;

    public PointLight(Transform transform, ShaderProgram[] lightningShaders)
    {
        _transform = transform;
        _lightningShaders = lightningShaders;
    }

    void IUpdatable.Update(float deltaTime)
    {
        foreach (ShaderProgram lightningShader in _lightningShaders)
        {
            lightningShader.Bridge.SetVector3("lightPosition", _transform.Position);
        }
    }
}