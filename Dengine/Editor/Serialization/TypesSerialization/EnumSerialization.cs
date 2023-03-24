using System.Numerics;
using System.Reflection;
using ImGuiNET;

public class EnumSerialization : IFieldSerialization
{
    public void Serialize(FieldInfo fieldInfo, object value, object instance)
    {
        Array enumValues = Enum.GetValues(fieldInfo.FieldType);
        
        EnableStyle(enumValues);
        ShowEnumComboBox(fieldInfo, value, instance, enumValues);
        DisableStyle();
    }

    private void EnableStyle(Array enumValues)
    {
        Vector2 size = ImGui.CalcTextSize(GetLongestEnum(enumValues));
        ImGui.PushItemWidth(size.X + 45);
        ImGui.PushID(123);
        ImGui.PushStyleColor(ImGuiCol.Header, new Vector4(0.23f, 0.23f, 0.24f, 1.00f) * 1.25f);
        ImGui.PushStyleColor(ImGuiCol.HeaderHovered, new Vector4(0.33f, 0.34f, 0.36f, 0.83f));
    }

    private void ShowEnumComboBox(FieldInfo fieldInfo, object value, object instance, Array enumValues)
    {
        if (ImGui.BeginCombo(string.Empty, value.ToString()))
        {
            foreach (object? enumeration in enumValues)
            {
                if (ImGui.Selectable(enumeration.ToString(), enumeration.Equals(value)))
                {
                    fieldInfo.SetValue(instance, enumeration);
                }
            }
            
            ImGui.EndCombo();
        }
    }

    private void DisableStyle()
    {
        ImGui.PopStyleColor();
        ImGui.PopStyleColor();
        ImGui.PopID();
    }

    private string GetLongestEnum(Array values)
    {
        string result = null!;
        int maxSize = 0;
            
        foreach (object value in values)
        {
            int size = value.ToString()!.Length;  
            
            if (maxSize < size)
            {
                maxSize = size;
                result = value.ToString()!;
            }
        }

        return result;
    }
}