
public class SpriteAnimation : TogglingComponent
{
    [EditorField] private readonly float _rate;
    private readonly Texture2D[] _frames;
    private readonly LitMaterial _material;
    private float _clock;
    private int _currentFrame;
    
    public SpriteAnimation(IReadOnlyList<string> pathToSprites, float rate, Material material)
    {
        _frames = GetFrames(pathToSprites);
        _rate = rate;
        _material = (LitMaterial)material;
    }

    private Texture2D[] GetFrames(IReadOnlyList<string> pathToSprites)
    {
        Texture2D[] result = new Texture2D[pathToSprites.Count];

        for (int i = 0; i < result.Length; ++i)
        {
            result[i] = new Texture2D(pathToSprites[i]);
        }

        return result;
    }

    protected override void OnInitialize()
    {
        foreach (Texture2D frame in _frames)
        {
            frame.Load();
        }
    }

    protected override void OnUpdate(float deltaTime)
    {
        if (Clock.Time >= _clock + _rate)
        {
            _clock = Clock.Time;
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