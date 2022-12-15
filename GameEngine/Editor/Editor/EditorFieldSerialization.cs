using System.Drawing;
using System.Numerics;
using ImGuiNET;

public class EditorFieldSerialization
{
    private readonly Dictionary<Type, Func<string, object, object>> _typeSerialization;

    public EditorFieldSerialization()
    {
        _typeSerialization = new Dictionary<Type, Func<string, object, object>>()
        {
            {typeof(float), ShowFloat},
            {typeof(Color), ShowColor}
        };
    }

    public object Execute(string name, object value)
    {
        return _typeSerialization[value.GetType()](name, value);
    }

    private object ShowFloat(string name, object value)
    {
        float floatValue = (float)value;
        ImGui.PushItemWidth(100);
        ImGui.DragFloat(name, ref floatValue, ImGuiData.DraggingSpeed);

        return floatValue;
    }
    
    private object ShowColor(string name, object value)
    {
        Color color = (Color)value;
        Vector3 colorVector = new Vector3(color.R, color.G, color.B) / 255f;

        ImGui.PushItemWidth(350);
        ImGui.ColorEdit3(name, ref colorVector);

        colorVector = colorVector.LerpByAxis(0, 255);

        return Color.FromArgb((int) colorVector.X, (int) colorVector.Y, (int) colorVector.Z);
    }
}