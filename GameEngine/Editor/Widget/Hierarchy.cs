using System.Numerics;
using ImGuiNET;

public class Hierarchy : Widget
{
    private readonly World _world;
    private readonly Inspector _inspector;
    private readonly Dictionary<int, bool> _selectables = new();
    private readonly WorldBrowser _worldBrowser;
    
    public Hierarchy(Window window, World world, Inspector inspector) : base("Hierarchy", window)
    {
        _world = world;
        _inspector = inspector;
        _worldBrowser = new WorldBrowser(world);
    }

    protected override Vector2 Size => new(UIData.HierarchyWidth, WindowHeight);
    protected override Vector2 Position => Vector2.Zero;
    private Vector2 ListBoxSize => new(UIData.HierarchyWidth - 8, WindowHeight - 48);
    
    protected override void OnDraw()
    {
        ImGui.BeginListBox(string.Empty, ListBoxSize);
        ImGui.PushItemWidth(-1);
        
        ShowAllGameObjects();

        ImGui.EndListBox();
    }

    private void ShowAllGameObjects()
    {
        foreach (GameObject gameObject in _world.GameObjects)
        {
            int id = gameObject.Data.Id;
            _selectables.TryAdd(id, false);
            
            if (ImGui.Selectable(gameObject.Data.Name, _selectables[id]))
            {
                SelectGameObject(id);
            }
        }
    }

    private void SelectGameObject(int id)
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