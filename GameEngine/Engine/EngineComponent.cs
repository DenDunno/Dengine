using OpenTK.Windowing.Common;

public abstract class EngineComponent
{
    protected bool Enabled { get; private set; } = true;

    public void Stop() => Enabled = false;

    public void Resume() => Enabled = true;
    
    public abstract void Initialize();
    public abstract void Update(FrameEventArgs args);
    public abstract void Draw(FrameEventArgs args);
}