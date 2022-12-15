using System.Drawing;
using System.Numerics;
using System.Reflection;
using ImGuiNET;

public class EditorFieldSerialization
{
    private readonly Dictionary<Type, Action<FieldInfo, object, object>> _typeSerialization;
    private readonly BindingFlags _bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
    
    public EditorFieldSerialization()
    {
        _typeSerialization = new Dictionary<Type, Action<FieldInfo, object, object>>()
        {
            {typeof(float), ShowFloat},
            {typeof(Color), ShowColor}
        };
    }

    public void Execute(IGameComponent component)
    {
        foreach (FieldInfo fieldInfo in component.GetType().GetFields(_bindingFlags))
        {
            Execute(fieldInfo, component);
        }
    }

    private void Execute(FieldInfo fieldInfo, object instance)
    {
        object? field = fieldInfo.GetValue(instance);

        if (field != null)
        {
            TrySerializeChildren(field);
            TrySerializeYourself(fieldInfo, field, instance);
        }
    }
    
    private void TrySerializeChildren(object field)
    {
        FieldInfo[] childFieldInfos = field.GetType().GetFields(_bindingFlags);

        foreach (FieldInfo childFieldInfo in childFieldInfos)
        {
            if (childFieldInfo.IsDefined(typeof(EditorField), false))
            {
                Execute(childFieldInfo, field);
            }
        }
    }
    
    private void TrySerializeYourself(FieldInfo fieldInfo, object field, object instance)
    {
        if (fieldInfo.IsDefined(typeof(EditorField), false) && _typeSerialization.ContainsKey(field.GetType()))
        {
            _typeSerialization[field.GetType()](fieldInfo, field, instance);
        }
    }

    private void ShowFloat(FieldInfo fieldInfo, object value, object instance)
    {
        float floatValue = (float)value;
        
        ImGui.PushItemWidth(100);
        ImGui.DragFloat(fieldInfo.Name, ref floatValue, ImGuiData.DraggingSpeed);
        
        fieldInfo.SetValue(instance, floatValue);
    }

    private void ShowColor(FieldInfo fieldInfo, object value, object instance)
    {
        Color color = (Color)value;
        
        Vector3 colorVector = new Vector3(color.R, color.G, color.B) / 255f;

        ImGui.PushItemWidth(350);
        ImGui.ColorEdit3(fieldInfo.Name, ref colorVector);

        colorVector = colorVector.LerpByAxis(0, 255);
        Color result = Color.FromArgb((int) colorVector.X, (int) colorVector.Y, (int) colorVector.Z);
        
        fieldInfo.SetValue(instance, result);
    }
}