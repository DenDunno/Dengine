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
        Vector2 size = ImGui.GetWindowSize();
        ImGui.BeginListBox(string.Empty, new Vector2(size.X - 8, size.Y - 200));
        
        foreach (IGameComponent component in _gameObjectToBeShown!.Components)
        {
            if (ImGui.TreeNode(component.GetType().Name))
            {
                _editorFieldSerialization.Execute(component);
                ImGui.TreePop();
            }
        }
        
        ImGui.EndListBox();
    }
}