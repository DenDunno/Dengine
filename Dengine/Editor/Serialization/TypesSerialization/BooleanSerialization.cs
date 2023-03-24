using ImGuiNET;

public class BooleanSerialization : FieldSerialization<bool>
{
    protected override object OnSerialize(string fieldInfoName, bool texture)
    {
        ImGui.Checkbox(fieldInfoName, ref texture);

        return texture;
    }
}