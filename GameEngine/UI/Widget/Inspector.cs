using System.Numerics;
using Quaternion = OpenTK.Mathematics.Quaternion;
using ImGuiNET;

public class Inspector
{
    private GameObjectData? _gameObjectToBeShown;
    private readonly float _draggingSpeed = 0.05f;

    public void InspectGameObject(GameObjectData data)
    {
        _gameObjectToBeShown = data;
    }
    
    public void DrawInspector(Window window, float width)
    {
        ImGui.Begin("Inspector", ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoResize);
        ImGui.SetWindowPos(new Vector2(window.Width - width, 0));
        ImGui.SetWindowSize(new Vector2(width, window.Height));

        if (_gameObjectToBeShown != null)
        {
            MapTransform();
        }

        ImGui.End();
    }

    private void MapTransform()
    {
        Vector3 position = _gameObjectToBeShown!.Transform.Position.ToNumeric();
        Vector3 rotation = _gameObjectToBeShown.Transform.Rotation.ToEulerAngles().ToNumeric();
        Vector3 scale = _gameObjectToBeShown.Transform.Scale.ToNumeric();
        
        ImGui.PushItemWidth(300);
        ImGui.DragFloat3("Position", ref position, _draggingSpeed);
        ImGui.DragFloat3("Rotation", ref rotation, _draggingSpeed);
        ImGui.DragFloat3("Scale", ref scale, _draggingSpeed);

        _gameObjectToBeShown.Transform.Position = position.ToOpenTk();
        _gameObjectToBeShown.Transform.Rotation = Quaternion.FromEulerAngles(rotation.ToOpenTk());
        _gameObjectToBeShown.Transform.Scale = scale.ToOpenTk();
    }
}