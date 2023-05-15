
public class GeneratedImageView : IGameComponent
{
    private readonly RawTextureSource _source;
    private readonly Texture2D _generatedTexture;
    private readonly Texture2DData _targetTextureData;
    [EditorField] private readonly ImageGeneration _imageGeneration;
    
    public GeneratedImageView(RawTextureSource source, Texture2D generatedTexture, Texture2DData targetTextureData)
    {
        _imageGeneration = new ImageGeneration(targetTextureData);
        _generatedTexture = generatedTexture;
        _targetTextureData = targetTextureData;
        _source = source;
    }

    void IGameComponent.Initialize()
    {
        Apply();
    }
    
    [EditorButton]
    private void Apply()
    {
        _imageGeneration.GeneratePopulation(100);
    }

    void IGameComponent.Update(float deltaTime)
    {
        MoveGeneration();
    }

    private void MoveGeneration()
    {
        Genom genom = _imageGeneration.Evolve(1000);
        
        DengineConsole.Instance.Log(genom.Error);
        
        _source.SetData(genom.Data, _targetTextureData.Size);
        _generatedTexture.Load();
    }
}