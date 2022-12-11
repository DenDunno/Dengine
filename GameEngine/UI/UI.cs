using System.Numerics;
using Dear_ImGui_Sample;
using ImGuiNET;
using OpenTK.Windowing.Common;

public class UI : IEngineComponent
{
    private readonly Window _window;
    private readonly World _world;
    private readonly ImGuiController _imGui;
    private readonly FPSCounter _fpsCounter = new();
    private readonly float _inspectorWidth = 500f;
    private readonly float _hierarchyWidth = 275f;
    private readonly float _controlPanelHeight = 400f;
    private readonly PlayModeSwitching _playModeSwitching;
    private readonly WorldBrowser _worldBrowser;
    private readonly Dictionary<int, bool> _selectables = new();
    private readonly Inspector _inspector = new();
    
    public UI(Window window, World world)
    {
        _worldBrowser = new WorldBrowser(world);
        _window = window;
        _world = world;
        _imGui = new ImGuiController(window);
        _playModeSwitching = new PlayModeSwitching(window, _worldBrowser.FindFirst<CameraControlling>());
    }

    public void Initialize()
    {
        ImGui.GetFont().Scale = 2;
        ImGui.GetStyle().ItemSpacing = new Vector2(3, 15);
        ImGui.GetStyle().WindowTitleAlign = Vector2.One * 0.5f;
        ImGui.GetStyle().ItemInnerSpacing = new Vector2(15, 15);
    }

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
            DrawControlPanel();
            _inspector.DrawInspector(_window, _inspectorWidth);
            _imGui.Render();
        }
    }

    private void DrawHierarchy()
    {
        ImGui.Begin("Hierarchy", ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoResize);
        ImGui.SetWindowPos(Vector2.Zero);
        ImGui.SetWindowSize(new Vector2(_hierarchyWidth, _window.Height));
        ImGui.BeginListBox(string.Empty, new Vector2(_hierarchyWidth - 8, _window.Height - 48));

        foreach (GameObject gameObject in _world.GameObjects)
        {
            int id = gameObject.Data.Id;
            _selectables.TryAdd(id, false);
            
            if (ImGui.Selectable(gameObject.Data.Name, _selectables[id]))
            {
                foreach (int key in _selectables.Keys.ToList())
                {
                    _selectables[key] = false;
                }

                GameObjectData gameObjectToBeShown = _worldBrowser.FindGameObject(id).Data;
                _inspector.InspectGameObject(gameObjectToBeShown);
                
                _selectables[id] = true;
            }
        }
        
        ImGui.EndListBox();
        ImGui.End();
    }

    private void DrawControlPanel()
    {
        ImGui.Begin("Control panel", ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoResize);
        ImGui.SetWindowPos(new Vector2(_hierarchyWidth, _window.Height - _controlPanelHeight));
        ImGui.SetWindowSize(new Vector2(_window.Width - _inspectorWidth - _hierarchyWidth, _controlPanelHeight));
        ImGui.End();
    }

    public void OnMouseWheel(MouseWheelEventArgs args)
    {
        _imGui.MouseScroll(args.Offset);
    }

    public void OnWindowResize(ResizeEventArgs args)
    {
        _imGui.WindowResized(args.Width, args.Height);
    }
}