using OpenTK.Graphics.OpenGL;

public class TexParameter
{
    private readonly TextureTarget _target;
    private readonly TextureParameterName _parameterName;
    private readonly int _value;

    public TexParameter(TextureTarget target, TextureParameterName parameterName, int value)
    {
        _target = target;
        _parameterName = parameterName;
        _value = value;
    }

    public void Enable()
    {
        GL.TexParameter(_target, _parameterName, _value);
    }
}