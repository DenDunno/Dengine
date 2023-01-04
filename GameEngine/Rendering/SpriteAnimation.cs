
public class SpriteAnimation : IGameComponent
{
    private readonly Texture[] _frames;
    private readonly float _rate;
    private readonly LitMaterial _material;
    private float _clock;
    private int _currentFrame;
    
    public SpriteAnimation(IReadOnlyList<string> pathToSprites, float rate, Material material)
    {
        _frames = GetFrames(pathToSprites);
        _rate = rate;
        _material = (LitMaterial)material;
    }

    private Texture[] GetFrames(IReadOnlyList<string> pathToSprites)
    {
        Texture[] result = new Texture[pathToSprites.Count];

        for (int i = 0; i < result.Length; ++i)
        {
            result[i] = new Texture(pathToSprites[i]);
        }

        return result;
    }

    void IGameComponent.Initialize()
    {
        foreach (Texture frame in _frames)
        {
            frame.Load();
        }
    }

    void IGameComponent.Update(float deltaTime)
    {
        if (Timer.Time >= _clock + _rate)
        {
            _clock = Timer.Time;
            MoveNextFrame();
        }
    }

    private void MoveNextFrame()
    {
        _currentFrame++;

        if (_currentFrame >= _frames.Length)
        {
            _currentFrame = 0;
        }

        _material.Data.Base = _frames[_currentFrame];
    }
}