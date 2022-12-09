using System.Numerics;
using Dear_ImGui_Sample;
using ImGuiNET;
using OpenTK.Windowing.Common;

public class UI 
{
    private readonly Window _window;
    private readonly World _world;
    private readonly ImGuiController _imGui;
    private readonly FPSCounter _fpsCounter = new();
    private readonly float _sideColumnsWidth = 250f;
    private readonly float _controlPanelHeight = 400f;
    private readonly PlayModeSwitching _playModeSwitching;
    private readonly WorldBrowser _worldBrowser;
    private readonly Dictionary<string, bool> _selectables = new();
    
    public UI(Window window, World world)
    {
        _worldBrowser = new WorldBrowser(world);
        _window = window;
        _world = world;
        _imGui = new ImGuiController(window);
        _playModeSwitching = new PlayModeSwitching(window, _worldBrowser.FindFirst<CameraControlling>());
    }
    
    private float Width => _window.Size.X;
    private float Height => _window.Size.Y;
    
    public void Update(FrameEventArgs args)
    {
        _fpsCounter.Update((float)args.Time);
        _imGui.Update((float)args.Time);
        _playModeSwitching.Update((float)args.Time);
    }

    public void Draw(FrameEventArgs obj)
    {
        if (_playModeSwitching.IsPlayMode == false)
        {
            DrawHierarchy();
            DrawInspector();
            DrawControlPanel();
            _imGui.Render();
        }
    }

    private void DrawHierarchy()
    {
        ImGui.Begin("Hierarchy", ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoResize);
        ImGui.SetWindowPos(Vector2.Zero);
        ImGui.SetWindowSize(new Vector2(_sideColumnsWidth, Height));
        ImGui.GetFont().Scale = 2;
        
        foreach (GameObject gameObject in _world.GameObjects)
        {
            string name = gameObject.Data.Name;
            _selectables.TryAdd(name, false);
            
            if (ImGui.Selectable(name, _selectables[name]))
            {
                foreach (var key in _selectables.Keys.ToList())
                {
                    _selectables[key] = false;
                }
                Console.WriteLine(gameObject.Data.Name);
                _selectables[name] = true;
            }
        }
        
        ImGui.End();
    }

    private void DrawInspector()
    {
        ImGui.Begin("Inspector", ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoResize);
        ImGui.SetWindowPos(new Vector2(Width - _sideColumnsWidth, 0));
        ImGui.SetWindowSize(new Vector2(_sideColumnsWidth, Height));
        ImGui.End();
    }

    private void DrawControlPanel()
    {
        ImGui.Begin("Control panel", ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoResize);
        ImGui.SetWindowPos(new Vector2(_sideColumnsWidth, Height - _controlPanelHeight));
        ImGui.SetWindowSize(new Vector2(Width - 2 * _sideColumnsWidth, _controlPanelHeight));
        ImGui.End();
    }

    public void OnMouseWheel(MouseWheelEventArgs args)
    {
        _imGui.MouseScroll(args.Offset);
    }
}