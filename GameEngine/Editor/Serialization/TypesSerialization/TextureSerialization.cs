using System.Numerics;
using ImGuiNET;

public class TextureSerialization : FieldSerialization<Texture>
{
    protected override object OnSerialize(string fieldInfoName, Texture value)
    {
        ImGui.Text(fieldInfoName);
        
        if (ImGui.ImageButton("Texture", (IntPtr) value.Id, Vector2.One * 100))
        {
            ImGui.OpenPopup("TexturesPopUp");
        }

        if (TryGetNewTexturePath(out string newTexturePath))
        {
            Texture newTexture = new(newTexturePath);
            newTexture.Load();
            value.Dispose();

            return newTexture;
        }

        return value;
    }
    
    private bool TryGetNewTexturePath(out string newTexturePath)
    {
        newTexturePath = string.Empty;
        
        if (ImGui.BeginPopup("TexturesPopUp"))
        {
            ImGui.Text("Textures");
            ImGui.Separator();
            
            foreach (string texturePath in TexturesViewer.Instance.Textures)
            {
                if (ImGui.Selectable(Path.GetFileNameWithoutExtension(texturePath)))
                {
                    newTexturePath = texturePath;
                    return true;
                }
            }

            ImGui.EndPopup();
        }

        return false;
    }
}