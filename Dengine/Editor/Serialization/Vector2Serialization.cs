using ImGuiNET;
using OpenTK.Mathematics;

public class Vector2Serialization : FieldSerialization<Vector2>
{
    protected override object OnSerialize(string fieldInfoName, Vector2 value)
    {
        System.Numerics.Vector2 vector2 = new(value.X, value.Y); 

        ImGui.DragFloat2(fieldInfoName, ref vector2, ImGuiData.DraggingSpeed);

        return new Vector2(vector2.X, vector2.Y);
    }
}