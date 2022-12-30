using System.Numerics;
using ImGuiNET;

public class Hierarchy : WidgetBase
{
    private readonly World _world;
    private readonly Inspector _inspector;
    private readonly Dictionary<int, bool> _selectables = new();
    private readonly WorldBrowser _worldBrowser;
    private int _currentSelectedGameObject;
    
    public Hierarchy(World world, Inspector inspector) : base("Hierarchy")
    {
        _world = world;
        _inspector = inspector;
        _worldBrowser = new WorldBrowser(world);
    }

    protected override void OnDraw()
    {
        Vector2 size = ImGui.GetWindowSize();
        ImGui.BeginListBox(string.Empty, new Vector2(size.X - 12, size.Y - 48));
        
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
        _selectables[_currentSelectedGameObject] = false;
        _selectables[id] = true;
        _currentSelectedGameObject = id;
        
        GameObjectData gameObjectToBeShown = _worldBrowser.FindGameObject(id).Data;
        _inspector.InspectGameObject(gameObjectToBeShown);
    }
}