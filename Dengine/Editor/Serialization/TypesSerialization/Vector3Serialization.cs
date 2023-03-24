using ImGuiNET;
using OpenTK.Mathematics;

public class Vector3Serialization : FieldSerialization<Vector3>
{
    protected override object OnSerialize(string fieldInfoName, Vector3 texture)
    {
        System.Numerics.Vector3 vector3 = texture.ToNumeric();

        ImGui.DragFloat3(fieldInfoName, ref vector3, ImGuiData.DraggingSpeed);

        return vector3.ToOpenTk();
    }
}