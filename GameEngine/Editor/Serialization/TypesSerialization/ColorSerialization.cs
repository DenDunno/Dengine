using System.Drawing;
using System.Numerics;
using ImGuiNET;

public class ColorSerialization : FieldSerialization<Color>
{
    protected override object OnSerialize(string fieldInfoName, Color texture)
    {
        Vector3 colorVector = new Vector3(texture.R, texture.G, texture.B) / 255f;

        ImGui.PushItemWidth(350);
        ImGui.ColorEdit3(fieldInfoName, ref colorVector);

        colorVector = colorVector.LerpByAxis(0, 255);

        return Color.FromArgb((int) colorVector.X, (int) colorVector.Y, (int) colorVector.Z);
    }
}