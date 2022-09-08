
public class ShaderProgramWithTexture : ShaderProgram
{
    private readonly Texture _texture;

    public ShaderProgramWithTexture(Texture texture, Shader[] shaders) : base(shaders)
    {
        _texture = texture;
    }

    protected override void OnInit()
    {
        _texture.Load();
    }

    protected override void OnUse()
    {
        _texture.Use();
    }
}