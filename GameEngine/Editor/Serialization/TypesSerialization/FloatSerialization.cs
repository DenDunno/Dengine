using ImGuiNET;

public class FloatSerialization : FieldSerialization<float>
{
    protected override object OnSerialize(string fieldInfoName, float texture)
    {
        ImGui.PushItemWidth(100);
        ImGui.DragFloat(fieldInfoName, ref texture, ImGuiData.DraggingSpeed);

        return texture;
    }
}