using System.Reflection;
using ImGuiNET;

public class ButtonsSerialization
{
    public void Execute(IGameComponent component)
    {
        MethodInfo[] methods = component
            .GetType()
            .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
            .Where(m => m.GetCustomAttributes(typeof(EditorButtonAttribute), false).Length > 0)
            .ToArray();

        foreach (MethodInfo methodInfo in methods)
        {
            if (ImGui.Button(methodInfo.Name))
            {
                methodInfo.Invoke(component, null);
            }
        }
    }
}