using ImGuiNET;

public class BooleanSerialization : FieldSerialization<bool>
{
    protected override object OnSerialize(string fieldInfoName, bool value)
    {
        ImGui.Checkbox(fieldInfoName, ref value);

        return value;
    }
}