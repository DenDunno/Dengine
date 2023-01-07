using ImGuiNET;

public class IntSerialization : FieldSerialization<int>
{
    protected override object OnSerialize(string fieldInfoName, int value)
    {
        ImGui.PushItemWidth(100);
        ImGui.DragInt(fieldInfoName, ref value);

        return value;
    }
}