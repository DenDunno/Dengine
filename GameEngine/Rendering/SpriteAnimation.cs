
public class SpriteAnimation : TogglingComponent
{
    [EditorField] private readonly float _rate;
    private readonly Texture[] _frames;
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

    protected override void OnInitialize()
    {
        foreach (Texture frame in _frames)
        {
            frame.Load();
        }
    }

    protected override void OnUpdate(float deltaTime)
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