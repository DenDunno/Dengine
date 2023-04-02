using ImGuiNET;

public class ColorVector4Serialization : FieldSerialization<ColorVector4>
{
    protected override object OnSerialize(string fieldInfoName, ColorVector4 value)
    {
        ImGui.ColorEdit4(fieldInfoName, ref value.Value);

        return value;
    }
}