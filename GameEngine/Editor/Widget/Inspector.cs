using System.Numerics;
using System.Reflection;
using Quaternion = OpenTK.Mathematics.Quaternion;
using ImGuiNET;

public class Inspector : Widget
{
    private GameObjectData? _gameObjectToBeShown;
    private readonly float _draggingSpeed = 0.05f;

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
        ImGui.DragFloat3("Position", ref position, _draggingSpeed);
        ImGui.DragFloat3("Rotation", ref rotation, _draggingSpeed);
        ImGui.DragFloat3("Scale", ref scale, _draggingSpeed);

        _gameObjectToBeShown.Transform.Position = position.ToOpenTk();
        _gameObjectToBeShown.Transform.Rotation = Quaternion.FromEulerAngles(rotation.ToOpenTk());
        _gameObjectToBeShown.Transform.Scale = scale.ToOpenTk();
    }

    private void DrawComponents()
    {
        foreach (IGameComponent component in _gameObjectToBeShown!.Components)
        {
            ShowHeader(component);
            ShowProperties(component);
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

    private void ShowProperties(IGameComponent component)
    {
        FieldInfo[] fields = component.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

        foreach (FieldInfo fieldInfo in fields)
        {
            if (fieldInfo.IsDefined(typeof(EditorField), false))
            {
                float value = (float)fieldInfo.GetValue(component)!;
                
                ImGui.PushItemWidth(100);
                ImGui.DragFloat(fieldInfo.Name, ref value, _draggingSpeed);
                
                fieldInfo.SetValue(component, value);
            }
        }
    }
}