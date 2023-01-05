using System.Numerics;
using Quaternion = OpenTK.Mathematics.Quaternion;
using ImGuiNET;

public class Inspector : Panel
{
    private GameObjectData? _gameObjectToBeShown;
    private readonly DataSerialization _dataSerialization = new();
    private readonly ButtonsSerialization _buttonsSerialization = new();
    
    public Inspector() : base("Inspector")
    {
    }

    public void InspectGameObject(GameObjectData data)
    {
        _gameObjectToBeShown = data;
    }

    protected override void OnPanelDraw()
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
        ImGui.BeginListBox(string.Empty, new Vector2(size.X - 12, size.Y - 186));
        
        foreach (IGameComponent component in _gameObjectToBeShown!.Components)
        {
            if (ImGui.TreeNode(component.GetType().Name))
            {
                ImGui.PushStyleColor(ImGuiCol.Button, new Vector4(155 / 255f, 120 / 255f, 68 / 255f, 1));
                ImGui.PushStyleColor(ImGuiCol.FrameBg, new Vector4(155 / 255f, 120 / 255f, 68 / 255f, 1));
                
                _dataSerialization.Execute(component);
                _buttonsSerialization.Execute(component);
                
                ImGui.PopStyleColor();
                ImGui.PopStyleColor();
                ImGui.TreePop();
            }
        }
        
        ImGui.EndListBox();
    }
}