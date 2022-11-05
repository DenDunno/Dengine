using OpenTK.Mathematics;

public class ColorShaderProgram : ShaderProgram, ICollisionShaderProgram
{
    private Vector3 _color = Vector3.One;

    public ColorShaderProgram(string vertexShaderPath, string fragmentShaderPath) : base(vertexShaderPath, fragmentShaderPath)
    {
    }

    public void SetCollisionColor()
    {
        _color = Vector3.UnitX;
    }

    public void SetNormalColor()
    {
        _color = Vector3.One;
    }

    protected override void OnUse()
    {
        Bridge.SetVector3("color", _color);
    }
}