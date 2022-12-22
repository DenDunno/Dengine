﻿using System.Numerics;
using ImGuiNET;

public class UI
{
    private readonly Widget[] _main;

    public UI(Window window, World world)
    {
        Inspector inspector = new(window);
        Hierarchy hierarchy = new(window, world, inspector);
        ControlPanel controlPanel = new(window);
        
        _main = new Widget[]
        {
            inspector,
            hierarchy,
            controlPanel,
            new StatsWidget(window),
        };
    }

    public void InitStyle()
    {
        ImGuiStylePtr style = ImGui.GetStyle();
        style.ItemSpacing = new Vector2(3, 15);
        style.WindowTitleAlign = Vector2.One * 0.5f;
        style.ItemInnerSpacing = new Vector2(15, 15);
        ImGui.GetFont().Scale = 2;
        ImGui.GetIO().ConfigFlags |= ImGuiConfigFlags.DockingEnable;
    }

    public void Update(float deltaTime)
    {
        _main.ForEach(widget => widget.Update(deltaTime));
    }
    
    public void DrawMain()
    {
        _main.ForEach(widget => widget.Draw());
    }
}