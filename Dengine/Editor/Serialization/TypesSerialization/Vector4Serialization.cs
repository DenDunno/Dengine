using ImGuiNET;
using OpenTK.Mathematics;

public class Vector4Serialization : FieldSerialization<Vector4>
{
    protected override object OnSerialize(string fieldInfoName, Vector4 value)
    {
        System.Numerics.Vector4 vector4 = new(value.X, value.Y, value.Z, value.W);

        ImGui.DragFloat4(fieldInfoName, ref vector4, ImGuiData.DraggingSpeed);

        return new Vector4(vector4.X, vector4.Y, vector4.Z, vector4.W);
    }
}