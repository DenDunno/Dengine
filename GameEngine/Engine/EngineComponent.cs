using OpenTK.Windowing.Common;

public abstract class EngineComponent
{
    public bool Enabled = true;
    public abstract void Initialize();
    public abstract void Update(FrameEventArgs args);
    public abstract void Draw(FrameEventArgs args);
}