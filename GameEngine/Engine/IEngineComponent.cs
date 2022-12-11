using OpenTK.Windowing.Common;

public interface IEngineComponent
{
    void Initialize();
    void Update(FrameEventArgs args);
    void Draw(FrameEventArgs args);
}