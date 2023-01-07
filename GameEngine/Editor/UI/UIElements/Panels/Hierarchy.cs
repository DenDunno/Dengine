using System.Numerics;
using ImGuiNET;

public class Hierarchy : Panel
{
    private readonly World _world;
    private readonly Inspector _inspector;
    private readonly Dictionary<int, bool> _selectables = new();
    private int _currentSelectedGameObject;
    
    public Hierarchy(World world, Inspector inspector) : base("Hierarchy")
    {
        _world = world;
        _inspector = inspector;
    }

    protected override void OnPanelDraw()
    {
        Vector2 size = ImGui.GetWindowSize();
        ImGui.BeginListBox(string.Empty, new Vector2(size.X - 12, size.Y - 48));
        
        ShowAllGameObjects();
        
        // ImGuiTreeNodeFlags node_flags = ImGuiTreeNodeFlags.OpenOnArrow | ImGuiTreeNodeFlags.OpenOnDoubleClick | ImGuiTreeNodeFlags.SpanAvailWidth | ImGuiTreeNodeFlags.Selected;
        //
        // if (ImGui.TreeNodeEx("asd", node_flags))
        // {
        //     ImGui.TreePop();
        // }
        
        ImGui.EndListBox();
    }

    private void ShowAllGameObjects()
    {
        foreach (GameObject gameObject in _world.GameObjects)
        {
            _selectables.TryAdd(gameObject.Data.Id, false);
            ShowGameObject(gameObject);
        }
    }

    private void ShowGameObject(GameObject gameObject)
    {
        
        if (ImGui.Selectable(gameObject.Data.Name, _selectables[gameObject.Data.Id]))
        {
            SelectGameObject(gameObject.Data.Id);
        }
    }

    private void SelectGameObject(int id)
    {
        _selectables[_currentSelectedGameObject] = false;
        _selectables[id] = true;
        _currentSelectedGameObject = id;
        
        GameObjectData gameObjectToBeShown = WorldBrowser.Instance.FindGameObject(id).Data;
        _inspector.InspectGameObject(gameObjectToBeShown);
    }
}