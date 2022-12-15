using System.Numerics;
using Quaternion = OpenTK.Mathematics.Quaternion;
using ImGuiNET;

public class Inspector : Widget
{
    private GameObjectData? _gameObjectToBeShown;
    private readonly EditorFieldSerialization _editorFieldSerialization = new();
    
    public Inspector(Window window) : base("Inspector", window)
    {
    }

    protected override Vector2 Size => new(UIData.InspectorWidth, WindowHeight);
    protected override Vector2 Position => new(WindowWidth - UIData.InspectorWidth, 0);

    public void InspectGameObject(GameObjectData data)
    {
        _gameObjectToBeShown = data;
    }

    protected override void OnDraw()
    {
        if (_gameObjectToBeShown != null)
        {
            MapTransform();
            DrawComponents();
        }
    }

    private void MapTransform()
    {
        Vector3 position = _gameObjectToBeShown!.Transform.Position.ToNumeric();
        Vector3 rotation = _gameObjectToBeShown.Transform.Rotation.ToEulerAngles().ToNumeric();
        Vector3 scale = _gameObjectToBeShown.Transform.Scale.ToNumeric();
        
        ImGui.PushItemWidth(300);
        ImGui.DragFloat3("Position", ref position, ImGuiData.DraggingSpeed);
        ImGui.DragFloat3("Rotation", ref rotation, ImGuiData.DraggingSpeed);
        ImGui.DragFloat3("Scale", ref scale, ImGuiData.DraggingSpeed);

        _gameObjectToBeShown.Transform.Position = position.ToOpenTk();
        _gameObjectToBeShown.Transform.Rotation = Quaternion.FromEulerAngles(rotation.ToOpenTk());
        _gameObjectToBeShown.Transform.Scale = scale.ToOpenTk();
    }

    private void DrawComponents()
    {
        foreach (IGameComponent component in _gameObjectToBeShown!.Components)
        {
            ShowHeader(component);
            _editorFieldSerialization.Execute(component);
            ImGui.Spacing();
        }
    }

    private void ShowHeader(IGameComponent component)
    {
        string name = component.GetType().Name;
        
        if (component is TogglingComponent gameComponent)
        {
            ImGui.Checkbox(name, ref gameComponent.Enabled);
        }
        else
        {
            ImGui.Text(name);
        }
    }
}