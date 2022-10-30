using OpenTK.Mathematics;

public class ColorShaderProgram : ShaderProgram
{
    private static Vector3 _color = Vector3.One;

    public ColorShaderProgram(string vertexShaderPath, string fragmentShaderPath) : base(vertexShaderPath, fragmentShaderPath)
    {
    }

    public static void SetCollisionColor(bool isCollision)
    {
        _color = isCollision ? Vector3.UnitX : Vector3.One;
    }

    protected override void OnUse()
    {
        Bridge.SetVector3("color", _color);
    }
}