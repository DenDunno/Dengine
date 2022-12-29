using System.Numerics;
using ImGuiNET;

public class TextureSerialization : FieldSerialization<Texture?>
{
    protected override object OnSerialize(string fieldInfoName, Texture? texture)
    {
        ImGui.Text(fieldInfoName);

        IntPtr id = (IntPtr)(texture?.Id ?? 0);
        
        if (ImGui.ImageButton("Texture", id, Vector2.One * 100))
        {
            ImGui.OpenPopup("TexturesPopUp");
        }

        if (TryGetNewTexturePath(out string newTexturePath))
        {
            SetupTexture(ref texture, newTexturePath);
        }

        return texture!;
    }

    private void SetupTexture(ref Texture? texture, string path)
    {
        texture?.Dispose();
            
        if (path == "NONE")
        {
            texture = null;
        }
        else
        {
            texture = new Texture(path);
            texture.Load();
        }
    }

    private bool TryGetNewTexturePath(out string newTexturePath)
    {
        newTexturePath = string.Empty;
        
        if (ImGui.BeginPopup("TexturesPopUp"))
        {
            ImGui.Text("Textures");
            ImGui.Separator();

            if (ImGui.Selectable("NONE"))
            {
                newTexturePath = "NONE";
            }
            
            foreach (string texturePath in TexturesViewer.Instance.Textures)
            {
                if (ImGui.Selectable(Path.GetFileNameWithoutExtension(texturePath)))
                {
                    newTexturePath = texturePath;
                }
            }

            ImGui.EndPopup();
        }

        return newTexturePath != string.Empty;
    }
}