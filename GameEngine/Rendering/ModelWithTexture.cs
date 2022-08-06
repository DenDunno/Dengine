using OpenTK.Mathematics;

public class ModelWithTexture : IModel
{
    private readonly IModel _model;
    private readonly Texture _texture;

    public ModelWithTexture(IModel model, Texture texture)
    {
        _model = model;
        _texture = texture;
    }

    public void Initialize()
    {
        _texture.Load();
        _model.Initialize();
    }

    public void Draw(in Matrix4 projectionViewMatrix)
    {
        _texture.Use();
        _model.Draw(in projectionViewMatrix);
    }
}