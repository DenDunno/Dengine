using ImGuiNET;

public class FloatSerialization : FieldSerialization<float>
{
    protected override object OnSerialize(string fieldInfoName, float value)
    {
        ImGui.PushItemWidth(100);
        ImGui.DragFloat(fieldInfoName, ref value, ImGuiData.DraggingSpeed);

        return value;
    }
}